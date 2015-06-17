using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.Menus
{
    enum eAuthenticationType
    {
        ADMIN
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

        public static bool ValidateUser(eAuthenticationType type)
        {
            Console.Write("\nUsername: ");
            string username = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();
            bool isValidCredential = false;

            switch (type)
            { 
                case eAuthenticationType.ADMIN:
                    isValidCredential = username == "user" && password == "1234";
                    break;
            }

            if (isValidCredential)
            {
                authenticationResult(eAuthenticationResults.Success, type);
                return true;
            }
            else
            {
                authenticationResult(eAuthenticationResults.Failed, type);
            }
            return false;
        }
    }
}
