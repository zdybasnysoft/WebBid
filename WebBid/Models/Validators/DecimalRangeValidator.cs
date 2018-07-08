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
    public class DecimalRangeValidator : RangeAttribute
    {
        private new const string ErrorMessage = "The field Amount of chips must be between 1 and 1000000.";
        private string pattern;

        public DecimalRangeValidator(double minimum, double maximum, int scale)
            : base(minimum, maximum)
        {
            ;
            var patternBeforeSeparator = @"^-?\d*";
            var patternAfterSeparator = @"([.,]\d{0," + scale + @"})?$";

            this.pattern = patternBeforeSeparator + patternAfterSeparator;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var regexAttr = new RegularExpressionAttribute(this.pattern);
            var regexResult = regexAttr.IsValid(value);
            var rangeResult = base.IsValid(value);

            return (regexResult && rangeResult) ?
                ValidationResult.Success :
                new ValidationResult(ErrorMessage);

        }
    }
}