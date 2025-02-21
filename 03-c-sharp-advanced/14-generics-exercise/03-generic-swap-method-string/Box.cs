using System.Text;
namespace _03GenericSwapMethodString
{
    public class Box<T>
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
