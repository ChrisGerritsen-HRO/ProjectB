using System;
using ProjectB.classes;
using ProjectB.DAL;

namespace ProjectB.pages
{
    class userAdmin
    {
        public static void choice() {
            Console.Clear();
            string listMenu = Menu.Menubuilder($"Gebruikers beheren" + "\n", new string[] {"Gebruikers lijst", "Gebruiker toevoegen", "Gebruiker verwijderen", "Gebruiker role aanpassen"}, 10, 14);
            if(listMenu == "Gebruikers lijst") {
                listUsers();
            } else if(listMenu == "Gebruiker toevoegen") {
                //addUser();
            } else if(listMenu == "Gebruiker verwijderen") {
                //removeUser();
            } else if (listMenu == "Gebruiker role aanpassen") {
                //addjustUser();
            }
        }

        public static void  listUsers() {
            foreach(var item in dataStorageHandler.storage.personAccount) {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Voornaam     | {item.firstName}\nAchternaam   |{item.insertion} {item.lastName}\nVerjaardag   | {item.birthDay.ToString("MM/dd/yyyy")}\nGeslacht     | {item.gender}\nRole         | {item.role}", 14, false);
            }
            Console.ReadLine();
        }
    }
}
