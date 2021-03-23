using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ProjectB
{
    public class Account {
        public string userEmail { get; set; }
        public string insertion { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string birthDay { get; set; } 
        public string gender { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }

    class Register
    {
        public void registerMain() {
            userInput();
        }

        public static void userInput() {
            string firstName, lastName, insertion, userEmail, birthDay, password, gender;
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime dateValue;

            while(true) {
                Console.WriteLine("Vul uw voornaam in: ");
                firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw naam."); }
            }
            while(true) {
                Console.WriteLine("[Optioneel] Vul uw tussenvoegsel in: ");
                insertion = Console.ReadLine();

                if(Regex.IsMatch(insertion, @"(?i)^[a-z.,\s]+$") || insertion == "") { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw tussenvoegsel."); }
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
                Console.WriteLine("Herhaal uw email: ");
                string userEmailConfirm = Console.ReadLine();

                if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw email."); }
            }
            while(true) {
                Console.WriteLine("Vul uw geboortedatum in: ");
                birthDay = Console.ReadLine();

                if(DateTime.TryParse(birthDay, out dateValue)) { break; }
                else { Console.WriteLine("Er klopt iets niet aan uw geboortedatum."); }
            }
            while(true) {
                Console.WriteLine("Wat is uw geslacht? ");
                Console.WriteLine("[1] Man \n [2] Vrouw \n [3] Onbekend");
                gender = Console.ReadLine();

                if(gender == "1") { gender = "man"; break; }
                else if(gender == "2") { gender = "vrouw"; break; }
                else if(gender == "3") { gender = "Onbekend"; break; }
                else { Console.WriteLine("Uw heeft niet een van de bovenstaande keuzes gekozen."); }
            }
            while(true) {
                Console.WriteLine("Vul een wachtwoord in: ");
                password = Console.ReadLine();
                Console.WriteLine("Herhaal wachtwoord: ");
                string passwordConfirm = Console.ReadLine();

                if(password == passwordConfirm && password.Length >= 6) { break; }
                else { Console.WriteLine("De wachtwoorden komen niet overeen."); }
            }

            // OBJECT
            var obj = new Account {
                userEmail = userEmail,
                firstName = firstName,
                insertion = insertion,
                lastName = lastName,
                birthDay = birthDay,
                gender = gender,
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