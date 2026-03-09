using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.Search;

[method: JsonConstructor]

public readonly struct SearchInput(
    string searchMode,
    string term,
    byte limit = 50)
{
    [JsonPropertyName("searchMode")]
    [Description("The search type. Valid values are 'keyword' and 'title'")]
    public string SearchMode { get; } = searchMode; 
    
    [JsonPropertyName("term")]
    [Description("Search terms")]
    public string Term { get; } = term;

    [JsonPropertyName("limit")]
    [Description("Maximum number of search results to return, between 1 and 100. Default: 50")]
    public byte Limit { get; } = limit;

    public static SearchInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("searchMode", out JsonElement searchMode) 
            || searchMode.ValueKind != JsonValueKind.String)
        {
            throw new WikiMcpException(
                "Expected parameter 'searchMode'", 
                "Include the parameter in the request arguments!");
        }

        if (!arguments.TryGetValue("term", out JsonElement term) 
            || term.ValueKind != JsonValueKind.String)
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
                        "Validation error",
                        $"Parameter 'limit' must be of type byte. Valid value range is {byte.MinValue} and {byte.MaxValue}.");
                }

                if (limitValue > 100)
                {
                    throw new WikiMcpException(
                        "Validation error",
                        "Parameter 'limit' must have a value between 1 and 100.");
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
    [Description("Title of the wikipedia article")]
    public string Title { get; } = title;
    
    [Description("An excerpt showing the place where the keyword appeared")]
    public string Excerpt { get; } = excerpt;
    
    [Description("Description of the wikipedia article")]
    public string? Description { get; } = description;
    
    [JsonPropertyName("The Thumbnail of the article if one is present")]
    public Thumbnail? Thumbnail { get; } = thumbnail;
}
