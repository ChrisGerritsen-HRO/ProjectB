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
            tools.textColor("Welcome, what would you like to do?", 14, false);
            tools.textColor("[1] create account\n[2] login\n[3] buy ticket\n[4] film lijst\n[5] admin\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "4") {
                    movieList.filmlijst();
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