using Newtonsoft.Json;
using ProjectB.classes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class Register
    {
        public static dataStorage storage { get; set; }
        public static void registerMain() {
            userInput();
        }

        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }

        public static void userInput() {
            Console.Clear();
            string firstName, lastName, insertion, userEmail, password, gender;
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime birthDay;

            while(true) {
                textColor("Vul uw voornaam in: ", 14, true);
                firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { textColor("Gebruik a.u.b alleen letters", 12, false); }
            }
            while(true) {
                textColor("[Optioneel] Vul uw tussenvoegsel in: ", 14, true);
                insertion = Console.ReadLine();

                if(Regex.IsMatch(insertion, @"(?i)^[a-z.,\s]+$") || insertion == "") { break; }
                else { textColor("Gebruik a.u.b alleen letters en punten.", 12, false); }
            }
            while(true) {
                textColor("Vul uw achternaam in: ", 14, true);
                lastName = Console.ReadLine();

                if(Regex.IsMatch(lastName, @"^[a-zA-Z]+$")) { break; }
                else { textColor("Gebruik a.u.b alleen letters", 12, false); }
            }
            while(true) {
                string fileContent = File.ReadAllText("storage.json");
                storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);

                textColor("Vul uw email in: ", 14, true);
                userEmail = Console.ReadLine();

                var storedMail = "";
                if(storage.personAccount != null) {
                    foreach (var item in storage.personAccount)
                    {
                        storedMail = item.userEmail;
                    }
                    if(userEmail == storedMail) {
                        textColor("Email is al in gebruik", 12, false);
                    } else {
                        textColor("Herhaal uw email: ", 14, true);
                        string userEmailConfirm = Console.ReadLine();

                        if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                        else { textColor("Ongeldig email, gebruik een geldig email", 12, false); }
                    }
                } else {
                    textColor("Herhaal uw email: ", 14, true);
                    string userEmailConfirm = Console.ReadLine();

                    if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                    else { textColor("Ongeldig email, gebruik een geldig email", 12, false); }
                }
            }
            while(true) {
                tools.textColor("Vul uw geboortedatum in (dd-MM-yyyy): ", 14, true);
                string birthDayInput = Console.ReadLine();

                try 
                {
                    birthDay = DateTime.Parse(birthDayInput);
                    break;
                }
                catch (FormatException) 
                {
                    tools.textColor("Verkeerde opmaak, gebruik dd-MM-yyyy", 12, false);
                }

                // if(DateTime.TryParse(birthDay, out dateValue)) { break; }
                // else { textColor("Vul een geldig geboorte datum in.", 12, false); }
            }
            while(true) {
                textColor("Wat is uw geslacht?\n[1] Man \n[2] Vrouw \n[3] anders ", 14, false);
                gender = Console.ReadLine();

                if(gender == "1") { gender = "Man"; break; }
                else if(gender == "2") { gender = "Vrouw"; break; }
                else if(gender == "3") { gender = "Anders"; break; }
                else { textColor("U heeft niet een van de bovenstaande keuzes gekozen.", 14, false); }
            }
            while(true) {
                textColor("Geef een wachtwoord met een minimum lengte van 6: ", 14, true);
                password = Console.ReadLine();
                if (password.Length >= 6)
                {
                    textColor("Herhaal wachtwoord: ", 14, true);
                    if (password == Console.ReadLine()) { break; }
                    else { textColor("Wachtwoord komt niet overeen, probeer opnieuw.", 12, false); }
                }
                else { textColor("Ongeldig wachtwoord.", 12, false); }
            }

            personAccounts obj = new personAccounts {
                userEmail = userEmail,
                firstName = firstName,
                insertion = insertion,
                lastName = lastName,
                birthDay = birthDay,
                gender = gender,
                password = password,
                role = "user",
            };
            
            // JSON
            dataStorageHandler.storage.personAccount.Add(obj);
            dataStorageHandler.saveChanges();
            Console.Clear();
            Menu.Mainmenu();
        }
    }
}