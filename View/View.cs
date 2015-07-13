using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.View
{
    class View
    {
        protected static void OnOpenView()
        {
            System.Diagnostics.Debug.Write("A View is opened");
        }

        protected static void OnCloseView()
        {
            System.Diagnostics.Debug.Write("A View is Closed");
        }
    }
}
