using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.View
{
    class View
    {
        protected static void OpenView()
        {
            
        }

        protected static void CloseView()
        {
            ClientServer.Client.SaveAndUploadAll();
        }
    }
}
