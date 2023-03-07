using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerLeague.Entities
{
    public class Team
    {
        public string Name { get; }

        public Team( string name )
        {
            Name = name;
        }
    }
}
