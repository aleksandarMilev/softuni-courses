namespace _07TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pumpsCount = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new(); 

            for (int i = 0; i < pumpsCount; i++)
            {
                int[] pumpsInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                pumps.Enqueue(pumpsInfo);
            }

            int index = 0;
            while (true)
            {
                int liters = 0;
                bool completed = true;
                foreach (int[] pump in pumps)
                {
                    int pumpLiters = pump[0];
                    int kmToNextPump = pump[1];

                    liters += pumpLiters;
                    if (liters - kmToNextPump < 0)
                    {
                        index++;
                        completed = false;
                        pumps.Enqueue(pumps.Dequeue());
                        break;
                    }
                    else
                    {
                        liters -= kmToNextPump;
                    }
                }

                if (completed)
                {
                    Console.WriteLine(index);
                    break;
                }
            }
        }
    }
}