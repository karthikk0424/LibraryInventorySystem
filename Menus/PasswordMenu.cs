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

        public static bool ValidateUser(eAuthenticationType type)
        {
            bool isValidCredential = false;

            switch (type)
            { 
                case eAuthenticationType.ADMIN:                    
                    isValidCredential = AdminController.ValidateAdmin(); 
                    break;
                case eAuthenticationType.STUDENT:
                    isValidCredential = StudentController.ValidateStudent();
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
