using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Server.Tools;

[method: JsonConstructor]
public readonly struct SearchPage(
    IEnumerable<Wikipedia.Search> pages)
{
    [JsonPropertyName("pages")] public IEnumerable<Wikipedia.Search> Items { get; } = pages;
}

[method: JsonConstructor]
public readonly struct RevisionPage(
    IEnumerable<Wikipedia.Revision> revisions)
{
    [JsonPropertyName("revisions")] public IEnumerable<Wikipedia.Revision> Items { get; } = revisions;
}

[method: JsonConstructor]
public readonly struct FilesPage(IEnumerable<Wikipedia.MediaFile> files)
{
    [JsonPropertyName("files")]  public IEnumerable<Wikipedia.MediaFile> Items { get; } = files;
}

[method: JsonConstructor]
public readonly struct McpOutput<T>(string type, T value)
{
    [Description("The type what is being serialized")]
    public string Type { get; } = type;
    
    [Description("The value that represents the actual content")]
    public T Value { get; } = value;
}