namespace _01SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string messageInput = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Reveal")
            {
                string[] arguments = command.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string action = arguments[0];
                switch (action)
                {
                    case "InsertSpace":
                        int index = int.Parse(arguments[1]);

                        messageInput = messageInput.Insert(index, " ");
                        Console.WriteLine(messageInput);
                        break;
                    case "Reverse":
                        string partToReverse = arguments[1];

                        if (!messageInput.Contains(partToReverse))
                        {
                            Console.WriteLine("error");
                        }
                        else
                        {
                            string newPart = "";
                            for (int i = partToReverse.Length - 1; i >= 0; i--)
                            {
                                newPart += partToReverse[i];
                            }

                            messageInput = messageInput.Replace(partToReverse, newPart);
                            Console.WriteLine(messageInput);
                        }
                        break;
                    case "ChangeAll":
                        string oldText = arguments[1];
                        string newText = arguments[2];

                        messageInput = messageInput.Replace(oldText, newText);
                        Console.WriteLine(messageInput);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"You have a new messageInput message: {messageInput}");
        }
    }
}