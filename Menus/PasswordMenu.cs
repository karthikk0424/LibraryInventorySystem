using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static bool ValidateUser(eAuthenticationType type)
        {
            bool isValidCredential = false;

            switch (type)
            { 
                case eAuthenticationType.ADMIN:                    
                    Console.Write("\nUsername: ");
                    string username = Console.ReadLine();
                    Console.Write("\nPassword: ");
                    string password = Console.ReadLine();
                    isValidCredential = username == "user" && password == "1234";
                    break;
                case eAuthenticationType.STUDENT:
                    isValidCredential = LibraryInventorySystem.Controller.StudentController.ValidateStudent();
                    break;
            }

            if (isValidCredential)
            {
                authenticationResult(eAuthenticationResults.Success, type);
                return true;
            }
            else
            {
                Console.WriteLine("Authentication failed, Incorrect username or password");
                authenticationResult(eAuthenticationResults.Failed, type);
            }
            return false;
        }
    }
}
