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
        public string Player { get; set; }
        public string[] Missions { get; set; }
        public int[] Scores { get; set; }

        public Score(string player, string[] missions, int[] scores)
        {
            Player = player;
            Missions = missions;
            Scores = scores;
        }


        public int TotalScore
        {
            get { return Scores.Sum(); }
        }

        public static List<Score> RankingByScore(List<Score> players)
        {
            List<Score> allScores = new List<Score>();
            foreach (Score player in players)
            {
                for (int i = 0; i < player.Scores.Length; i++)
                {
                    allScores.Add(new Score(player.Player, new string[] { player.Missions[i] }, new int[] { player.Scores[i] }));
                }
            }
            allScores.Sort((x, y) => y.Scores[0].CompareTo(x.Scores[0]));
            return allScores;
        }

    }
}
