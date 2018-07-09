using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebBid.Models.Validators;
using Moq;
using WebBid.Models.Entities;
using System.Data.Entity;

namespace WebBid.Test.Models.Validators
{
    [TestClass]
    public class DecimalRangeValidatorTest
    {
        [TestMethod]
        public void pass_for_matching_scales()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(123.12);

            Assert.IsTrue(result);   
        }

        [TestMethod]
        public void fail_for_negative_value()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(-123.12);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void fail_for_value_over_scale()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(123.123);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void pass_for_value_above_scale()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(123.1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void fail_for_value_over_max()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(1234.12);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void fail_for_value_above_mim()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(0.99);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void pass_for_value_without_fraction()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid(123);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void fail_for_non_number()
        {
            var validator = new DecimalRangeValidator(1.0, 1000.0, 2);
            var result = validator.IsValid("qwerty");

            Assert.IsFalse(result);
        }

    }
}
