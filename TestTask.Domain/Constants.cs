using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public static class Constants
    {
        public static class User
        {
            public static class Name
            {
                public const int MIN_NAME_LENGTH = 6;
                public const int MAX_NAME_LENGTH = 20;
                public const string NAME_REGEX_PATTERN = @"[A-Za-z0-9]{1,20}";
            }

            public static class Email
            {
                public const string EMAIL_REGEX_PATTERN = @"^[+a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            }

            public static class Skype
            {
                public const string SKYPE_REGEX_PATTERN = @"[a-zA-Z][a-zA-Z0-9\.,\-_]{5,20}";
            }
        }
    }
}
