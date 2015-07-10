using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace LibraryInventorySystem
{
    class Utils
    {
        public static int OptionSelection(int numberOfOption, string message = "\nEnter an option to continue: " )
        {
            Console.Write(message);
            bool valid = false;
            int selection = 0;
            do
            {
                Int32.TryParse(Console.ReadLine(), out selection);
                valid = (selection <= numberOfOption && selection >= 1);
                if (!valid)
                {
                    Console.WriteLine("Invalid Selection");
                    Console.Write(message);
                }
            } while (!valid);

            return selection;
        }

        #region TableHelper by Patrick McDonald
        private static int tableWidth = 110;

        private static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = " ";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width);
            }
            Console.WriteLine("\n");
            Console.WriteLine(row);
        }

        private static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        #endregion
    }
}
