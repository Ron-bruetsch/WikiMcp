using System.Text.Json.Serialization;

namespace Server.Tools;

/// <summary>
/// Little wrapper object to handle paged results
/// </summary>
/// <param name="items"></param>
/// <typeparam name="T"></typeparam>
[method: JsonConstructor]
public readonly struct Paged<T>(
    IEnumerable<T>? pages,
    IEnumerable<T>? revisions,
    IEnumerable<T>? files)
{
    [JsonPropertyName("pages")]
    public IEnumerable<T>? Pages { get; } = pages;   
    
    [JsonPropertyName("revisions")]
    public IEnumerable<T>? Revisions { get; } = revisions;
    
    [JsonPropertyName("files")]
    public IEnumerable<T>? Files { get; } = files;
}

[method: JsonConstructor]
public readonly struct McpOutput<T>(string type, T value)
{
    public string Type { get; } = type;

    public T Value { get; } = value;
}