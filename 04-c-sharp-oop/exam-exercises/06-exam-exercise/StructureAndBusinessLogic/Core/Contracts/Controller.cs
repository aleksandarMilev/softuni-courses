using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Repositories.Contracts;
using System.Linq;
using Handball.Utilities.Messages;
using Handball.Models;
using System.Text;

namespace Handball.Core.Contracts
{
    public class Controller : IController
    {
        private IRepository<IPlayer> players;
        private IRepository<ITeam> teams;

        public Controller()
        {
            players = new PlayerRepository();
            teams = new TeamRepository();
        }

        public string NewTeam(string name)
        {
            if (teams.Models.Any(t => t.Name == name))
            {
                return string.Format(OutputMessages.TeamAlreadyExists, name, teams.GetType().Name);
            }

            teams.AddModel(new Team(name));

            return string.Format(OutputMessages.TeamSuccessfullyAdded, name, teams.GetType().Name);
        }

        public string NewPlayer(string typeName, string name)
        {
            if (typeName != "Goalkeeper" && typeName != "CenterBack" && typeName != "ForwardWing")
            {
                return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
            }

            IPlayer playerCheck = players.Models.FirstOrDefault(p => p.Name == name);

            if (playerCheck != null)
            {
                return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, players.GetType().Name, playerCheck.GetType().Name);
            }

            IPlayer player = null;

            if (typeName == "Goalkeeper")
            {
                player = new Goalkeeper(name);
            }
            else if (typeName == "CenterBack")
            {
                player = new CenterBack(name);
            }
            else
            {
                player = new ForwardWing(name);
            }

            players.AddModel(player);

            return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
        }

        public string NewContract(string playerName, string teamName)
        {
            if (!players.Models.Any(p => p.Name == playerName))
            {
                return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
            }

            if (!teams.Models.Any(t => t.Name == teamName))
            {
                return string.Format(OutputMessages.TeamNotExisting, teamName, teams.GetType().Name);
            }

            Player player = players.Models.First(p => p.Name == playerName) as Player;

            if (player.Team != null)
            {
                return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
            }

            player.JoinTeam(teamName);

            Team team = teams.Models.First(t => t.Name == teamName) as Team;

            team.SignContract(player);

            return string.Format(OutputMessages.SignContract, playerName, teamName);
        }

        public string NewGame(string firstTeamName, string secondTeamName)
        {
            ITeam team1 = teams.Models.First(t => t.Name == firstTeamName) as Team;
            ITeam team2 = teams.Models.First(t => t.Name == secondTeamName) as Team;


            if (team2.OverallRating > team1.OverallRating)
            {
                team2.Win();
                team1.Lose();

                return string.Format(OutputMessages.GameHasWinner, team2.Name, team1.Name);
            }
            else if (team2.OverallRating == team1.OverallRating)
            {
                team1.Draw();
                team2.Draw();

                return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
            }
            else
            {
                team1.Win();
                team2.Lose();

                return string.Format(OutputMessages.GameHasWinner, team1.Name, team2.Name);
            }
        }

        public string PlayerStatistics(string teamName)
        {
            StringBuilder result = new();
            result.AppendLine($"***{teamName}***");

            Team team = teams
                .Models
                .First(t => t.Name == teamName) as Team;

            foreach (Player player in team.Players
                .OrderByDescending(p => p.Rating)
                .ThenBy(p => p.Name))
            {
                result.AppendLine(player.ToString());
            }

            return result.ToString().TrimEnd();
        }

        public string LeagueStandings()
        {
            StringBuilder result = new();
            result.AppendLine("***League Standings***");

            foreach (Team team in teams.
                Models
                .OrderByDescending(t => t.PointsEarned)
                .ThenByDescending(t => t.OverallRating)
                .ThenBy(t => t.Name))
            {
                result.AppendLine(team.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
