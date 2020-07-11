using System;

namespace CricketInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            var matches=Cricbuzz.GetLiveMatches().GetAwaiter().GetResult();
            if(matches.matches.Count>0)
            {
                var detail=Cricbuzz.GetMatchDetail(matches.matches[0].match_id).GetAwaiter().GetResult();
            }
            Console.ReadKey();
        }

    }
}
