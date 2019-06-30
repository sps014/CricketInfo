using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketScore
    {
        public BattingScore Batting { get; }
        public BowlingScore Bowling { get; }

        public List<CricketBatsman> Batsmen { get; }
        public List<CricketBowler> Bowlers { get; }

        public string CurrentRunRate { get; }
        public string PreviousOvers { get; }

        public CricketPartnership Partnership { get; }
        public string Target { get; }


        public CricketScore(BattingScore batting,BowlingScore bowling,
            List<CricketBatsman> batsmen, List<CricketBowler> bowlers,string crr,
            string prev_over,string target,CricketPartnership partnership)
        {
            Batting = batting;
            Bowling = bowling;
            Bowlers = bowlers;
            Batsmen = batsmen;
            CurrentRunRate = crr;
            PreviousOvers = prev_over;
            Target = target;
            Partnership = partnership;
        }


        
    }
    public class CricketBowler
    {
        public string ID { get; }
        public string Overs { get; }
        public string Maiden { get; }
        public string Runs { get; }
        public string Wicket { get; }
        public CricketBowler(string id, string overs, string maiden, string runs, string wickets)
        {
            ID = id;
            Overs = overs;
            Maiden = maiden;
            Runs = runs;
            Wicket = wickets;
        }
    }
    public class CricketBatsman
    {
        public string ID { get; }
        public bool OnStrike { get; }
        public string Runs { get; }
        public string Balls { get; }
        public string Fours { get; }
        public string Sixes { get; }

        public CricketBatsman(string id, string strike, string runs, string balls, string fours, string sixes)
        {
            ID = id;
            OnStrike = strike != "0" ? true : false;
            Runs = runs;
            Balls = balls;
            Fours = fours;
            Sixes = sixes;
        }
    }

    public class BattingScore
    {
        public string ID { get; }
        public string Score { get; }

        public InningScore Innnings { get; }
        public BattingScore(string id, string score, InningScore innings)
        {
            ID = id;
            Score = score;
            Innnings = innings;
        }
    }
    public class InningScore
    {
        public string ID { get; }
        public string Score { get; }
        public string Wkts { get; }
        public string Overs { get; }
        public InningScore(string id, string score, string wkts, string overs)
        {
            ID = id;
            Score = score;
            Wkts = wkts;
            Overs = overs;
        }
    }
    public class BowlingScore
    {
        public string ID { get; }
        public string Score { get; }

        public InningScore Innnings { get; }

        public BowlingScore(string id, string score, InningScore innings)
        {
            ID = id;
            Score = score;
            Innnings = innings;
        }
    }

}
