using System;
namespace _02Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");
            int n = int.Parse(Console.ReadLine());

            Article article = new Article(input[0], input[1], input[2]);

            for (int i = 0; i < n; i++)
            {
                string[] arguments = Console.ReadLine().Split(": ");
                switch (arguments[0])
                {
                    case "Edit":
                        string newContent = arguments[1];
                        article.EditContent(newContent);
                        break;
                    case "ChangeAuthor":
                        string newAuthor = arguments[1];
                        article.ChangeAuthor(newAuthor);
                        break;
                    case "Rename":
                        string newTitle = arguments[1];
                        article.RenameTitle(newTitle);
                        break;
                }
            }

            Console.WriteLine(article);
        }
    }

    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public void RenameTitle(string newTitle)
        {
            Title = newTitle;
        }

        public void EditContent(string newContent)
        {
            Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}