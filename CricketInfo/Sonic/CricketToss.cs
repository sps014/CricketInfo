using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketToss
    {
        public string Winner { get; }
        public string Decision { get; }

        public CricketToss(string winner,string decision)
        {
            Winner = winner;
            Decision = decision;
        }
    }
}
