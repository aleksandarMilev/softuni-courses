using System; 
namespace _01SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine());
            int secondTime = int.Parse(Console.ReadLine());
            int thirdTime = int.Parse(Console.ReadLine());

            int totalSeconds = firstTime + secondTime + thirdTime;
            int minutes = totalSeconds / 60;
            int leftSeconds = totalSeconds - minutes * 60;
            if (leftSeconds < 10)
            {
                Console.WriteLine($"{minutes}:0{leftSeconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{leftSeconds}");
            }
        }
    }
}