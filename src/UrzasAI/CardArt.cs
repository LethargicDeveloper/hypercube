using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Hypercube.UrzasAI;

public class CardArt : INotifyPropertyChanged
{
    string artUrl = string.Empty;
    string state = string.Empty;

    [JsonPropertyName("art_url")]
    public string ArtUrl 
    {
        get => this.artUrl;
        set
        {
            if (value != this.artUrl)
            {
                this.artUrl = value;
                NotifyPropertyChanged();
            }
        }
    }

    [JsonPropertyName("state")]
    public string State 
    {
        get => this.state;
        set
        {
            if (value != this.state)
            {
                this.state = value;
                NotifyPropertyChanged();
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}