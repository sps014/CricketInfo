using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    public string @long { get; set; }
}

public class OverSummary
{
    public string over { get; set; }
    public string ball_def { get; set; }
    public string rem_over { get; set; }
    public string runs { get; set; }
    public string wickets { get; set; }
    public string fours { get; set; }
    public string sixes { get; set; }
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
    public string name { get; set; }
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
    public string name { get; set; }
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

public class CommLine
{
    public string score { get; set; }
    public string wkts { get; set; }
    public string o_no { get; set; }
    public string i_id { get; set; }
    public string o_summary { get; set; }
    public string runs { get; set; }
    public string bat_s_name { get; set; }
    public string bat_s_runs { get; set; }
    public string bat_s_balls { get; set; }
    public string bat_ns_name { get; set; }
    public string bat_ns_runs { get; set; }
    public string bat_ns_balls { get; set; }
    public string bowl_name { get; set; }
    public string bowl_overs { get; set; }
    public string bowl_maidens { get; set; }
    public string bowl_runs { get; set; }
    public string bowl_wickets { get; set; }
    public string timestamp { get; set; }
    public string evt { get; set; }
    public string comm { get; set; }
    public string bgcolor { get; set; }
    public string img { get; set; }
    public string link { get; set; }
}

public class Ads
{
}

public class MatchDetail
{
    public string match_id { get; set; }
    public string series_id { get; set; }
    public string series_name { get; set; }
    public string data_path { get; set; }
    public Header header { get; set; }
    public Venue venue { get; set; }
    public OverSummary over_summary { get; set; }
    public BatTeam bat_team { get; set; }
    public BowTeam bow_team { get; set; }
    public List<Batsman> batsman { get; set; }
    public List<Bowler> bowler { get; set; }
    public string rrr { get; set; }
    public string crr { get; set; }
    public string target { get; set; }
    public string prtshp { get; set; }
    public string last_wkt { get; set; }
    public string last_wkt_name { get; set; }
    public string last_wkt_score { get; set; }
    public List<CommLine> comm_lines { get; set; }
    public string range { get; set; }
    public int pulltoRefreshStopRate { get; set; }
    public int burst_cache_id { get; set; }
    public bool burst_cache { get; set; }
    public int burst_cache_time { get; set; }
    public Ads ads { get; set; }
}