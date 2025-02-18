using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Domain.Visitors;

public class OnlineVisitor
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public DateTime Time { get; set; }
    public string ClientId { get; set; }
}