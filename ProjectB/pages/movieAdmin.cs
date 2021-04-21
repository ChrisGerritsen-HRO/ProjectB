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
            Console.Clear();
            tools.textColor("Welkom beheerder, wat wilt u doen?", 14, false);
            tools.textColor("[1] Film toevoegen\n[2] Film\n[3] Terug naar hoofdmenu\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "1") {
                    createMovie();
                    } 
                if (userinput == "2") {
                    removeMovie();
                if (userinput == "3") {
                    break;
                }
                } else {
                    tools.textColor("Deze optie is niet beschikbaar", 4, false);
                }
            }
        }        
        public static void createMovie() {
            Console.Clear();
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
            int arrLen = 0;
            if(obj1.movie != null) {
                arrLen = ((Newtonsoft.Json.Linq.JArray)obj1.movie).Count;
            }
            movies obj = new movies {
                movieID = arrLen,
                movieName = moviename,
                movieAge = movieage,
                movieGenre = moviegenre,

            };            

            // JSON
            dataStorageHandler.storage.movie.Add(obj);
            dataStorageHandler.saveChanges();
            Menu.mainMenu();
        }

        public static void removeMovie() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            var len = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count;
            for(int i = 0; i < len; i++) {
                tools.textColor($"ID: {obj.movie[i].movieID}\nNaam : {obj.movie[i].movieName}\nLeeftijd : {obj.movie[i].movieAge}\nGenre : {obj.movie[i].movieGenre}\n", 14, false);
            } 

            tools.textColor("[1] Terug gaan\n", 15, false);
            if(Console.ReadLine() == "1") {
                Console.Clear();
                moviesMain();
            }
        }
    }
}

