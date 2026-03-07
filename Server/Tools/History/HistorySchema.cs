using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Server.Wikipedia;

namespace Server.Tools.History;

[method: JsonConstructor]
public readonly struct HistoryInput(
    string title,
    uint? olderThan,
    uint? newerThan,
    string? filter)
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
        if (!arguments.TryGetValue("title", out JsonElement title))
        {
            throw new  ArgumentException("Expected parameter title");
        }

        bool ota = arguments.TryGetValue("olderThan", out JsonElement olderThan);
        bool nta = arguments.TryGetValue("newerThan", out JsonElement newerThan);
        bool fa = arguments.TryGetValue("filter", out JsonElement filter);

        return new HistoryInput(
            title.GetString()!,
            ota ? olderThan.GetUInt32() : null,
            nta ? newerThan.GetUInt32() : null,
            fa ? filter.GetString()! : null);
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
    public uint Id { get; } = id;
    
    public PageInfo Page { get; } = page;
    
    public User User { get; } = user;
    
    public uint Size { get; } = size;
    
    public bool Minor { get; } = minor;
    
    public string Timestamp { get; } = timestamp;
    
    public int? Delta { get; } = delta;
    
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