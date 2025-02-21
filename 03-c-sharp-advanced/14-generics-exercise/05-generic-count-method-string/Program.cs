namespace _05GenericCountMethodString
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

            string elementToCompare = Console.ReadLine();
            Console.WriteLine(box.ElementsGreaterThanAnElement(elementToCompare));
        }
    }
}
