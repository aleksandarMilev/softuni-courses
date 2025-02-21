using CollectionHierarchy.Core.Interfaces;
using CollectionHierarchy.Models.Interfaces;
using CollectionHierarchy.Models;
using System.Collections.Generic;
using System;
namespace CollectionHierarchy.Core
{
    public class Engine : IEngine
    {
        public void Run()
        {
            Dictionary<string, List<int>> addedIndexes = new()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() }
            };

            Dictionary<string, List<string>> removedItems = new()
            {
                { "AddCollection", new List<string>() },
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() }
            };

            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyListCollection myListCollection = new MyListCollection();

            string[] elements = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string element in elements)
            {
                addedIndexes["AddCollection"].Add(addCollection.Add(element));
                addedIndexes["AddRemoveCollection"].Add(addRemoveCollection.Add(element));
                addedIndexes["MyList"].Add(myListCollection.Add(element));
            }

            int removeCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < removeCount; i++)
            {
                removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
                removedItems["MyList"].Add(myListCollection.Remove());
            }

            Console.WriteLine(string.Join(" ", addedIndexes["AddCollection"]));
            Console.WriteLine(string.Join(" ", addedIndexes["AddRemoveCollection"]));
            Console.WriteLine(string.Join(" ", addedIndexes["MyList"]));

            Console.WriteLine(string.Join(" ", removedItems["AddRemoveCollection"]));
            Console.WriteLine(string.Join(" ", removedItems["MyList"]));
        }
    }
}
