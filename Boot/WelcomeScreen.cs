using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Menus;
using LibraryInventorySystem.View;
using LibraryInventorySystem.Controller;

namespace LibraryInventorySystem.Boot
{
    class WelcomeScreen
    {
        public virtual void InitWelcomeScreen()
        {
            LibraryController.Init();

            Console.WriteLine("\n\nLibrary Personalization Menu\n");
            Console.WriteLine(" 1 - Admin");
            Console.WriteLine(" 2 - Student");

            int selection = Utils.OptionSelection(2);              
            
            LibraryController.Init();

            switch (selection)
                {
                    case 1:
                        Console.WriteLine("\n**** Authentication is required for Admin mode ****");            
                        AdminView.Init();
                        PasswordMenu.ValidateUser(eAuthenticationType.ADMIN);       
                        break;
                    case 2:
                        StudentView.Init();
                        PasswordMenu.ValidateUser(eAuthenticationType.STUDENT); 
                        break;
                }

        }
    }
}
