using System;
using System.Device.Location;

namespace ApplicationServer
{
    public class NominatimSearch
    {
        public OSMObject[] Property1 { get; set; }
    }

    public class OSMObject
    {
        public int place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public int osm_id { get; set; }
        public string[] boundingbox { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string display_name { get; set; }
        public string _class { get; set; }
        public string type { get; set; }
        public float importance { get; set; }
        public Address address { get; set; }
        public string svg { get; set; }
        public GeoCoordinate GetGeoCoordinate()
        {
            return new GeoCoordinate(Double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture), Double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture));
        }
    }

    public class Address
    {
        public string historic { get; set; }
        public string house_number { get; set; }
        public string road { get; set; }
        public string suburb { get; set; }
        public string borough { get; set; }
        public string city { get; set; }
        public string ISO31662lvl4 { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }

    public class Location {
        
        public Location(string lat, string lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
        public string lat { get; set; }
        public string lon { get; set; }
    }
}