using System;
using System.Collections.Generic;
namespace _05TeamworkProjects
{
    internal class Program
    {
        static void Main()
        {
            List<Team> teamsList = new List<Team>();

            int creatorReqCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < creatorReqCount; i++)
            {
                string[] arr = Console.ReadLine().Split("-");
                string creator = arr[0];
                string teamName = arr[1];

                Team team = new Team();
                team.Creator = creator;
                team.Name = teamName;

                var existTeams = teamsList.Find(n => n.Name == teamName);
                if (existTeams is not null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                var existCreator = teamsList.Find(cr => cr.Creator == creator);
                if (existCreator is not null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }

                Console.WriteLine($"Team {teamName} has been created by {creator}!");
                teamsList.Add(team);
            }

            string request;
            while ((request = Console.ReadLine()) != "end of assignment")
            {
                string[] memberReq = request.Split("->");
                string user = memberReq[0];
                string teamName = memberReq[1];

                bool checkTeam = teamsList.Any(n => n.Name == teamName);
                if (!checkTeam)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                bool checkMember = teamsList.Any(x => x.Creator == user) ||
                    teamsList.Any(x => x.Members.Contains(user));
                if (checkMember)
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }

                teamsList.Find(n => n.Name == teamName).Members.Add(user);
            }

            List<Team> zeroMembersList = new List<Team>();
            List<Team> leftTeams = new List<Team>();
            zeroMembersList = teamsList.Where(m => m.Members.Count <= 0).ToList();
            leftTeams = teamsList.Where(m => m.Members.Count > 0).ToList();

            var orderedLeftList = leftTeams.OrderByDescending(m => m.Members.Count)
                .ThenBy(n => n.Name)
                .ToList();
            orderedLeftList.ForEach(t => Console.WriteLine(t));

            Console.WriteLine("Teams to disband:");
            var orderedZeroMemList = zeroMembersList.OrderBy(n => n.Name).ToList();
            orderedZeroMemList.ForEach(t => Console.WriteLine(t.Name));
        }
    }
    class Team
    {
        public Team()
        {
            Members = new List<string>();
        }
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            return $"{Name}\n" +
                $"- {Creator}\n" +
                $"{PrintMembers()}";
        }
        public string PrintMembers()
        {
            string res = "";

            Members = Members.OrderBy(name => name).ToList();

            for (int i = 0; i < Members.Count - 1; i++)
            {
                res += $"-- {Members[i]}\n";
            }

            res += $"-- {Members[Members.Count - 1]}";
            return res;
        }
    }
}