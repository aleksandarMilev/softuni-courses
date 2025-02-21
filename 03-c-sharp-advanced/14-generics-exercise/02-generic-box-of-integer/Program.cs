namespace _02GenericBoxOfInteger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<int> box = new();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                int item = int.Parse(Console.ReadLine());
                box.Add(item);
            }

            Console.WriteLine(box.ToString());
        }
    }
}
