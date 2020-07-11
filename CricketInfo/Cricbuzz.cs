using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CricketInfo
{
    public  static class Cricbuzz
    {
        static HttpClient client = new HttpClient();

        public const string LiveMatchesURL = "http://mapps.cricbuzz.com/cbzios/match/livematches";
        public static async Task<LiveMatches> GetLiveMatches()
        {
            var response=await client.GetAsync(LiveMatchesURL);
            var jsonString=await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LiveMatches>(jsonString);
        }
    }
}
