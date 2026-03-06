using System.Text.Json.Serialization;
using Server.Transfer;

namespace Server.Wikipedia;

[method: JsonConstructor]
public readonly struct MediaFile(
    string title,
    string fileDescriptionUrl,
    MediaFileLatest latest,
    Thumbnail preferred,
    Thumbnail original,
    Thumbnail thumbnail)
{
    [JsonPropertyName("title")]
    public string Title { get; } = title;

    [JsonPropertyName("file_description_url")]
    public string FileDescriptionUrl { get; } = fileDescriptionUrl;
    
    [JsonPropertyName("latest")]
    public MediaFileLatest Latest { get; } = latest;
    
    [JsonPropertyName("preferred")]
    public Thumbnail Preferred { get; } = preferred;
    
    [JsonPropertyName("original")]
    public Thumbnail Original { get; } = original;
    
    [JsonPropertyName("thumbnail")]
    public Thumbnail Thumbnail { get; } = thumbnail;
}

[method: JsonConstructor]
public readonly struct User( 
    uint id,
    string name)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;
    
    [JsonPropertyName("name")]
    public string Name { get; } = name;
}

[method: JsonConstructor]
public readonly struct MediaFileLatest(
    string timestamp,
    User user)
{
    [JsonPropertyName("timestamp")]
    public string Timestamp { get; } = timestamp;
    
    [JsonPropertyName("user")]
    public User User { get; } = user;
}