using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ProjectB
{
    public class Account {
        public string userEmail { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthDay { get; set; } 
        public string password { get; set; }
        public string role { get; set; }
    }

    class Register
    {
        public void registerMain() {
            userInput();
        }

        public static void userInput() {
            string firstName, lastName, userEmail, birthDay, password;
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime dateValue;
            
            while(true) {
                Console.WriteLine("Vul uw voornaam in: ");
                firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw naam."); }
            }
            while(true) {
                Console.WriteLine("Vul uw achternaam in: ");
                lastName = Console.ReadLine();

                if(Regex.IsMatch(lastName, @"^[a-zA-Z]+$")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw naam."); }
            }
            while(true) {
                Console.WriteLine("Vul uw email in: ");
                userEmail = Console.ReadLine();

                if(userEmail.Contains("@")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw email."); }
            }
            while(true) {
                Console.WriteLine("Vul uw geboortedatum in: ");
                birthDay = Console.ReadLine();

                if(DateTime.TryParse(birthDay, out dateValue)) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw geboortedatum."); }
            }
            while(true) {
                Console.WriteLine("Vul een wachtwoord in: ");
                password = Console.ReadLine();
                Console.WriteLine("Herhaal wachtwoord: ");
                string passwordConfirm = Console.ReadLine();

                if(password == passwordConfirm) { break; }
                else { Console.WriteLine("De wachtwoorden komen niet overeen."); }
            }

            // OBJECT
            var obj = new Account {
                userEmail = userEmail,
                firstName = firstName,
                lastName = lastName,
                birthDay = birthDay,
                password = password,
                role = "user"
            };

            // JSON
            string path = "account.txt";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path; 
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);

            if(File.Exists(path)) {
                string storedData = System.IO.File.ReadAllText(path);
                using (StreamWriter sw = File.AppendText(path)) {
                    sw.WriteLine(json);
                }
            } else {
                using (StreamWriter sw = File.AppendText(path)) {
                    sw.WriteLine(json);
                }
            }
        }
    }
}