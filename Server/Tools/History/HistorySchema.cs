using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Errors;
using Server.Wikipedia;

namespace Server.Tools.History;

[method: JsonConstructor]
public readonly struct HistoryInput(
    string title,
    uint? olderThan=null,
    uint? newerThan=null,
    string? filter=null)
{
    [JsonPropertyName("title")]
    [Description("The title of the wikipedia article")]
    public string Title { get; } = title;

    [JsonPropertyName("olderThan")]
    [Description("The revision ID. Returns the next 20 revisions older than the given revision ID")]
    public uint? OlderThan { get; } = olderThan;

    [JsonPropertyName("newerThan")]
    [Description("The revision ID. Returns the next 20 revisions newer than the given revision ID")]
    public uint? NewerThan { get; } = newerThan;
    
    [JsonPropertyName("filter")]
    [Description("Filter that returns only revisions with certain tags")]
    public string? Filter { get; } = filter;

    public static HistoryInput From(IDictionary<string, JsonElement> arguments)
    {
        if (!arguments.TryGetValue("title", out JsonElement title) 
            || title.ValueKind != JsonValueKind.String)
        {
            throw new WikiMcpException(
                "Expected parameter title",
                "Supply the title property in our request");
        }

        bool ota = arguments.TryGetValue("olderThan", out JsonElement olderThan);
        bool nta = arguments.TryGetValue("newerThan", out JsonElement newerThan);
        _ = arguments.TryGetValue("filter", out JsonElement filter);

        switch (ota, nta)
        {
            case (true, true):
                if (olderThan.ValueKind == JsonValueKind.Null && newerThan.ValueKind == JsonValueKind.Null)
                {
                    return new HistoryInput(
                        title.GetString()!,
                        null,
                        null,
                        filter.GetString());
                }
                
                throw new WikiMcpException(
                    "Validation error",
                    "Only one of the arguments 'olderThan' and 'newerThan' is allowed at the time!");
            case (true, false):
                if (!olderThan.TryGetUInt32(out uint olderValue))
                {
                    throw new WikiMcpException(
                        "Validation error",
                        $"Value for parameter 'olderThan' must be an unsigned integer. Allowed value range is {uint.MinValue} to {uint.MaxValue}!",
                        "Fix your input");
                }

                return new HistoryInput(
                    title.GetString()!,
                    olderValue,
                    filter: filter.GetString());
            case (false, true):
                if (!newerThan.TryGetUInt32(out uint newerValue))
                {
                    throw new WikiMcpException(
                        "Validation error",
                        $"Value for parameter 'newerThan' must be an unsigned integer. Allowed value range is {uint.MinValue} to {uint.MaxValue}!",
                        "Fix your input");
                }
                
                return new HistoryInput(
                    title.GetString()!,
                    newerThan: newerValue,
                    filter: filter.GetString());
            case (false, false):
                return new HistoryInput(
                    title.GetString()!,
                    filter: filter.GetString());
        }
    }
}


public readonly struct HistoryOutput(
    uint id,
    PageInfo page,
    User user,
    uint size,
    bool minor,
    string timestamp,
    int? delta,
    string? comment)
{
    [Description("The identifier of the wikipedia revision")]
    public uint Id { get; } = id;
    
    [Description("Information about the article")]
    public PageInfo Page { get; } = page;
    
    [Description("The author that made the revision")]
    public User User { get; } = user;
    
    [Description("The size of the revision")]
    public uint Size { get; } = size;
    
    [Description("Specifies if the revision was minor")]
    public bool Minor { get; } = minor;
    
    [Description("The timestamp of the revision")]
    public string Timestamp { get; } = timestamp;
    
    public int? Delta { get; } = delta;

    [Description("A comment from the author explaining the revision")]
    public string? Comment { get; } = comment;
    
    public HistoryOutput(Revision model) : this(
        model.Id,
        model.Page,
        model.User,
        model.Size,
        model.Minor,
        model.Timestamp,
        model.Delta,
        model.Comment)
    {
        
    } 
}