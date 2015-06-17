using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibraryInventorySystem
{
    class Utils
    {
        public static int OptionSelection(int numberOfOption)
        {
            bool valid = false;
            int selection = 0;
            do
            {
                Int32.TryParse(Console.ReadLine(), out selection);
                valid = (selection <= numberOfOption && selection >= 1);
                if (!valid)
                {
                    Console.WriteLine("Invalid Selection");
                    Console.Write("Enter an option to continue: ");
                }
            } while (!valid);

            return selection;
        } 

        public static XmlDocument LoadedDocument()
        {
            XmlDocument document =  new XmlDocument();
            document.Load(Constants.BOOKS_XML_FILE);
            return document;

        }
    }
}
