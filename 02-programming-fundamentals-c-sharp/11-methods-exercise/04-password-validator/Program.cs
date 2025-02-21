using System;
namespace _04PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string passwordInput = Console.ReadLine();

            if (IsPasswordLengthCorrect(passwordInput)
                && ArePasswordCharactersCorrect(passwordInput)
                && ArePasswordDigitsAtLeastTwo(passwordInput))
            {
                Console.WriteLine("Password is valid");
            }
       
            if (!IsPasswordLengthCorrect(passwordInput))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!ArePasswordCharactersCorrect(passwordInput))
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!ArePasswordDigitsAtLeastTwo(passwordInput))
            {
                Console.WriteLine("Password must have at least 2 digits");
            }         
        }

        static bool IsPasswordLengthCorrect(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            return true;
        }

        static bool ArePasswordCharactersCorrect(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char currentCharacter = password[i];
                if (!char.IsLetterOrDigit(currentCharacter))
                {
                    return false;
                }
            }
            return true;
        }

        static bool ArePasswordDigitsAtLeastTwo(string password)
        {
            int digitsCount = 0;
            for (int i = 0; i < password.Length; i++)
            {
                char currentCharacter = password[i];
                if (char.IsDigit(currentCharacter))
                {
                    digitsCount++;
                }
            }

            if (digitsCount < 2)
            {
                return false;
            }

            return true;
        }
    }
}