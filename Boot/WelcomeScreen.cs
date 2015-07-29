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
        public static void Display()
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
                        AdminView.Init();    
                        break;
                    case 2:
                        StudentView.Init();
                        break;
                }

        }
    }
}
