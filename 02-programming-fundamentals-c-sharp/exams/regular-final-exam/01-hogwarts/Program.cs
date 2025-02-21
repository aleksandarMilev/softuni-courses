namespace _01Hogwarts
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()).ToLower() != "abracadabra")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0].ToLower();
                switch (action)
                {
                    case "abjuration":
                        text = text.ToUpper();
                        Console.WriteLine(text);
                        break;
                    case "necromancy":
                        text = text.ToLower();
                        Console.WriteLine(text);
                        break;
                    case "illusion":
                        int index = int.Parse(arguments[1]);
                        char letter = char.Parse(arguments[2]);

                        if (ValidIndex(index, text))
                        {
                            text = text.Remove(index, 1);
                            text = text.Substring(0, index) + letter + text.Substring(index);
                            Console.WriteLine("Done!");
                        }
                        else
                        {
                            Console.WriteLine("The spell was too weak.");
                        }
                        break;
                    case "divination":
                        string firstSubstr = arguments[1];
                        string secondSubstr = arguments[2];

                        if (text.Contains(firstSubstr))
                        {
                            text = text.Replace(firstSubstr, secondSubstr);
                            Console.WriteLine(text);
                        }
                        break;
                    case "alteration":
                        string strRemove = arguments[1];

                        if (text.Contains(strRemove))
                        {
                            text = text.Replace(strRemove, "");
                            Console.WriteLine(text);
                        }
                        break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;
                }
            }
        }

        static bool ValidIndex(int index, string text)
        {
            return index >= 0 && index < text.Length;
        }
    }
}