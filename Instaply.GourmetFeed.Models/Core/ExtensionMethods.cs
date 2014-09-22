using System.Text.RegularExpressions;

namespace Instaply.GourmetFeed.Models.Core
{
    public static class ExtensionMethods
    {
        public static eValidationValues ValidateLogin(this User user)
        {
            const string matchEmailPattern = @"[-a-zA-Z0-9._]+@[a-zA-Z0-9]([-a-zA-Z0-9_]*[a-zA-Z0-9])?([.][a-zA-Z0-9][-a-zA-Z0-9_]*[a-zA-Z0-9])+";

            if (user == null)
                return eValidationValues.UserCannotBeNull;

            if (string.IsNullOrWhiteSpace(user.Email))
                return eValidationValues.EmailAddressEmpty;

            if (string.IsNullOrWhiteSpace(user.Password))
                return eValidationValues.PasswordEmpty;

            if (!Regex.IsMatch(user.Email, matchEmailPattern))
                return eValidationValues.EmailInvalid;

            return eValidationValues.Valid;
        }
    }
}
