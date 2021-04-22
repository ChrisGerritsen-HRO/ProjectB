using ProjectB.DAL;
using ProjectB.pages;
using ProjectB.classes;
using System;

namespace ProjectB.pages
{
    class Menu
    {
        public static void mainMenu()
        {
            tools.textColor("Welkom, wat wilt u doen?", 14, false);
            tools.textColor("[1] Account aanmaken\n[2] Inloggen\n[3] Kaartje reserveren\n[4] Film lijst\n[5] Beheerders\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "4") {
                    movieList.listMain();
                    mainMenu();
                    break;
                    } 
                if (userinput == "5") {
                    movieAdmin.moviesMain();
                    mainMenu();
                } else {
                    tools.textColor("Alleen optie 4 en 5 zijn beschikbaar", 4, false);
                }
            }
        }
    }
}