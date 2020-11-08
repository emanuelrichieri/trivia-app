using System;
namespace TdP2019TPFinalRichieri.Exceptions
{
    public class InvalidParametersException : Exception
    {
        public InvalidParametersException()
        {
        }

        public InvalidParametersException(string pMessage) : base(pMessage) {}
    }
}
