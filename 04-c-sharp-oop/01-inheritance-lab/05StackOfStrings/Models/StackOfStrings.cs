using System.Collections.Generic;

namespace CustomStack.Models
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
            => Count == 0;

        public Stack<string> AddRange(IEnumerable<string> elements)
        {
            foreach (string element in elements)
            {
                Push(element);
            }

            return this;
        }
    }
}
