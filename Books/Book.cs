using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace LibraryInventorySystem.Books
{
    static class Book
    {
        public static void GetBookAvailability(int serial)
        {
            // TUT
        }

        public static void Add()
        {
            XDocument doc = XDocument.Load(Constants.BOOKS_XML_FILE);
            XElement root = new XElement(Constants.XML_ELEMENT_NODE);

            Console.Write("Enter Book name: ");
            string bookName = Console.ReadLine();

            Console.Write("Enter the serial number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter the Author name: ");
            string authorName = Console.ReadLine();

            //Add as attribute
            root.Add(new XAttribute(Constants.BOOK_NAME, bookName));
            root.Add(new XAttribute(Constants.BOOK_SERIAL_NUMBER, serialNumber));
            root.Add(new XAttribute(Constants.BOOK_AUTHOR_NAME, authorName));

            //Add as element
	    // tEST
            //root.Add(new XElement(Constants.BOOK_NAME, bookName));
            //root.Add(new XElement(Constants.BOOK_SERIAL_NUMBER, serialNumber));
            //root.Add(new XElement(Constants.BOOK_AUTHOR_NAME, authorName));

            doc.Element(Constants.XML_ROOT_ELEMENT).Add(root);
            doc.Save(Constants.BOOKS_XML_FILE);
        }

        public static void Delete()
        {
            Console.Write("Enter the serial number");
            int serial = Convert.ToInt32(Console.ReadLine());

            //Deletion through loop
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(Constants.BOOKS_XML_FILE);
            XmlNodeList nodes = xdoc.GetElementsByTagName(Constants.XML_ELEMENT_NODE);
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    nodes[i].ParentNode.RemoveChild(nodes[i]);
                    xdoc.Save(Constants.BOOKS_XML_FILE);
                }
            }

            /*    
            //Alternate deletion using LINQ
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("books.xml");
            XmlNode childtodelete = xdoc.SelectSingleNode("/Books/Book[Serial_Number=\"1100\"]");
            childtodelete.ParentNode.RemoveChild(childtodelete);
            xdoc.Save(Constants.BOOKS_XML_FILE);
             */
        }

        public static void Modify()
        {
            Console.Write("Enter the serial number: ");

            int serial = Utils.OptionSelection(9999);
            string bookName = string.Empty;
            string authorName = string.Empty;
            int count = 0;

            XmlDocument document = Utils.LoadedDocument();
            XmlNodeList nodes = document.GetElementsByTagName(Constants.XML_ELEMENT_NODE);
            XmlNode selectedNode = null;
            foreach (XmlNode node in nodes)
            {
                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    selectedNode = node;
                    bookName = node.Attributes[Constants.BOOK_NAME].Value;
                    serial = Int32.Parse(node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value);
                    count = Int32.Parse(node.Attributes[Constants.BOOK_AVAILABILITY].Value);
                    authorName = node.Attributes[Constants.BOOK_AUTHOR_NAME].Value;
                }
            }

            Console.WriteLine("\nModify Menu");
            Console.WriteLine("\nWhat would you like to modify");
            Console.WriteLine("1 - Book Name ");
            Console.WriteLine("2 - Book Count");
            Console.WriteLine("3 - Serial Number");
            Console.WriteLine("4 - Author Name"); // HW
            Console.Write("\nEnter selection: ");

            int selection = Utils.OptionSelection(3);

            switch (selection)
            {
                case 1:
                    Console.WriteLine("Enter the book name: ");
                    bookName = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter the new count");
                    count = Utils.OptionSelection(99);
                    break;
                case 3:
                    Console.WriteLine("Enter the author name: ");
                    authorName = Console.ReadLine();
                    break;
                case 4:
                    Console.WriteLine("Enter the serial number: ");
                    serial = Utils.OptionSelection(9999);
                    break;
            }

            selectedNode.Attributes[Constants.BOOK_NAME].Value = bookName;
            selectedNode.Attributes[Constants.BOOK_SERIAL_NUMBER].Value = serial.ToString();
            selectedNode.Attributes[Constants.BOOK_AVAILABILITY].Value = count.ToString();
            selectedNode.Attributes[Constants.BOOK_AUTHOR_NAME].Value = authorName;
            document.Save(Constants.BOOKS_XML_FILE);
        }

        public static void Query()
        {
            Console.Clear();
            Console.WriteLine("Search books");
            Console.WriteLine("-------------");
            Console.WriteLine("1 - Search by book name");
            Console.WriteLine("2 - Search by book id/serial");

            int selection = Utils.OptionSelection(2);
            int serial = 0;
            string bookName = string.Empty;

            switch(selection)
            {
                case 1:
                    Console.Write("\nEnter the book name: ");
                    bookName = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("\nEnter the serial number: ");
                    serial = Utils.OptionSelection(9999);
                    break;
            }
            
            XmlDocument document = new XmlDocument();
            document.Load(Constants.BOOKS_XML_FILE);

            XmlNodeList nodes = document.GetElementsByTagName(Constants.XML_ELEMENT_NODE);
            bool isItemFound = false;
            foreach (XmlNode node in nodes)
            {

                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString() || node.Attributes[Constants.BOOK_NAME].Value.ToLower().Contains(bookName))
                {
                    isItemFound = true;
                    Console.WriteLine("\nBook Details");
                    Console.WriteLine("-------------");
                    Console.WriteLine("Name\t\t: " + node.Attributes[Constants.BOOK_NAME].Value);
                    Console.WriteLine("Serial Number\t: " + node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value);
                    Console.WriteLine("Availability\t: " + node.Attributes[Constants.BOOK_AVAILABILITY].Value);
                    Console.WriteLine("Author Name\t: " + node.Attributes[Constants.BOOK_AUTHOR_NAME].Value);
                }
            }
            if (!isItemFound)
            {
                Console.WriteLine("Oops, No book is found under the given serial number");
            }
        }

        public void RequestBook(string BookName, string AuthorName, int serial = 0)
        { 
        
        }

        public static void BorrowBook(int serial)
        {
            XmlDocument document = new XmlDocument();
        }
    }
}
