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
        public string? Player { get; set; }
        public string? Mission { get; set; }
        public int Scores { get; set; }

        public Score(string player, string mission, int scores)
        {
            Player = player;
            Mission = mission;
            Scores = scores;
        }
        

    }
}
