using System;
using System.Collections.Generic;
using Cards.Models;
namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            List<Card> cards = new(); 

            string[] cardsInput = Console.ReadLine().Split(", ");
            foreach (string item in cardsInput)
            {
                string[] currCard = item.Split(" ");

                string face = currCard[0];
                string suit = currCard[1];

                try
                {
                    Card card = new(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}
