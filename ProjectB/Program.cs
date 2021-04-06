using ProjectB.DAL;
using ProjectB.pages;
using System;

namespace ProjectB
{
    class Program
    {
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }
        static void Main()
        {
            dataStorageHandler.init("storage.json");
            // Register.registerMain();
            // Login.loginMain();

            textColor("Welkom, wat wilt u doen? ", 14, false);
            textColor("[1] creëer account\n[2] login\n[3] koop een ticket\n[4] zoek naar een film\n", 15, false);
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Console.Clear();
                textColor("Weet u zeker dat u een nieuw account wil aanmaken?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); Register.registerMain();; }
                else if (input == "2") { Console.Clear(); Main(); }
            } 
            else if (userInput == "2") 
            {
                Console.Clear();
                textColor("Weet u zeker dat u wilt inloggen?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); Login.loginMain(); }
                else if (input == "2") { Console.Clear(); Main(); }
            }
        }
    }
}
