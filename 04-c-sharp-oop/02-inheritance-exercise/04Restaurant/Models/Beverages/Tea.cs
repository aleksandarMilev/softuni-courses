﻿namespace Restaurant.Models.Beverages
{
    public sealed class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliliters)
            : base(name, price, milliliters)
        {
        }
    }
}
