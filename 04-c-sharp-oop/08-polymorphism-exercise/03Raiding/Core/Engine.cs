using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private IHeroFactory heroFactory;
        private ICollection<IHero> heroes;

        public Engine(IHeroFactory heroFactory)
        {
            this.heroFactory = heroFactory;
            heroes = new List<IHero>();
        }

        public void Run()
        {
            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                try
                {
                    heroes.Add(heroFactory.Create(type, name));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    i--;
                } 
            }

            foreach (IHero hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            int bossPower = int.Parse(Console.ReadLine());

            if (heroes.Sum(h => h.Power) >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private IHero CreateHero(string heroType, string heroName)
        {
            IHero hero = heroFactory.Create(heroType, heroName);
            return hero;
        }
    }
}
