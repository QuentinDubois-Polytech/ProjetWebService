using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testconsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            double d = Double.Parse("52.8725945", System.Globalization.CultureInfo.InvariantCulture);
            Console.WriteLine(d);
        }
    }
}
