using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketOfficial
    {
        public Official Umpire1 { get; }
        public Official Umpire2 { get; }
        public Official Umpire3 { get; }
        public Official Referee { get; }

        public CricketOfficial(Official u1,Official u2,Official u3,Official referee)
        {
            Umpire1 = u1;
            Umpire2 = u2;
            Umpire3 = u3;
            Referee = referee;
        }
       
    }
    public class Official
    {
        public string Name { get; }
        public string ID { get; }
        public string Country { get; }
        public Official(string name, string id, string country)
        {
            Name = name;
            ID = id;
            Country = country;
        }
    }
}
