using System.Text;
namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;


        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.employees = new();
        }


        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return employees.Count; } }


        public void Add(Employee employee)
        {
            if (Capacity > 0)
            {
                employees.Add(employee);
                Capacity--;
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                employees.Remove(employee);
                Capacity++;
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            if (employees.Any())
            {
                Employee oldestEmployee = this.employees.OrderByDescending(e => e.Age).First();
                return oldestEmployee;
            }

            return null;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = this.employees.FirstOrDefault(e => e.Name == name);
            if (employee != null)
            {
                return employee;
            }

            return null;
        }

        public string Report()
        {
            StringBuilder report = new();
            report.AppendLine("Employees working at Bakery {bakeryName}: ");

            if (this.employees.Any())
            {
                foreach (Employee employee in this.employees)
                {
                    report.AppendLine(employee.ToString());
                }
            }

            return report.ToString();
        }

    }
}
