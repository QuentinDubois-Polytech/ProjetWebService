using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testconsole.Proxy;
using System.Text.Json;
using System.Globalization;
using System.Threading;

namespace testconsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;
            double[] test = { 1.1, 2.2 };
            
            Console.WriteLine("[" + string.Join(",", test) + "]");
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
