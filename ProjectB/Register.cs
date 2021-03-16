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
            Console.WriteLine("Vul uw voornaam in: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Vul uw achternaam in: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Vul uw email: ");
            string userEmail = Console.ReadLine();

            if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$") && Regex.IsMatch(lastName, @"^[a-zA-Z]+$") && userEmail.Contains("@")) {
                Console.WriteLine("Bedankt!");
            } else {
                Console.WriteLine("Er klopt iets niet aan de gegevens.");
                userInput();
            }
        }
    }
}