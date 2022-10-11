﻿using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Hypercube;

public class Cube
{
    readonly Settings settings;

    string? workingDirectory;

    public Cube()
    {
        this.settings = ServiceLocator.Provider.GetRequiredService<Settings>();
    }

    [JsonPropertyOrder(1)]
    public string CubeName { get; init; } = string.Empty;
    
    [JsonPropertyOrder(2)]
    public string ScryfallUri { get; init; } = string.Empty;

    [JsonPropertyOrder(3)]
    public string Expansion { get; init; } = string.Empty;

    [JsonPropertyOrder(4)]
    public string ExpansionCode { get; init; } = string.Empty;

    [JsonPropertyOrder(5)]
    public SortedSet<Card> Cards { get; set; } = new(new ScryfallReferenceComparer());

    string CubeDirectory => this.workingDirectory ?? this.settings.CubeLocation;

    public void SetWorkingDirectory(string? path)
    {
        this.workingDirectory = path;
    }

    public void AddOrUpdate(Card card)
    {
        var existingCard = Cards.FirstOrDefault(_ => _.ScryfallReference == card.ScryfallReference);
        if (existingCard != null)
        {
            Cards.Remove(existingCard);
        }
        
        Cards.Add(card);
    }

    public void Save()
    {
        var path = Path.Combine(CubeDirectory, CubeName);
        var json = JsonSerializer.Serialize(this, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(Path.Combine(path, "cube.json"), json);
    }

    public string GetArtImagePath(string scryfallReference)
    {
        var path = Path.Combine(CubeDirectory, CubeName, $"art_{GetDeterministicHashCode(scryfallReference)}.png");
        return File.Exists(path) ? path : string.Empty;
    }

    public void SaveArtImage(string scryfallReference, Image image)
    {
        var path = Path.Combine(CubeDirectory, CubeName, $"art_{GetDeterministicHashCode(scryfallReference)}.png");
        image.Save(path);
    }

    public string GetCardImagePath(string scryfallReference)
    {
        var path = Path.Combine(CubeDirectory, CubeName, $"card_{GetDeterministicHashCode(scryfallReference)}.png");
        return File.Exists(path) ? path : string.Empty;
    }

    public void SaveCardImage(string scryfallReference, Image image)
    {
        var path = Path.Combine(CubeDirectory, CubeName, $"card_{GetDeterministicHashCode(scryfallReference)}.png");
        image.Save(path);
    }

    int GetDeterministicHashCode(string str)
    {
        unchecked
        {
            int hash1 = (5381 << 16) + 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length; i += 2)
            {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1)
                    break;
                hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
            }

            return hash1 + (hash2 * 1566083941);
        }
    }
}