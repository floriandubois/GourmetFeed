using System.Text.RegularExpressions;

namespace Instaply.GourmetFeed.Models.Core
{
    public static class ExtensionMethods
    {
        const string MatchEmailPattern = @"[-a-zA-Z0-9._]+@[a-zA-Z0-9]([-a-zA-Z0-9_]*[a-zA-Z0-9])?([.][a-zA-Z0-9][-a-zA-Z0-9_]*[a-zA-Z0-9])+";
        public static eValidationValues ValidateLogin(this User user)
        {

            if (user == null)
                return eValidationValues.UserCannotBeNull;

            if (string.IsNullOrWhiteSpace(user.Email))
                return eValidationValues.EmailAddressEmpty;

            if (string.IsNullOrWhiteSpace(user.Password))
                return eValidationValues.PasswordEmpty;

            if (!Regex.IsMatch(user.Email, MatchEmailPattern))
                return eValidationValues.EmailInvalid;

            return eValidationValues.Valid;
        }
        public static eValidationValues ValidateCreateUser(this User user)
        {
            if (user == null)
                return eValidationValues.UserCannotBeNull;

            if (string.IsNullOrWhiteSpace(user.Email))
                return eValidationValues.EmailAddressEmpty;

            if (string.IsNullOrWhiteSpace(user.Password))
                return eValidationValues.PasswordEmpty;

            if (string.IsNullOrWhiteSpace(user.FirstName))
                return eValidationValues.FirstNameEmpty;

            if (string.IsNullOrWhiteSpace(user.LastName))
                return eValidationValues.LastNameEmpty;

            if (!Regex.IsMatch(user.Email, MatchEmailPattern))
                return eValidationValues.EmailInvalid;

            return eValidationValues.Valid;
        }
    }
}
