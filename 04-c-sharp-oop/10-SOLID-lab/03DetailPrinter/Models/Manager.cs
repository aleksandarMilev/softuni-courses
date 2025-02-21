using System;
using System.Collections.Generic;
namespace DetailPrinter.Models
{
    public class Manager : Employee
    {
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; private set; }

        public override string GetEmployeeInfo()
        {
            string result = string.Empty;
            result += $"{Name}{Environment.NewLine}";
            result += string.Join(Environment.NewLine, Documents);

            return result;
        }
    }
}
