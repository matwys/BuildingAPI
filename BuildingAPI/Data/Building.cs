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
        public decimal AboveSurface { get; set; }
        public List<Floor> Floors { get; set; } = new List<Floor>();

        /**
        * method responsible for calculating Height of Building
        *
        * @return float value of sum of all height of the floors + AboveSurface
        */
        public decimal calculateHeight()
        {
            return AboveSurface + Floors.Sum(item => item.calculateHeight());
        }

        public decimal calculateSurface()
        {
            return Floors.Sum(item => item.calculateSurface());
        }
    }
}
