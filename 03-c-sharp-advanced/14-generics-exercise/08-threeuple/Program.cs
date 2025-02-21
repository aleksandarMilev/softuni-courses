namespace _08Threeuple
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string fullName = firstLine[0] + " " + firstLine[1];
            string address = firstLine[2];
            string[] townArr = firstLine[3..];
            string town = string.Join(" ", townArr);
            CustomThreeuple<string, string, string> addressInfo = new(fullName, address, town);

            string[] secondLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string nameWithBeer = secondLine[0];
            int litersOfBeer = int.Parse(secondLine[1]);
            bool drunkOrNo = secondLine[2] == "drunk";
            CustomThreeuple<string, int, bool> beerInfo = new(nameWithBeer, litersOfBeer, drunkOrNo);

            string[] thirdLine = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string name = thirdLine[0];
            double bankBalance = double.Parse(thirdLine[1]);
            string bankName = thirdLine[2];
            CustomThreeuple<string, double, string> bankAccount = new(name, bankBalance, bankName);

            Console.WriteLine(addressInfo);
            Console.WriteLine(beerInfo);
            Console.WriteLine(bankAccount);
        }
    }
}
