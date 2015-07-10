using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using LibraryInventorySystem.Controller;
using System.Web.DynamicData;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace LibraryInventorySystem.Books
{
    static class Book
    {
        public static void GetBookAvailability(int serial)
        {
            // Return the available number of books - M_Assignment
        }

        public static void Add()
        {
            Console.Write("Enter Book name: ");
            string bookName = Console.ReadLine();

            Console.Write("Enter the serial number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter the Author name: ");
            string authorName = Console.ReadLine();

            /*
            XDocument doc = XDocument.Load(Constants.BOOKS_XML_FILE);
            XElement root = new XElement(Constants.XML_ELEMENT_NODE);
            //
            //Add as attribute
            root.Add(new XAttribute(Constants.BOOK_NAME, bookName));
            root.Add(new XAttribute(Constants.BOOK_SERIAL_NUMBER, serialNumber));
            root.Add(new XAttribute(Constants.BOOK_AUTHOR_NAME, authorName));
            //
            //Add as element
            root.Add(new XElement(Constants.BOOK_NAME, bookName));
            root.Add(new XElement(Constants.BOOK_SERIAL_NUMBER, serialNumber));
            root.Add(new XElement(Constants.BOOK_AUTHOR_NAME, authorName));
            //
            doc.Element(Constants.XML_ROOT_ELEMENT).Add(root);
            doc.Save(Constants.BOOKS_XML_FILE);
            */

            XmlDocument document = LibraryController.LoadDocument();
            XmlElement root = document.CreateElement(Constants.XML_ELEMENT_NODE_BOOK);

            Console.Write(document.Name);
            
            XmlAttribute a_bookname = document.CreateAttribute(Constants.BOOK_NAME);
            a_bookname.Value = bookName;
            XmlAttribute a_serialNumber = document.CreateAttribute(Constants.BOOK_SERIAL_NUMBER);
            a_serialNumber.Value = serialNumber;
            XmlAttribute a_authorName = document.CreateAttribute(Constants.BOOK_AUTHOR_NAME);
            a_authorName.Value = authorName;

            root.Attributes.Append(a_bookname);
            root.Attributes.Append(a_serialNumber);
            root.Attributes.Append(a_authorName);

            document.DocumentElement.AppendChild(root);
            LibraryController.SaveBookDocument();

            //Find book and increament book count => A_Assignment

        }

        public static void Delete()
        {
            Console.Write("Enter the serial number");
            int serial = Convert.ToInt32(Console.ReadLine());

            //Deletion through loop
            XmlDocument xdoc = LibraryController.LoadDocument();
            XmlNodeList nodes = LibraryController.GetXMLNodeList();
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    nodes[i].ParentNode.RemoveChild(nodes[i]);
                    xdoc.Save(Constants.XML_FILE_NAME_BOOKS);
                }
            }

            /*    
            //Alternate deletion using LINQ SelectSingleNode
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

            XmlDocument document = LibraryController.LoadDocument();
            XmlNode selectedNode = null;
            foreach (XmlNode node in LibraryController.GetXMLNodeList())
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
            Console.WriteLine("3 - Author Name"); 
            Console.WriteLine("4 - Serial Number");
            
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
            LibraryController.SaveBookDocument();
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
            
            bool isItemFound = false;
            foreach (XmlNode node in LibraryController.GetXMLNodeList())
            {

                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString() || (!string.IsNullOrEmpty(bookName) && node.Attributes[Constants.BOOK_NAME].Value.ToLower().Contains(bookName)))
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

        public static void RequestNewBook(string BookName, string AuthorName, int serial = 0)
        { 
            
        }

        public static void BorrowBook()
        {
            Console.Write("Enter the serial number: ");
            int serial = Utils.OptionSelection(9999);
            
            XmlDocument document = LibraryController.LoadDocument();

            foreach (XmlNode node in LibraryController.GetXMLNodeList())
            {
                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    string bookName = node.Attributes[Constants.BOOK_NAME].Value;
                    string authorName = node.Attributes[Constants.BOOK_AUTHOR_NAME].Value;
                    string count = node.Attributes[Constants.BOOK_AVAILABILITY].Value;

                    XmlElement root = document.CreateElement(Constants.XML_NODE_APPROVALS);
                    
                    XmlAttribute a_bookname = document.CreateAttribute(Constants.BOOK_NAME);
                    a_bookname.Value = bookName;

                    XmlAttribute a_serialNumber = document.CreateAttribute(Constants.BOOK_SERIAL_NUMBER);
                    a_serialNumber.Value = serial.ToString();

                    XmlAttribute a_authorName = document.CreateAttribute(Constants.BOOK_AUTHOR_NAME);
                    a_authorName.Value = authorName;

                    root.Attributes.Append(a_bookname);
                    root.Attributes.Append(a_serialNumber);
                    root.Attributes.Append(a_authorName);

                    document.DocumentElement.AppendChild(root);
                    document.Save(Constants.XML_FILE_NAME_BOOKS);
                }
            }
            LibraryController.SaveBookDocument();
        }

        public static void ListAllBooks()
        {
            string[] rowToPrint = new string[] {"Book Name", "Serial", "Availability", "Author name"};
            Utils.PrintRow(rowToPrint);
            rowToPrint = new string[] {"-----------------------------------------------------------------------------------------------------------"};
            Utils.PrintRow(rowToPrint);

            LibraryController.LoadDocument();
            foreach (XmlNode node in LibraryController.GetXMLNodeList())
            {
                rowToPrint = new string[] { 
                    node.Attributes[Constants.BOOK_NAME].Value, 
                    node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value, 
                    node.Attributes[Constants.BOOK_AVAILABILITY].Value,
                    node.Attributes[Constants.BOOK_AUTHOR_NAME].Value
                };
                Utils.PrintRow(rowToPrint);
            }
        }

        public static void ListAwaitingApprovals()
        {
            XmlNodeList nodeList = LibraryController.GetXMLNodeList(Constants.XML_NODE_APPROVALS);
            if (nodeList.Count == 0)
            {
                Console.WriteLine("\nThere is nothing awaiting for approval");
                return;
            }
            string[] rowToPrint = new string[] { "Book Name", "Serial", "Author name" };
            Utils.PrintRow(rowToPrint);
            rowToPrint = new string[] {"-----------------------------------------------------------------------------------------------------------" };
            Utils.PrintRow(rowToPrint);
            
            foreach (XmlNode node in nodeList)
            {
                if (node.Name == Constants.XML_NODE_APPROVALS)
                {
                        rowToPrint = new string[] { 
                        node.Attributes[Constants.BOOK_NAME].Value, 
                        node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value, 
                        node.Attributes[Constants.BOOK_AUTHOR_NAME].Value
                    };
                    Utils.PrintRow(rowToPrint);
                }
            }

            Console.WriteLine("\n\nEnter serial number to approve (1 to approve all): ");
            int serial = Utils.OptionSelection(9999);

            XmlDocument document = LibraryController.LoadDocument();
            foreach (XmlNode node in LibraryController.GetXMLNodeList())
            {
                if (node.Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                {
                    int count = Int32.Parse(node.Attributes[Constants.BOOK_AVAILABILITY].Value);
                    count = count - 1;
                    node.Attributes[Constants.BOOK_AVAILABILITY].Value = count.ToString();

                    XmlNodeList nodes = LibraryController.GetXMLNodeList(Constants.XML_NODE_APPROVALS);
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        if (nodes[i].Attributes[Constants.BOOK_SERIAL_NUMBER].Value == serial.ToString())
                        {
                            nodes[i].ParentNode.RemoveChild(nodes[i]);
                            LibraryController.SaveBookDocument();
                        }
                    }
                }
            }
        }
    }
}
