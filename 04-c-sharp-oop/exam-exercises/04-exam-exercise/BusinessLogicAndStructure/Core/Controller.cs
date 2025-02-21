using System;
using System.Collections.Generic;
using System.Linq;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = booths.Models.Count() + 1;

            IBooth booth = new Booth(boothId, capacity);

            booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, booth.BoothId, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth is null)
            {
                throw new ArgumentNullException($"Booth with ID: {boothId} does not exist!");
            }

            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);

            }

            IDelicacy delicacy = CreateDelicacy(delicacyTypeName, delicacyName);

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth is null)
            {
                throw new ArgumentNullException($"Booth with ID: {boothId} does not exist!");
            }

            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            ICocktail cocktail = CreateCocktail(cocktailTypeName, cocktailName, size);

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string ReserveBooth(int countOfPeople)
        {
            if (!booths.Models.Any())
            {
                throw new InvalidOperationException("Booth repository empty!");
            }

            IEnumerable<IBooth> boothsFilter = booths.
                Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId);

            if (!boothsFilter.Any())
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            Booth boothFound = boothsFilter.First() as Booth;
            boothFound.IsReserved = true;

            return string.Format(OutputMessages.BoothReservedSuccessfully, boothFound.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth is null)
            {
                throw new ArgumentNullException($"Booth with ID: {boothId} does not exist!");
            }

            string[] arguments = order.Split("/", StringSplitOptions.RemoveEmptyEntries);

            string itemTypeName = arguments[0];
            string itemName = arguments[1];
            int orderedPiecesCount = int.Parse(arguments[2]);

            IDelicacy delicacy = null;
            ICocktail cocktail = null;

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.DelicacyStillNotAdded, itemTypeName, itemName);
                }
                else
                {
                    double amount = delicacy.Price * orderedPiecesCount;
                    booth.UpdateCurrentBill(amount);

                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
                }
            }
            else if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                string cocktailSize = arguments[3];
                cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == cocktailSize);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, cocktailSize, itemName);
                }
                else
                {
                    double amount = cocktail.Price * orderedPiecesCount;
                    booth.UpdateCurrentBill(amount);

                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, orderedPiecesCount, itemName);
                }
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth is null)
            {
                throw new ArgumentNullException($"Booth with ID: {boothId} does not exist!");
            }

            booth.Charge();
            booth.ChangeStatus();

            string result = "";
            result += string.Format(OutputMessages.GetBill, $"{booth.Turnover:f2}");
            result += $"{Environment.NewLine}";
            result += string.Format(OutputMessages.BoothIsAvailable, boothId);

            return result;
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth is null)
            {
                throw new ArgumentNullException($"Booth with ID: {boothId} does not exist!");
            }

            return booth.ToString();
        }

        private static IDelicacy CreateDelicacy(string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy = null;

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
            }

            return delicacy;
        }
        private static ICocktail CreateCocktail(string cocktailTypeName, string cocktailName, string size)
        {
            ICocktail cocktail = null;

            switch (cocktailTypeName)
            {
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
            }

            return cocktail;
        }
    }
}
