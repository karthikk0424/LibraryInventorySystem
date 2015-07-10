using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace LibraryInventorySystem.ClientServer
{
    static class Server
    {        
        public static void UploadToCloud(string filename)
        {
            WebClient myWebClient = new WebClient();
            
            try
            {
                byte[] responseArray = myWebClient.UploadFile( Constants.XML_SERVER_PATH + "fileupload.php", "POST", filename);
                
                // Decode and display the response.
                Console.WriteLine("\nResponse Received.The contents of the file uploaded is:\n{0}",
                    System.Text.Encoding.ASCII.GetString(responseArray));
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception", e);
            }        
        }        
    }
}
