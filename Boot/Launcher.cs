using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryInventorySystem.Boot
{
    class Launcher
    {
        static void Main(string[] args)
        {
            Console.Title = "Shallow Valley";
            string consoleName = "++++ Shallow Valley Console ++++";
            Console.WriteLine(consoleName);
            WelcomeScreen welcome = new WelcomeScreen();
            welcome.InitWelcomeScreen();
            Console.ReadKey(true);
        }
    }
}
