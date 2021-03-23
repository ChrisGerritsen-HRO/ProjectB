using System;
using System.Text.RegularExpressions;

namespace projectB
{
    class Program
    {
        //Black = 0, DarkBlue = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4, DarkMagenta = 5
        //DarkYellow = 6, Gray = 7, DarkGray = 8, Blue = 9, Green = 10
        //Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White = 15
        static void textColor(string text, int color, bool inputLocation)

        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }

        static void createAccouint() 
        {
            while (true)
            {
                textColor("Enter full name: ", 14, true);
                string fullName = Console.ReadLine();
                if (Regex.IsMatch(fullName, "^[a-zA-Z. ]{1,256}$")) { break; }
                else { textColor("invalid name, please only enter letters", 12, false); }
            }
            while (true) 
            {
                textColor("Enter age: ", 14, true);
                string age = Console.ReadLine();
                if (Regex.IsMatch(age, "^[0-9]{1,3}$")) { break; }
                else { textColor("invalid age, pleas enter numbers only", 12, false); }
            }
            while (true)
            {
                textColor("Enter email: ", 14, true);
                string email = Console.ReadLine();
                if (Regex.IsMatch(email, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$")) { break; }
                else { textColor("invalid email, please enter a valid email", 12, false); }
            }
            while (true)
            {
                textColor("enter password(min length = 4): ", 14, true);
                string password = Console.ReadLine();
                if (Regex.IsMatch(password, "[a-zA-Z0-9]{4,1000}"))
                {
                    textColor("confirm password: ", 14, true);
                    if (password == Console.ReadLine()) { break; }
                    else { textColor("wrong password, please try again.", 12, false); }
                }
                else { textColor("invalid password, please try again.", 12, false); }
            }
        }





        static void mainMenu()
        {
            textColor("Welcome, what would you like to do?", 14, false);
            textColor("[1] create account\n[2] login\n[3] buy ticket\n[4] serch movies\n", 15, false);
            if (Console.ReadLine() == "1")
            {
                Console.Clear();
                textColor("Would you like to create a new account?", 14, false);
                textColor("[1] YES, continue", 10, false); textColor("[2] NO, back to main menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); createAccouint(); }
                else if(input == "2"){ Console.Clear(); mainMenu(); }
            }
        }



        static void Main(string[] args)
        {
            mainMenu();
        }
    }
}
