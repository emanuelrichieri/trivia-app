using System;
namespace TdP2019TPFinalRichieri.Exceptions
{
    public class NotEnoughQuestionsException : Exception
    {
        public NotEnoughQuestionsException(string pMessage) : base(pMessage)
        {
        }
    }
}
