using System.Text;
namespace Parking
{
    public class Parking
    {
        private List<Car> _cars;


        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            _cars = new();
        }


        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return _cars.Count; } }


        public void Add(Car car)
        {
            if (Capacity > 0)
            {
                _cars.Add(car);
                Capacity--;
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = _cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (car != null)
            {
                _cars.Remove(car);
                Capacity++;
                return true;
            }

            return false;
        }
        public Car GetLatestCar()
        {
            if (_cars.Any())
            {
                Car car = _cars.OrderByDescending(c => c.Year).First();
                return car;
            }

            return null;
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = _cars.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (car != null)
            {
                return car;
            }

            return null;
        }
        public string GetStatistics()
        {
            StringBuilder result = new();
            result.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in _cars)
            {
                result.AppendLine(car.ToString());
            }

            return result.ToString();
        }
    }
}
