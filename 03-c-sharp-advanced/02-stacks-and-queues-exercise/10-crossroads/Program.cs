namespace _10Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> carQueue = new();

            int greenDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            int carsPassedCount = 0;
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                int currGreenDuartion = greenDuration;
                int currFreeWindowDuartion = freeWindowDuration;
                if (input == "green")
                {
                    while (currGreenDuartion > 0 &&
                        carQueue.Any())
                    {
                        string car = carQueue.Dequeue();
                        for (int i = 0; i < car.Length; i++)
                        {
                            currGreenDuartion--;
                            if (currGreenDuartion <= 0)
                            {
                                currFreeWindowDuartion--;
                                if (currFreeWindowDuartion < 0)
                                {
                                    if (i < car.Length - 1)
                                    {
                                        Console.WriteLine("A crash happened!");
                                        Console.WriteLine($"{car} was hit at {car[i + 1]}.");
                                        return;
                                    }
                                }
                            }
                        }
                        carsPassedCount++;
                    }
                }
                else
                {
                    carQueue.Enqueue(input);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedCount} total cars passed the crossroads.");
        }
    }
}