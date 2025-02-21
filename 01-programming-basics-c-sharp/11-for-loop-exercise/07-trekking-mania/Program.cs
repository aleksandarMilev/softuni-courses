using System;
namespace _07TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalGroupsCount = int.Parse(Console.ReadLine());
            int musala = 0;
            int monblan = 0;
            int cilimandjaro = 0;
            int k2 = 0;
            int everest = 0;

            for (int i = 0; i < totalGroupsCount; i++)
            {
                int theGroupCount = int.Parse(Console.ReadLine());
                if (theGroupCount <= 5)
                {
                    musala += theGroupCount;
                }
                else if (theGroupCount > 5 && theGroupCount <= 12)
                {
                    monblan += theGroupCount;
                }
                else if (theGroupCount > 12 && theGroupCount <= 25)
                {
                    cilimandjaro += theGroupCount;
                }
                else if (theGroupCount > 25 && theGroupCount <= 40)
                {
                    k2 += theGroupCount;
                }
                else if (theGroupCount > 40)
                {
                    everest += theGroupCount;
                }
            }
            int totalPeopleCount = musala + monblan + cilimandjaro + k2 + everest;
            Console.WriteLine($"{(musala / (double)totalPeopleCount) * 100:f2}%");
            Console.WriteLine($"{(monblan / (double)totalPeopleCount) * 100:f2}%");
            Console.WriteLine($"{(cilimandjaro / (double)totalPeopleCount) * 100:f2}%");
            Console.WriteLine($"{(k2 / (double)totalPeopleCount) * 100:f2}%");
            Console.WriteLine($"{(everest / (double)totalPeopleCount) * 100:f2}%");
        }
    }
}