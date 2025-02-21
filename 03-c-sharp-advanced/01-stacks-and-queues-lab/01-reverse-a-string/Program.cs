namespace _01ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> stack = new();

            foreach (char c in input)
            {
                stack.Push(c);
            }

            while (stack.Any())
            {
                char lastChar = stack.Pop();
                Console.Write(lastChar);
            }
        }
    }
}