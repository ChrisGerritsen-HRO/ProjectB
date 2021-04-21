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
            tools.textColor("Welkom beheerder, wat wilt u doen?", 14, false);
            tools.textColor("[1] Film toevoegen\n[2] Film \n", 15, false);
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
            createMovie();
        }        
        public static void createMovie() {
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
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj1 = JsonConvert.DeserializeObject(fileContent);
            movies obj = new movies {
                movieID = ((Newtonsoft.Json.Linq.JArray)obj1.movie).Count,
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

