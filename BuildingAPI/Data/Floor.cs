using MongoDB.Bson.Serialization.Attributes;

namespace BuildingAPI.Data
{
    public class Floor : IBuildingMethods
    {
        public int Number { get; set; }
        public decimal HeightOfCeiling { get; set; }
        public List<Room> Rooms { get; set; } = new List<Room>();

        /**
        * method responsible for calculating Height of Floor
        *
        * @return decimal value of max of all height of the rooms + HseightOfCeiling
        */
        public decimal calculateHeight()
        {
            return HeightOfCeiling + Rooms.Max(item => item.calculateHeight());
        }
        /**
        * method responsible for calculating Surface of Floor
        *
        * @return decimal value of sum of all surface of the rooms
        */
        public decimal calculateSurface()
        {
            return Rooms.Sum(item => item.calculateSurface());
        }
    }
}
