namespace _01FlowerWreaths
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> roses = new(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wreathCount = 0;
            int sumStored = 0;

            while (lilies.Any() && roses.Any())
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    while (lilies.Peek() + roses.Peek() > 15)
                    {
                        int currentLile = lilies.Pop();
                        lilies.Push(currentLile - 2);
                    }

                    wreathCount++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else
                {
                    sumStored += lilies.Pop() + roses.Dequeue();
                }
            }

            while (sumStored >= 15)
            {
                sumStored -= 15;
                wreathCount++;
            }

            if (wreathCount >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCount} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathCount} wreaths more!");
            }
        }
    }
}
