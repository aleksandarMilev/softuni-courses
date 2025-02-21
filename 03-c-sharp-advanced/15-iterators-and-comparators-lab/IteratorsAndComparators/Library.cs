using System.Collections;
namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> _books;

        public Library(params Book[] books)
        {
            _books = books
                .OrderBy(t => t.Title)
                .ThenByDescending(y => y.Year)
                .ToList();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book book in _books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

