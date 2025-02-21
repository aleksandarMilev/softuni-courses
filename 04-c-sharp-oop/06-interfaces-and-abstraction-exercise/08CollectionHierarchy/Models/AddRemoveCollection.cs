using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;
namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private const int AddIndex = 0;

        private readonly List<string> collection;

        public AddRemoveCollection()
        {
            collection = new();
        }

        public int Add(string item)
        {
            collection.Insert(AddIndex, item);
            return AddIndex;
        }
        public string Remove()
        {
            string element = null;
            if (collection.Count > 0)
            {
                element = collection[collection.Count - 1];
                collection.RemoveAt(collection.Count - 1);
            }

            return element;
        }
    }
}
