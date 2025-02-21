using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }
        public string Size { get; private set; } //TODO : Validate
        public double Price
        {
            get => price;
            private set
            {
                switch (Size)
                {
                    case "Small":
                        price = (1.0 / 3.0) * value;
                        break;
                    case "Middle":
                        price = (2.0 / 3.0) * value;
                        break;
                    case "Large":
                        price = value;
                        break;
                    default:
                        break;
                }
            }
        }

        public override string ToString()
            => $"{Name} ({Size}) - {Price:f2} lv";
    }
}
