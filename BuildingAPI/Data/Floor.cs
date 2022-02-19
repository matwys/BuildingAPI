using MongoDB.Bson.Serialization.Attributes;

namespace BuildingAPI.Data
{
    public class Floor
    {
        public int Number { get; set; }
        public float HeightOfCeiling { get; set; }
        public List<Room> Rooms { get; set; }

        /**
        * method responsible for calculating Height of Floor
        *
        * @return float value of max of all height of the rooms + HseightOfCeiling
        */
        public float calculateHeight()
        {
            return HeightOfCeiling + Rooms.Max(item => item.calculateHeight());
        }

        public float calculateSurface()
        {
            return Rooms.Sum(item => item.calculateSurface());
        }
    }
}
