using System.Net;
using Test.Models.Excepciones;

namespace Test.API.Modelos
{
    public class ErroresGenericos
    {

        #region Generic Errors

        public static readonly ApiErrors NullRequestError = new ApiErrors() { ErrorCode = 6001, ErrorMessage = "Null Request", ErrorType = Constants.GENERIC_ERROR_TYPE, HttpCode = HttpStatusCode.BadRequest };
        public static readonly ApiErrors InternalServerError = new ApiErrors() { ErrorCode = 6002, ErrorMessage = "", ErrorType = Constants.SYSTEM_ERROR_TYPE, HttpCode = HttpStatusCode.InternalServerError };
        public static readonly ApiErrors NotFoundError = new ApiErrors() { ErrorCode = 6003, ErrorMessage = "Not Found", ErrorType = Constants.GENERIC_ERROR_TYPE, HttpCode = HttpStatusCode.BadRequest };
        public static readonly ApiErrors Generic = new ApiErrors() { ErrorCode = 6004, ErrorMessage = "Invalid Login Format", ErrorType = Constants.GENERIC_ERROR_TYPE, HttpCode = HttpStatusCode.InternalServerError };

        #endregion Generic Errors
    }
}
