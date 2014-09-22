using Instaply.GourmetFeed.Models;
using Instaply.GourmetFeed.Models.Core;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace UnitTestWindowsPhone
{
    /// <summary>
    /// Test the login feature
    /// </summary>
    [TestClass]
    public class CreateAccountTest
    {
        /// <summary>
        /// Test the validating method to ensure it returns valid when all the fields are correctly filled
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_Valid()
        {
            User user = new User
            {
                Email = "test@test.com",
                Password = "password",
                FirstName = "test1",
                LastName= "test2",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.Valid, result, "Login: Validate fields with correct values success");
        }

        /// <summary>
        /// Test the validating method to ensure it returns EmailInvalid when the Email address is invalid
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_UnvalidEmail()
        {
            User user = new User
            {
                Email = "test",
                Password = "password",
                FirstName = "test1",
                LastName = "test2",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.EmailInvalid, result, "Login: Validate fields with invalid email success");
        }

        /// <summary>
        /// Test the validating method to ensure it returns EmailAddressEmpty when the email address is empty
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_EmptyEmail()
        {
            User user = new User
            {
                Email = "",
                Password = "password",
                FirstName = "test1",
                LastName = "test2",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.EmailAddressEmpty, result, "Login: Validate fields with empty email success");
        }

        /// <summary>
        /// Test the validating method to ensure it returns PasswordEmpty when the Password is empty
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_EmptyPassword()
        {
            User user = new User
            {
                Email = "test@test.com",
                Password = "",
                FirstName = "test1",
                LastName = "test2",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.PasswordEmpty, result, "Login: Validate fields with empty password success");
        }

        /// <summary>
        /// Test the validating method to ensure it returns PasswordEmpty when the first name is empty
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_EmptyFirstName()
        {
            User user = new User
            {
                Email = "test@test.com",
                Password = "password",
                FirstName = "",
                LastName = "test2",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.FirstNameEmpty, result, "Login: Validate fields with empty first name success");
        }

        /// <summary>
        /// Test the validating method to ensure it returns PasswordEmpty when the last name is empty
        /// </summary>
        [TestMethod]
        public void ValidateFieldsTest_EmptyLastName()
        {
            User user = new User
            {
                Email = "test@test.com",
                Password = "password",
                FirstName = "test2",
                LastName = "",
            };

            var result = user.ValidateLogin();
            Assert.AreEqual(eValidationValues.LastNameEmpty, result, "Login: Validate fields with empty last name success");
        }
    }
}
