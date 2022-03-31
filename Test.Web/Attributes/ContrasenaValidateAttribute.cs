using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;

namespace Test.Web.Attributes
{
    public class ContrasenaValidateAttribute : Attribute, IModelValidator//Acceder a la interfaz IModelValidator
    {
        public string ErrorMessage { get; set; }
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            return new List<ModelValidationResult>
            {
                new ModelValidationResult("", ErrorMessage)
            };
        }
    }
}
