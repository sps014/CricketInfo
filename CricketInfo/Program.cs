using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketInfo
{
    class Program
    {
        static void Main(string[] args)
        {

            foreach (var v in Cricbuzz.Cricbuzz.GetMatches())
            {


                if (v.Score != null)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(v.Team1.ShortName + "  vs  " + v.Team2.ShortName + " , ");
                    Console.WriteLine(v.Venue.City);
                    Console.WriteLine(v.StateTitle + "\t");
                    Console.WriteLine("CRR: " + v.Score.CurrentRunRate);

                    Console.ForegroundColor = ConsoleColor.Blue;

                    DrawBattingTable();

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    ShowBatsman(v.Score.Batsmen[0]);

                    if (v.Score.Batsmen.Count > 1)
                    {
                        ShowBatsman(v.Score.Batsmen[1]);

                    }

                    Console.Write("\n");
                    Console.ForegroundColor = ConsoleColor.Blue;

                    DrawBowlingTable();

                    Console.ForegroundColor = ConsoleColor.Cyan;

                    ShowBowler(v.Score.Bowlers[0]);
                    if(v.Score.Bowlers.Count>=2)
                    ShowBowler(v.Score.Bowlers[1]);

                    Console.Write("\n");

                    PrintPreviousOvers(v.Score);

                    Console.ForegroundColor = ConsoleColor.Blue;

                    //ShowCommentry(v);

                    Console.WriteLine("\n\n");

                }
            }

            Console.ReadKey();
        }
        static void ShowCommentry(Cricbuzz.CricketMatch match)
        {
            Console.WriteLine("\n");
            foreach (var v in match.Commentaries)
            {
                string text = v.CommentaryLines;
                text = text.Replace("<b>", "");
                text = text.Replace("</b>", "");
                Console.WriteLine(text + "\n");
            }
        }
        static void ShowBowler(Cricbuzz.CricketBowler bowler)
        {
            string bid = bowler.ID;
            string bname = Cricbuzz.Cricbuzz.GetPlayerNameFromId(bid);
            Console.WriteLine(bname.PadRight(30) + bowler.Overs.PadRight(10) + bowler.Maiden.PadRight(10) + bowler.Runs.PadRight(10) + bowler.Wicket);
        }

        static void DrawBattingTable()
        {
            Console.WriteLine("Batsman:".PadRight(30) + "R(B)".PadRight(10) + "4(s)".PadRight(10) + "6(s)".PadRight(10) + "SR");
        }
        static void DrawBowlingTable()
        {
            Console.WriteLine("Bowling:".PadRight(30) + "O".PadRight(10) + "M".PadRight(10) + "R".PadRight(10) + "W");
        }
        static void ShowBatsman(Cricbuzz.CricketBatsman batsman)
        {
            string bid = batsman.ID;
            string bname = Cricbuzz.Cricbuzz.GetPlayerNameFromId(bid);
            if (batsman.OnStrike)
                bname.Insert(0, "*");

            Console.Write(bname.PadRight(30));
            string rb = batsman.Runs + "(" + batsman.Balls + ")";
            string four = batsman.Fours.PadRight(10);
            string sixes = batsman.Sixes.PadRight(10);
            string strike = (int.Parse(batsman.Runs) * 100.0f / int.Parse(batsman.Balls)).ToString();
            Console.Write(rb.PadRight(10));
            Console.Write(four);
            Console.Write(sixes);
            Console.WriteLine(strike);

        }
        static ConsoleColor GetRandomColor()
        {
            return (ConsoleColor)(new Random().Next(Enum.GetNames(typeof(ConsoleColor)).Length));
        }
        static void PrintPreviousOvers(Cricbuzz.CricketScore score)
        {
            var part = score.PreviousOvers.Split(' ');

            for (int i = 0; i < part.Length; i++)
            {
                if (part[i] == "W")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else if (part[i] == "6")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else if (part[i] == "4" || part[i] == "B4")
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else if (part[i] == "|")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(part[i] + " ");

            }
        }

    }
}
