using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using LibraryInventorySystem.Books;
using LibraryInventorySystem.Menus;
using LibraryInventorySystem.Controller;

namespace LibraryInventorySystem.View
{
    class StudentView : View
    {
        public static void Init()
        {
            PasswordMenu.authenticationResult += (result, authType) =>
            {
                if (authType == eAuthenticationType.STUDENT && result == eAuthenticationResults.Success)
                {
                    Display();
                }
            };

            PasswordMenu.ValidateUser(eAuthenticationType.STUDENT, StudentController.ValidateStudent());  
        }

        private static void Display()
        {
            Console.Clear();
            Console.WriteLine("\nStudent Menu");
            Console.WriteLine("-------------");
            Console.WriteLine(" 1 - Query book");
            Console.WriteLine(" 2 - List All Books");
            Console.WriteLine(" 3 - Borrow book");
            Console.WriteLine(" 4 - Request new book - beta");
            Console.WriteLine(" 5 - Back");

            int selection = Utils.OptionSelection(5);

            switch (selection)
            { 
                case 1:
                    Book.Query();
                    break;
                case 2:
                    Book.ListAllBooks();
                    break;
                case 3:
                    Book.Borrow();
                    break;
                case 4:
                    Book.RequestNewBook();                    
                    break;
                case 5:
                    OnCloseView();
                    break;
            }
            Console.ReadKey(true);
            Display();
        }
    }
}
