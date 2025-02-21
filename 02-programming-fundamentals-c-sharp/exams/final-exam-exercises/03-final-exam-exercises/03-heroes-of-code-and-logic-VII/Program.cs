using System;
using System.Collections.Generic;
namespace _03HeroesOfCodeAndLogicVII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hero> heroesMap = new Dictionary<string, Hero>();
            int inputCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputCount; i++)
            {
                string[] hero = Console.ReadLine().Split();
                string heroName = hero[0];
                int heroHp = int.Parse(hero[1]);
                int heroMp = int.Parse(hero[2]);

                heroesMap.Add(heroName, new Hero(heroName, heroHp, heroMp));
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] actions = command.Split(" - ", StringSplitOptions.RemoveEmptyEntries);
                string action = actions[0];
                string heroName = actions[1];
                switch (action)
                {
                    case "CastSpell":
                        int neededMp = int.Parse(actions[2]);
                        string spell = actions[3];

                        if (heroesMap[heroName].MP >= neededMp)
                        {
                            heroesMap[heroName].MP -= neededMp;
                            Console.WriteLine($"{heroName} has successfully cast {spell} and now has {heroesMap[heroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(actions[2]);
                        string attacker = actions[3];

                        heroesMap[heroName].HP -= damage;
                        if (heroesMap[heroName].HP > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroesMap[heroName].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroesMap.Remove(heroName);
                        }
                        break;
                    case "Recharge":
                        int mpIncrease = int.Parse(actions[2]);
                        if (heroesMap[heroName].MP + mpIncrease > 200)
                        {
                            mpIncrease = 200 - heroesMap[heroName].MP;
                        }

                        heroesMap[heroName].MP += mpIncrease;
                        Console.WriteLine($"{heroName} recharged for {mpIncrease} MP!");
                        break;
                    case "Heal":
                        int hpIncrease = int.Parse(actions[2]);
                        if (heroesMap[heroName].HP + hpIncrease > 100)
                        {
                            hpIncrease = 100 - heroesMap[heroName].HP;
                        }

                        heroesMap[heroName].HP += hpIncrease;
                        Console.WriteLine($"{heroName} healed for {hpIncrease} HP!");
                        break;
                    default:
                        break;
                }
            }

            foreach (KeyValuePair <string, Hero> kvp in heroesMap)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine($"\tHP: {kvp.Value.HP}");
                Console.WriteLine($"\tMP: {kvp.Value.MP}");
            }
        }
    }
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}