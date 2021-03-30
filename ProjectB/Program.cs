using System;
using System.Text.RegularExpressions;

namespace justafile
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
                textColor("Vul uw voornaam in: ", 14, true);
                string firstName = Console.ReadLine();
                if (Regex.IsMatch(firstName, "^[a-zA-Z]{1,256}$")) { break; }
                else { textColor("gebruik a.u.b alleen letters", 12, false); }
            }

            while (true)
            {
                textColor("[Optioneel] Vul uw tussenvoegsel in: ", 14, true);
                string insertion = Console.ReadLine();
                if (Regex.IsMatch(insertion, @"^[a-zA-Z.]$") || insertion == "") { break; }
                else { textColor("gebruik a.u.b alleen letters en punten.", 12, false); }
            }

            while (true)
            {
                textColor("Vul uw achternaam in: ", 14, true);
                string lastName = Console.ReadLine();
                if (Regex.IsMatch(lastName, "^[a-zA-Z]{1,256}$")) { break; }
                else { textColor("gebruik a.u.b alleen letters", 12, false); }
            }

            while (true)
            {
                var dateFormats = new[] { "dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy" };
                DateTime dateValue;
                textColor("Vul uw geboortedatum in(dd-MM-yyyy): ", 14, true);
                string birthDay = Console.ReadLine();
                if (DateTime.TryParse(birthDay, out dateValue)) { break; }
                else { textColor("vul een geldig geboorte datum in.", 12, false); }
            }

            while (true) 
            {
                textColor("Wat is uw geslacht?\n[1] Man \n[2] Vrouw \n[3] anders ", 14, false);
                string gender = Console.ReadLine();
                if (gender == "1") { gender = "man"; break; }
                else if (gender == "2") { gender = "vrouw"; break; }
                else if (gender == "3") { gender = "Onbekend"; break; }
                else { textColor("U heeft niet een van de bovenstaande keuzes gekozen.", 14, false); }
            }

            while (true)
            {
                textColor("Vul uw email in: ", 14, true);
                string email = Console.ReadLine();
                if (Regex.IsMatch(email, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$"))
                {
                    textColor("Herhaal uw email: ", 14, true);
                    if (email == Console.ReadLine()) { break; }
                    else { textColor("email heeft geen overeenkomst, probeer opnieuw.", 12, false); }
                }
                else { textColor("ongeldig email, gebruik een geldig email", 12, false); }
            }

            while (true)
            {
                textColor("geef een wachtwoord met een minimum lengte van 6: ", 14, true);
                string password = Console.ReadLine();
                if (password.Length >= 6)
                {
                    textColor("confirm password: ", 14, true);
                    if (password == Console.ReadLine()) { break; }
                    else { textColor("wachtwoord komt niet overeen, probeer opnieuw.", 12, false); }
                }
                else { textColor("ongeldig wachtwoord.", 12, false); }
            }

            Console.Clear();
            mainMenu();
        }

        static void mainMenu()
        {
            textColor("Welkom, wat wilt u doen? ", 14, false);
            textColor("[1] creëer account\n[2] login\n[3] koop een ticket\n[4] zoek naar een film\n", 15, false);
            if (Console.ReadLine() == "1")
            {
                Console.Clear();
                textColor("weet u zeker dat u een nieuw account wil aanmaken?", 14, false);
                textColor("[1] JA, ga door", 10, false); textColor("[2] NEE, terug naar menu", 12, false);
                string input = Console.ReadLine();
                if (input == "1") { Console.Clear(); createAccouint(); }
                else if (input == "2") { Console.Clear(); mainMenu(); }
            }
        }

        static void Main(string[] args)
        {
            mainMenu();
        }
    }
}

