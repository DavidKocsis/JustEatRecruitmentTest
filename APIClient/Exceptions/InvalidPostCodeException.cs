using System;

namespace APIClient.Exceptions
{
    public class InvalidPostCodeException : Exception
    {
        public InvalidPostCodeException (string message) : base(message)
        {}
    }
}
