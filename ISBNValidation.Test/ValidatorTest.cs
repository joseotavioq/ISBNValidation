using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ISBNValidation.Test
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        public void Check_Rule1_Calculate_Valid_ISBN()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-306-40615-2");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Check_Rule1_Calculate_Invalid_ISBN()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-306-40615-1");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Check_Rule2_Checksum_With_X_Is_Valid()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("030-000-009-X");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Check_Rule2_Checksum_With_x_Is_Valid()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("030-000-009-x");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Check_Rule3_Can_Only_Be_Zero_Or_Three_Hyphen_Try_With_Two()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-30640615-2");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Check_Rule3_Can_Only_Be_Zero_Or_Three_Hyphen_Try_With_Zero()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0306406152");

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Check_Rule4_Hyphen_Cannot_Be_At_The_Start()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("-0306-40615-2");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Check_Rule4_Hyphen_Cannot_Be_At_The_End()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-306-406152-");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Check_Rule5_Hyphen_May_Not_Be_Consecutive()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0--30640615-2");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Isbn_Should_Have_Ten_Numbers_Try_With_More_Then_Ten()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-306-40615-20");

            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void Isbn_Should_Have_Ten_Numbers_Try_With_Less_Then_Ten()
        {
            var validator = new Validator();

            var result = validator.IsValidIsbn("0-306-4061-5");

            Assert.IsFalse(result);
        }
    }
}