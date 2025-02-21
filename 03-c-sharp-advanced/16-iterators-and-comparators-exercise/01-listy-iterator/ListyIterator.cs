using System.Collections;
namespace _01ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> _elements;
        private int index = 0;

        public ListyIterator(List<T> elements)
        {
            _elements = elements;
        }


        public bool Move()
        {
            if (index < _elements.Count - 1)
            {
                index++;
                return true;
            }

            return false;
        }
        public void Print()
        {
            if (_elements.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(_elements[index]);
        }
        public bool HasNext()
        {
            return index < _elements.Count - 1;
        }
        public void PrintAll()
        {
            _elements.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in _elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
