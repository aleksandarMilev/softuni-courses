namespace _03GenericSwapMethodString
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<string> box = new();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                string item = Console.ReadLine();
                box.Add(item);
            }

            int[] indexes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap(indexes[0], indexes[1]);

            Console.WriteLine(box.ToString());
        }
    }
}
