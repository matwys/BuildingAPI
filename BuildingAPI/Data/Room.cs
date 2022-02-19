namespace BuildingAPI.Data
{
    public class Room
    {
        public int Number { get; set; }
        public float Height { get; set; }
        public float Surface { get; set; }

        public float calculateHeight()
        {
            return Height;
        }

        public float calculateSurface()
        {
            return Surface;
        }
    }
}
