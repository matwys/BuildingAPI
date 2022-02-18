using MongoDB.Bson.Serialization.Attributes;

namespace BuildingAPI.Data
{
    public class Floor
    {
        public int Number { get; set; }
        public float Height { get; set; }
    }
}
