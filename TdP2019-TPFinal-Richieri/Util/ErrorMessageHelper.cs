using System;
namespace TdP2019TPFinalRichieri.Util
{
    public static class ErrorMessageHelper
    {
        /// <summary>
        /// Gets generic message to response the user when an 
        /// unexpected error ocurred during an operation.
        /// </summary>
        /// <returns>The user message.</returns>
        /// <param name="pOperation">Operation that caused the error.</param>
        public static string FailedOperation(string pOperation) 
        {
            return $"Sorry. An unexpected error ocurred when {pOperation} . " + 
                   "Please try again later or contact your administrator.";
        }
    }
}
