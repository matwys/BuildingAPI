namespace BuildingAPI.Data
{
    public class Room : IBuildingMethods
    {
        public int Number { get; set; }
        public decimal Height { get; set; }
        public decimal Surface { get; set; }

        /**
        * method responsible for getting Height of Room
        *
        * @return decimal value of the room height 
        */
        public decimal calculateHeight()
        {
            return Height;
        }


        /**
        * method responsible for getting Surface of Room
        *
        * @return decimal value of the room surface 
        */
        public decimal calculateSurface()
        {
            return Surface;
        }
    }
}
