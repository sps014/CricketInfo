using System;
using System.Threading.Tasks;

namespace CricketInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var liveMatches=Cricbuzz.GetLiveMatches().GetAwaiter().GetResult();

            foreach (var match in liveMatches.matches)
            {
                PrintMatch(match).Wait();
            }
            
            Console.ReadKey();
        }

        static async Task PrintMatch(Match match)
        {
            Console.WriteLine(match.header.status);
            var detail = await Cricbuzz.GetMatchDetail(match.match_id);
        }


    }
}
