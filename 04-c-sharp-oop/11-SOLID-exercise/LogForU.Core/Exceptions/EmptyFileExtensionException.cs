using System;
namespace LogForU.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string DefaultMessage = "File extension cannot be empty or white space!";

        public EmptyFileExtensionException()
            : base(DefaultMessage)
        {
        }

        public EmptyFileExtensionException(string message)
            : base(message)
        {
        }
    }
}
