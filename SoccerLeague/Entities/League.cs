using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Entities
{
    public class TeamComparer :  IComparer<KeyValuePair<string, int>>
    {
        public int Compare(KeyValuePair<string, int> x, KeyValuePair<string, int> y )
        {
            int result = x.Value.CompareTo( y.Value );

            if( result != 0)
            {
                return result * -1;
            }

            return x.Key.CompareTo( y.Key );
        }
    }

    public class League
    {
        private Dictionary<string, int> m_points = new Dictionary<string, int>();

        public void AddPointsForTeam( string teamName, int point )
        {
            if( m_points.ContainsKey( teamName ))
            {
                m_points[teamName] += point;
            }
            else
            {
                m_points.Add( teamName, point );
            }

            
        }

        public List<KeyValuePair<string, int>> GetLeague()
        {
            List<KeyValuePair<string, int>> list = m_points.ToList();
            list.Sort(new TeamComparer());

            return list;
        }
    }
}
