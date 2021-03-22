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

            Console.WriteLine("Vul uw voornaam in: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Vul uw achternaam in: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Vul uw email in: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Vul uw geboortedatum in: ");
            string birthDay = Console.ReadLine();

            if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && Regex.IsMatch(lastName, @"^[a-zA-Z]+$")
             && userEmail.Contains("@") && DateTime.TryParse(birthDay, out dateValue)) {
                Console.WriteLine("Bedankt!");
            } else {
                Console.WriteLine("Er klopt iets niet aan de gegevens.");
                userInput();
            }
        }
    }
}