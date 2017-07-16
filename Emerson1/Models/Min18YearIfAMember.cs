using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Emerson1.Models
{
    public class Min18YearIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birthdate is required.");

            var spanYears = DateTime.Now.Year - customer.BirthDate.Value.Year;

            return spanYears >= 18 ? ValidationResult.Success : new ValidationResult("Customer must be 18 years of age.");

            //return base.IsValid(value, validationContext);
        }
    }
}