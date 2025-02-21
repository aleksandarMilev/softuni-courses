namespace _01WorldTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] arguments = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                switch (action)
                {
                    case "Add Stop":
                        int indexAdd = int.Parse(arguments[1]);
                        string strAdd = arguments[2];

                        if (ValidIndex(indexAdd, text))
                        {
                            text = text.Insert(indexAdd, strAdd);
                        }

                        Console.WriteLine(text);
                        break;
                    case "Remove Stop":
                        int indexStart = int.Parse(arguments[1]);
                        int indexEnd = int.Parse(arguments[2]);

                        if (ValidIndex(indexStart, text) &&
                            ValidIndex(indexEnd, text))
                        {
                            text = text.Remove(indexStart, indexEnd - indexStart + 1);
                        }

                        Console.WriteLine(text);
                        break;
                    case "Switch":
                        string oldStr = arguments[1];
                        string newStr = arguments[2];

                        if (text.Contains(oldStr))
                        {
                            text = text.Replace(oldStr, newStr);
                        }

                        Console.WriteLine(text);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {text}");
        }

        static bool ValidIndex(int index, string text)
        {
            return index >= 0 && index < text.Length;
        }
    }
}