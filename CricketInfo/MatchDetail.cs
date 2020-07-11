using System.Collections.Generic;
using System.Text.Json.Serialization;

public class VideoGeo
{
    public List<object> country { get; set; }

}

public class Settings
{
    public int refresh { get; set; }
    public int timeout { get; set; }
    public List<object> pull_geo { get; set; }
    public bool force_refresh { get; set; }
    public VideoGeo video_geo { get; set; }
    public bool video_enabled { get; set; }
    public string mode { get; set; }

}

public class Series
{
    public string id { get; set; }
    public string name { get; set; }
    public string short_name { get; set; }
    public string type { get; set; }
    public bool tour { get; set; }
    public string start_date { get; set; }
    public string end_date { get; set; }
    public string category { get; set; }
    public string seriesType { get; set; }

}

public class Venue
{
    public string id { get; set; }
    public string name { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public string location { get; set; }
    public string timezone { get; set; }
    public string latitude { get; set; }
    public string longitude { get; set; }

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

public class Batting
{
    public string id { get; set; }
    public string score { get; set; }
    public List<Innings> innings { get; set; }

}

public class Innings2
{
    public string id { get; set; }
    public string score { get; set; }
    public string wkts { get; set; }
    public string overs { get; set; }

}

public class Bowling
{
    public string id { get; set; }
    public string score { get; set; }
    public List<Innings2> innings { get; set; }

}

public class Batsman
{
    public string id { get; set; }
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
    public string o { get; set; }
    public string m { get; set; }
    public string r { get; set; }
    public string w { get; set; }

}

public class Score
{
    public OverSummary over_summary { get; set; }
    public string prev_overs { get; set; }
    public Batting batting { get; set; }
    public Bowling bowling { get; set; }
    public string max_overs { get; set; }
    public string crr { get; set; }
    public string overs_left { get; set; }
    public string target { get; set; }
    public string prtshp { get; set; }
    public string last_wkt { get; set; }
    public string last_wkt_score { get; set; }
    public List<Batsman> batsman { get; set; }
    public List<Bowler> bowler { get; set; }

}

public class Toss
{
    public string winner { get; set; }
    public string decision { get; set; }

}

public class Team1
{
    public string id { get; set; }
    public string name { get; set; }
    public string s_name { get; set; }
    public string round_flag { get; set; }
    public string square_flag { get; set; }
    public List<int> squad { get; set; }
    public List<int> squad_bench { get; set; }

}

public class Team2
{
    public string id { get; set; }
    public string name { get; set; }
    public string s_name { get; set; }
    public string round_flag { get; set; }
    public string square_flag { get; set; }
    public List<int> squad { get; set; }
    public List<int> squad_bench { get; set; }

}

public class Umpire1
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }

}

public class Umpire2
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }

}

public class Umpire3
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }

}

public class Referee
{
    public string id { get; set; }
    public string name { get; set; }
    public string country { get; set; }

}

public class Official
{
    public Umpire1 umpire1 { get; set; }
    public Umpire2 umpire2 { get; set; }
    public Umpire3 umpire3 { get; set; }
    public Referee referee { get; set; }

}

public class Player
{
    public string id { get; set; }
    public string f_name { get; set; }
    public string name { get; set; }
    public string bat_style { get; set; }
    public string bowl_style { get; set; }
    public string speciality { get; set; }
    public string image { get; set; }
    public string role { get; set; }

}

public class Batsman2
{
    public string id { get; set; }
    public string strike { get; set; }
    [JsonPropertyName("4s")]
    public string fours { get; set; }
    [JsonPropertyName("6s")]

    public string sixes { get; set; }
    public string r { get; set; }
    public string b { get; set; }

}

public class Bowler2
{
    public string id { get; set; }
    public string o { get; set; }
    public string m { get; set; }
    public string r { get; set; }
    public string w { get; set; }
    public string n { get; set; }
    public string wd { get; set; }

}

public class CommLine
{
    public string score { get; set; }
    public string wkts { get; set; }
    public string o_no { get; set; }
    public string b_no { get; set; }
    public string i_id { get; set; }
    public string bt_tm_name { get; set; }
    public string o_summary { get; set; }
    public string o_runs { get; set; }
    public List<Batsman2> batsman { get; set; }
    public List<Bowler2> bowler { get; set; }
    public string timestamp { get; set; }
    public string evt { get; set; }
    public List<string> all_evt { get; set; }
    public string comm { get; set; }

}

public class MatchDetail
{
    public Settings settings { get; set; }
    public string id { get; set; }
    public Series series { get; set; }
    public string start_time { get; set; }
    public string timeForNextDay { get; set; }
    public string exp_end_time { get; set; }
    public string state { get; set; }
    public bool dn { get; set; }
    public string match_desc { get; set; }
    public string type { get; set; }
    public bool live_coverage { get; set; }
    public bool minor_series { get; set; }
    public string state_title { get; set; }
    public string status { get; set; }
    public Venue venue { get; set; }
    public Score score { get; set; }
    public string hys { get; set; }
    public Toss toss { get; set; }
    public Team1 team1 { get; set; }
    public Team2 team2 { get; set; }
    public Official official { get; set; }
    public List<Player> players { get; set; }
    public string last_update_time { get; set; }
    public List<CommLine> comm_lines { get; set; }

}
