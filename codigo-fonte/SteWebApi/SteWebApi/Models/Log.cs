using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SteWebApi.Model;

public class Log
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonRequired]
    public DateTime? Date { get; set; }
    [BsonRequired]
    public string? UserName { get; set; }
    [BsonRequired]
    public string? ElementId { get; set; }
    [BsonRequired]
    public string? ElementName { get; set; }
    [BsonRequired]
    public string? Type { get; set; }
    public string? OldValue { get; set; }
    [BsonRequired]
    public string? Note { get; set; }
}