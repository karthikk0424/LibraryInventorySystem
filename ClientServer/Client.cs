using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.ClientServer
{
    class Client
    {
        public static void SaveAndUpload(string filename)
        {
            Server.UploadToCloud(filename);
        }
    }
}
