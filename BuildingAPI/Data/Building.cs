using MongoDB.Bson.Serialization.Attributes;

namespace BuildingAPI.Data
{
    public class Building
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Address { get; set; }
        public List<String> Owners { get; set; }
        public string Summary { get; set; }
        public float Surface { get; set; }
        public float Height { get; set; }

    }
}
