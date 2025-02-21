using System;
namespace _04TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int judgesCount = int.Parse(Console.ReadLine());
            int presentationsCount = 0;
            double allPresentationsGrade = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Finish")
                {
                    Console.WriteLine($"Student's final assessment is {allPresentationsGrade / (double)presentationsCount:f2}.");
                    break;
                }
                presentationsCount++;
                string presentationName = command;
                double currentPresentationGrade = 0;
                for (int i = 0; i < judgesCount; i++)
                {
                    currentPresentationGrade += double.Parse(Console.ReadLine());
                }
                double currentPresentationAverageGrade = currentPresentationGrade / judgesCount;
                Console.WriteLine($"{presentationName} - {currentPresentationAverageGrade:f2}.");
                allPresentationsGrade += currentPresentationAverageGrade;
            }
        }
    }
}