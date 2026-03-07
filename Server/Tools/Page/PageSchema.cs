using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Wikipedia;

namespace Server.Tools.Page;

public enum PageMode
{
    Bare,
    WithHtml,
    Html
}

[method: JsonConstructor]
public readonly struct PageInput(
    PageMode mode,
    string title)
{
    [Description("Specifies what information should be included in the response")]
    public PageMode Mode { get; } = mode;

    [Description("The title of the wikipedia page that should be retrieved")]
    public string Title { get; } = title;

    public static PageInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("mode", out JsonElement mode))
        {
            throw new ArgumentException($"Expected parameter $mode");
        }

        if (!arguments.TryGetValue("title", out JsonElement title))
        {
            throw new ArgumentException($"Expected parameter $title");
        }

        return new PageInput(
            Enum.Parse<PageMode>(mode.ToString()!),
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