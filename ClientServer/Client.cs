using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.ClientServer
{
    class Client
    {
        public static void SaveAndUploadAll()
        {
           Server.UploadToCloud(Constants.XML_FILE_NAME_BOOKS);
           Server.UploadToCloud(Constants.XML_FILE_NAME_STUDENTS);
        }
    }
}
