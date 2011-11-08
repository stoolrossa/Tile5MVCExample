using System.Collections.Generic;

namespace Tile5Mvc.GeoJSON
{
    public class FeatureCollection : GeoJsonObject
    {
        public FeatureCollection()
        {
            this.features = new List<Feature>();
        }

        public List<Feature> features { get; set; }
    }
}