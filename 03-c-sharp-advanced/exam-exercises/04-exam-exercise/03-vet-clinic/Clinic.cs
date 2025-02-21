using System.Text;
namespace _03VetClinic
{
    public class Clinic
    {
        private Dictionary<string, Pet> _pets;


        public Clinic(int capacity)
        {
            Capacity = capacity;
            _pets = new();
        }

        public int Capacity { get; set; }
        public int Count { get { return _pets.Count; } }


        public void Add(Pet pet)
        {
            if (_pets.Count < Capacity)
            {
                if (!_pets.ContainsKey(pet.Name))
                {
                    _pets.Add(pet.Name, pet);
                    Capacity--;
                }
            }
        }
        public bool Remove(string name)
        {
            if (_pets.ContainsKey(name))
            {
                _pets.Remove(name);
                Capacity++;
                return true;
            }

            return false;
        }
        public Pet GetPet(string name, string owner)
        {
            if (_pets.ContainsKey(name))
            {
                if (_pets[name].Owner == owner)
                {
                    return _pets[name];
                }
            }

            return null;
        }
        public Pet GetOldestPet()
        {
            var oldestPet = _pets.OrderByDescending(a => a.Value.Age).FirstOrDefault();
            return oldestPet.Value;
        }
        public string GetStatistics()
        {
            StringBuilder result = new();
            result.AppendLine("The clinic has the following patients:");
            if (_pets.Any())
            {
                foreach (var item in _pets)
                {
                    result.AppendLine($"Pet {item.Key} with owner: {item.Value.Owner}");
                }
            }

            return result.ToString();
        }
    }
}
