using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AC1
{
    public class Score
    {
        public string? player;
        public string? mission;
        public int score;
        public string? GetPlayer()
        {
            if (ValidatePlayer(player))
            {
                return this.player;
            }
            else return null;
        }
        public void SetPlayer(string player)
        {
            this.player = player;
        }
        public string GetMission()
        {
            if (ValidateMission(mission))
            {
                return this.mission;
            }
            else return null; 

        }
        public void SetMission(string mission)
        {
            this.mission = mission;
        }
        public int GetScore()
        {
            if (ValidateScore(score))
            {
                return this.score;
            }
            else return 0;
        }
        public void SetScore(int score)
        {
            this.score = score;
        }

        
        //meterlo en otro lado
        public static bool ValidatePlayer(string input)
        {
            Regex regex = new Regex(@"[^a-zA-Z0-9\s]");
            return !regex.IsMatch(input);
        }
        public static bool ValidateMission(string input)
        {
            string[] GreeceAlph = { "Alfa", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mi", "Ni", "Ksi", "Omicron", "Pi", "Ro", "Sigma", "Tau", "Ipsilon", "Fi", "Khi", "Psi", "Omega" };

            foreach (string word in GreeceAlph)
            {
                if (input.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
        public bool ValidateScore(int num)
        {
            if (num >= 0 && num <= 500)
            {
                return true;
            }
            else return false;
        }

    }
}
