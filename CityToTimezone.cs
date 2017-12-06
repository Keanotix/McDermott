using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timezone
{
    public class CityToTimezone
    {
        public class TimeZoneData
        {
            public string dstOffset { get; set; }
            public string rawOffset { get; set; }
            public string status { get; set; }
            public string timeZoneId { get; set; }
            public string timeZoneName { get; set; }

        }

        public TimeZoneData GetTimezone(string cityName)
            {
                TimeZoneData data = new TimeZoneData();
                var geocoder = new Geocoder.GeocodeService();
                var Location =  geocoder.GeocodeLocation(cityName);
                var timezoneRequestString = "https://maps.googleapis.com/maps/api/timezone/json?location=" + Location.Latitude.ToString() + "," + Location.Longitude.ToString() + "&timestamp=1374868635&sensor=false";
                var result = new System.Net.WebClient().DownloadString(timezoneRequestString);
                var json = JsonConvert.DeserializeObject<TimeZoneData>(result);

                return json;
            }
        }
}
