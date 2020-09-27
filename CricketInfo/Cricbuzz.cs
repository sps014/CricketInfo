using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CricketInfo
{
    public static class Cricbuzz
    {
        static HttpClient client = new HttpClient();

        public const string LiveMatchesURL = "http://mapps.cricbuzz.com/cbzios/match/livematches";
        public const string MatchDetailStartURL = "http://mapps.cricbuzz.com/cbzios/match/";
        public const string MatchDetailEndURL = "/commentary";

        public static async Task<LiveMatches> GetLiveMatches()
        {
            var response = await client.GetAsync(LiveMatchesURL);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LiveMatches>(jsonString);
        }
        public static async Task<MatchDetail> GetMatchDetail(string match_id)

        {
            if (match_id == null)
                return null;

            var response = await client.GetAsync(MatchDetailStartURL + match_id + MatchDetailEndURL);
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<MatchDetail>(jsonString);
        }
    }
}
