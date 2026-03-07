using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Transfer;

namespace Server.Tools.Search;

public enum SearchType
{
    Keyword,
    Title
}

[method: JsonConstructor]
public readonly struct SearchInput(
    string searchMode,
    string term,
    byte limit = 50)
{
    [JsonPropertyName("searchMode")]
    [Description("The search type. Valid values are keyword or title")]
    public string SearchMode { get; } = searchMode; 

    [JsonPropertyName("term")]
    [Description("Search terms")]
    public string Term { get; } = term;

    [JsonPropertyName("limit")]
    [Description("Maximum number of search results to return, between 1 and 100. Default: 50")]
    public byte Limit { get; } = limit;

    public static SearchInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("searchMode", out JsonElement searchMode))
        {
            throw new ArgumentException($"Expected parameter $type");
        }

        if (!arguments.TryGetValue("term", out JsonElement term))
        {
            throw new ArgumentException($"Expected parameter $term");
        }

        bool result = arguments.TryGetValue("limit", out JsonElement limit);

        return new SearchInput(
            searchMode.GetString()!,
            term.GetString()!,
            result ? limit.GetByte() : (byte)50);
    }
}

[method: JsonConstructor]
public readonly struct SearchOutput(
    string title,
    string excerpt,
    string? description,
    Thumbnail? thumbnail)
{
    public string Title { get; } = title;
    
    public string Excerpt { get; } = excerpt;
    
    public string? Description { get; } = description;
    
    public Thumbnail? Thumbnail { get; } = thumbnail;
}
