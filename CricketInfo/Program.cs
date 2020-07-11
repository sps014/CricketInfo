using System;

namespace CricketInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cricbuzz.GetLiveMatches().GetAwaiter().GetResult();
            Console.ReadKey();
        }

    }
}
