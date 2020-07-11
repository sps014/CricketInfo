using System;

namespace CricketInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            testc();
            Console.ReadKey();
        }
        static async void testc()
        {
            var result= await Cricbuzz.GetLiveMatches();

        }
    }
}
