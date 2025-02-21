using System;
namespace _05HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            List<string> commentsList = new List<string>();

            string commentInput;
            while ((commentInput = Console.ReadLine()) != "end of comments")
            {
                commentsList.Add(commentInput);
            }

            Console.WriteLine("<h1>");
            Console.WriteLine($"{title}");
            Console.WriteLine("</h1>");

            Console.WriteLine("<article>");
            Console.WriteLine($"{content}");
            Console.WriteLine("</article>");

            foreach (string comment in commentsList)
            {
                Console.WriteLine("<div>");
                Console.WriteLine($"{comment}");
                Console.WriteLine("</div>");
            }
        }
    }
}