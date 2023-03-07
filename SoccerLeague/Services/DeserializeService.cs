using SoccerLeague.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Services
{
    public static class DeserializeService
    {
        //--------------------------------------------------------------------------------------

        private static Tuple<Team, int> GetTeamAndScore(string text)
        {
            string regex = @"\d+";
            System.Text.RegularExpressions.Match match =   System.Text.RegularExpressions.Regex.Match(text, regex);
            if( match.Success)
            {
                string scoreAsString = match.Value;
                int score = int.Parse(scoreAsString);
                string teamName = text.Substring(0, match.Index).Trim();

                return new Tuple<Team, int>(new Team(teamName), score);
            }

            throw new Exception("Team and score part of the string is in an incorrect format");
        }

        //--------------------------------------------------------------------------------------

        public static Match GetMatchFromLine(string line)
        {
            try
            {
                string[] lines = line.Split(',');

                if (lines.Length == 2) 
                {
                    Tuple<Team, int> teamA = GetTeamAndScore(lines[0]);
                    Tuple<Team, int> teamB = GetTeamAndScore(lines[1]);
                    return new Match(teamA.Item1, teamA.Item2, teamB.Item1, teamB.Item2);
                }

                throw new Exception("Line is not split with a single comma");
                
            }
            catch (Exception ex)
            {
                throw new Exception("Line is in an incorrect format", ex);
            }
        }

        //--------------------------------------------------------------------------------------

        public static List<Match> GetMatchesFromText(string text)
        {
            List<Match> matches = new List<Match>();

            return matches;
        }

        //--------------------------------------------------------------------------------------

    }
}
