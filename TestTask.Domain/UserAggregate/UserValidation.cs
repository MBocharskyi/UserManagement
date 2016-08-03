using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTask.Domain.UserAggregate
{
    public static class UserValidation
    {
        public static bool IsValid(User user)
        {
            return ValidateName(user.Name)
                && ValidateEmail(user.Email)
                && ValidateSkypeLogin(user.SkypeLogin);
        }

        private static bool ValidateName(string name)
        {
            return name.Length >= Constants.User.Name.MIN_NAME_LENGTH
                && name.Length <= Constants.User.Name.MAX_NAME_LENGTH
                && Regex.IsMatch(name, Constants.User.Name.NAME_REGEX_PATTERN);
        }

        private static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, Constants.User.Email.EMAIL_REGEX_PATTERN);
        }

        private static bool ValidateSkypeLogin(string skype)
        {
            if (skype != null)
            {
                return Regex.IsMatch(skype, Constants.User.Skype.SKYPE_REGEX_PATTERN);
            }
            return true;
        }
    }
}
