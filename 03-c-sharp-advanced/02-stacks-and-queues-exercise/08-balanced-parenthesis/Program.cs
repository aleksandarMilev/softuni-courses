namespace _08BalancedParenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> brackets = new();

            foreach (char character in input)
            {
                switch (character)
                {
                    case '(':
                    case '{':
                    case '[':
                        brackets.Push(character);
                        break;
                    case ')':
                        if (brackets.Count <= 0 || brackets.Pop() != '(')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case '}':
                        if (brackets.Count <= 0 || brackets.Pop() != '{')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    case ']':
                        if (brackets.Count <= 0 || brackets.Pop() != '[')
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }

            if (brackets.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}