using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Source_Control_Final_Assignment.Models
{
    public class CharacterValidation : ValidationAttribute
    {
        private readonly string _chars;
        public CharacterValidation(string chars) : base("{0} contains invalid character")
        {
            _chars = chars;
        }
        protected override ValidationResult IsValid(Object value, ValidationContext validationcontext)
        {
            if (value != null)
            {
                for (int i = 0; i < _chars.Length; i++)
                {
                    var valueAsString = value.ToString();
                    if (valueAsString.Contains(_chars[i]))
                    {
                        var errorMessage = FormatErrorMessage(validationcontext.DisplayName);
                        return new ValidationResult(errorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}