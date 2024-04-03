using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AC1
{
    public class Program
    {
        public static void Main()
        {
            int num = 1, numMissions = 0;
            string playerName;
            string[] playerMissions;
            int[] playerScores;
            const string Player = "Player ", AskPlayer = "Write player's name", AskMission = "Write player's mission", AskScore = "Write player's score", AskNumMissions = "Write the number of missions";
            List<Score> players = new List<Score>();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Player + num);
                do
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(AskPlayer);
                    playerName = Console.ReadLine();
                } while (!ValidatePlayer(playerName));

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(AskNumMissions);
                numMissions = Convert.ToInt32(Console.ReadLine());
                playerMissions = new string[numMissions];
                playerScores = new int[numMissions];

                for (int j = 0; j < numMissions; j++)
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(AskMission);
                        playerMissions[j] = Console.ReadLine();
                    } while (!ValidateMission(playerMissions[j]));

                    do
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(AskScore);
                        playerScores[j] = Convert.ToInt32(Console.ReadLine());
                    } while (!ValidateScore(playerScores[j]));
                }

                Score player = new Score(playerName, playerMissions, playerScores);
                players.Add(player);

                num++;
                Console.ResetColor();
                Console.Clear();
            }

            List<Score> uniqueRanking = GenerateUniqueRanking(players);

            Console.WriteLine("Unique Ranking:");
            foreach (Score player in uniqueRanking)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Player: " + player.Player);
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = 0; i < player.Missions.Length; i++)
                {
                    Console.WriteLine("Mission: " + player.Missions[i] + " Score: " + player.Scores[i]);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            Console.ReadLine();

            List<Score> rankedScores = Score.RankingByScore(players);
            Console.WriteLine("Ranking by Score:");
            int top = 0;
            foreach (Score score in rankedScores)
            {
                top++;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"TOP {top}: Player: {score.Player}, Mission: {score.Missions[0]}, Score: {score.Scores[0]}");
            }
            Console.ResetColor();
        }

        public static bool ValidatePlayer(string input)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s]+$");
            return regex.IsMatch(input);
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
            return num >= 0 && num <= 500;
        }

        public static List<Score> GenerateUniqueRanking(List<Score> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                for (int j = 0; j < players[i].Missions.Length; j++)
                {
                    for (int k = j + 1; k < players[i].Missions.Length; k++)
                    {
                        if (players[i].Missions[j] == players[i].Missions[k])
                        {
                            if (players[i].Scores[j] > players[i].Scores[k])
                            {
                                players[i].Missions[k] = null;
                                players[i].Scores[k] = 0;
                            }
                            else
                            {
                                players[i].Missions[j] = null;
                                players[i].Scores[j] = 0;
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < players.Count; i++)
            {
                List<string> validMissions = new List<string>();
                List<int> validScores = new List<int>();

                for (int j = 0; j < players[i].Missions.Length; j++)
                {
                    if (players[i].Missions[j] != null || players[i].Scores[j] != 0)
                    {
                        validMissions.Add(players[i].Missions[j]);
                        validScores.Add(players[i].Scores[j]);
                    }
                }

                players[i].Missions = validMissions.ToArray();
                players[i].Scores = validScores.ToArray();
            }

            players.Sort((x, y) => y.TotalScore.CompareTo(x.TotalScore));
            return players;
        }
    }
}