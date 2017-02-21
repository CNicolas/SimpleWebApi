using SimpleWebApi.Models;
using System;
using System.Text;

namespace SimpleWebApi.Helpers
{
    public static class CheckCredentialsHelper
    {
        private const string ValidEmail = "clement.nicolas@test.com";
        private const string ValidPassword = "motdepasse";

        public static bool IsEmailValid(AuthenticationParameters parameters)
        {
            return ValidEmail == parameters.Email;
        }

        public static bool IsPasswordValid(AuthenticationParameters parameters)
        {
            return ValidPassword == parameters.Password;
        }

        public static bool IsEmailValid(string email)
        {
            return ValidEmail == email;
        }

        public static bool IsPasswordValid(string password)
        {
            return ValidPassword == password;
        }

        public static bool CheckCredentials(string authorizationHeaderValueParameter)
        {
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeaderValueParameter));
            var splitted = credentials.Split(':');

            return IsEmailValid(splitted[0]) && IsPasswordValid(splitted[1]);
        }
    }
}