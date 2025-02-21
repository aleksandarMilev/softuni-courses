using System;
namespace LogForU.Core.Exceptions
{
    public class EmptyCreatedDateTimeException : Exception
    {
        private const string DefaultMessage = "The date-time cannot be empty or white space!";

        public EmptyCreatedDateTimeException()
            : base(DefaultMessage)
        {
        }

        public EmptyCreatedDateTimeException(string message)
            : base(message)
        {
        }
    }
}
