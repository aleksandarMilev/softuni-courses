namespace _04AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(n => n * 1.2m)
                .ToArray();

            foreach (decimal number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}