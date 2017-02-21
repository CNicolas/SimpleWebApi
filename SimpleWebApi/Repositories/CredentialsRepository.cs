using SimpleWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleWebApi.Repositories
{
    public class CredentialsRepository
    {
        public IReadOnlyDictionary<string, string> Credentials { get; private set; }
        
        public CredentialsRepository()
        {
            Credentials = new Dictionary<string, string> {
                { "c.nicolas@test.com", "motdepasse"},
                { "c.nicolas@test1.com", "motdepasse1"},
                { "c.nicolas@test2.com", "motdepasse2"}
            };
        }

        private bool IsEmailValid(string email)
        {
            return Credentials.ContainsKey(email);
        }

        public bool AreCredentialsValid(string email, string password)
        {
            return IsEmailValid(email) && Credentials[email] == password;
        }

        public bool ParseAndCheckBase64CredentialsString(string base64credentials)
        {
            var credentials = Encoding.UTF8.GetString(Convert.FromBase64String(base64credentials));
            var splitted = credentials.Split(':');

            if (splitted.Length == 2)
            {
                return AreCredentialsValid(splitted[0], splitted[1]);
            }

            return false;
        }
    }
}