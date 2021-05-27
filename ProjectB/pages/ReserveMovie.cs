using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectB.pages
{
    class reserveMovie {
        public static void reserveMain() {
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            for(int i = 0; i < dataStorageHandler.storage.movie.Count; i++)
            {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"ID          | {i}\nNaam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nDuur         | {obj.movie[i].movieDuration} minuten", 14, false);
            }
            
            while(true){
                tools.textColor("Kies een film: ", 14, true);
                int selectedID;
                selectedID = Convert.ToInt32(Console.ReadLine());
                if(selectedID > dataStorageHandler.storage.movie.Count-1 || selectedID < 0) { // Als de ingevoerde ID hoger is dan de hoogste ID dan onderstaande uitgevoerd
                    tools.textColor("Dit is geen gelde film ID!", 12, false);
                } else {
                    int thefilmID = obj.movie[selectedID].movieID;
                    reserveTimesheet(thefilmID);
                    break;
                }
            }
        }
        public static void reserveTimesheet(int movieID) {
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            tools.textColor("Hieronder de beschikbare films", 14, false);
            foreach(var item in dataStorageHandler.storage.MoviePlanning) {
                if(item.movieID == movieID) {
                    tools.textColor("----------------------------", 14, false);
                    tools.textColor($"Naam         | {item.movieName}\nTijdstip      | {item.movieTime.ToString("HH:mm")}", 14, false);
                }
            }
            string test = Console.ReadLine(); 
        }
    }
}