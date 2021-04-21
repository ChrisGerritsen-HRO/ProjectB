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

        public static void filmlijst() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            var len = ((Newtonsoft.Json.Linq.JArray)obj.personAccount).Count;
            for(int i = 0; i < len; i++) {
                tools.textColor($"Filmnaam : {obj.movie[i].movieName}\nFilmleeftijd : {obj.movie[i].movieAge}\n", 14, false);
            } 

            tools.textColor("[1] Terug gaan\n", 15, false);
            if(Console.ReadLine() == "1") {
                Console.Clear();
                Menu.mainMenu();
            }

        }        
    }
}