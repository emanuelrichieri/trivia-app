using System;
namespace TdP2019TPFinalRichieri.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string pMessage) : base(pMessage) {}
    }
}
