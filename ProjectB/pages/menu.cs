using System;

namespace ProjectB.pages
{
    public class Menu
    {
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }
        
        public static void Mainmenu()
        {
            string mainmenu = Menubuilder(@"  _     _                                                               
 | |   (_)                                                              
 | |__  _  ___  ___  ___ ___   ___  _ __    _ __   __ _  __ _ _ __ ___  
 | '_ \| |/ _ \/ __|/ __/ _ \ / _ \| '_ \  | '_ \ / _` |/ _` | '_ ` _ \ 
 | |_) | | (_) \__ \ (_| (_) | (_) | |_) | | | | | (_| | (_| | | | | | |
 |_.__/|_|\___/|___/\___\___/ \___/| .__/  |_| |_|\__,_|\__,_|_| |_| |_|
                                   | |                                  
                                   |_|                                  " + "\n", new string[] { "Registreer", "Inloggen", "Films", "Over", "Afsluiten" }, 12, 14);
            if (mainmenu == "Registreer") {
                Console.Clear();
                Register.registerMain();
            } else if (mainmenu == "Inloggen") {
                Console.Clear();
                Login.loginMain();
            } else if (mainmenu == "Films") {
                Console.WriteLine("geen films jammer joh.");
            } else if (mainmenu == "Over") {
                Console.WriteLine("Hier komt over");
            } else if (mainmenu == "Afsluiten") {
                Environment.Exit(0);
            }
        }

        public static void dashboard() {
            Console.Clear();
            if (Login.user is not null && Login.user.role == "user") {
                userMenu();
            } else if (Login.user is not null && Login.user.role == "admin") {
                adminMenu();
            }
        }

        public static void userMenu() {
            string userMenu = Menubuilder($"Welkom: {Login.user.firstName}" + "\n", new string[] {"Films bekijken", "Reserveren", "Mijn reserveringen", "Uitloggen"}, 12, 14);
            if (userMenu == "Films bekijken") {
                movieList.listMain();
            } else if (userMenu == "Reserveren") {

            } else if (userMenu == "Mijn reserveringen") {

            } else if (userMenu == "Uiloggen") {
                Login.logout();
            }
        } 
        public static void adminMenu() {
            string adminMenu = Menubuilder($"Welkom: {Login.user.firstName}" + "\n", new string[] {"Reserveringen beheren", "Films beheren", "Zalen beheren", "Gebruikers beheren", "Uitloggen"}, 12, 14);
            if (adminMenu == "Reserveringen beheren") {

            } else if (adminMenu == "Films beheren") {
                movieAdmin.moviesMain();
            } else if (adminMenu == "Zalen beheren") {
                roomAdmin.roomMain();
            } else if (adminMenu == "Gebruikers beheren") {

            } else if (adminMenu == "Uitloggen") {
                Login.logout();
            }
        }

        static string Menubuilder(string title, string[] items, int titleColor, int SelectColor)
        {
            int currentItem = 0; //geselecteerde item
            while (true)
            {
                Console.Clear();
                textColor(title, titleColor, false); //print title
                for (int i = 0; i < items.Length; i++) //print alle items uit het menu, met de geselecteerde item gekleurd
                {
                    if (currentItem == i)
                    {
                        textColor(">>" + items[i] + "  ", SelectColor, false);
                    }
                    else
                    {
                        textColor("  " + items[i] + "  ", 15, false);
                    }
                }
                ConsoleKeyInfo key;
                key = Console.ReadKey(true); //wacht tot de user een input geeft
                if (key.Key.ToString() == "DownArrow")
                {
                    currentItem++;
                    if (currentItem > items.Length - 1) { currentItem = 0; }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentItem--;
                    if (currentItem < 0) { currentItem = items.Length - 1; }
                }
                else if (key.Key.ToString() == "Enter")
                {
                    break;
                }
                else { continue; }
            }
            Console.Clear();
            return items[currentItem]; //geeft de naam van de item dat geselecteerd is terug 
        }
    }
}