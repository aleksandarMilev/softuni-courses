namespace _09CustomLinkedList
{
    public class CustomLinkedList<T>
    {
        private class Node
        {
            public Node(T value)
            {
                Value = value;
            }

            public Node Next { get; set; }

            public Node Previous { get; set; }

            public T Value { get; set; }
        }

        private Node head;
        private Node tail;

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            Node newHead = new(element);

            if (Count == 0)
            {
                head = tail = newHead;
            }
            else
            {
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }

            Count++;
        }

        public void AddLast(T element)
        {
            Node newTail = new(element);

            if (Count == 0)
            {
                tail = head = newTail;
            }
            else
            {
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }

            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedElement = head.Value;

            Node newHead = head.Next;

            if (Count == 1)
            {
                head = tail = null;
            }
            else
            {
                newHead.Previous = null;
                head = newHead;
            }

            Count--;

            return removedElement;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T removedElement = tail.Value;

            Node newTail = tail.Previous;

            if (Count == 1)
            {
                tail = head = null;
            }
            else
            {
                newTail.Next = null;
                tail = newTail;
            }

            Count--;

            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];

            var currentNode = head;

            for (int i = 0; i < Count; i++)
            {
                array[i] = currentNode.Value;
                currentNode = currentNode.Next;
            }

            return array;
        }
    }
}
