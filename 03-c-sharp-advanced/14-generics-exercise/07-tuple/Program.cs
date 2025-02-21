namespace _07Tuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = firstLine[0] + " " + firstLine[1];
            string address = firstLine[2];
            CustomTuple<string, string> nameAndAddress = new(name, address);

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string nameWithBeer = secondLine[0];
            int litersOfBeer = int.Parse(secondLine[1]);
            CustomTuple<string, int> nameAndBeer = new(nameWithBeer, litersOfBeer);

            string[] thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int integerNumber = int.Parse(thirdLine[0]);
            double floatNumber = double.Parse(thirdLine[1]);
            CustomTuple<int, double> integerAndDouble = new(integerNumber, floatNumber);

            Console.WriteLine(nameAndAddress);
            Console.WriteLine(nameAndBeer);
            Console.WriteLine(integerAndDouble);
        }
    }
}
