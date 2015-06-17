using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;

namespace LibraryInventorySystem.Controller
{
    class LibraryController
    {
        struct Book
        {
            public string m_Name;
            public int m_Count;
            public int m_SerialNumber;
            public string m_authorName;

            public Book(string name, int count, int serialNumber, string authorName)
            {
                m_Name = name;
                m_Count = count;
                m_SerialNumber = serialNumber;
                m_authorName = authorName;
            }
        }

        public static void Init()
        {
            LoadXML();
        }

        private static void LoadXML()
        {
            if(!File.Exists(Constants.BOOKS_XML_FILE))
            {
                FileStream file = File.Create(Constants.BOOKS_XML_FILE);
                file.Close();
                CreateXMLData();
            }
        }

        public static void CreateXMLData()
        {
            Book[] books = new Book[10];
            books[0] = new Book("Computer Networks", 2, 1101, "M John");
            books[1] = new Book("Network Programming", 2, 1102, "M John");
            books[2] = new Book("Computer Graphics", 2, 1103, "M John");
            books[3] = new Book("Software Engineering", 2, 1104, "M John");
            books[4] = new Book("Computer Architecture", 2, 1105, "M John");
            books[5] = new Book("Analog Communication", 2, 1106, "M John");
            books[6] = new Book("Digital Signal Processing", 2, 1107, "M John");
            books[7] = new Book("Signals and System", 2, 1108, "M John");
            books[8] = new Book("System Software", 2, 1109, "M John");
            books[9] = new Book("Database Management System", 2, 1100, "M John");
            
            using (XmlWriter writer = XmlWriter.Create(Constants.BOOKS_XML_FILE))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement("Books");
                writer.WriteWhitespace("\n");

                foreach (Book book in books)
                {
                    writer.WriteStartElement("Book");

                    writer.WriteAttributeString("Name", book.m_Name);
                    writer.WriteAttributeString("Available", book.m_Count.ToString());
                    writer.WriteAttributeString("Serial_Number", book.m_SerialNumber.ToString());
                    writer.WriteAttributeString("Author", book.m_authorName);

                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        private static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    Console.WriteLine("Error: {0}", e.Message);
                    break;
                case XmlSeverityType.Warning:
                    Console.WriteLine("Warning {0}", e.Message);
                    break;
            }

            Console.WriteLine("\nData file does not exist or corrupt");
            Console.WriteLine("1 - Recreate Data ");
            Console.WriteLine("2 - Manually Fix Issue (not recommended)");
            Console.Write("\nEnter selection: ");

            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    CreateXMLData();
                    break;
                case 2:
                    Environment.Exit(Constants.ERROR_SUCCESS);
                    break;
            }
        }
    }
}
