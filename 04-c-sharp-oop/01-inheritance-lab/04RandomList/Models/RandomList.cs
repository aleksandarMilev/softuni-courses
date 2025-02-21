using System;
using System.Collections.Generic;

namespace CustomRandomList.Models
{
    public class RandomList : List<string>
    {
        private Random random = new();

        public string RandomString()
        {
            int index = random.Next();
            string element = this[index];
            RemoveAt(index);

            return element;
        }
    }
}
