namespace Tile5Mvc.SpatialDataAccess
{
    public class Cadastre
    {
        public static GeoJSON.FeatureCollection Retrieve(Bounds bounds)
        {
            var featureCollection = new GeoJSON.FeatureCollection();

            var connection = new System.Data.SqlClient.SqlConnection("Data Source=localhost;Initial Catalog=spatial;User ID=spatial;Password=spatial");

            string sql = "select geom.STAsBinary() as wkb, id from state_1 with(index(IX_SP_state_1)) where geom.STIntersects(geography::STPolyFromText('POLYGON((" + bounds.min.lon + " " + bounds.min.lat + "," + bounds.max.lon + " " + bounds.min.lat + ',' + bounds.max.lon + " " + bounds.max.lat + ',' + bounds.min.lon + " " + bounds.max.lat + ',' + bounds.min.lon + " " + bounds.min.lat + "))', 4283)) = 1;";

            using (connection)
            {
                connection.Open();

                var command = new System.Data.SqlClient.SqlCommand(sql, connection);

                using (command)
                {
                    var reader = command.ExecuteReader();

                    using (reader)
                    {
                        while (reader.Read())
                        {
                            // read the well known binary using NTS
                            var wkbReader = new NetTopologySuite.IO.WKBReader();
                            var sqlGeometry = wkbReader.Read(reader.GetSqlBytes(0).Stream);

                            // create a GeoJSON geometry using the NTS geometry
                            var geoJsonGeometry = new GeoJSON.Geometry(sqlGeometry);

                            // set the geometry type as a polygon because our layer only contains polygons
                            geoJsonGeometry.type = GeoJSON.ObjectType.Polygon.ToString();

                            // create a GeoJSON feature and assign the geometry to the feature
                            var geoJsonFeature = new GeoJSON.Feature();
                            geoJsonFeature.geometry = geoJsonGeometry;
                            geoJsonFeature.properties.id = reader.GetInt32(1).ToString();

                            // add the feature to the feature collection
                            featureCollection.features.Add(geoJsonFeature);
                        }
                    }

                }
            }
            return featureCollection;
        }

    }
}