using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibraryInventorySystem.Controller
{
    class StudentController
    {

        public int CurrentStudentNumber
        {
            set { }
        }

        LibraryController.Student m_CurrentStudent;
        public LibraryController.Student CurrentStudent
        { 
            get {return m_CurrentStudent;}
        }

        public static void GetCurrentStudent()
        { 
        
        }

        public static bool ValidateStudent()
        {
            int number = Utils.OptionSelection(99999, "Enter the Student number to continue: ");
            XmlDocument document = LibraryController.LoadDocument(Constants.XML_FILE_NAME_STUDENTS);
            foreach (XmlNode node in LibraryController.GetXMLNodeList(Constants.XML_ELEMENT_NODE_STUDENT))
            {
                if (node.Attributes[Constants.STUDENT_NUMBER].Value == number.ToString())
                {
                    Console.WriteLine("Student is valid");
                    Console.WriteLine("Create stud struct");
                    return true;
                }
            }
            Console.WriteLine("Student number is invalid");
            return false;
        }
    }
}
