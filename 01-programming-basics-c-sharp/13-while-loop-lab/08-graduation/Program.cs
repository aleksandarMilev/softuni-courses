using System;
namespace _08Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currentClass = 1;
            int badGradesCount = 0;
            double gradesSum = 0;
            bool isRemoved = false;

            while (currentClass <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if (grade < 4)
                {
                    badGradesCount++;
                }
                else if (grade >= 4)
                {
                    currentClass++;
                    gradesSum += grade;
                }

                if (badGradesCount >= 2)
                {
                    isRemoved = true;
                    break;
                }
            }
            double averageGrade = gradesSum / 12;

            if (isRemoved)
            {
                Console.WriteLine($"{name} has been excluded at {currentClass} grade");
            }
            else
            {
                Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
            }
        }
    }
}