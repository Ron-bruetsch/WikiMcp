using System.Text.Json.Serialization;

namespace Server.Wikipedia;

[method: JsonConstructor]
public readonly struct Revision(
    uint id,
    PageInfo page,
    User user,
    uint size,
    bool minor,
    string timestamp,
    int? delta,
    string? comment)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;

    [JsonPropertyName("page")]
    public PageInfo Page { get; } = page;

    [JsonPropertyName("user")]
    public User User { get; } = user;

    [JsonPropertyName("size")]
    public uint Size { get; } = size;

    [JsonPropertyName("minor")]
    public bool Minor { get; } = minor;

    [JsonPropertyName("timestamp")]
    public string Timestamp { get; } = timestamp;

    [JsonPropertyName("delta")]
    public int? Delta { get; } = delta;

    [JsonPropertyName("comment")]
    public string? Comment { get; } = comment;
}

[method: JsonConstructor]
public readonly struct PageInfo(
    uint id,
    string? title)
{
    [JsonPropertyName("id")]
    public uint Id { get; } = id;

    [JsonPropertyName("title")]
    public string? Title { get; } = title;
}