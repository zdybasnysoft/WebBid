using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
using WebBid.Controllers;
using WebBid.Models.Entities;

namespace WebBid.Models.Validators
{
    public class DecimalRangeValidator : ValidationAttribute
    {
        private new const string ErrorMessage = "The field Amount of chips must be between 1 and 1000000.";
        private RangeAttribute rangeAttr;
        private RegularExpressionAttribute regexAttr;

        public DecimalRangeValidator(double minimum, double maximum, int scale)
        {
            rangeAttr = new RangeAttribute(minimum, maximum);

            var patternBeforeSeparator = @"^-?\d*";
            var patternAfterSeparator = @"([.,]\d{0," + scale + @"})?$";

            var pattern = patternBeforeSeparator + patternAfterSeparator;
            regexAttr = new RegularExpressionAttribute(pattern);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool regexResult = regexAttr.IsValid(value);
            var rangeResult = rangeAttr.IsValid(value);

            return (regexResult && rangeResult) ?
                ValidationResult.Success :
                new ValidationResult(ErrorMessage);
        }
    }
}