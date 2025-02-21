using System;
namespace _01DataTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            string value = Console.ReadLine();

            string result = DataType(dataType, value);
            Console.WriteLine(result);
        }

        static string DataType(string dataType, string value)
        {
            if (dataType == "int")
            {
                if (int.TryParse(value, out int intValue))
                {
                    int intResult = intValue * 2;
                    return intResult.ToString();
                }
                else
                {
                    return "Invalid data type!";
                }
            }
            else if (dataType == "real")
            {
                if (double.TryParse(value, out double doubleValue))
                {
                    double doubleResult = doubleValue * 1.5;
                    return doubleResult.ToString("F2");
                }
                else
                {
                    return "Invalid data type!";
                }
            }
            else if (dataType == "string")
            {
                return $"${value}$";

            }
            return "Invalid data type!";
        }
    }
}