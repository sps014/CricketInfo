using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Cricbuzz
{
    public static class Cricbuzz
    {
        const string URL = "https://www.cricbuzz.com/match-api/livematches.json";
        public static List<CricketMatch> GetMatches()
        {
            var allMatches = GetJsonObjectfromServer();

            List<CricketMatch> CricketMatchList = new List<CricketMatch>();

            if (allMatches != null)
            {
                foreach (var match in allMatches)
                {
                    CricketMatch Match = CreateCricketMatchFromJson(match);
                    CricketMatchList.Add(Match);
                }
            }

            return CricketMatchList;
        }
        private static CricketMatch CreateCricketMatchFromJson(KeyValuePair<string,object> match)
        {
            string id = GetProperty(match, "id");
            string match_index = GetProperty(match, "match_index");
            string start_time= GetProperty(match, "start_time");
            string timeForNextDay = GetProperty(match, "timeForNextDay");
            string exp_end_time = GetProperty(match, "exp_end_time");
            string state = GetProperty(match, "state");
            string dn = GetProperty(match, "dn");
            string match_desc = GetProperty(match, "match_desc");
            string live_coverage = GetProperty(match, "live_coverage");
            string state_title = GetProperty(match, "state_title");
            string minor_series = GetProperty(match, "minor_series");
            string status = GetProperty(match, "status");
            string type = GetProperty(match, "type");


            CricketSeries series = CreateCricketSeries(match);
            CricketVenue venue = CreateCricketVenue(match);
            CricketScore score = CreateCricketScore(match);
            CricketTeam team1 = CreateCricketTeam(match);
            CricketTeam team2 = CreateCricketTeam(match,false);
            var players = CreateCricketPlayers(match);
            var toss = CreateCricketToss(match);

            string winningID = GetProperty(match, "winning_team_id");
            string winningMargin = GetProperty(match, "winningmargin");

            var mom = CreateMOM(match);
            var official = CreateCricketOfficial(match);
            var commentary = CricketCommentary.GetCommentary(id);

            return new CricketMatch(id,match_index,series,venue,score,team1,team2,players,toss,start_time,exp_end_time,
                timeForNextDay,state, dn,match_desc,type,live_coverage,
                minor_series,state_title,status,winningID,winningMargin,mom,official,commentary);
        }

        private static List<string> CreateMOM(KeyValuePair<string,object> match)
        {
            try
            {
                var momList = (match.Value as Dictionary<string, object>)["mom"] as ArrayList;

                var mom = new List<string>();
                foreach (var m in momList)
                    mom.Add(m.ToString());
                return mom;
            }
            catch { return null; }
        }
        private static CricketSeries CreateCricketSeries(KeyValuePair<string,object> match)
        {
            var seriesKeyValuePairs = match.Value as Dictionary<string, object>;
            var series = (seriesKeyValuePairs["series"] as Dictionary<string,object>);
            if (series != null)
            {


                string id = GetProperty(series, "id");
                string name = GetProperty(series, "name");
                string short_name = GetProperty(series, "short_name");
                string type = GetProperty(series, "type");
                string tour = GetProperty(series, "tour");
                string start_date = GetProperty(series, "start_date");
                string end_date = GetProperty(series, "end_date");
                string category = GetProperty(series, "category");
                string seriesType = GetProperty(series, "seriesType");

            return new CricketSeries(id,name,short_name,type,tour,start_date,end_date,category);
            }
            else
            {
                return null;
            }
        }
        private static CricketVenue CreateCricketVenue(KeyValuePair<string, object> match)
        {
            var venuePair = match.Value as Dictionary<string, object>;
            var venue = (venuePair["venue"] as Dictionary<string, object>);
            if (venue != null)
            {


                string id = GetProperty(venue, "id");
                string name = GetProperty(venue, "name");
                string city = GetProperty(venue, "city");
                string country = GetProperty(venue, "country");
                string location = GetProperty(venue, "location");
                string timezone = GetProperty(venue, "timezone");
                string latitude = GetProperty(venue, "latitude");
                string longitude = GetProperty(venue, "longitude");


                return new CricketVenue(id, name,city, country, location,timezone,latitude,longitude);
            }
            else
            {
                return null;
            }
        }
        private static CricketScore CreateCricketScore(KeyValuePair<string, object> match)
        {
            var scorePair = match.Value as Dictionary<string, object>;
            try
            {
                var scoreMatch = (scorePair["score"] as Dictionary<string, object>);
                if (scoreMatch != null)
                {
                    //batting

                    var battingObj = scoreMatch["batting"] as Dictionary<string, object>;
                    var battingId = GetProperty(battingObj, "id");
                    var battingScore = GetProperty(battingObj, "score");

                    var battingInningScoreArray = battingObj["innings"] as ArrayList;
                    var battingInningScore = battingInningScoreArray[0] as Dictionary<string, object>;

                    var batInningId = GetProperty(battingInningScore, "id");
                    var wicketsBatting = GetProperty(battingInningScore, "wkts");
                    var inningScore = GetProperty(battingInningScore, "score");
                    var overs = GetProperty(battingInningScore, "overs");


                    InningScore batInnings = new InningScore(batInningId, inningScore, wicketsBatting, overs);
                    BattingScore BattingScore = new BattingScore(battingId, battingScore, batInnings);

                    //bowling
                    var bowlingObj = scoreMatch["bowling"] as Dictionary<string, object>;
                    var bowlingId = GetProperty(bowlingObj, "id");
                    var bowlingScore = GetProperty(bowlingObj, "score");

                    var bowlingInningScoreArray = bowlingObj["innings"] as ArrayList;
                    InningScore bowlInnings;
                    if (bowlingInningScoreArray.Count>0)
                    {
                        var bowlingInningScore = bowlingInningScoreArray[0] as Dictionary<string, object>;

                        var bowlInningId = GetProperty(bowlingInningScore, "id");
                        var wicketsbowling = GetProperty(bowlingInningScore, "wkts");
                        var inningBowlScore = GetProperty(bowlingInningScore, "score");
                        var BowlOvers = GetProperty(bowlingInningScore, "overs");

                        bowlInnings = new InningScore(bowlInningId, inningBowlScore, wicketsbowling, BowlOvers);

                    }

                    bowlInnings = null;
                    BowlingScore BowlingScore = new BowlingScore(bowlingId, bowlingScore, bowlInnings);

                    //Get current BatsMen
                    List<CricketBatsman> batsmen = CreateCurrentCricketBatsmen(scoreMatch);

                    //Get current bowlers
                    List<CricketBowler> bowlers = CreateCurrentCricketBowler(scoreMatch);

                    //get crr
                    var crr = GetProperty(scoreMatch, "crr");
                    var pre_over = GetProperty(scoreMatch, "prev_overs");
                    var target = GetProperty(scoreMatch, "target");

                    //part
                    var p = CreateCricketPartnership(scoreMatch);

                    return new CricketScore(BattingScore, BowlingScore, batsmen, bowlers,crr
                        ,pre_over,target,p);
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
                //Console.WriteLine(e);
                return null;
            }
        }

        private static CricketTeam CreateCricketTeam(KeyValuePair<string, object> match,bool isTeam1=true)
        {
            var teamKeyValue = match.Value as Dictionary<string, object>;
            try
            {
                Dictionary<string,object> team1;
                if(isTeam1)
                    team1  = (teamKeyValue["team1"] as Dictionary<string, object>);
                else
                    team1 = (teamKeyValue["team2"] as Dictionary<string, object>);

                if (team1 != null)
                {
                    string id = GetProperty(team1, "id");
                    string name = GetProperty(team1, "name");
                    string sname = GetProperty(team1, "s_name");

                    var squadArray = (team1["squad"] as ArrayList);
                    var slist = new List<string>();
                    foreach(var m in squadArray)
                    {
                        slist.Add(m.ToString());
                    }
                    var squadBenchArray = (team1["squad_bench"] as ArrayList);
                    var sqblist = new List<string>();
                    foreach (var m in squadArray)
                    {
                        sqblist.Add(m.ToString());
                    }
                    return new CricketTeam(id, name, sname,slist,sqblist);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static List<CricketPlayer> CreateCricketPlayers(KeyValuePair<string, object> match)
        {
            var playerKeyValue = match.Value as Dictionary<string, object>;
            try
            {
                var players=playerKeyValue["players"] as ArrayList;

                List<CricketPlayer> playerList = new List<CricketPlayer>();

                if (players != null)
                {
                    foreach(Dictionary<string,object> v in players)
                    {
                        string id = GetProperty(v, "id");
                        string fname= GetProperty(v, "f_name");
                        string name = GetProperty(v, "name");
                        string batStyle = GetProperty(v, "bat_style");
                        string bowlStyle = GetProperty(v, "bowl_style");
                        string speciality = GetProperty(v, "speciality");
                        string role = GetProperty(v, "role");


                        CricketPlayer player = new CricketPlayer(id, fname, name, batStyle, bowlStyle, speciality, role);
                        playerList.Add(player);
                    }
                    return playerList;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        private static CricketToss CreateCricketToss(KeyValuePair<string, object> match)
        {
            var matchKeyValue = match.Value as Dictionary<string, object>;
            try
            {
                var toss = matchKeyValue["toss"] as Dictionary<string,Object>;


                if (toss != null)
                {
                    string winner = GetProperty(toss, "winner");
                    string decision = GetProperty(toss, "decision");
                    return new CricketToss(winner, decision);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static CricketOfficial CreateCricketOfficial(KeyValuePair<string, object> match)
        {
            var matchKeyValue = match.Value as Dictionary<string, object>;
            try
            {
                var official = matchKeyValue["official"] as Dictionary<string, Object>;


                if (official != null)
                {
                    Official u1 = GetOfficial(official, "umpire1");
                    Official u2 = GetOfficial(official, "umpire2");
                    Official u3 = GetOfficial(official, "umpire3");
                    Official referee = GetOfficial(official, "referee");

                    return new  CricketOfficial(u1, u2, u3, referee);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Official GetOfficial(Dictionary<string,object> official,string name)
        {
            try
            {
                var off = official[name] as Dictionary<string,object>;
                var id = GetProperty(off, "id");
                var oname = GetProperty(off, "name");
                var country = GetProperty(off, "country");

                return new Official(oname,id,country);
            }
            catch { return null; }

        }
        private static CricketPartnership CreateCricketPartnership(Dictionary<string, object> match)
        {
            try
            {
                var partnership = match["partnership"] as Dictionary<string, Object>;


                if (partnership != null)
                {
                    string runs = GetProperty(partnership, "runs");
                    string balls = GetProperty(partnership, "balls");
                    return new CricketPartnership(runs, balls);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        private static List<CricketBatsman> CreateCurrentCricketBatsmen(Dictionary<string,object> score)
        {
            List<CricketBatsman> cricketBatsmenList = new List<CricketBatsman>();
            var batsmanArray = score["batsman"] as ArrayList;
            foreach(var v  in batsmanArray)
            {
                var batsman = v as Dictionary<string, object>;
                string id = GetProperty(batsman, "id");
                var strike = GetProperty(batsman, "strike");
                var runs = GetProperty(batsman, "r");
                var balls = GetProperty(batsman, "b");
                var fours = GetProperty(batsman, "4s");
                var sixes = GetProperty(batsman, "6s");

                CricketBatsman batter = new CricketBatsman(id, strike, runs, balls, fours, sixes);
                cricketBatsmenList.Add(batter);
            }
            return cricketBatsmenList;

        }
        private static List<CricketBowler> CreateCurrentCricketBowler(Dictionary<string, object> score)
        {
            List<CricketBowler> cricketBowlerList = new List<CricketBowler>();
            var batsmanArray = score["bowler"] as ArrayList;
            foreach (var v in batsmanArray)
            {
                var bowler = v as Dictionary<string, object>;
                string id = GetProperty(bowler, "id");
                var o = GetProperty(bowler, "o");
                var m = GetProperty(bowler, "m");
                var r = GetProperty(bowler, "r");
                var w = GetProperty(bowler, "w");

                CricketBowler ourBowler = new CricketBowler(id, o, m, r, w);
                cricketBowlerList.Add(ourBowler);
            }
            return cricketBowlerList;

        }
        public static string GetPlayerNameFromId(string id)
        {
            WebRequest req = WebRequest.Create("https://m.cricbuzz.com/cricket-stats/player/"+id);
            using (var res = req.GetResponse())
            {
                string page = new StreamReader(res.GetResponseStream()).ReadToEnd();
                //string pattern = "<h4 [^>]*class=\"cb-list-item ui-header ui-branding-header\"([\\s\\S]*?)</h4>";
                string pattern = "<h4 class=\"cb-list-item ui-header ui-branding-header\">(.*?)</h4>";
                var c=Regex.Matches(page, pattern, RegexOptions.Multiline);
                foreach(Match m in c)
                {
                    return (m.Groups[1].Value);
                }
                return "";
            }
        }
        private static string GetProperty(KeyValuePair<string,object> keyValuePair,string property_name)
        {
            var matchValue = keyValuePair.Value as Dictionary<string, object>;
            try
            {
                return matchValue[property_name].ToString();
            }
            catch(Exception)
            {
                return null;
            }

        }
        private static string GetProperty(Dictionary<string, object> Dictionary, string property_name)
        {
            try
            {
                return Dictionary[property_name].ToString();
            }
            catch (Exception)
            {
                return null;
            }

        }
        private static Dictionary<string, object> GetJsonObjectfromServer()
        {
            WebRequest req = WebRequest.Create(URL);
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            Dictionary<string, object> MatchesDictionary = new Dictionary<string, object>();

            using (var res = req.GetResponse())
            {
                Stream output = Console.OpenStandardOutput();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string r = reader.ReadToEnd();
                var json = scriptSerializer.Deserialize<Dictionary<string, object>>(r);

                try
                {
                    return json["matches"] as Dictionary<string, Object>;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
    }
}
