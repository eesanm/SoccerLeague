// See https://aka.ms/new-console-template for more information
using SoccerLeague.Entities;
using SoccerLeague.Helpers;
using SoccerLeague.Services;

League league = new League();

//-- get the first input.  
Console.WriteLine("Enter match details or filename:");
string line = Console.ReadLine() ?? "";

// if this is a text file the proces text file
if (TextInputHelper.IsInputAFilePath(line))
{

}

// if it's not a text file, continue to ask for match details 
do
{
    // if input is not in the correct format,
    // then read a new line
    if (!TextInputHelper.IsInputAMatchDetail(line))
    {
        Console.WriteLine("Input is not in the correct format. Re-enter match details in correct format:");
        line = Console.ReadLine() ?? "";
    }
    // if input is in the correct format,
    // then deserialise and add match to league
    else
    {
        Match match = DeserializeService.GetMatchFromLine(line);
        league.AddMatchToLeague(match);

        Console.WriteLine("Enter next match details:");
        line = Console.ReadLine() ?? "";
    }
} while (!string.IsNullOrEmpty(line) && line != "end");


var fullPoints = league.GetLeague();
fullPoints.ForEach((item) => { Console.WriteLine($"{item.Key} {item.Value}"); }

);

Console.WriteLine("Done");