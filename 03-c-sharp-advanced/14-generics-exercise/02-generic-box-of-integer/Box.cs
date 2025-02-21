using System.Text;
namespace _02GenericBoxOfInteger
{
    public class Box<T>
    {
        private List<T> _items = new();


        public void Add(T element)
        {
            _items.Add(element);
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
