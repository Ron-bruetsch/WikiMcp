using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;

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
            throw new WikiMcpException("Expected parameter 'title'", "Include this property in the request arguments");
        }
        
        return new MediaFileInput(title.GetString()!);
    }
}
