using System.Text.RegularExpressions;
namespace _02MessageTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\![A-Z][a-z]{2,}\!\:\[[A-Za-z]{8,}\]";
            int inputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputsCount; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string text = match.Value;
                    string[] commandAndMessage = text.Split(":");

                    string commandCrypted = commandAndMessage[0];
                    var commandVar = commandCrypted.Where(ch => char.IsLetter(ch));
                    string command = new string(commandVar.ToArray());

                    string messageCrypted = commandAndMessage[1];
                    var messageVar = messageCrypted.Where(ch => char.IsLetter(ch));
                    string message = new string(messageVar.ToArray());

                    string numbersCode = "";
                    for (int j = 0; j < message.Length; j++)
                    {
                        int currLetterAsASCII = message[j];
                        numbersCode += currLetterAsASCII + " ";
                    }

                    Console.WriteLine($"{command}: {numbersCode.TrimEnd()}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}