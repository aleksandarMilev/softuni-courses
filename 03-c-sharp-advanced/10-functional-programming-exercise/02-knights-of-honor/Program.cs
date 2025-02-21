namespace _02KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = arr =>
            {
                foreach (string name in arr)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(names);
        }
    }
}