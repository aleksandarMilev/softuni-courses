using System;
namespace LogForU.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string DefaultMessage = "Invalid file path!";

        public InvalidPathException()
            : base(DefaultMessage)
        {
        }

        public InvalidPathException(string message)
            : base(message)
        {
        }
    }
}
