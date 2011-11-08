namespace Tile5Mvc.GeoJSON
{
    public abstract class GeoJsonObject
    {
        public string type { get; set; }
    }
    
    public enum ObjectType
    {
        Feature,
        FeatureCollection,
        Point,
        MultiPoint,
        LineString,
        MultiLineString,
        Polygon,
        MultiPolygon,
        GeometryCollection
    }
}