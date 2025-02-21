using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;
namespace CollectionHierarchy.Models
{
    public class MyListCollection : IMyListCollection
    {
        private const int AddIndex = 0;
        private const int RemoveIndex = 0;

        private readonly List<string> collection;

        public MyListCollection()
        {
            collection = new();
        }


        public int Used
            => collection.Count;

        public int Add(string item)
        {
            collection.Insert(AddIndex, item);
            return AddIndex;
        }

        public string Remove()
        {
            string item = collection[RemoveIndex];
            collection.RemoveAt(RemoveIndex);

            return item;
        }
    }
}
