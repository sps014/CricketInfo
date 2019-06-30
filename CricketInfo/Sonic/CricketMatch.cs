using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricbuzz
{
    public class CricketMatch
    {
        public string ID { get; }
        public string MatchIndex { get; }
        public CricketSeries Series { get; }
        public CricketVenue Venue { get; }

        public string WinningTeamID { get; }
        public string WinningMargin { get; }
        public CricketScore Score { get; }
        public CricketTeam Team1 { get; }
        public CricketTeam Team2 { get; }

        public List<string> MOM { get; }
        public string StartTime { get; }
        public bool TimeForNextDay { get; }
        public string ExpectedEndTime { get; }
        public string State { get; }
        public bool DN {get;}
        public string MatchDescription { get; }
        public string Type { get; }
        public string LiveCoverage { get; }
        public bool MinorSeries { get; }
        public string StateTitle { get; }
        public string Status { get; }
        public List<CricketPlayer> Players { get; }
        public CricketToss Toss { get; }

        public List<CricketCommentary.Commentary> Commentaries { get; }
        public CricketOfficial Official { get; }
        public CricketMatch(string id,string match_index,CricketSeries series,
            CricketVenue venue,CricketScore score,CricketTeam team1,CricketTeam team2,
            List<CricketPlayer> players,CricketToss toss,
            string startTime,string expEndTime,string timeForNextDay,
            string state,string dn,string matchDescription,string type,string liveCoverage,
            string minorSeries,string stateTitle,string status,string winningTeamID,
            string winningTeamMargin,List<string> mom,CricketOfficial official,List<CricketCommentary.Commentary> commentary)
        {
            ID = id;
            MatchIndex = match_index;
            Series = series;
            Venue = venue;
            StartTime = startTime;
            ExpectedEndTime = expEndTime;
            TimeForNextDay = Convert.ToBoolean(timeForNextDay);
            State = state;
            DN = Convert.ToBoolean(dn);
            MatchDescription = matchDescription;
            Type = type;
            LiveCoverage = liveCoverage;
            MinorSeries = Convert.ToBoolean(minorSeries);
            StateTitle = stateTitle;
            Status = status;
            Score = score;
            Team1 = team1;
            Team2 = team2;
            Players = players;
            Toss = toss;
            WinningMargin = winningTeamMargin;
            WinningTeamID = winningTeamID;
            MOM = mom;
            Official = official;
            Commentaries = commentary;
        }
    }
}
