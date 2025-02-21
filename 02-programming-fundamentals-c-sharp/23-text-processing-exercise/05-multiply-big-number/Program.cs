using System;
namespace _05MultiplyBigNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            if (bigNumber == "0" || multiplier == 0)
            {
                Console.WriteLine(0);
                return;
            }

            char[] productAsCharArr = new char[bigNumber.Length + 1];
            int carry = 0;

            for (int i = bigNumber.Length - 1; i >= 0; i--)
            {
                int currentDigit = int.Parse(bigNumber[i].ToString());
                int currentNumbersProduct = currentDigit * multiplier + carry;

                productAsCharArr[i + 1] = (char)((currentNumbersProduct % 10) + '0');
                carry = currentNumbersProduct / 10;
            }

            if (carry > 0)
            {
                productAsCharArr[0] = (char)(carry + '0');
            }

            string product = new string(productAsCharArr).TrimStart('\0');
            Console.WriteLine(product);
        }
    }
}