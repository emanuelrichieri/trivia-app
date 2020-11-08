using System;
namespace TdP2019TPFinalRichieri.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string pMessage) : base(pMessage) { }
    }
}
