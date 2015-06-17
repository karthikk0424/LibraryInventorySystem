using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.View
{
    class StudentView
    {
        public static void Display()
        {
            Console.WriteLine("Student Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Query book");
            Console.WriteLine("2 - Borrow book");
            Console.WriteLine("3 - Request new book - beta");

            int selection = Utils.OptionSelection(3);

            switch (selection)
            { 
                case 1:
                    // HW
                    break;
                case 2:
                    break;
                case 3:
                    break;

            }
        }

    }
}
