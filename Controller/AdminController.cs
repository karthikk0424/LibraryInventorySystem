using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Books;

namespace LibraryInventorySystem.Controller
{
    class AdminController
    {
        public static bool ValidateAdmin()
        {
            Console.Write("\nUsername: ");
            string username = Console.ReadLine();
            Console.Write("\nPassword: ");
            string password = Console.ReadLine();

            bool isValid = username == "" && password == "";
            return isValid;
        }

    }
}
