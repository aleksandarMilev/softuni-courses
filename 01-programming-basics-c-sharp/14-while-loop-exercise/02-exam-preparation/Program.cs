using System;
namespace _02ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalCountAllowedBadGrades = int.Parse(Console.ReadLine());
            int currentCountAllowedBadGrades = 0;
            int currentExerciseCount = 0;
            double gradeSum = 0;
            string lastExerciseName = "";
            while (true)
            {
                string exerciseName = Console.ReadLine();
                if (exerciseName == "Enough")
                {
                    Console.WriteLine($"Average score: {gradeSum / currentExerciseCount:f2}");
                    Console.WriteLine($"Number of problems: {currentExerciseCount}");
                    Console.WriteLine($"Last problem: {lastExerciseName}");
                    break;
                }
                lastExerciseName = exerciseName;
                currentExerciseCount++;
                int grade = int.Parse(Console.ReadLine());
                gradeSum += grade;
                if (grade <= 4)
                {
                    currentCountAllowedBadGrades++;
                }
                if (totalCountAllowedBadGrades == currentCountAllowedBadGrades)
                {
                    Console.WriteLine($"You need a break, {currentCountAllowedBadGrades} poor grades.");
                    break;
                }
            }
        }
    }
}