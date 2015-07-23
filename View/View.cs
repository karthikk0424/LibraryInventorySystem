using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryInventorySystem.Boot;

namespace LibraryInventorySystem.View
{
    class View
    {
        protected static void OnOpenView()
        {
               
        }

        protected static void OnCloseView()
        {
            WelcomeScreen.Display();
        }
    }
}
