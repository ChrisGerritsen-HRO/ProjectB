using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectB.pages
{
    class Login
    {
        public static dynamic user { get; set; }
        public static void loginMain() {
            login();
        }

        public static void login() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            
            bool loginBool = true;
            while(loginBool) {
                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                Console.WriteLine("Wachtwoord: ");
                string password = Console.ReadLine();

                var len = ((Newtonsoft.Json.Linq.JArray)obj.personAccount).Count;
                for(int i = 0; i < len; i++) {
                    if(obj.personAccount[i].userEmail == email && obj.personAccount[i].password == password) {
                        user = obj.personAccount[i];

                        // if(obj.personAccount[i].gender == "man") {
                        //     Console.WriteLine($"Welkom Dhr. {obj.personAccount[i].lastName}");
                        // } else if (obj.personAccount[i].gender == "vrouw") {
                        //     Console.WriteLine($"Welkom Mevr. {obj.personAccount[i].lastName}");
                        // } else {
                        //     Console.WriteLine($"Welkom {obj.personAccount[i].firstName} {obj.personAccount[i].lastName}");
                        // }
                        loginBool = false;
                    }
                }
            }
            Menu.dashboard();
        }

        public static void logout() {
            Console.Clear();
            user = "";
            Menu.mainMenu();
        }
    }
}