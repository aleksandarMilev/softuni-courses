using System;
namespace _03DeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> cards = Console.ReadLine()
                .Split(", ")
                .ToList();

            int commands = int.Parse(Console.ReadLine());
            for (int i = 0; i < commands; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ");
                string action = arguments[0];
                switch (action)
                {
                    case "Add":
                        string cardAdd = arguments[1];
                        if (!cards.Contains(cardAdd))
                        {
                            cards.Add(cardAdd);
                            Console.WriteLine("Card successfully added");
                        }
                        else
                        {
                            Console.WriteLine("Card is already in the deck");
                        }
                        break;
                    case "Remove":
                        string cardRemove = arguments[1];
                        if (cards.Contains(cardRemove))
                        {
                            cards.Remove(cardRemove);
                            Console.WriteLine("Card successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("Card not found");
                        }
                        break;
                    case "Remove At":
                        int indexRemove = int.Parse(arguments[1]);
                        if (IsIndexValid(cards, indexRemove))
                        {
                            cards.RemoveAt(indexRemove);
                            Console.WriteLine("Card successfully removed");
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }
                        break;
                    case "Insert":
                        int insertIndex = int.Parse(arguments[1]);
                        string cardInsert = arguments[2];

                        if (IsIndexValid(cards, insertIndex))
                        {
                            if (!cards.Contains(cardInsert))
                            {
                                cards.Insert(insertIndex, cardInsert);
                                Console.WriteLine("Card successfully added");
                            }
                            else
                            {
                                Console.WriteLine("Card is already added");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Index out of range");
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(", ", cards));
        }
        static bool IsIndexValid(List<string> cards, int index)
        {
            return index >= 0 && index < cards.Count;
        }
    }
}