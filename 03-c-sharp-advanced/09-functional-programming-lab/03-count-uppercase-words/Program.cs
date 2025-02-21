namespace _03CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isFirstLetterUpper = x => char.IsUpper(x[0]);
            string[] text = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isFirstLetterUpper(x))
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, text));
        }
    }
}