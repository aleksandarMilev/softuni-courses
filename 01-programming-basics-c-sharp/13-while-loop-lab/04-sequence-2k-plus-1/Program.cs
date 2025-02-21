using System;
namespace _04Sequence2KPlus1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int nums = 1;
            while (n >= nums)
            {
                Console.WriteLine(nums);
                nums = nums * 2 + 1;
            }
        }
    }
}