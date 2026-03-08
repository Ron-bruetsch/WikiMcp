using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;
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
            throw new WikiMcpException(
                "Expected parameter 'searchMode'", 
                "Include the parameter in the request arguments!");
        }

        if (!arguments.TryGetValue("term", out JsonElement term))
        {
            throw new WikiMcpException(
                "Expected parameter 'term'",
                "Include the parameter in the request arguments!");
        }
        
        bool result = arguments.TryGetValue("limit", out JsonElement limit);

        switch (result)
        {
            case true:
                if (!limit.TryGetByte(out byte limitValue))
                {
                    throw new WikiMcpException(
                        $"Parameter 'limit' must be of type byte. Valid value range is {byte.MinValue} and {byte.MaxValue}.");
                }

                if (limitValue > 100)
                {
                    throw new WikiMcpException(
                        $"Parameter 'limit' must have a value between 1 and 100.");
                }
                
                return new SearchInput(
                    searchMode.ToString(),
                    term.ToString(), 
                    limitValue);
            case false:
                return new SearchInput(
                    searchMode.ToString(),
                    term.ToString());
        }
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
