using System;
using System.Linq;

namespace Cards.Models
{
    public class Card
    {
        private readonly string[] validFaces = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            private set
            {
                if (!validFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                face = value;
            }
        }
        public string Suit
        {
            get => suit;
            private set
            {
                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit = "\u2665";
                        break;
                    case "D":
                        suit = "\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                    default:
                        throw new ArgumentException("Invalid card!");
                }
            }
        }

        public override string ToString()
            => $"[{Face}{Suit}]";
    }
}
