namespace _01ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = arr => Console.WriteLine(string.Join(Environment.NewLine, arr));

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(names);
        }
    }
}