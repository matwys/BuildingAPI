namespace BuildingAPI.Data
{
    public class Room
    {
        public int Number { get; set; }
        public decimal Height { get; set; }
        public decimal Surface { get; set; }

        public decimal calculateHeight()
        {
            return Height;
        }

        public decimal calculateSurface()
        {
            return Surface;
        }
    }
}
