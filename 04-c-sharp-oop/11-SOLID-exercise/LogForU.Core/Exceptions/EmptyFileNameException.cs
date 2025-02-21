using System;
namespace LogForU.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string DefaultMessage = "File name cannot be empty or white space!";

        public EmptyFileNameException()
            : base(DefaultMessage)
        {
        }

        public EmptyFileNameException(string message)
            : base(message)
        {
        }
    }
}
