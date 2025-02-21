using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;

            delicacyMenu = new DelicacyRepository();
            cocktailMenu = new CocktailRepository();
        }

        public int BoothId { get; private set; }
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }

                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu
            => delicacyMenu;

        public IRepository<ICocktail> CocktailMenu
            => cocktailMenu;

        public double CurrentBill { get; private set; }
        public double Turnover { get; private set; }
        public bool IsReserved { get; set; }

        public void UpdateCurrentBill(double amount)
            => CurrentBill += amount;

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void ChangeStatus()
            => IsReserved = !IsReserved;

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Booth: {BoothId}");
            result.AppendLine($"Capacity: {Capacity}");
            result.AppendLine($"Turnover: {Turnover:f2} lv");
            result.AppendLine("-Cocktail menu:");

            foreach (ICocktail cocktail in CocktailMenu.Models)
            {
                result.AppendLine($"--{cocktail}");
            }

            result.AppendLine("-Delicacy menu:");

            foreach (IDelicacy delicacy in DelicacyMenu.Models)
            {
                result.AppendLine($"--{delicacy}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
