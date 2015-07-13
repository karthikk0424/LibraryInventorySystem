using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibraryInventorySystem.Controller
{
    class StudentController
    {
        public struct Student
        {
            public string m_Name;
            public int m_StudentNumber;
            public string m_DeptName;

            public Student(string name, int studentNumber, string deptName)
            {
                m_Name = name;
                m_StudentNumber = studentNumber;
                m_DeptName = deptName;
            }
        }

        public int CurrentStudentNumber
        {
            set { }
        }

        static Student m_CurrentStudent;
        public Student CurrentStudent
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
            foreach (XmlNode node in document.GetElementsByTagName(Constants.XML_ELEMENT_NODE_STUDENT))
            {
                if (node.Attributes[Constants.STUDENT_NUMBER].Value == number.ToString())
                {
                    m_CurrentStudent = new Student(node.Attributes[Constants.STUDENT_NUMBER].Value,
                                       number,
                                       node.Attributes[Constants.STUDENT_NUMBER].Value);
                                        
                    return true;
                }
            }
            Console.WriteLine("Student number is invalid");
            return false;
        }
    }
}
