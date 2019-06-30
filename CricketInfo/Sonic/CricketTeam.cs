using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketTeam
    {
        public string ID { get; }
        public string Name { get; }
        public string ShortName { get; }

        /// <summary>
        /// Returns ID of the players involved in match
        /// </summary>
        public List<string> Squad { get; }
        /// <summary>
        /// Returns ID of the players not invoved  in match but in squad
        /// </summary>
        public List<string> SquadBench { get; }

        public CricketTeam(string id,string name,string shortName,List<string> squad,List<string> squadBench)
        {
            ID = id;
            Name = name;
            ShortName = shortName;
            Squad = squad;
            SquadBench = squadBench;
        }

    }
}
