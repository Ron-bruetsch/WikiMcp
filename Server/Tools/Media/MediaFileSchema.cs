using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;

namespace Server.Tools.Media;

[method: JsonConstructor]
public readonly struct MediaFileInput(
    string title)
{
    [JsonPropertyName("title")]
    [Description("The title of the wikipedia article for which the media files should be retrieved")]
    public string Title { get; } = title;

    public static MediaFileInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("title", out JsonElement title)
            || title.ValueKind != JsonValueKind.String)
        {
            throw new WikiMcpException(
                "Validation error",
                "Expected parameter 'title'", 
                "Include this property in the request arguments");
        }
        
        return new MediaFileInput(title.GetString()!);
    }
}
