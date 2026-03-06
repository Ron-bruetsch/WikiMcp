using System.Text.Json.Serialization;

namespace Server.Wikipedia;

[method: JsonConstructor]
public readonly struct Page(
    uint id,
    string key,
    string title,
    PageLatest pageLatest,
    string contentModel,
    PageLicense pageLicense,
    string? htmlUrl,
    string? html,
    string? source)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;
    
    [JsonPropertyName("key")]
    public string Key { get; } = key;
    
    [JsonPropertyName("title")]
    public string Title { get; } = title;
    
    [JsonPropertyName("latest")]
    public PageLatest PageLatest { get; } = pageLatest;
    
    [JsonPropertyName("content_model")]
    public string ContentModel { get; } = contentModel;

    [JsonPropertyName("license")]
    public PageLicense PageLicense { get; } = pageLicense;
    
    [JsonPropertyName("html_url")]
    public string? HtmlUrl { get; } = htmlUrl;
    
    [JsonPropertyName("html")]
    public string? Html { get; } = html;
    
    [JsonPropertyName("source")]
    public string? Source { get; } = source;
}

[method: JsonConstructor]
public readonly struct PageLicense(
    string url,
    string title)
{
    [JsonPropertyName("url")]
    public string Url { get; } = url;
    
    [JsonPropertyName("title")]
    public string Title { get; } = title;
}

[method: JsonConstructor]
public readonly struct PageLatest(
    uint id,
    string timestamp)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;
    
    [JsonPropertyName("timestamp")]
    public string Timestamp { get; } = timestamp;
}