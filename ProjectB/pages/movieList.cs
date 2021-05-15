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
            string userinput = Menu.Menubuilder(@" ______   __     __         __    __     ______    
/\  ___\ /\ \   /\ \       /\ '-./  \   /\  ___\   
\ \  __\ \ \ \  \ \ \____  \ \ \-./\ \  \ \___  \  
 \ \_\    \ \_\  \ \_____\  \ \_\ \ \_\  \/\_____\ 
  \/_/     \/_/   \/_____/   \/_/  \/_/   \/_____/ " + "\n", new string[] {"Hele filmlijst", "Zoeken in filmlijst", "Terug"}, 12, 14);
            if (userinput == "Hele filmlijst" ) {listMain();}
            else if (userinput == "Zoeken in filmlijst") {search.filmlijst();}
            else if (userinput == "Terug") {Menu.Mainmenu();}
        }
        public static void listMain() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            var len = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count;
            for(int i = 0; i < len; i++) {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre     | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
            } 

            tools.textColor("[1] Terug gaan\n", 15, false);
            if(Console.ReadLine() == "1") {
                Console.Clear();
                Menu.Mainmenu();
            }

        }     
    }
}


    