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
            tools.textColor("[1] Film toevoegen\n[2] Film verwijderen\n[3] Terug naar hoofdmenu\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "1") {
                    createMovie();
                } 
                if (userinput == "2") {
                    removeMovie();
                }
                if (userinput == "3") {
                    Console.Clear();                    
                    Menu.mainMenu();
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

                movies obj = new movies {
                    movieName = moviename,
                    movieAge = movieage,
                    movieGenre = moviegenre,

                };            

                // JSON
                dataStorageHandler.storage.movie.Add(obj);
                dataStorageHandler.saveChanges();

                tools.textColor("Nog een film toevoegen [1]", 14, false);
                tools.textColor("Terug gaan [2]", 14, false);
                if(Console.ReadLine() == "2"){
                    Console.Clear();
                    moviesMain();
                }
            }


        }

        public static void removeMovie() {
            while(true) {
                Console.Clear();
                string fileContent = File.ReadAllText("storage.json");
                dynamic obj = JsonConvert.DeserializeObject(fileContent);
                int arrLen = 0;

                try // Gaat hier controleren of er al een object bestaat in de JSON array
                {
                    dynamic obj1 = JsonConvert.DeserializeObject(fileContent);

                    if (((Newtonsoft.Json.Linq.JArray)obj1.movie).Count > 0) {  // Zo ja geef de aantal door
                        arrLen = ((Newtonsoft.Json.Linq.JArray)obj1.movie).Count; 
                    }
                }
                catch
                {
                    arrLen = 0;
                }

                if(arrLen == 0) {
                    tools.textColor("Er zijn nog geen films geregistreerd!", 12, false);

                } else {
                    for(int i = 0; i < arrLen; i++) {
                     tools.textColor($"ID: {i}\nNaam : {obj.movie[i].movieName}\nLeeftijd : {obj.movie[i].movieAge}\nGenre : {obj.movie[i].movieGenre}\n", 14, false);
                    }

                    int selectedID = Convert.ToInt32(Console.ReadLine());
                    string deletedMovie = obj.movie[selectedID].movieName;

                    dataStorageHandler.storage.movie.RemoveAt(selectedID); // verwijderd de object in de array van de gewenste index(selectedID)
                    dataStorageHandler.saveChanges();
                    Console.Clear();
                    tools.textColor($"{deletedMovie} is succesvol verwijderd\n", 15, false);                    

                }


                tools.textColor("[1] Nog een film verwijderen\n[2] Terug gaan\n", 15, false);
                if(Console.ReadLine() == "1") {
                    continue;
                } else if(Console.ReadLine() == "2") {
                    Console.Clear();
                    moviesMain();
                }
            }
        }
    }
}

