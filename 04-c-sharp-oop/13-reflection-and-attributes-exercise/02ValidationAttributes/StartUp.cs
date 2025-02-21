using System;
using ValidationAttributes.Models;
using ValidationAttributes.Utils;
namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Person person = new("Ivan", 19);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
