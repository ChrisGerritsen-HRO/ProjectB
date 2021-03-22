using System;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProjectB
{
    class Register
    {
        public void registerMain() {
            userInput();
        }

        public static void userInput() {
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime dateValue;
            
            while(true) {
                Console.WriteLine("Vul uw voornaam in: ");
                string firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw naam."); }
            }
            while(true) {
                Console.WriteLine("Vul uw achternaam in: ");
                string lastName = Console.ReadLine();

                if(Regex.IsMatch(lastName, @"^[a-zA-Z]+$")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw naam."); }
            }
            while(true) {
                Console.WriteLine("Vul uw email in: ");
                string userEmail = Console.ReadLine();

                if(userEmail.Contains("@")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw email."); }
            }
            while(true) {
                Console.WriteLine("Vul uw geboortedatum in: ");
                string birthDay = Console.ReadLine();

                if(DateTime.TryParse(birthDay, out dateValue)) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw geboortedatum."); }
            }
            while(true) {
                Console.WriteLine("Vul een wachtwoord in: ");
                string password = Console.ReadLine();
                Console.WriteLine("Herhaal wachtwoord: ");
                string passwordConfirm = Console.ReadLine();

                if(password == passwordConfirm) { break; }
                else { Console.WriteLine("De wachtwoorden komen niet overeen."); }
            }
        }
    }
}