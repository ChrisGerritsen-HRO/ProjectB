using ProjectB.pages;
using ProjectB.classes;
using System;

namespace ProjectB.pages
{
    class about
    {
        public static void aboutPage()
        {
            tools.textColor("       Informatie      ", 14, false);
            tools.textColor("----------------------", 14, false);
            tools.textColor("Bioscoop       | ", 14, true); Console.WriteLine("bioscoop naam hier"); 
            tools.textColor("Adres          | ", 14, true); Console.WriteLine("bioscoop adres hier");
            tools.textColor("Openingstijden | ", 14, true); Console.WriteLine("bioscoop openingstijden hier");
            tools.textColor("over ons       | ", 14, true); Console.WriteLine("hier over ons");
            
            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter" && Login.user == null) {Console.Clear(); Menu.Mainmenu();}
                else {continue;}
            }
        }
    }
}