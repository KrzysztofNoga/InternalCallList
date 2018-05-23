using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace OcenaUczestnikow.Helpers
{
    public class AccManageHelper
    {
        /// <summary>
        /// Przyjmuje hasło niezhashowane jako parametr
        /// Zwraca wygenerowaną sól i zhashowane hasło
        /// </summary>
        public static void HashPasswordWithNewSalt(string password, out string salt, out string hashedPassword)
        {
            salt = System.Web.Helpers.Crypto.GenerateSalt();
            string passwordWithSalt = password + salt;
            hashedPassword = System.Web.Helpers.Crypto.SHA256(passwordWithSalt);
        }

        /// <summary>
        /// Przyjmuje hasło niezhashowane i sól jako parametry
        /// Zwraca zhashowane hasło
        /// </summary>
        public static string HashPasswordWithExistingSalt(string password, string salt)
        {
            string passwordWithSalt;
            if (salt != null) passwordWithSalt = password + salt;
            else passwordWithSalt = password;
            string hashedPassword = System.Web.Helpers.Crypto.SHA256(passwordWithSalt);
            return hashedPassword;
        }

    }
}