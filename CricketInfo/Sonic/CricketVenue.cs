using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketVenue
    {
        public string ID { get; }
        public string Name { get; }
        public string City { get; }
        public string Country { get; }
        public string Location { get; }
        public string TimeZone { get; }
        public string Latitude { get; }
        public string Longitude { get; }
       
        public CricketVenue(string id,string name,string city,string country,
            string location,string timezone,string latitude,string longitude)
        {
            ID = id;
            Name = name;
            City = city;
            Country = country;
            Location = location;
            TimeZone = timezone;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
