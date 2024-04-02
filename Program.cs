using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AC1
{
    public class Program
    {
        public static void Main()
        {
            int num = 1, playerScore;
            string playerName, playerMission;
            const string Player = "Player ", AskPlayer = "Write player's name", AskMission = "Write player's mission", AskScore = "Write player's score";
            List<Score> players = new List<Score>();

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine(Player + num);
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(AskPlayer);
                    playerName = Console.ReadLine();
                } while (!ValidatePlayer(playerName));

                do
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(AskMission);
                    playerMission = Console.ReadLine();
                } while (!ValidateMission(playerMission));

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(AskScore);
                    playerScore = Convert.ToInt32(Console.ReadLine());
                } while (!ValidateScore(playerScore));

                Score player = new Score(playerName, playerMission, playerScore);
                players.Add(player);

                num++;
                Console.ResetColor();
                Console.Clear();
            }

            List<Score> uniqueRanking = GenerateUniqueRanking(players);

            foreach (Score player in uniqueRanking)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player: " + player.Player);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Mission: " + player.Mission);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Score: " + player.Scores);
                Console.WriteLine();
                Console.ResetColor();
            }
        }
        public static bool ValidatePlayer(string input)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            return !regex.IsMatch(input);
        }
        public static bool ValidateMission(string input)
        {
            string[] GreeceAlph = { "Alfa", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mi", "Ni", "Ksi", "Omicron", "Pi", "Ro", "Sigma", "Tau", "Ipsilon", "Fi", "Khi", "Psi", "Omega" };
            bool containsGreekWord = false;

            foreach (string word in GreeceAlph)
            {
                if (input.Contains(word))
                {
                    containsGreekWord = true;
                    break;
                }
            }
            string pattern = @"^.*-\d{3}$";
            return containsGreekWord && Regex.IsMatch(input, pattern);
        }
        public static bool ValidateScore(int num)
        {
            if (num >= 0 && num <= 500)
            {
                return true;
            }
            else return false;
        }
        public static List<Score> GenerateUniqueRanking (List<Score> players)
        {
            players.Sort((x, y) => y.Scores.CompareTo(x.Scores));
            return players;
        }
    }
}
