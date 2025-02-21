namespace _11KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());

            Stack<int> bullets = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> locks = new(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int intelligenceValue = int.Parse(Console.ReadLine());

            int bulletsCount = 0;
            int currentBarrelSize = barrelSize;

            while (bullets.Any() &&
                locks.Any())
            {
                if (currentBarrelSize == 0)
                {
                    currentBarrelSize = barrelSize;
                    Console.WriteLine("Reloading!");
                    continue;
                }
                if (bullets.Pop() > locks.Peek())
                {
                    Console.WriteLine("Ping!");
                }
                else
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                bulletsCount++;
                currentBarrelSize--;
            }

            if (currentBarrelSize == 0 &&
                bullets.Any())
            {
                Console.WriteLine("Reloading!");
            }

            if ((!bullets.Any() && !locks.Any()) ||
                bullets.Any())
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - (bulletsCount * bulletPrice)}");
            }
            else 
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
        }
    }
}