using SpisRozmowTelefonicznych.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpisRozmowTelefonicznych.Helpers
{
    public static class AuthExtension
    {
        /// <summary>
        /// Zwraca true jeżeli użytkownik jest zalogowany, w przeciwnym wypadku false.
        /// </summary>
        public static bool UserIsLoggedIn(this HtmlHelper html)
        {
            return html.ViewContext.HttpContext.User.Identity.IsAuthenticated;
        }


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