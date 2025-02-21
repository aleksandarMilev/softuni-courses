namespace DetailPrinter
{
    public abstract class Employee
    {
        public Employee(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract string GetEmployeeInfo();
    }
}
