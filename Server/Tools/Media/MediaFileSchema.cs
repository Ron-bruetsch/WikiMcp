using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Tools.Media;

[method: JsonConstructor]
public readonly struct MediaFileInput(
    string title)
{
    [JsonPropertyName("title")]
    public string Title { get; } = title;

    public static MediaFileInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("title", out JsonElement title))
        {
            throw new ArgumentException($"Expected parameter $title");
        }
        
        return new MediaFileInput(title.GetString()!);
    }
}
