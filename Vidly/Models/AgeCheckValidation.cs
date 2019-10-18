using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class AgeCheckValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId.Equals(0) || customer.MembershipTypeId.Equals(1))
            {
                return ValidationResult.Success;
            }

            if (customer.Birthday != null && DateTime.Now.Year - customer.Birthday.Year < 18)
            {
                return new ValidationResult("You must be above 18");
            }
            return ValidationResult.Success;
        }
    }
}