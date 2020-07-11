using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CricketInfo
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Url
    {
        public string match { get; set; }

    }

    public class Header
    {
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string state { get; set; }
        public string match_desc { get; set; }
        public string type { get; set; }
        public string state_title { get; set; }
        public string toss { get; set; }
        public string status { get; set; }

    }

    public class Venue
    {
        public string name { get; set; }
        public string location { get; set; }
        public string timezone { get; set; }
        public string lat { get; set; }
        [JsonPropertyName("long")]
        public string longi { get; set; }

    }

    public class Innings
    {
        public string id { get; set; }
        public string score { get; set; }
        public string wkts { get; set; }
        public string overs { get; set; }

    }

    public class BatTeam
    {
        public string id { get; set; }
        public List<Innings> innings { get; set; }

    }

    public class Innings2
    {
        public string id { get; set; }
        public string score { get; set; }
        public string wkts { get; set; }
        public string overs { get; set; }

    }

    public class BowTeam
    {
        public string id { get; set; }
        public List<Innings2> innings { get; set; }

    }

    public class Batsman
    {
        public string id { get; set; }
        public string name { get; set; }
        public string strike { get; set; }
        public string r { get; set; }
        public string b { get; set; }

        [JsonPropertyName("4s")]
        public string fours { get; set; }
        [JsonPropertyName("6s")]
        public string sixes { get; set; }

    }

    public class Bowler
    {
        public string id { get; set; }
        public string name { get; set; }
        public string o { get; set; }
        public string m { get; set; }
        public string r { get; set; }
        public string w { get; set; }

    }

    public class Team1
    {
        public string id { get; set; }
        public string name { get; set; }
        public string s_name { get; set; }
        public string flag { get; set; }

    }

    public class Team2
    {
        public string id { get; set; }
        public string name { get; set; }
        public string s_name { get; set; }
        public string flag { get; set; }

    }

    public class Match
    {
        public string match_id { get; set; }
        public string series_id { get; set; }
        public string series_name { get; set; }
        public string data_path { get; set; }
        public Header header { get; set; }
        public string alerts { get; set; }
        public Venue venue { get; set; }
        public BatTeam bat_team { get; set; }
        public BowTeam bow_team { get; set; }
        public List<Batsman> batsman { get; set; }
        public List<Bowler> bowler { get; set; }
        public Team1 team1 { get; set; }
        public Team2 team2 { get; set; }
        public List<int> srs_category { get; set; }

    }

    public class SrsCategory
    {
        public int id { get; set; }
        public string title { get; set; }

    }

    public class LiveMatches
    {
        public Url url { get; set; }
        public List<Match> matches { get; set; }
        public List<SrsCategory> srs_category { get; set; }

    }


}
