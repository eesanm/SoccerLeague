using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Entities
{
    public class League
    {
        //--------------------------------------------------------------------------------------

        private class TeamComparer : IComparer<KeyValuePair<string, int>>
        {
            public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y)
            {
                int result = x.Value.CompareTo(y.Value);

                if (result != 0)
                {
                    return result * -1;
                }

                return x.Key.CompareTo(y.Key);
            }
        }

        private Dictionary<string, int> _points = new Dictionary<string, int>();

        //--------------------------------------------------------------------------------------

        private void AddPointsForTeam( string teamName, int point )
        {
            if( _points.ContainsKey( teamName ))
            {
                _points[teamName] += point;
            }
            else
            {
                _points.Add( teamName, point );
            }            
        }

        //--------------------------------------------------------------------------------------

        public List<KeyValuePair<string, int>> GetLeague()
        {
            List<KeyValuePair<string, int>> list = _points.ToList();
            list.Sort(new TeamComparer());

            return list;
        }

        //--------------------------------------------------------------------------------------

        public void AddMatchToLeague(Match match)
        {
            //-- Team A wins
            if (match.TeamAScore > match.TeamBScore)
            {
                AddPointsForTeam(match.TeamA.Name, 3);
                AddPointsForTeam(match.TeamB.Name, 0);
            }

            //-- Team B wins
            else if (match.TeamBScore > match.TeamAScore)
            {
                AddPointsForTeam(match.TeamB.Name, 3);
                AddPointsForTeam(match.TeamA.Name, 0);
            }

            else
            {
                AddPointsForTeam(match.TeamA.Name, 1);
                AddPointsForTeam(match.TeamB.Name, 1);
            }
        }

        //--------------------------------------------------------------------------------------
    }
}
