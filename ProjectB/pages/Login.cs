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
        public static personAccounts user { get; set; }
        public static void loginMain() {
            login();
        }

        public static void login() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
         
            
            List<personAccounts> a = dataStorageHandler.storage.personAccount;
            
            int count = 0;
            while(true) {
                Console.Clear();
                tools.textColor("Email: ", 14, true);
                string email = Console.ReadLine();
                tools.textColor("Wachtwoord: ", 14, true);
                string password = Console.ReadLine();
                var len = a.Count;
                for(int i = 0; i < len; i++) {
                    if(a[i].userEmail == email && a[i].password == password) {
                        user = a[i];
                        Menu.dashboard();
                    } else {
                        tools.textColor("Email en wachtwoord komen niet overeen", 12, true);
                        count++;
                    }
                    if(count == 4) {
                        Menu.Mainmenu();
                    }
                }
            }
        }

        public static void logout() {
            Console.Clear();
            user = null;
            Menu.Mainmenu();
        }
    }
}