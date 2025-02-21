using FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    static void Main()
    {
        List<Team> teams = new();

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] arguments = command
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            string action = arguments[0];
            string teamName = arguments[1];
            try
            {
                switch (action)
                {
                    case "Team":
                        AddTeam(teamName, teams);
                        break;
                    case "Add":
                        string playerName = arguments[2];
                        int endurance = int.Parse(arguments[3]);
                        int sprint = int.Parse(arguments[4]);
                        int dribble = int.Parse(arguments[5]);
                        int passing = int.Parse(arguments[6]);
                        int shooting = int.Parse(arguments[7]);

                        AddPlayer(
                            teamName,
                            playerName,
                            endurance,
                            sprint,
                            dribble,
                            passing,
                            shooting,
                            teams);
                        break;
                    case "Remove":
                        playerName = arguments[2];
                        RemovePlayer(teamName, playerName, teams);
                        break;
                    case "Rating":
                        PrintRating(teamName, teams);
                        break;
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void AddTeam(string name, List<Team> teams) => teams.Add(new Team(name));

        static void AddPlayer(
            string teamName,
            string name,
            int endurance,
            int sprint,
            int dribble,
            int passing,
            int shooting,
            List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Player player = new(name, endurance, sprint, dribble, passing, shooting);
            team.Add(player);
        }

        static void RemovePlayer(string teamName, string playerName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            team.Remove(playerName);
        }

        static void PrintRating(string teamName, List<Team> teams)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException($"Team {teamName} does not exist.");
            }

            Console.WriteLine($"{teamName} - {team.Rating:f0}");
        }
    }
}
