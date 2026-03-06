using System.Text.Json.Serialization;

namespace Server.Transfer;

/// <summary>
/// Result of a search request to the wikipedia api 
/// </summary>
/// <param name="id">Page identifier</param>
/// <param name="key">Page title in URL-friendly format</param>
/// <param name="title">Page title in reading-friendly format</param>
/// <param name="excerpt">A few lines giving a sample of page content with search terms</param>
/// <param name="description">Short summary of the page topic based on the corresponding entry on Wikidata or null if no entry exists</param>
/// <param name="thumbnail">Reduced-size version of the page's lead image or null if no lead imagine exists</param>
[method: JsonConstructor]
public readonly struct Search(
    uint id,
    string key,
    string title,
    string excerpt,
    string? description,
    Thumbnail? thumbnail)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;

    [JsonPropertyName("key")]
    public string Key { get; } = key;
    
    [JsonPropertyName("title")]
    public string Title { get; } = title;
    
    [JsonPropertyName("excerpt")]
    public string Excerpt { get; } = excerpt;
    
    [JsonPropertyName("description")]
    public string? Description { get; } = description;
    
    [JsonPropertyName("thumbnail")]
    public Thumbnail? Thumbnail { get; } = thumbnail;
}

[method: JsonConstructor]
public readonly struct Thumbnail(
    string mimetype,
    uint? size,
    uint? width,
    uint? height,
    uint? duration,
    string url)
{
    [JsonPropertyName("mimetype")]
     public string Mimetype { get; } = mimetype;
     
     [JsonPropertyName("size")]
     public uint? Size { get; } = size;
     
     [JsonPropertyName("width")]
     public uint? Width { get; } = width;
     
     [JsonPropertyName("height")]
     public uint? Height { get; } = height;
     
     [JsonPropertyName("duration")]
     public uint? Duration { get; } = duration;
     
     [JsonPropertyName("url")]
     public string Url { get; } = url;
}