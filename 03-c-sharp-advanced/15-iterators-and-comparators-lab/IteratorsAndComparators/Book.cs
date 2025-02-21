namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        private class BookComparer : IComparer<Book>
        {
            public int Compare(Book x, Book y)
            {
                if (x.Title.CompareTo(y.Title) != 0)
                {
                    return x.Title.CompareTo(y.Title);
                }

                return x.Year.CompareTo(y.Year);
            }
        }


        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors.ToList();
        }
        

        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }


        public int CompareTo(Book other)
        {
            if (Year.CompareTo(other.Year) != 0)
            {
                return Year.CompareTo(other.Year);
            }

            return Title.CompareTo(other.Title);
        }
        public override string ToString()
        {
            return $"{Title} {Year}";
        }
    }
}
