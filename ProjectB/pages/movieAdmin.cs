using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    class movieAdmin {
        public static dataStorage storage { get; set; }
        public static void moviesMain() {
            userInput();
        }        
        public static void userInput() {
            string moviename, moviegenre;
            int movieage;
            while(true){
                Console.Clear();
                tools.textColor("film naam: ", 14, false);
                moviename = Console.ReadLine();
                tools.textColor("leeftijd film: ", 14, false);
                movieage = Convert.ToInt32(Console.ReadLine());
                tools.textColor("genre: ", 14, false);
                moviegenre = Console.ReadLine();
                tools.textColor("Nog een film toevoegen? [1]", 14, false);
                tools.textColor("Menu afsluiten? [2]", 14, false);
                if(Console.ReadLine() == "2"){
                    Console.Clear();
                    break;
                }
            }
            movies obj = new movies {
                movieName = moviename,
                movieAge = movieage,
                movieGenre = moviegenre,

            };            

            // JSON
            dataStorageHandler.storage.movie.Add(obj);
            dataStorageHandler.saveChanges();
            Menu.mainMenu();
        }
    }
}

