using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.Page;

[method: JsonConstructor]
public readonly struct TitleInput(
    string title)
{
    [JsonPropertyName("title")]
    [Description("The title of the wikipedia page that should be retrieved")]
    public string Title { get; } = title;

    public static TitleInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("title", out JsonElement title)  
            || title.ValueKind != JsonValueKind.String)
        {
            throw new WikiMcpException(
                "Validation error",
                "Expected parameter 'title'", 
                "Include this parameter in the request.");
        }

        return new TitleInput(
            title.ToString()!);
    }
}

[method: JsonConstructor]
public readonly struct PageOutput(
    string title,
    PageLatest latest,
    string contentModel,
    string content)
{
    [Description("The title of the wikipedia article")]
    public string Title { get; } = title;
    
    [Description("The latest for this article")]
    public PageLatest Latest { get; } = latest;
    
    [Description("Specifies the format of the content")]
    public string ContentModel { get; } = contentModel;
    
    [Description("Contains the content of the article in the wikitext format")]
    public string Content { get; } = content;
}