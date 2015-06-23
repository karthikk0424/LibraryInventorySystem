using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using LibraryInventorySystem.Books;

namespace LibraryInventorySystem.View
{
    class StudentView
    {
        public static void Display()
        {
            Console.WriteLine("Student Menu");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Query book");
            Console.WriteLine("2 - List All Books");
            Console.WriteLine("3 - Borrow book");
            Console.WriteLine("4 - Request new book - beta");
            Console.Write("\nEnter an option :");

            int selection = Utils.OptionSelection(4);

            switch (selection)
            { 
                case 1:
                    // HW
                    break;
                case 2:
                    Book.ListAllBooks();
                    break;
                case 3:
                    Book.BorrowBook();
                    break;
                case 4:
                    Utils.PrintRow();
                    break;

            }
        }

        public static void Borrow()
        {
            Console.WriteLine("Enter the serial number to borrow book");

            int serial = Utils.OptionSelection(9999);
            XmlDocument document = new XmlDocument();
            document.Load(Constants.BOOKS_XML_FILE);

            XmlNodeList nodes = document.GetElementsByTagName(Constants.XML_ELEMENT_NODE);
            bool isItemFound = false;
            int numberOfBook = 1;
            
            foreach (XmlNode node in nodes)
            {                
                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    isItemFound = true;
                    Console.WriteLine("\nBook Requested");
                    Console.WriteLine("---------------");
                    Console.WriteLine("Name\t\t: " + node.Attributes[Constants.BOOK_NAME].Value);
                    Console.WriteLine("Serial Number\t: " + node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value);
                    numberOfBook = Int32.Parse(node.Attributes[Constants.BOOK_AVAILABILITY].Value);
                    if (numberOfBook > 0)
                    {
                        numberOfBook--;
                    }
                    else
                    {
                        break;
                    }
                    node.Attributes[Constants.BOOK_AVAILABILITY].Value = numberOfBook.ToString();
                    document.Save(Constants.BOOKS_XML_FILE);

                    Console.WriteLine("Author Name\t: " + node.Attributes[Constants.BOOK_AUTHOR_NAME].Value);
                }
            }
            if (!isItemFound)
            {
                Console.WriteLine("Oops, No book is found under the given serial number");
            }
        }

    }
}
