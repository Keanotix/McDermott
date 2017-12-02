using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    class Program
    {        
        static void Main(string[] args)
        {
            Parser timeZoneParser = new Parser();
            using (Reader fileReader = new Reader())
            {
                List<Tuple<string, string>> lTimes = fileReader.Read();

                if (lTimes.Count() != 0)
                { 
                    for (int x =0; x < (lTimes.Count); x++)
                    {
                        Console.WriteLine(lTimes[x].Item1 + " " + lTimes[x].Item2);
                        
                    }
                    Console.ReadKey(); // pause the program to view the console window
                }
            }
        }
    }
}
