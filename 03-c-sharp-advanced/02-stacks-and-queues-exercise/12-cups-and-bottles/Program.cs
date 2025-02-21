namespace _12CupsAndBottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cups = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> bottles = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wastedLitters = 0;

            while (cups.Any() &&
                bottles.Any())
            {
                int currentBottle = bottles.Pop();
                int currentCup = cups.Dequeue();

                currentCup -= currentBottle;
                if (currentCup <= 0)
                {
                    wastedLitters += Math.Abs(currentCup);
                }
                else
                {
                    while (currentCup > 0 &&
                        bottles.Any())
                    {
                        currentBottle = bottles.Pop();
                        currentCup -= currentBottle;
                        if (currentCup <= 0)
                        {
                            wastedLitters += Math.Abs(currentCup);
                            break;
                        }
                    }
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");

            }

            Console.WriteLine($"Wasted litters of water: {wastedLitters}");
        }
    }
}