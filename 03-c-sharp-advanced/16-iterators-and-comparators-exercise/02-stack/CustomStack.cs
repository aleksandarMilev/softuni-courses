using System.Collections;
namespace _03Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int _InitialLength = 2;
        private T[] _elements = new T[_InitialLength];


        public int Count { get; private set; }


        public void Push(T element)
        {
            if (_elements.Length == Count)
            {
                Resize();
            }

            _elements[Count] = element;
            Count++;
        }
        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            Count--;
            return _elements[Count];
        }
        private void Resize()
        {
            T[] newArr = new T[_elements.Length * 2];
            for (int i = 0; i < _elements.Length; i++)
            {
                newArr[i] = _elements[i];
            }

            _elements = newArr;
        }


        public IEnumerator<T> GetEnumerator()

        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return _elements[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
