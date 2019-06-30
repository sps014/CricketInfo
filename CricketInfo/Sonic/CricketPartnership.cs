using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketPartnership
    {
        public string Runs { get; }
        public  string Balls { get; }

        public CricketPartnership(string runs, string balls)
        {
            Runs = runs;
            Balls = balls;
        }
    }
}
