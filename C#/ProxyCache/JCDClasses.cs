using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace ProxyCacheConsole
{
    [DataContract]
    public class JCDContract
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string commercial_name { get; set; }
        [DataMember]
        public string[] cities { get; set; }
        [DataMember]
        public string country_code { get; set; }


    }


    [DataContract]
    public class JCDStation
    {
        [DataMember]
        public int number { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string contractName { get; set; }
        [DataMember]
        public Position position { get; set; }
        [DataMember]
        public Totalstands totalStands { get; set; }
    }


    [DataContract]
    public class Totalstands
    {
        [DataMember]
        public Availabilities availabilities { get; set; }
    }

    [DataContract]
    public class Availabilities
    {
        [DataMember]
        public int bikes { get; set; }
        [DataMember]
        public int stands { get; set; }
    }



    [DataContract]
    public class Position
    {
        [DataMember]
        public double latitude { get; set; }
        [DataMember]
        public double longitude { get; set; }
    }
}






