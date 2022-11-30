using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testconsole.Proxy;
using System.Text.Json;

namespace testconsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            JCDecauxServiceProxyClient client = new JCDecauxServiceProxyClient();
            client.getStationsList();
            //Console.WriteLine(JsonSerializer.Serialize(client.getStationsList().Where(s => s.contractName == "lyon").ToList()));
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
