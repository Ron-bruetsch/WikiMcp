using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.Page;

[method: JsonConstructor]
public readonly struct PageInput(
    string mode,
    string title)
{
    [JsonPropertyName("mode")]
    [Description("Specifies what information should be included in the response. Valid options are bare or html")]
    public string Mode { get; } = mode;

    [JsonPropertyName("title")]
    [Description("The title of the wikipedia page that should be retrieved")]
    public string Title { get; } = title;

    public static PageInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("mode", out JsonElement mode) 
            || string.IsNullOrWhiteSpace(mode.GetString()))
        {
            throw new WikiMcpException(
                "Validation error",
                "Expected parameter 'mode'", 
                "Include this parameter in the request. Valid values are 'bare' or 'html'");
        }

        if (!arguments.TryGetValue("title", out JsonElement title)  
            || string.IsNullOrWhiteSpace(title.GetString()))
        {
            throw new WikiMcpException(
                "Validation error",
                "Expected parameter 'title'", 
                "Include this parameter in the request.");
        }

        return new PageInput(
            mode.GetString()!,
            title.ToString()!);
    }
}

[method: JsonConstructor]
public readonly struct PageOutput(
    string title,
    PageLatest latest,
    string contentModel,
    string? htmlUrl,
    string? html,
    string? source)
{
    public string Title { get; } = title;
    
    public PageLatest Latest { get; } = latest;
    
    public string ContentModel { get; } = contentModel;
    
    public string? HtmlUrl { get; } = htmlUrl;
    
    public string? Html { get; } = html;
    
    public string? Source { get; } = source;
}

[method: JsonConstructor]
public readonly struct ConvertObject(string html)
{
    [JsonPropertyName("html")]
    public string Html { get; } = html;
}