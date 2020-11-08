using System;
using System.Collections.Generic;

namespace TdP2019TPFinalRichieri.DTO
{
    public class ResponseDTO : ResponseDTO<object>
    {

    }

    public class ResponseDTO<TDTO> where TDTO : class
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ResponseCode Code { get; set; }
        public TDTO Data { get; set; }

        /// <summary>
        /// ResponseDTO with success = true, ResponseCode = Ok and a given message with no Data object.
        /// </summary>
        /// <see cref="ResponseCode"/>
        /// <param name="pMessage">Response message.</param>
        public static ResponseDTO<TDTO> Ok(string pMessage)
        {
            return Ok(pMessage, null);
        }

        /// <summary>
        /// ResponseDTO with success = true, ResponseCode = Ok, a given message
        /// and a given object in Data property.
        /// </summary>
        /// <see cref="ResponseCode"/>
        /// <param name="pData">Data property.</param>
        /// <param name="pMessage">Response message</param>
        public static ResponseDTO<TDTO> Ok(string pMessage, TDTO pData)
        {
            return Build(true, pMessage, pData, ResponseCode.Ok);
        }

        /// <summary>
        /// ResponseDTO with success = true, ResponseCode = Ok and a given object in Data property.
        /// </summary>
        /// <see cref="ResponseCode"/>
        /// <param name="pData">Data property.</param>
        public static ResponseDTO<TDTO> Ok(TDTO pData)
        {
            return Build(true, "OK", pData, ResponseCode.Ok);
        }

        /// <summary>
        /// Error ResponseDTO with BadRequest code and a given message.
        /// </summary>
        /// <see cref="ResponseCode"/>
        public static ResponseDTO<TDTO> BadRequest(string pMessage)
        {
            return Error(pMessage, ResponseCode.BadRequest);
        }

        /// <summary>
        /// Error ResponseDTO with Unauthorized code and a given message.
        /// </summary>
        /// <see cref="ResponseCode"/>
        public static ResponseDTO<TDTO> Unauthorized(string pMessage)
        {
            return Error(pMessage, ResponseCode.Unauthorized);
        }

        /// <summary>
        /// Error ResponseDTO with InternalError code and a given message.
        /// </summary>
        /// <see cref="ResponseCode"/>
        public static ResponseDTO<TDTO> InternalError(string pMessage)
        {
            return Error(pMessage, ResponseCode.InternalError);
        }

        /// <summary>
        /// Error ResponseDTO with NotFound code and a given message.
        /// <see cref="ResponseCode"/>
        /// </summary>
        public static ResponseDTO<TDTO> NotFound(string pMessage)
        {
            return Error(pMessage, ResponseCode.NotFound);
        }


        /// <summary>
        /// Error ResponseDTO with NoContent code and a given message.
        /// <see cref="ResponseCode"/>
        /// </summary>
        public static ResponseDTO<TDTO> NoContent(string pMessage)
        {
            return Error(pMessage, ResponseCode.NoContent);
        }

        /// <summary>
        /// Default error ResponseDTO with success = false and a given ResponseCode.
        /// <see cref="ResponseCode"/>
        /// </summary>
        public static ResponseDTO<TDTO> Error (string pMessage, ResponseCode pCode)
        {
            return Build(false, pMessage, null, pCode);
        }

        public static ResponseDTO<TDTO> Build(bool pSuccess, string pMessage, TDTO pData, ResponseCode pCode)
        {
            return new ResponseDTO<TDTO>
            {
                Success = pSuccess,
                Message = pMessage,
                Data = pData,
                Code = pCode
            };
        }
    }

    /// <summary>
    /// Response codes based on Http Status codes.
    /// </summary>
    public enum ResponseCode
    {
        Ok = 200,
        NoContent = 204,
        BadRequest = 400,
        NotFound = 404,
        Unauthorized = 401,
        InternalError = 500
    }
}
