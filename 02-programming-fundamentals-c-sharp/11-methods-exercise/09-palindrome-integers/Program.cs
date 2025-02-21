using System;
namespace _09PalindromeIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            while (text != "End")
            {
                if (text == "END")
                {
                    break;
                }

                if (!IsPalindrome(text))
                {
                    Console.WriteLine("false");
                }
                else
                {
                    Console.WriteLine("true");
                }
                text = Console.ReadLine();
            }
        }
    
        static bool IsPalindrome(string text)
        {
            string reverseText = string.Empty;
        
            for (int i = text.Length - 1; i >= 0; i--)
            {
                reverseText += text[i];
            }

            if (text != reverseText)
            {
                return false;
            }
            return true;
        }
    }
}

