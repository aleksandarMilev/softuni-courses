namespace _06GenericCountMethodDouble
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Box<double> box = new();

            int inputsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputsCount; i++)
            {
                double item = double.Parse(Console.ReadLine());
                box.Add(item);
            }

            double elementToCompare = double.Parse(Console.ReadLine());
            int greaterElementsCount = box.ElementsGreaterThanAnElement(elementToCompare);

            Console.WriteLine(greaterElementsCount);
        }
    }
}
