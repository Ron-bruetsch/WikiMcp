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
    SearchType searchType,
    string term,
    byte limit = 50)
{
    public SearchType Type { get; } = searchType; 

    [Description("Search terms")]
    public string Term { get; } = term;

    [Description("Maximum number of search results to return, between 1 and 100. Default: 50")]
    public byte Limit { get; } = limit;

    public static SearchInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("type", out JsonElement type))
        {
            throw new ArgumentException($"Expected parameter $type");
        }

        if (!arguments.TryGetValue("term", out var term))
        {
            throw new ArgumentException($"Expected parameter $term");
        }

        bool result = arguments.TryGetValue("limit", out JsonElement limit);

        return new SearchInput(
            Enum.Parse<SearchType>(type.GetString()!),
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
