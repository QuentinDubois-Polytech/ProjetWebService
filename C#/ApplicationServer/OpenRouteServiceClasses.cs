using System;
using System.Device.Location;

namespace ApplicationServer
{


    public class OpenRouteServiceDirection
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
        public float[] bbox { get; set; }
        public Metadata metadata { get; set; }

        public double getDuration()
        {
            return features[0].properties.summary.duration;
        }

        public double getDistance()
        {
            return features[0].properties.summary.distance;
        }
    }

    public class Metadata
    {
        public string attribution { get; set; }
        public string service { get; set; }
        public long timestamp { get; set; }
        public QueryDirection query { get; set; }
        public EngineDirection engine { get; set; }
    }

    public class QueryDirection
    {
        public float[][] coordinates { get; set; }
        public string profile { get; set; }
        public string format { get; set; }
    }

    public class EngineDirection
    {
        public string version { get; set; }
        public DateTime build_date { get; set; }
        public DateTime graph_date { get; set; }
    }

    public class Feature
    {
        public float[] bbox { get; set; }
        public string type { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Properties
    {
        public Segment[] segments { get; set; }
        public int[] way_points { get; set; }
        public Summary summary { get; set; }
    }

    public class Summary
    {
        public float distance { get; set; }
        public float duration { get; set; }
    }

    public class Segment
    {
        public float distance { get; set; }
        public float duration { get; set; }
        public Step[] steps { get; set; }
    }

    public class Step
    {
        public float distance { get; set; }
        public float duration { get; set; }
        public int type { get; set; }
        public string instruction { get; set; }
        public string name { get; set; }
        public int[] way_points { get; set; }
        public int exit_number { get; set; }
    }

    public class Geometry
    {
        public float[][] coordinates { get; set; }
        public string type { get; set; }
    }

    public class OpenRouteServiceSearch
    {
        public Geocoding geocoding { get; set; }
        public string type { get; set; }
        public FeaturesSearch[] features { get; set; }
        public float[] bbox { get; set; }

        public GeoCoordinate GetGeoCoordinate()
        {
            return new GeoCoordinate(features[0].geometry.coordinates[1], features[0].geometry.coordinates[0]);
        }

        public string GetCity()
        {
            return features[0].properties.locality;
        }
    }

    public class FeaturesSearch
    {
        public string type { get; set; }
        public PropertiesSearch properties { get; set; }
        public GeometrySearch geometry { get; set; }
    }

    public class GeometrySearch
    {
        public float[] coordinates { get; set; }
        public string type { get; set; }
    }

    public class Geocoding
    {
        public string version { get; set; }
        public string attribution { get; set; }
        public QuerySearch query { get; set; }
        public EngineSearch engine { get; set; }
        public long timestamp { get; set; }
    }

    public class QuerySearch
    {
        public string text { get; set; }
        public int size { get; set; }
        public bool _private { get; set; }
        public Lang lang { get; set; }
        public int querySize { get; set; }
        public string parser { get; set; }
        public Parsed_Text parsed_text { get; set; }
    }

    public class Lang
    {
        public string name { get; set; }
        public string iso6391 { get; set; }
        public string iso6393 { get; set; }
        public string via { get; set; }
        public bool defaulted { get; set; }
    }

    public class Parsed_Text
    {
        public string housenumber { get; set; }
        public string street { get; set; }
    }

    public class EngineSearch
    {
        public string name { get; set; }
        public string author { get; set; }
        public string version { get; set; }
    }


    public class PropertiesSearch
    {
        public string id { get; set; }
        public string gid { get; set; }
        public string layer { get; set; }
        public string source { get; set; }
        public string source_id { get; set; }
        public string name { get; set; }
        public string housenumber { get; set; }
        public string street { get; set; }
        public string postalcode { get; set; }
        public string match_type { get; set; }
        public string accuracy { get; set; }
        public string country { get; set; }
        public string country_gid { get; set; }
        public string country_a { get; set; }
        public string macroregion { get; set; }
        public string macroregion_gid { get; set; }
        public string macroregion_a { get; set; }
        public string region { get; set; }
        public string region_gid { get; set; }
        public string region_a { get; set; }
        public string macrocounty { get; set; }
        public string macrocounty_gid { get; set; }
        public string localadmin { get; set; }
        public string localadmin_gid { get; set; }
        public string locality { get; set; }
        public string locality_gid { get; set; }
        public string continent { get; set; }
        public string continent_gid { get; set; }
        public string label { get; set; }
    }

}
