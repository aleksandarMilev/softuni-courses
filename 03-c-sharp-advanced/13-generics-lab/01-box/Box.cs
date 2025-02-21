namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> items;


        public Box()
        {
            items = new();
        }


        public int Count
        {
            get
            {
                return items.Count;
            }
        }


        public void Add(T element)
        {
            items.Add(element);
        }

        public T Remove()
        {
            T topmostElement = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);

            return topmostElement;
        }
    }
}
