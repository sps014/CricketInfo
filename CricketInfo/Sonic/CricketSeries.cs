using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketSeries
    {
        public string ID  { get;}

        public string Name { get;}

        public string ShortName { get;}

        public string Type { get;}

        public bool Tour { get;}

        public string StartDate { get; }

        public string EndDate  { get; }

        public string Category { get; }

        public CricketSeries(string id,string name,string short_name,string type,string tour,string start_date,string end_date,string category)
        {
            ID = id;
            Name = name;
            ShortName = short_name;
            Type= type;
            Tour = Convert.ToBoolean(tour);
            StartDate =(start_date);
            EndDate= (end_date);
            Category = category;
        }

    }
}
