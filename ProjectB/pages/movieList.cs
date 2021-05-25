using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;

namespace ProjectB.pages 
{
    class movieList {
        public static dataStorage storage { get; set; }

        public static void choice() {
            Console.Clear();
            string listMenu = Menu.Menubuilder($"Films bekijken" + "\n", new string[] {"Hele filmlijst", "Zoeken in filmlijst", "Terug naar hoofdmenu"}, 10, 14);
            if(listMenu == "Hele filmlijst") {
                listMain();
            } else if(listMenu == "Zoeken in filmlijst") {
                search.movieSearch();
            } else if(listMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }
        public static void listMain() {
            Console.Clear();

            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            var len = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count;
            for(int i = 0; i < len; i++) {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
            } 

            tools.textColor(">> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {
                    if (Login.user is not null) {Console.Clear(); Menu.dashboard();}
                    else {Console.Clear(); Menu.Mainmenu();}
                }
                else {continue;}
            }
        }
    }
}