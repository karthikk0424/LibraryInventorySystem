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
                    OnOpenView();
                }
            };
        }

        private const string NEW_APPROVALS = "(new)"; // Make this appear if new approvals are required
        public static void Display()
        {
            
            Console.Clear();
            Console.WriteLine("\nAdmin Menu");
            Console.WriteLine("--------------");
            Console.WriteLine(" 1 - Add Book ");
            Console.WriteLine(" 2 - List all books");
            Console.WriteLine(" 3 - Query Book");
            Console.WriteLine(" 4 - Delete Book");
            Console.WriteLine(" 5 - Modify Book");
            Console.WriteLine(" 6 - Awaiting approvals");
            Console.WriteLine(" 7 - Book Requests - beta");
            Console.WriteLine(" 8 - Back");

            int selection = Utils.OptionSelection(8);

            switch(selection)
            {
                case 1:
                    Book.Add();
                    break;
                case 2:
                    Book.ListAllBooks();
                    break;
                case 3:
                    Book.Query();
                    break;
                case 4:
                    Book.Delete();
                    break;
                case 5:
                    Book.Modify();
                    break;
                case 6:
                    Book.ListAwaitingApprovals();
                    break;
                case 7:
                    Book.ShowRequestedBooks();
                    break;
                case 8:
                    OnCloseView();
                    break;
            }
            Console.ReadKey(true);
            Display();
        }
    }
}
