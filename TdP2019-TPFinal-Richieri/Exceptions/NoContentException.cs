using System;
namespace TdP2019TPFinalRichieri.Exceptions
{
    public class NoContentException : Exception
    {
        public NoContentException() { } 

        public NoContentException(string pMessage) : base(pMessage)
        {
        }
    }
}
