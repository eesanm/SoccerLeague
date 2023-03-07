using SoccerLeague.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Services
{
    public static class LeagueService
    {

        private static Tuple<Team, int>? GetTeamAndScore(string text)
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

            return null;
        }

        public static Match? GetMatchFromLine(string line)
        {
            string[] lines = line.Split(',');
            Tuple<Team, int>? teamA = GetTeamAndScore(lines[0]);
            Tuple<Team, int>? teamB = GetTeamAndScore(lines[1]);

            if( teamA != null && teamB != null)
            {
                return new Match(teamA.Item1, teamA.Item2, teamB.Item1, teamB.Item2);
            }

            return null;
        }


        public static List<Match> GetMatchesFromText(string text)
        {
            List<Match> matches = new List<Match>();

            return matches;
        }

        public static void AddMatchToLeague( League league, Match match )
        {
            //-- Team A wins
            if( match.TeamAScore > match.TeamBScore )
            {
                league.AddPointsForTeam(match.TeamA.Name, 3);
                league.AddPointsForTeam(match.TeamB.Name, 0);
            }

            //-- Team B wins
            else if (match.TeamBScore > match.TeamAScore)
            {
                league.AddPointsForTeam(match.TeamB.Name, 3);
                league.AddPointsForTeam(match.TeamA.Name, 0);
            }

            else
            {
                league.AddPointsForTeam(match.TeamA.Name, 1);
                league.AddPointsForTeam(match.TeamB.Name, 1);
            }
        }
    }
}
