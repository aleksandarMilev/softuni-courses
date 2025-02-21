using System;
using System.Linq;
using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {number}";
        }
    }
}
