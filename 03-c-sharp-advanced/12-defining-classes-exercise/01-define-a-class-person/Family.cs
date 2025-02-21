namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;


        public Family()
        {
            this.People = new();
        }


        public List<Person> People { get; set; }


        public void AddMember(Person member)
        {
            this.People.Add(member);
        }
        public Person GetOldestMember()
        {
            return this.People
                .OrderByDescending(p => p.Age)
                .FirstOrDefault();
        }
    }
}
