using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketPlayer
    {
        public string ID { get; }
        public string FullName { get; }
        public string Name { get; }

        public string BatStyle { get; }
        public string BowlStyle { get; }
        public string Speciality { get; }
        public string Role { get; }

        public CricketPlayer(string id,string fname,string name,string batStyle,string bowlStyle,string speciality,string role)
        {
            ID = id;
            FullName = fname;
            Name = name;
            BatStyle = batStyle;
            BowlStyle = bowlStyle;
            Speciality = speciality;
            Role = role;
        }
    }
}
