namespace Tile5Mvc.SpatialDataAccess
{
    public class Bounds
    {
        public Point min { get; set; }
        public Point max { get; set; }
    }

    public class Point
    {
        public decimal lon { get; set; }
        public decimal lat { get; set; }
    }
}