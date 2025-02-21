using System;
namespace LogForU.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string DefaultMessage = "The message text cannot be empty or white space!";

        public EmptyMessageTextException()
            : base(DefaultMessage)
        {
        }

        public EmptyMessageTextException(string message)
            : base(message)
        {
        }
    }
}
