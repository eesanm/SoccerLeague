using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SoccerLeague.Helpers
{
    public static class TextInputHelper
    {
        //------------------------------------------------------------------

        public static bool IsInputAFilePath(string input)
        {
            return false;
        }

        //------------------------------------------------------------------

        public static bool IsInputAMatchDetail( string input )
        {
            string regexPattern = @"[a-zA-Z ]+\s\d+,[a-zA-Z ]+\s\d+";
            Match match = Regex.Match(input, regexPattern);
            return match.Success;
        }

        //------------------------------------------------------------------
    }
}
