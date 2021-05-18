using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;


namespace ProjectB.pages
{
    public class Reserve
    {   public static void ReserveMain() {
            Console.Clear();
            string movieMenu = Menu.Menubuilder($"Reservatie beheren" + "\n", new string[] {"Reservatie verwijderen", "Reservatie bekijken", "Terug naar hoofdmenu"}, 10, 14);
            if(movieMenu == "Resereatie verwijderen") {
                
            } else if(movieMenu == "Reservatie bekijken") {
                movieList.choice();
            } else if(movieMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }
    }
}
