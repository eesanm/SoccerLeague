using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Entities
{
    public class Match
    {
        public Team TeamA { get; set; }
        public int TeamAScore { get; set; }
        public Team TeamB { get; set; }
        public int TeamBScore { get; set; }

        public Match(Team teamA, int teamAScore, Team teamB, int teamBScore)
        {
            TeamA = teamA;
            TeamAScore = teamAScore;
            TeamB = teamB;
            TeamBScore = teamBScore;
        }
    }
}
