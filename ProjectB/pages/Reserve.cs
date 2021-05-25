using Newtonsoft.Json;
using ProjectB.classes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectB.DAL;
using System.Text;


namespace ProjectB.pages
{
    class Reserve{
        public static dataStorage storage { get; set; }
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }
        
        
        
       
            
       
        
        public static void ReserveMain(){
            Console.Clear();
            string movieMenu = Menu.Menubuilder($"Reserveringen beheren" + "\n", new string[] {"Reservering maken", "Reservering aanpassen", "Reservering annuleren", "Terug naar hoofdmenu"}, 10, 14);
            if(movieMenu == "Reservering maken") {
                ReserveAdd();
            } else if(movieMenu == "Reservering aanpassen") {
                
            } else if(movieMenu == "Reservering annuleren") {
                
            } else if(movieMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }
        public static void ReserveAdd(){
            Console.Clear();
            string firstName, lastName, insertion, userEmail, birthDay, gender, rndCode;
            var dateFormats = new[] {"dd.MM.yyyy", "dd-MM-yyyy", "dd/MM/yyyy"};
            DateTime dateValue;

            int count = 0;
            
            while(true) {
                textColor("Vul uw voornaam in: ", 14, true);
                firstName = Console.ReadLine();

                if(Regex.IsMatch(firstName, @"^[a-zA-Z]+$")) { break; }
                else { textColor("Gebruik a.u.b alleen letters", 12, false); }
                
                if(count == 4) {
                    Menu.Mainmenu();}
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
                
                textColor("Vul uw email in: ", 14, true);
                userEmail = Console.ReadLine();
                
                
                    
                
                textColor("Herhaal uw email: ", 14, true);
                string userEmailConfirm = Console.ReadLine();

                if(Regex.IsMatch(userEmail, "^[A-Za-z0-9_.-]{1,64}@[A-Za-z-]{1,255}.(com|net|nl|org)$") && userEmail == userEmailConfirm) { break; }
                else { textColor("Ongeldig email, gebruik een geldig email", 12, false); }
                }
            
            while(true) {
                textColor("Vul uw geboortedatum in(dd-MM-yyyy): ", 14, true);
                birthDay = Console.ReadLine();

                if(DateTime.TryParse(birthDay, out dateValue)) { break; }
                else { textColor("Vul een geldig geboorte datum in.", 12, false); }
            }
            while(true) {
                textColor("Wat is uw geslacht?\n[1] Man \n[2] Vrouw \n[3] anders ", 14, false);
                gender = Console.ReadLine();

                if(gender == "1") { gender = "Man"; break; }
                else if(gender == "2") { gender = "Vrouw"; break; }
                else if(gender == "3") { gender = "Anders"; break; }
                else { textColor("U heeft niet een van de bovenstaande keuzes gekozen.", 14, false); }
            }
            while(true){
                int length = 8;
                StringBuilder str_build= new StringBuilder(); 
                Random random = new Random();  

                char letter;  

                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    
                    str_build.Append(letter);  
                }  
                rndCode = str_build.ToString();
                Console.Clear();
                
               
                textColor("Bedankt voor het het reserveren.\nUw reserveringscode is: ", 14, true);
                textColor(rndCode, 9, false);
                tools.textColor("\n>> Terug", 14, false);
                while (true) {
                    var key = Console.ReadKey();
                    if (key.Key.ToString() == "Enter" && Login.user == null) {Console.Clear(); Menu.Mainmenu();}
                    else {continue;}
                
            Reserves obj = new Reserves {
                userEmail = userEmail,
                firstName = firstName,
                insertion = insertion,
                lastName = lastName,
                birthDay = birthDay,
                gender = gender,
                rndcode = rndCode,
                
            };
            
            // JSON
            dataStorageHandler.storage.Reserve.Add(obj);
            dataStorageHandler.saveChanges();
            }
        }
        }
        public static void ReserveManage(){
            Console.Clear();
            
        }    
           
    }
}


        
    

