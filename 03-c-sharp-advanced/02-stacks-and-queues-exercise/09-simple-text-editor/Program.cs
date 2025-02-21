namespace _09SimpleTextEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> operations = new();
            operations.Push(string.Empty);
            string result = string.Empty;

            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = command[0];
                switch (action)
                {
                    case "1":
                        string appendWord = command[1];
                        result += appendWord;
                        operations.Push(result);
                        break;
                    case "2":
                        int eraseCount = int.Parse(command[1]);
                        result = result.Remove(result.Length - eraseCount);
                        operations.Push(result);
                        break;
                    case "3":
                        int position = int.Parse(command[1]);
                        int index = position - 1;
                        if (index >= 0 && index <= result.Length - 1)
                        {
                            Console.WriteLine(result[index]);
                        }
                        break;
                    case "4":
                        operations.Pop();
                        result = operations.Peek();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}