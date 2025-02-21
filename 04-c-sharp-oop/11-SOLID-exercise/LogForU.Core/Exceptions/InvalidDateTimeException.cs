using System;
namespace LogForU.Core.Exceptions
{
    public class InvalidDateTimeException : Exception
    {
        private const string DefaultMessage = "Invalid date-time format!";

        public InvalidDateTimeException()
            : base(DefaultMessage)
        {
        }

        public InvalidDateTimeException(string message)
            : base(message)
        {
        }
    }
}
