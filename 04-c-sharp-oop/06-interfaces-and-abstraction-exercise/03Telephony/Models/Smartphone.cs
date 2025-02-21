using System;
using System.Linq;
using Telephony.Models.Interfaces;
namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string number)
        {
            if (!number.All(ch => char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (!url.All(ch => !char.IsDigit(ch)))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }
    }
}
