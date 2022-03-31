using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Test.Models.Excepciones
{
    public class ApiErrors
    {
        
        public string ErrorMessage { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorType { get; set; }
        public HttpStatusCode HttpCode { get; set; }
        
    }
}
