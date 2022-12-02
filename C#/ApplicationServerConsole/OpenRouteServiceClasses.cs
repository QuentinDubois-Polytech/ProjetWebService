using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Device.Location;
using static System.Net.Mime.MediaTypeNames;
using System.Globalization;

namespace ApplicationServerConsole
{

    public class OpenRouteServiceDirections
    {
        public Route[] routes { get; set; }
        public float[] bbox { get; set; }
        public Metadata metadata { get; set; }

        public double getDuration()
        {
            return routes[0].summary.duration;
        }
    }

    public class Metadata
    {
        public string attribution { get; set; }
        public string service { get; set; }
        public long timestamp { get; set; }
        public QueryDirections query { get; set; }
        public EngineDirections engine { get; set; }
    }

    public class QueryDirections
    {
        public float[][] coordinates { get; set; }
        public string profile { get; set; }
        public string format { get; set; }
        public string language { get; set; }
    }

    public class EngineDirections
    {
        public string version { get; set; }
        public DateTime build_date { get; set; }
        public DateTime graph_date { get; set; }
    }

    public class Route
    {
        public Summary summary { get; set; }
        public Segment[] segments { get; set; }
        public float[] bbox { get; set; }
        public string geometry { get; set; }
        public int[] way_points { get; set; }
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
    }



    public class OpenRouteServiceSearch
    {
        public Geocoding geocoding { get; set; }
        public string type { get; set; }
        public FeaturesSearch[] features { get; set; }
        public float[] bbox { get; set; }

        public GeoCoordinate GetCoordinate()
        {
            return new GeoCoordinate(features[0].geometry.coordinates[1], features[0].geometry.coordinates[0]);
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
        public int confidence { get; set; }
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

    public class BodyRequestDirections
    {
        public List<double[]> coordinates { get; set; }
        public string language { get; set; }

        public BodyRequestDirections() : this("fr") { }

        public BodyRequestDirections(string language)
        {
            coordinates = new List<double[]>();
            this.language = language;
        }

        public void AddCoordinate(GeoCoordinate geoCoordinate)
        {
            coordinates.Add(new double[2] { geoCoordinate.Longitude, geoCoordinate.Latitude });
        }
    }
}
