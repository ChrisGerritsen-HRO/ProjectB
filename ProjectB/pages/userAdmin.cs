using System;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class userAdmin
    {
        public static dataStorage storage { get; set; }
        public static void choice() {
            Console.Clear();
            string listMenu = Menu.Menubuilder($"Gebruikers beheren" + "\n", new string[] {"Gebruikers lijst", "Gebruiker toevoegen", "Gebruiker verwijderen", "Gebruiker role aanpassen", "Terug naar hoofdmenu"}, 10, 14);
            if(listMenu == "Gebruikers lijst") {
                listUsers();
            } else if(listMenu == "Gebruiker toevoegen") {
                addUser();
            } else if(listMenu == "Gebruiker verwijderen") {
                removeUser();
            } else if (listMenu == "Gebruiker role aanpassen") {
                adjustUser();
            } else if(listMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }

        public static void  listUsers() {
            Console.Clear();
            foreach(var item in dataStorageHandler.storage.personAccount) {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Voornaam     | {item.firstName}\nAchternaam   |{item.insertion} {item.lastName}\nVerjaardag   | {item.birthDay.ToString("MM/dd/yyyy")}\nGeslacht     | {item.gender}\nRole         | {item.role}", 14, false);
            }
            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {Console.Clear(); choice();}
                else {continue;}
            }
        }

        public static void addUser() {
            Console.Clear();
            string firstName, lastName, insertion, userEmail, password, gender, role;
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime birthDay;

            while(true) {
                tools.textColor("Vul de voornaam in: ", 14, true);
                firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { tools.textColor("Gebruik a.u.b alleen letters", 12, false); }
            }
            while(true) {
                tools.textColor("[Optioneel] Vul de tussenvoegsel in: ", 14, true);
                insertion = Console.ReadLine();

                if(Regex.IsMatch(insertion, @"(?i)^[a-z.,\s]+$") || insertion == "") { break; }
                else { tools.textColor("Gebruik a.u.b alleen letters en punten.", 12, false); }
            }
            while(true) {
                tools.textColor("Vul de achternaam in: ", 14, true);
                lastName = Console.ReadLine();

                if(Regex.IsMatch(lastName, @"^[a-zA-Z]+$")) { break; }
                else { tools.textColor("Gebruik a.u.b alleen letters", 12, false); }
            }
            while(true) {
                string fileContent = File.ReadAllText("storage.json");
                storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);

                tools.textColor("Vul de email in: ", 14, true);
                userEmail = Console.ReadLine();

                var storedMail = "";
                if(storage.personAccount != null) {
                    foreach (var item in storage.personAccount)
                    {
                        storedMail = item.userEmail;
                    }
                    if(userEmail == storedMail) {
                        tools.textColor("Email is al in gebruik", 12, false);
                    } else {
                        tools.textColor("Herhaal de email: ", 14, true);
                        string userEmailConfirm = Console.ReadLine();

                        if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                        else { tools.textColor("Ongeldig email, gebruik een geldig email", 12, false); }
                    }
                } else {
                    tools.textColor("Herhaal de email: ", 14, true);
                    string userEmailConfirm = Console.ReadLine();

                    if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                    else { tools.textColor("Ongeldig email, gebruik een geldig email", 12, false); }
                }
            }
            while(true) {
                tools.textColor("Vul de geboortedatum in (dd-MM-yyyy): ", 14, true);
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
                tools.textColor("Wat is de geslacht?\n[1] Man \n[2] Vrouw \n[3] anders ", 14, false);
                gender = Console.ReadLine();

                if(gender == "1") { gender = "Man"; break; }
                else if(gender == "2") { gender = "Vrouw"; break; }
                else if(gender == "3") { gender = "Anders"; break; }
                else { tools.textColor("U heeft niet een van de bovenstaande keuzes gekozen.", 14, false); }
            }
            while(true) {
                tools.textColor("Geef een wachtwoord met een minimum lengte van 6: ", 14, true);
                password = Console.ReadLine();
                if (password.Length >= 6)
                {
                    tools.textColor("Herhaal wachtwoord: ", 14, true);
                    if (password == Console.ReadLine()) { break; }
                    else { tools.textColor("Wachtwoord komt niet overeen, probeer opnieuw.", 12, false); }
                }
                else { tools.textColor("Ongeldig wachtwoord.", 12, false); }
            }

            role = Menu.Menubuilder($"Selecteer de gewenste soort gebruiker" + "\n", new string[] {"user", "admin"}, 14, 14);

            personAccounts obj = new personAccounts {
                userEmail = userEmail,
                firstName = firstName,
                insertion = insertion,
                lastName = lastName,
                birthDay = birthDay,
                gender = gender,
                password = password,
                role = role,
            };
            
            // JSON
            dataStorageHandler.storage.personAccount.Add(obj);
            dataStorageHandler.saveChanges();
            Console.Clear();

            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {Console.Clear(); choice();}
                else {continue;}
            }
        }

        public static void removeUser() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            if(dataStorageHandler.storage.personAccount.Count == 0) {
                tools.textColor("Er zijn nog geen gebruikers geregistreerd!", 12, false);

            } else {
                for(int i = 0; i < dataStorageHandler.storage.personAccount.Count; i++) {
                    tools.textColor("----------------------------", 14, false);
                    tools.textColor($"ID           | {i}\nVoornaam     | {obj.personAccount[i].firstName}\nAchternaam   | {obj.personAccount[i].lastName}\nEmail        | {obj.personAccount[i].userEmail}+\nRole         | {obj.personAccount[i].role}", 14, false);
                }

                int selectedID = 0;
                while(true){
                    tools.textColor("ID van het te verwijderen gebruiker: ", 14, true);
                    selectedID = Convert.ToInt32(Console.ReadLine());
                    if(selectedID > dataStorageHandler.storage.personAccount.Count-1 || selectedID < 0) { // Als de ingevoerde ID hoger is dan de hoogste ID dan onderstaande uitgevoerd
                        tools.textColor("Dit is geen gelde gebruikers ID!", 12, false);
                    } else {
                        break;
                    }
                }
                string deletedUser = obj.personAccount[selectedID].firstName;

                dataStorageHandler.storage.personAccount.RemoveAt(selectedID); // verwijderd de object in de array van de gewenste index(selectedID)
                dataStorageHandler.saveChanges();
                Console.Clear();
                tools.textColor("de gebruiker ", 15, true); tools.textColor($"{deletedUser}", 11, true); tools.textColor(" is succesvol verwijderd\n", 15, false);                    

            }

            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {Console.Clear(); choice();}
                else {continue;}
            }           
        }

        public static void adjustUser() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            if(dataStorageHandler.storage.personAccount.Count == 0) {
                tools.textColor("Er zijn nog geen gebruikers geregistreerd!", 12, false);

            } else {
                for(int i = 0; i < dataStorageHandler.storage.personAccount.Count; i++) {
                    tools.textColor("----------------------------", 14, false);
                    tools.textColor($"ID           | {i}\nVoornaam     | {obj.personAccount[i].firstName}\nAchternaam   | {obj.personAccount[i].lastName}\nEmail        | {obj.personAccount[i].userEmail}+\nRole         | {obj.personAccount[i].role}", 14, false);
                }

                int selectedID = 0;
                while(true){
                    tools.textColor("ID van de gewenste gebruiker: ", 14, true);
                    selectedID = Convert.ToInt32(Console.ReadLine());
                    if(selectedID > dataStorageHandler.storage.personAccount.Count-1 || selectedID < 0) { // Als de ingevoerde ID hoger is dan de hoogste ID dan onderstaande uitgevoerd
                        tools.textColor("Dit is geen gelde gebruikers ID!", 12, false);
                    } else {
                        break;
                    }
                }
                string deletedUser = obj.personAccount[selectedID].firstName;
                dataStorageHandler.storage.personAccount[selectedID].role = Menu.Menubuilder($"Selecteer de gewenste soort gebruiker" + "\n", new string[] {"user", "admin"}, 14, 14);


                Console.Clear();
                tools.textColor("de gebruiker ", 15, true); tools.textColor($"{deletedUser}", 11, true); tools.textColor(" heeft de nieuwe rol \n", 15, true); tools.textColor($"{dataStorageHandler.storage.personAccount[selectedID].role}", 11, false);                 

            }
            dataStorageHandler.saveChanges();
            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter" && Login.user.role == "admin") {Console.Clear(); choice();}
                else if (key.Key.ToString() == "Enter" && Login.user.role == "user") {Console.Clear(); Menu.dashboard();}
                else {continue;}
            }                
        }         
    }
}
