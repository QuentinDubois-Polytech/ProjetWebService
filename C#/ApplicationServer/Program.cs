using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace ApplicationServer
{
    internal class Program
    {
        static void Main(string[] args) {
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/ApplicationServer/ApplicationService/");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(ApplicationService), httpUrl);

            //Add a service endpoint
            host.AddServiceEndpoint(typeof(IApplicationService), new BasicHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();
           
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.WriteLine("Service ApplicationServer");
            Console.ReadLine();
        }
    }
}
