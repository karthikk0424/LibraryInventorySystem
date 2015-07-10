using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Menus;
using LibraryInventorySystem.Books;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;

namespace LibraryInventorySystem.View
{
    class AdminView : View
    {
        public static void Init()
        {
            PasswordMenu.authenticationResult += (result, authType) =>
            {
                if (authType == eAuthenticationType.ADMIN && result == eAuthenticationResults.Success)
                {
                    Display();
                }
            };
        }

        private const string NEW_APPROVALS = "(new)"; // Make this appear if new approvals are required
        public static void Display()
        {
            Console.WriteLine("\nAdmin Menu");
            Console.WriteLine("1 - Add Book ");
            Console.WriteLine("2 - Query Book");
            Console.WriteLine("3 - Delete Book");
            Console.WriteLine("4 - Modify Book");
            Console.WriteLine("5 - Awaiting approvals");
            Console.WriteLine("6 - Advance options");

            int selection = Utils.OptionSelection(5);

            switch(selection)
            {
                case 1:
                    Book.Add();
                    break;
                case 2:
                    Book.Query();
                    break;
                case 3:
                    Book.Delete();
                    break;
                case 4:
                    Book.Modify();
                    break;
                case 5:
                    Book.ListAwaitingApprovals();
                    break;
            }
        }
    }
}
