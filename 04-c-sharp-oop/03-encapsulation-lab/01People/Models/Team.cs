using System.Collections.Generic;

namespace People.Models
{
    public class Team
    {
        private ICollection<Person> firstTeam;
        private ICollection<Person> reserveTeam;

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }


        public string Name { get; private set; }
        public ICollection<Person> FirstTeam => firstTeam;
        public ICollection<Person> ReserveTeam => reserveTeam;

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
