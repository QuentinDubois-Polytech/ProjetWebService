using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ApplicationServerConsole
{
    public class OpenRouteDirection
    {
        public string type { get; set; }
        public Feature[] features { get; set; }
        public float[] bbox { get; set; }
        public Metadata metadata { get; set; }

        public double getDuration()
        {
            return features[0].properties.summary.duration;
        }
    }

    public class Metadata
    {
        public string attribution { get; set; }
        public string service { get; set; }
        public long timestamp { get; set; }
        public Query query { get; set; }
        public Engine engine { get; set; }
    }

    public class Query
    {
        public float[][] coordinates { get; set; }
        public string profile { get; set; }
        public string format { get; set; }
    }

    public class Engine
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
        public Properties()
        {
            segments = new List<Segment>();
        }
        public List<Segment> segments { get; set; }
        public Summary summary { get; set; }
        public int[] way_points { get; set; }
    }

    public class Summary
    {
        public float distance { get; set; }
        public float duration { get; set; }
    }

    [DataContract]
    public class Segment
    {
        [DataMember]
        public float distance { get; set; }
        [DataMember]
        public float duration { get; set; }
        [DataMember]
        public List<Step> steps { get; set; }
    }

    [DataContract]
    public class Step
    {
        [DataMember]
        public float distance { get; set; }
        [DataMember]
        public float duration { get; set; }
        [DataMember]
        public int type { get; set; }
        [DataMember]
        public string instruction { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public int[] way_points { get; set; }
    }

    public class Geometry
    {
        public float[][] coordinates { get; set; }
        public string type { get; set; }
    }
}
