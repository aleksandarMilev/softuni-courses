using System;
using System.Collections.Generic;
using System.Linq;
namespace _03MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Player> playersMap = new Dictionary<string, Player>();

            string command;
            while ((command = Console.ReadLine()) != "Season end")
            {
                if (command.Contains("vs"))
                {
                    string[] battle = command.Split();
                    string player1 = battle[0];
                    string player2 = battle[2];

                    if (playersMap.ContainsKey(player1) &&
                        playersMap.ContainsKey(player2))
                    {
                        Player playerOne = playersMap[player1];
                        Player playerTwo = playersMap[player2];
                        if (playerOne.Skills.Keys.Intersect(playerTwo.Skills.Keys).Any())
                        {
                            int playerOnePoints = playerOne.Skills.Values.Sum();
                            int playerTwoPoints = playerTwo.Skills.Values.Sum();

                            if (playerOnePoints > playerTwoPoints)
                            {
                                playersMap.Remove(player2);
                            }
                            else if (playerOnePoints < playerTwoPoints)
                            {
                                playersMap.Remove(player1);
                            }
                        }
                    }
                    continue;
                }

                string[] input = command.Split(" -> ");
                string playerName = input[0];
                string skillName = input[1];
                int skillPoints = int.Parse(input[2]);

                if (!playersMap.ContainsKey(playerName))
                {
                    playersMap.Add(playerName, new Player(playerName));
                    playersMap[playerName].Skills.Add(skillName, skillPoints);
                    playersMap[playerName].TotalPoints += skillPoints;
                }
                else
                {
                    if (!playersMap[playerName].Skills.ContainsKey(skillName))
                    {
                        playersMap[playerName].Skills[skillName] = skillPoints;
                        playersMap[playerName].TotalPoints += skillPoints;
                    }
                    else
                    {
                        if (playersMap[playerName].Skills[skillName] < skillPoints)
                        {
                            int diff = skillPoints - playersMap[playerName].Skills[skillName];
                            playersMap[playerName].Skills[skillName] = skillPoints;
                            playersMap[playerName].TotalPoints += diff;
                        }
                    }
                }
            }

            var sortedPLayers = playersMap.Values.OrderByDescending(v => v.TotalPoints)
                .ThenBy(n => n.Name);

            foreach (var player in sortedPLayers)
            {
                Console.WriteLine($"{player.Name}: {player.TotalPoints} skill");

                var orderedPostions = player.Skills.OrderByDescending(v => v.Value)
                    .ThenBy(n => n.Key);

                foreach (var position in orderedPostions)
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }
        }
    }
    class Player
    {
        public Player(string name)
        {
            Name = name;
            Skills = new Dictionary<string, int>();
        }
        public string Name { get; set; }
        public int TotalPoints { get; set; }

        public Dictionary<string, int> Skills { get; set; }
    }
}