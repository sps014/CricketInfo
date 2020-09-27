using System;
using CricketInfo;
using System.Threading.Tasks;

var liveMatches = Cricbuzz.GetLiveMatches().GetAwaiter().GetResult();

foreach (var match in liveMatches.matches)
{
    PrintMatch(match).Wait();
}

Console.ReadKey();

async Task PrintMatch(Match match)
{
    Console.WriteLine(match.header.status);
    var detail = await Cricbuzz.GetMatchDetail(match.match_id);
    foreach (var item in detail.comm_lines)
    {
        Console.WriteLine(item.comm);
    }
}