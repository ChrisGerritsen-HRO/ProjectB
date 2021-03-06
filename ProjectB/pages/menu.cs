using System;
using ProjectB.classes;

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
            string mainmenu = Menubuilder(@" __    __     ______     __   __   __     ______        ______     ______   ______     ______    
/\ '-./  \   /\  __ \   /\ \ / /  /\ \   /\  ___\      /\  ___\   /\__  _\ /\  __ \   /\  == \   
\ \ \-./\ \  \ \ \/\ \  \ \ \'/   \ \ \  \ \  __\      \ \___  \  \/_/\ \/ \ \  __ \  \ \  __<   
 \ \_\ \ \_\  \ \_____\  \ \__|    \ \_\  \ \_____\     \/\_____\    \ \_\  \ \_\ \_\  \ \_\ \_\ 
  \/_/  \/_/   \/_____/   \/_/      \/_/   \/_____/      \/_____/     \/_/   \/_/\/_/   \/_/ /_/ 
                                                                                                 
" + "\n", new string[] { "Registreer", "Inloggen", "Films", "Over", "Afsluiten" }, 12, 14);
            if (mainmenu == "Registreer") {
                Console.Clear();
                Register.registerMain();
            } else if (mainmenu == "Inloggen") {
                Console.Clear();
                Login.loginMain();
            } else if (mainmenu == "Films") {
                movieList.choice();
            } else if (mainmenu == "Over") {
                About.aboutPage();
            } else if (mainmenu == "Afsluiten") {
                Environment.Exit(0);
            }
        }

        public static void dashboard() {
            Console.Clear();
            
            personAccounts user = (personAccounts)Login.user;
        
            if (user != null && user.role != null && (user.role) ==  "user") {
                userMenu();
            } else if (user != null && user.role == "admin") {
                adminMenu();
            } else { 
                Mainmenu();
            }
        }

        public static void userMenu() {
            string userMenu = Menubuilder($"Welkom: {Login.user.firstName}" + "\n", new string[] {"Films bekijken", "Reserveren", "Mijn reserveringen", "Reservering annuleren", "Uitloggen"}, 14, 14);
            if (userMenu == "Films bekijken") {
                movieList.choice();
            } else if (userMenu == "Reserveren") {
                reserveUser.reserveUserMain();
            } else if (userMenu == "Mijn reserveringen") {
                reserveUser.viewUserReservation();
            } else if (userMenu == "Reservering annuleren") {
                reserveUser.cancelUserReservation();
            } else if (userMenu == "Uitloggen") {
                Login.logout();
            }
        } 
        public static void adminMenu() {
            string adminMenu = Menubuilder($"Welkom: {Login.user.firstName}" + "\n", new string[] {"Reserveringen beheren", "Films beheren", "Zalen beheren", "Snacks beheren", "Gebruikers beheren", "Uitloggen"}, 14, 14);
            if (adminMenu == "Reserveringen beheren") {
                Menu.dashboard();
            } else if (adminMenu == "Films beheren") {
                movieAdmin.moviesMain();
            } else if (adminMenu == "Zalen beheren") {
                roomAdmin.roomMain();
            } else if (adminMenu == "Snacks beheren") {
                snacksAdmin.snacksMain();
            } else if (adminMenu == "Gebruikers beheren") {
                userAdmin.choice();
            } else if (adminMenu == "Uitloggen") {
                Login.logout();
            }
        }

        public static string Menubuilder(string title, string[] items, int titleColor, int SelectColor)
        {
            int currentItem = 0; //geselecteerde item
            while (true)
            {
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
                Console.Clear();
            }
            return items[currentItem]; //geeft de naam van de item dat geselecteerd is terug 
        }
    }
}