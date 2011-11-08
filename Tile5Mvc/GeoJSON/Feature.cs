namespace Tile5Mvc.GeoJSON
{
    public class Feature : GeoJsonObject
    {
        public Feature()
        {
            this.properties = new Properties();
            base.type = ObjectType.Feature.ToString();
        }

        public Geometry geometry { get; set; }

        public Properties properties { get; set; }
    }
}