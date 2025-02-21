using System;
namespace _01PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] arguments = command.Split();
                switch (arguments[0])
                {
                    case "TakeOdd":
                        string oddText = "";

                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                oddText = oddText += password[i];
                            }
                        }

                        password = oddText;
                        Console.WriteLine(password);
                        break;
                    case "Cut":
                        int cutIndex = int.Parse(arguments[1]);
                        int cutLength = int.Parse(arguments[2]);

                        password = password.Remove(cutIndex, cutLength);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string oldPart = arguments[1];
                        string newPart = arguments[2];

                        if (password.Contains(oldPart))
                        {
                            password = password.Replace(oldPart, newPart);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }
    }
}