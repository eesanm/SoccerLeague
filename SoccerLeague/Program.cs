// See https://aka.ms/new-console-template for more information
using SoccerLeague.Entities;
using SoccerLeague.Services;

//var match = LeagueService.GetMatchFromLine("Argentina 1, South Africa 0");

//League league = new League();
//league.AddPointsForTeam("Spain", 3);
//league.AddPointsForTeam("Spain", 3);
//league.AddPointsForTeam("Argentina", 4);
//league.AddPointsForTeam("South Afroca", 10);
//league.AddPointsForTeam("South Africa", 1);
//league.AddPointsForTeam("South Africa", 9);



//var fullPoints = league.GetLeague();


//fullPoints.ForEach(
//    (item) =>
//    {
//        Console.WriteLine($"{item.Key} {item.Value}");
//    }
//);

League league = new League();
Console.WriteLine("Enter match details or filename");
string? line = Console.ReadLine();


do
{
    if (line != null)
    {
        Match? match = LeagueService.GetMatchFromLine(line);

        if (match != null)
        {
            LeagueService.AddMatchToLeague(league, match);
        }
    }

    Console.WriteLine("Enter match details");
    line = Console.ReadLine();

} while (line != null && line != "end");


    var fullPoints = league.GetLeague();


fullPoints.ForEach(
    (item) =>
    {
        Console.WriteLine($"{item.Key} {item.Value}");
    }
);

Console.WriteLine("Done");