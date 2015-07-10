using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem
{
    static class Constants
    {
        public const string XML_SERVER_PATH = "http://127.0.0.1/LibraryInventory/";

        public const string XML_FILE_NAME_BOOKS = "books.xml";
        public const string XML_FILE_NAME_STUDENTS = "students.xml";
        public const string BOOKS_APPROVAL_XML_FILE = "bookapproval.xml";
        public const string BOOKS_REQUESTED_XML_FILE = "bookrequest.xml";

        public const string XML_ROOT_ELEMENT_BOOK = "Books";
        public const string XML_ELEMENT_NODE_BOOK = "Book";

        public const string XML_ROOT_ELEMENT_STUDENT = "Students";
        public const string XML_ELEMENT_NODE_STUDENT = "Student";

        public const string BOOK_NAME = "Name";
        public const string BOOK_AVAILABILITY = "Available";
        public const string BOOK_SERIAL_NUMBER = "Serial_Number";
        public const string BOOK_AUTHOR_NAME = "Author";

        public const string STUDENT_NAME = "Name";
        public const string STUDENT_NUMBER = "Number";
        public const string STUDENT_DEPARTMENT = "Department";

        public const string XML_NODE_APPROVALS = "Approvals";
        
        #region Exit Codes
        public const string USER = "user";
        public const int ERROR_SUCCESS = 0;
        public const int ERROR_BAD_ARGUMENTS = 0xA0;
        public const int ERROR_ARITHMETIC_OVERFLOW = 0x216;
        public const int ERROR_INVALID_COMMAND_LINE = 0x667;
        #endregion
    }
}

