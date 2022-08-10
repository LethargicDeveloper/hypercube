using RestSharp;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace Hypercube.UrzasAI;

public class UrzasAIClient
{
    readonly RestClient client;
    readonly ConcurrentDictionary<string, (BackgroundWorker worker, CardImage image)> imageTasks = new();

    public UrzasAIClient(HttpClient client)
    {
        this.client = new RestClient(client);
    }

    public async Task<CardText> GenerateCardTextAsync(UrzasAIRequest urzasAIRequest)
    {
        var json = JsonSerializer.Serialize(urzasAIRequest);
        var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);
        var query = dict?.Select(_ =>
        {
            var key = HttpUtility.UrlEncode(_.Key);
            var value = HttpUtility.UrlEncode(
                _.Value.ValueKind == JsonValueKind.True || _.Value.ValueKind == JsonValueKind.False
                ? _.Value.ToString()?.ToLower()
                : _.Value.ToString());
            return $"{key}={value}";
        }) ?? Enumerable.Empty<string>();
        var queryString = string.Join("&", query.ToArray());

        var request = new RestRequest($"card?{queryString}");
        var result = await this.client.GetAsync<CardText>(request);
        return result ?? new CardText();
    }

    public async Task<CardImage> GenerateImageAsync(CardText cardText)
    {
        var taskId = await GetWomboTaskIdAsync(cardText);
        if (string.IsNullOrEmpty(taskId))
            return new CardImage();

        var request = new RestRequest($"art/latest?wombo_task_id={taskId}");
        var result = await this.client.GetAsync<CardImage>(request);
        result ??= new CardImage();

        if (result.State != "completed")
        {
            var worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;

            this.imageTasks.TryAdd(taskId, (worker, result));

            worker.DoWork += (sender, e) =>
            {
                bool completed = false;
                int count = 0;
                CardImage? image;

                do
                {
                    var request = new RestRequest($"art/latest?wombo_task_id={taskId}");
                    image = this.client.Get<CardImage>(request);
                    completed = image?.State == "completed";
                    if (!completed)
                    {
                        Thread.Sleep(1000);
                        count++;
                    }
                }
                while (!completed && count < 10);

                image ??= new CardImage();

                if (this.imageTasks.TryGetValue(e.Argument?.ToString() ?? "", out var task))
                {
                    worker.ReportProgress(0, (task.image, image));
                }

                e.Result = taskId;
            };
            worker.ProgressChanged += (sender, e) =>
            {
                if (e.UserState == null) return;

                var (taskImage, image) = (ValueTuple<CardImage, CardImage>)e.UserState;

                taskImage.ArtUrl = image.ArtUrl;
                taskImage.State = image.State;
            };
            worker.RunWorkerCompleted += (sender, e) =>
            {
                var taskId = e.Result?.ToString() ?? "";
                _ = this.imageTasks.Remove(taskId, out _);
            };
            worker.RunWorkerAsync(taskId);
        }

        return result;
    }

    async Task<string?> GetWomboTaskIdAsync(CardText cardText)
    {
        var json = JsonSerializer.Serialize(cardText);
        var request = new RestRequest($"art?card={json}");
        var result = await this.client.GetAsync<WomboTask>(request);
        return result?.WomboTaskId;
    }

    class WomboTask : CardText
    {
        [JsonPropertyName("wombo_task_id")]
        public string WomboTaskId { get; set; } = string.Empty;
    }
}