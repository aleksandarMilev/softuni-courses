using System.Text;
namespace _04Froggy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] stones = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new(stones);
            StringBuilder result = new();

            foreach (int stone in lake)
            {
                result.Append($"{stone}, ");
            }

            Console.WriteLine(result.ToString().TrimEnd(',', ' '));
        }
    }
}
