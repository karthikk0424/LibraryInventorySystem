using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Controller;

namespace LibraryInventorySystem.Menus
{
    enum eAuthenticationType
    {
        ADMIN,
        STUDENT
    }

    enum eAuthenticationResults
    { 
        Success,
        Failed
    }

    class PasswordMenu
    {
        public delegate void AuthencationResult(eAuthenticationResults result, eAuthenticationType authType);
        public static AuthencationResult authenticationResult;

        public static void ValidateUser(eAuthenticationType type, bool result)
        {
            bool isValidCredential = result;

            if (isValidCredential)
            {
                authenticationResult(eAuthenticationResults.Success, type);
            }
            else
            {
                Console.WriteLine("Authentication failed, Incorrect username or password");
                authenticationResult(eAuthenticationResults.Failed, type);
            }
        }
    }
}
