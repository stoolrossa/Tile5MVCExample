namespace Tile5Mvc.GeoJSON
{
    public class Geometry : GeoJsonObject
    {

        public Geometry()
        {
            this.coordinates = new decimal[0][];
        }

        public Geometry(GeoAPI.Geometries.IGeometry shape)
        {
            this.coordinates = new decimal[shape.Coordinates.Length][];
            for(var i = 0; i < shape.Coordinates.Length; i++)
            {
                var coordinate = shape.Coordinates[i];
                this.coordinates[i] = new decimal[2] { System.Convert.ToDecimal(coordinate.X), System.Convert.ToDecimal(coordinate.Y) };
            }
        }

        public decimal[][] coordinates { get; set; }
    }
}