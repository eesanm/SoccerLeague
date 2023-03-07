// See https://aka.ms/new-console-template for more information
using SoccerLeague.Entities;
using SoccerLeague.Helpers;
using SoccerLeague.Services;

League league = new League();

//-- get the first input.  
Console.WriteLine("Enter match details or filename:");
string line = Console.ReadLine() ?? "";

// if this is a text file then process text file
if (TextInputHelper.IsInputAFilePath(line))
{
    List<string> lines = File.ReadAllLines(line).ToList();

    lines.ForEach(lineFromFile =>
    {
        if (!TextInputHelper.IsInputAMatchDetail(lineFromFile))
        {
            throw new Exception("File lines are not in the correct format");
        }

        league.AddMatchToLeague(DeserializeService.GetMatchFromLine(lineFromFile));
    });
}

// if it's not a text file, continue to ask for match details 
else
{
    do
    {
        // if input is not in the correct format,
        // then read a new line
        if (!TextInputHelper.IsInputAMatchDetail(line))
        {
            Console.WriteLine("Input is not file and is not in the correct format for a match detail. ");
            Console.WriteLine("Re-enter match details in correct format:");
            line = Console.ReadLine() ?? "";
        }
        // if input is in the correct format,
        // then deserialise and add match to league
        else
        {
            league.AddMatchToLeague(DeserializeService.GetMatchFromLine(line));

            Console.WriteLine("Enter next match details (hit enter or type 'end' to quit):");
            line = Console.ReadLine() ?? "";
        }
    } while (!string.IsNullOrEmpty(line) && line != "end");
}

var fullPoints = league.GetLeague();

Console.WriteLine("\n\r----------------------------------");

fullPoints.ForEach((item) => { Console.WriteLine($"{item.Key}, {item.Value} pt(s)") ; });
DatabaseService.PersistLeague(league);
               
Console.WriteLine("----------------------------------\n\r");