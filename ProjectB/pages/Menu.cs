using System;
using ProjectB.pages;

namespace ProjectB.pages
{
    class Menu
    {
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }
        public static void mainMenu()
        {
            Console.Clear();
            textColor("Welkom, wat wilt u doen? ", 14, false);
            textColor("[1] Registreren\n[2] Inloggen\n[3] Afsluiten\n", 15, false);
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.Clear();
                textColor("Weet u zeker dat u een nieuw account wil aanmaken?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); Register.registerMain(); }
                else if (input == "2") { Console.Clear(); mainMenu(); }
            } 
            else if (userInput == "2") 
            {
                Console.Clear();
                textColor("Weet u zeker dat u wilt inloggen?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); Login.loginMain(); }
                else if (input == "2") { Console.Clear(); mainMenu(); }
            }
            else if (userInput == "3") 
            {
                Console.Clear();
                textColor("Weet u zeker dat u wilt afsluiten?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); System.Environment.Exit(1); }
                else if (input == "2") { Console.Clear(); mainMenu(); }
            }
        }

        public static void dashboard() {
            if (Login.user is not null && Login.user.role == "user") {
                userMenu();
            } else if (Login.user is not null && Login.user.role == "admin") {
                adminMenu();
            }
        }

        public static void userMenu() {
            Console.Clear();
            if (Login.user is not null && Login.user.role == "user") {
                Console.WriteLine("[1] Maak een reservering\n[2] Bekijk de filmlijst\n[3] Uitloggen\n");
                string option = Console.ReadLine();

                if (option == "3") {
                    Console.Clear();
                    textColor("Weet u zeker dat u wilt uitloggen?", 14, false);
                    textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                    string input = Console.ReadLine();
                    if (input == "1") { Console.Clear(); mainMenu(); }
                    else if (input == "2") { Console.Clear(); userMenu(); }
                }
            } else {
                mainMenu();
            }
        }

        public static void adminMenu() {
            Console.Clear();
            if (Login.user is not null && Login.user.role == "admin") {
                Console.WriteLine("[1] Maak een reservering\n[2] Bekijk de filmlijst\n[3] Zalen beheren\n[4] Uitloggen\n");
                string option = Console.ReadLine();

                if (option == "3") {
                    Console.Clear();
                    textColor("Weet u zeker dat u zalen wilt beheren?", 14, false);
                    textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                    string input = Console.ReadLine();
                    if (input == "1") { Console.Clear(); roomAdmin.roomMain(); }
                    else if (input == "2") { Console.Clear(); adminMenu(); }
                }
                if (option == "4") {
                    Console.Clear();
                    textColor("Weet u zeker dat u wilt uitloggen?", 14, false);
                    textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                    string input = Console.ReadLine();
                    if (input == "1") { Console.Clear(); mainMenu(); }
                    else if (input == "2") { Console.Clear(); adminMenu(); }
                }
            } else {
                mainMenu();
            }
        }
    }
}