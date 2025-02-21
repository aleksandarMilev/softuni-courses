using System;
using System.Linq;
using System.Reflection;
namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methodsInfo = type.GetMethods((BindingFlags)60);

            foreach (MethodInfo methodInfo in methodsInfo)
            {
                AuthorAttribute[] authorAttributes = methodInfo.GetCustomAttributes<AuthorAttribute>().ToArray();

                foreach (AuthorAttribute authorAttribute in authorAttributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {authorAttribute.Name}");
                }
            }
        }
    }
}