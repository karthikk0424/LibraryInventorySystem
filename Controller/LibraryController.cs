using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.IO;
using System.Xml.Linq;
using LibraryInventorySystem.ClientServer;

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
            if (!File.Exists(Constants.XML_FILE_NAME_BOOKS))
            {
                CreateDefaultXMLData();
            }

            if (!File.Exists(Constants.XML_FILE_NAME_STUDENTS))
            {
                CreateStudentXMLData();
            }
        }

        public static void FlushXMLData()
        {
            XmlDocument document = LoadDocument();
            foreach (XmlNode node in GetXMLNodeList())
            {
                node.RemoveAll();
            }
        }

        public static void CreateStudentXMLData()
        {
            StudentController.Student[] students = new StudentController.Student[3];
            students[0] = new StudentController.Student("Akshay", 21106, "B.Tech IT");
            students[1] = new StudentController.Student("Karthik", 21126, "B.Tech IT");
            students[2] = new StudentController.Student("Padma", 21136, "B.Tech IT");

            using (XmlWriter writer = XmlWriter.Create(Constants.XML_FILE_NAME_STUDENTS))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(Constants.XML_ROOT_ELEMENT_STUDENT);
                writer.WriteWhitespace("\n");

                foreach (StudentController.Student student in students)
                {
                    writer.WriteStartElement(Constants.XML_ELEMENT_NODE_STUDENT);

                    writer.WriteAttributeString(Constants.STUDENT_NAME, student.m_Name);
                    writer.WriteAttributeString(Constants.STUDENT_NUMBER, student.m_StudentNumber.ToString());
                    writer.WriteAttributeString(Constants.STUDENT_DEPARTMENT, student.m_DeptName);

                    writer.WriteEndElement();
                    writer.WriteWhitespace("\n");
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        public static void CreateDefaultXMLData()
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
            
            using (XmlWriter writer = XmlWriter.Create(Constants.XML_FILE_NAME_BOOKS))
            {
                writer.WriteStartDocument();
                writer.WriteWhitespace("\n");
                writer.WriteStartElement(Constants.XML_ROOT_ELEMENT_BOOK);
                writer.WriteWhitespace("\n");

                foreach (Book book in books)
                {
                    writer.WriteStartElement(Constants.XML_ELEMENT_NODE_BOOK);

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
            Console.WriteLine("2 - Quit application");
            Console.Write("\nEnter selection: ");

            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    CreateDefaultXMLData();
                    break;
                case 2:
                    Environment.Exit(Constants.ERROR_SUCCESS);
                    break;
            }
        }

        #region XmlDocument helper methods

        private static XmlDocument m_document = null;
        public static XmlDocument LoadDocument(string documentName = Constants.XML_FILE_NAME_BOOKS)
        {
            if (m_document == null || !documentName.Contains(m_document.DocumentElement.Name))
            {
                m_document = new XmlDocument();
                m_document.Load(documentName);

            }
            return m_document;
        }

        public static XmlNodeList GetXMLNodeList(string XmlTagName = Constants.XML_ELEMENT_NODE_BOOK)
        {
            return m_document.GetElementsByTagName(XmlTagName);
        }

        public static void SaveBookDocument()
        {
            m_document.Save(Constants.XML_FILE_NAME_BOOKS);
            Client.SaveAndUploadAll();
        }

        public static void SaveStudentDocument()
        {
            m_document.Save(Constants.XML_FILE_NAME_STUDENTS);
            Client.SaveAndUploadAll();
        }
        #endregion
    }
}
