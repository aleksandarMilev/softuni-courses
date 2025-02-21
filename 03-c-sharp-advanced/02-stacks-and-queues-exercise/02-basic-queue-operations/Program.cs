namespace _02BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int elementsEnqueueCount = input[0];
            int elementsDequeueCount = input[1];
            int elementSearch = input[2];

            int[] numbersEnqueue = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> numbers = new(numbersEnqueue);

            for (int i = 0; i < elementsDequeueCount; i++)
            {
                numbers.Dequeue();
            }

            if (numbers.Any())
            {
                if (numbers.Contains(elementSearch))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}