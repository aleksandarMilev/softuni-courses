int index = int.Parse(Console.ReadLine());
for (int i = 0; i < index; i++)
{
    string numbersAsString = Console.ReadLine();
    string firstNumberAsString = string.Empty;
    string secondNumberAsString = string.Empty;
    bool isFirstNumberFound = false;
    for (int j = 0; j < numbersAsString.Length; j++)
    {
        char currentDigit = numbersAsString[j];
        if (isFirstNumberFound == false)
        {
            if (currentDigit == ' ')
            {
                isFirstNumberFound = true;
            }
            else
            {
                firstNumberAsString += numbersAsString[j];
            }
        }
        else
        {
            secondNumberAsString += currentDigit;
        }
    }
    long firstNumber = long.Parse(firstNumberAsString);
    long secondNumber = long.Parse(secondNumberAsString);
    long firstNumberDigitsSum = 0;
    long secondNumberDigitsSum = 0;
    if (firstNumber >= secondNumber)
    {
        while (firstNumber > 0)
        {
            long firstNumberCurrentDigit = firstNumber % 10;
            firstNumberDigitsSum += firstNumberCurrentDigit;
            firstNumber /= 10;
        }
        Console.WriteLine(firstNumberDigitsSum);
    }
    else
    {
        while (secondNumber > 0)
        {
            long secondNumberCurrentDigit = secondNumber % 10;
            secondNumberDigitsSum += secondNumberCurrentDigit;
            secondNumber /= 10;
        }
        Console.WriteLine(secondNumberDigitsSum);
    }
}
