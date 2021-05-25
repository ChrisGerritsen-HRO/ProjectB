using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    class movieRosterAdmin {
        public static dataStorage storage { get; set; }

        public static void movieRosterMain() {
            string movieRosterMenu = Menu.Menubuilder("Film schema beheren" + "\n", new string[] {"Film toevoegen aan schema", "Film schema bekijken", "Terug naar hoofdmenu?"}, 10, 14);
            if(movieRosterMenu == "Film toevoegen aan schema") {
                createMovieRoster();
            } else if(movieRosterMenu == "Film schema bekijken") {
                showMovieRoster();
            } else if(movieRosterMenu == "Terug naar hoofdmenu?") {
                Menu.dashboard();
            }
        }
        public static void createMovieRoster() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);

            Console.WriteLine("Hoi Hoi");

            if(storage.movieRoom != null && storage.movie != null) {
                foreach (var item in storage.movie)
                {
                    Console.WriteLine(item.movieName);
                }
            }
        }

        public static void showMovieRoster() {
            Console.Clear();
            Console.WriteLine("Dit is het film schema");
        }
    }
}