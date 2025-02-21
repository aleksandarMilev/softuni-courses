using CollectionHierarchy.Models.Interfaces;
using System.Collections.Generic;
namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private readonly List<string> collection;

        public AddCollection()
        {
            collection = new();
        }

        public int Add(string item)
        {
            collection.Add(item);
            return collection.Count - 1;
        }
    }
}
