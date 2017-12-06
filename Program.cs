using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                CityToTimezone ctz = new CityToTimezone();
                
                List<Tuple<string, string>> lTimes = fileReader.Read(); // reads in Timezone.txt as intended
               
                if (lTimes.Count() != 0) // null check if FileReader reads file incorrectly
                { 
                    for (int x =0; x < (lTimes.Count); x++) 
                    {

                        var timezoneData = ctz.GetTimezone(lTimes[x].Item2);
                        var convertedTime = new DateTime();

                        try // handles errors in time strings
                        {
                            convertedTime = DateTime.Parse(lTimes[x].Item1).AddSeconds(Convert.ToDouble(timezoneData.rawOffset));
                        }
                        catch {  convertedTime = DateTime.Now; } // returns current time

                        string outputLine = String.Format("The time in the UK is {0} and the time in {1} is {2}", 
                                                            lTimes[x].Item1, 
                                                            timezoneData.timeZoneName, 
                                                            convertedTime.ToShortTimeString());
                        Console.WriteLine(outputLine);


                    }
                    Console.ReadKey(); // pause the program to view the console window
                }
            }
        }
    }
}
