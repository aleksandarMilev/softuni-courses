namespace SoftUniParking
{
    public class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;


        public Parking(int capacity)
        {
            Capacity = capacity;
            Cars = new();
        }


        public Dictionary<string, Car> Cars { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Cars.Count; } }


        public string AddCar(Car car)
        {
            if (Cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }

            if (Count >= Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                Cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!Cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return Cars[registrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var regNum in registrationNumbers)
            {
                RemoveCar(regNum);
            }
        }
    }
}

