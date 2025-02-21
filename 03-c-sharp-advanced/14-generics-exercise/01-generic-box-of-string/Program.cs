namespace _01GenericBoxOfString
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

            Console.WriteLine(box.ToString());
        }
    }
}
