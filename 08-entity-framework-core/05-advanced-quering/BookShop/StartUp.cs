namespace BookShop
{
    using Data;
    using System.Text;
    using BookShop.Models;
    using System.Globalization;
    using BookShop.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static async Task Main()
        {
            using BookShopContext context = new();

            //1
            //string command = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetBooksByAgeRestriction(context, command!));

            //2
            //await Console.Out.WriteLineAsync(await GetGoldenBooks(context));

            //3
            //await Console.Out.WriteLineAsync(await GetBooksByPrice(context));

            //4
            //int year = int.Parse(Console.ReadLine()!);
            //await Console.Out.WriteLineAsync(await GetBooksNotReleasedIn(context, year));

            //5
            //string categoriesList = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetBooksByCategory(context, categoriesList));

            //6
            //string date = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetBooksReleasedBefore(context, date));

            //7
            //string nameEndsWithChar = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetAuthorNamesEndingIn(context, nameEndsWithChar));

            //8
            //string bookTitleContainsStr = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetBookTitlesContaining(context, bookTitleContainsStr));

            //9
            //string authorLastNameStartsWithChar = Console.ReadLine()!;
            //await Console.Out.WriteLineAsync(await GetBooksByAuthor(context, authorLastNameStartsWithChar));

            //10
            //int titleLength = int.Parse(Console.ReadLine()!);
            //int result = await CountBooks(context, titleLength);
            //await Console.Out.WriteLineAsync(result.ToString());

            //11
            //await Console.Out.WriteLineAsync(await CountCopiesByAuthor(context));

            //12
            //await Console.Out.WriteLineAsync(await GetTotalProfitByCategory(context));

            //13
            //await Console.Out.WriteLineAsync(await GetMostRecentBooks(context));

            //14
            //await IncreasePrices(context);

            //15
            //int result = await RemoveBooks(context);
            //await Console.Out.WriteLineAsync(result.ToString());
        }

        //1
        public static async Task<string> GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (Enum.TryParse(command, true, out AgeRestriction ageRestrParam))
            {
                string[] titles = await context.Books
                    .AsNoTracking()
                    .Where(b => b.AgeRestriction == ageRestrParam)
                    .OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToArrayAsync();

                StringBuilder builder = new();

                foreach (string t in titles)
                {
                    builder.AppendLine(t);
                }

                return builder
                    .ToString()
                    .Trim();
            }

            return "Invalid age restriction parameter!";
        }

        //2
        public static async Task<string> GetGoldenBooks(BookShopContext context)
        {
            string[] titles = await context.Books
                    .AsNoTracking()
                    .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5_000)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArrayAsync();

            StringBuilder builder = new();

            foreach (string t in titles)
            {
                builder.AppendLine(t);
            }

            return builder
                .ToString()
                .Trim();
        }

        //3
        public static async Task<string> GetBooksByPrice(BookShopContext context)
        {
            var books = await context.Books
                    .AsNoTracking()
                    .Where(b => b.Price > 40)
                    .OrderByDescending(b => b.Price)
                    .Select(b => new 
                    {
                        b.Title,
                        b.Price
                    })
                    .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var b in books)
            {
                builder.AppendLine($"{b.Title} - {b.Price.ToString("C2")}");
            }

            return builder
                .ToString()
                .Trim();
        }

        //4
        public static async Task<string> GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] titles = await context.Books
                    .AsNoTracking()
                    .Where(b => 
                        b.ReleaseDate != null && 
                        b.ReleaseDate.Value.Year != year)
                    .OrderBy(b => b.BookId)
                    .Select(b => b.Title)
                    .ToArrayAsync();

            StringBuilder builder = new();

            foreach (string t in titles)
            {
                builder.AppendLine(t);
            }

            return builder
                .ToString()
                .Trim();
        }

        //5
        public static async Task<string> GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categoriesList = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] titles = await context.Books
                .AsNoTracking()
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .Where(c => c.BookCategories
                    .Any(bc => categoriesList
                        .Contains(bc.Category.Name.ToLower())))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (string t in titles)
            {
                builder.AppendLine(t);
            }

            return builder
                .ToString()
                .Trim();
        }

        //6
        public static async Task<string> GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var books = await context.Books
                .AsNoTracking()
                .Where(b => b.ReleaseDate < DateTime.ParseExact(
                                                                date,
                                                                "dd-MM-yyyy",
                                                                CultureInfo.InvariantCulture))
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new 
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                })
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var b in books)
            {
                builder.AppendLine($"{b.Title} - {b.EditionType} - {b.Price.ToString("c2")}");
            }

            return builder
                .ToString()
                .Trim();
        }

        //7
        public static async Task<string> GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            string[] names = await context.Authors
                .AsNoTracking()
                .Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .Select(a => a.FirstName + " " + a.LastName)
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (string n in names)
            {
                builder.AppendLine(n);
            }

            return builder
                .ToString()
                .Trim();
        }

        //8
        public static async Task<string> GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] titles = await context.Books
                .AsNoTracking()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (string t in titles)
            {
                builder.AppendLine(t);
            }

            return builder
                .ToString()
                .Trim();
        }

        //9
        public static async Task<string> GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = await context.Books
                .AsNoTracking()
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new 
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                })
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var b in books)
            {
                builder.AppendLine($"{b.Title} ({b.AuthorName})");
            }

            return builder
                .ToString()
                .Trim();
        }

        //10
        public static async Task<int> CountBooks(BookShopContext context, int lengthCheck)
        {
            return await context.Books
                .AsNoTracking()
                .Where(b => b.Title.Length > lengthCheck)
                .CountAsync();
        }

        //11
        public static async Task<string> CountCopiesByAuthor(BookShopContext context)
        {
            var authors = await context.Authors
                .AsNoTracking()
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,
                    BooksCopies = a.Books.Sum(b => b.Copies)

                })
                .OrderByDescending(a => a.BooksCopies)
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var a in authors)
            {
                builder.AppendLine($"{a.AuthorName} - {a.BooksCopies}");
            }

            return builder
                .ToString()
                .Trim();
        }

        //12
        public static async Task<string> GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Include(c => c.CategoryBooks)
                    .ThenInclude(cb => cb.Book)
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks.Sum(bc => bc.Book.Copies * bc.Book.Price)
                })
                .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var c in categories)
            {
                builder.AppendLine($"{c.Name} - {c.TotalProfit.ToString("c2")}");
            }

            return builder
                .ToString()
                .Trim();
        }

        //13
        public static async Task<string> GetMostRecentBooks(BookShopContext context)
        {
            var categories = await context.Categories
                .AsNoTracking()
                .Include(b => b.CategoryBooks)
                    .ThenInclude(cb => cb.Book)
                .OrderBy(c => c.Name)
                .Select(c => new 
                {
                    c.Name,
                    Books = c.CategoryBooks
                        .Select(cb => new 
                        {
                            cb.Book.Title,
                            ReleaseYear = cb.Book.ReleaseDate!.Value.Year,
                        })
                        .OrderByDescending(b => b.ReleaseYear)
                        .Take(3)
                        .ToArray()
                })
                .ToArrayAsync();

            StringBuilder builder = new();

            foreach (var c in categories)
            {
                builder.AppendLine($"--{c.Name}");

                foreach (var b in c.Books)
                {
                    builder.AppendLine($"{b.Title} ({b.ReleaseYear})");
                }
            }

            return builder
                .ToString()
                .Trim();
        }

        //14
        public static async Task IncreasePrices(BookShopContext context)
        {
            Book[] books = await context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < 2_010)
                .ToArrayAsync();

            foreach (Book b in books)
            {
                b.Price += 5;
            }

            await context.SaveChangesAsync();
        }

        //15
        public static async Task<int> RemoveBooks(BookShopContext context)
        {
            var books = await context.Books
                .Where(b => b.Copies < 4_200)
                .ToArrayAsync();

            context.Books.RemoveRange(books);
            await context.SaveChangesAsync();

            return books.Length;
        }
    }
}