using System;
namespace _04._Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());
            int twoToThree = 0; int threeToFour = 0; int fourToFive = 0; int fiveOrMore = 0;
            double gradeAmount = 0;

            for (int i = 1; i <= students; i++)
            {
                double grade = double.Parse(Console.ReadLine());
                if (grade >= 2 && grade <= 2.99)
                {
                    twoToThree++;
                    gradeAmount += grade;
                }
                else if (grade >= 3 && grade <= 3.99)
                {
                    threeToFour++;
                    gradeAmount += grade;
                }
                else if (grade >= 4 && grade <= 4.99)
                {
                    fourToFive++;
                    gradeAmount += grade;
                }
                else if (grade >= 5)
                {
                    fiveOrMore++;
                    gradeAmount += grade;
                }
            }
            double twoToThreeP = (double)twoToThree / students * 100;
            double threeToFourP = (double)threeToFour / students * 100;
            double fourToFiveP = (double)fourToFive / students * 100;
            double fiveOrMoreP = (double)fiveOrMore / students * 100;
            double averageGrade = gradeAmount / students;
            Console.WriteLine($"Top students: {fiveOrMoreP:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {fourToFiveP:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {threeToFourP:f2}%");
            Console.WriteLine($"Fail: {twoToThreeP:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}