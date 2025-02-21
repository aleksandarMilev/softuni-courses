using System.Text;
namespace _05GenericCountMethodString
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> _items = new();


        public void Add(T element)
        {
            _items.Add(element);
        }


        public void Swap(int index1, int index2)
        {
            T temp = _items[index1];
            _items[index1] = _items[index2];
            _items[index2] = temp;
        }
        public int ElementsGreaterThanAnElement(T element)
        {
            int counter = 0;
            foreach (var item in _items)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }
            return counter;
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            foreach (T item in _items)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }
    }
}
