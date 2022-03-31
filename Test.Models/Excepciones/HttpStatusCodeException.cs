using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Models.Excepciones
{
    public class HttpStatusCodeException : Exception
    {
        public int StatusCode { get; set; }
        public string ContenType { get; set; }

        public HttpStatusCodeException(int statusCode)
        {
            StatusCode = statusCode;
        }
        public HttpStatusCodeException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
