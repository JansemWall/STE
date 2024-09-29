using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SteWebApi.Model;
public class Item
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Code { get; set; }

    
    public bool? IsLend { get; set; }
    
    [BsonRepresentation(BsonType.ObjectId)]
    public string? CategoryId { get; set; }
}