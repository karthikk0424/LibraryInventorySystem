using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Books;

namespace LibraryInventorySystem.Controller
{
    class AdminController
    {
        public static void AwaitingApprovals()
        {
            Book.ListAwaitingApprovals();
        }
    }
}
