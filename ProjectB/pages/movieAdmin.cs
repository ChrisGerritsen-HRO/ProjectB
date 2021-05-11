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
                } else if (userinput == "2") {
                    removeMovie();
                } else if (userinput == "3") {
                    Console.Clear();                    
                    Menu.Mainmenu();
                } else {
                    tools.textColor("Deze optie is niet beschikbaar", 4, false);
                }
            }
        }        
        public static void createMovie() {
            Console.Clear();
            string moviename, moviegenre, movietime, moviedescription;
            int movieage, movietheater, movieduration;
            while(true){
                Console.Clear();
                tools.textColor("Film naam: ", 14, false);
                moviename = Console.ReadLine();

                tools.textColor("Film beschrijving: ", 14, false);
                moviedescription = Console.ReadLine();

                while(true) {
                    tools.textColor("Film minumum leeftijd: ", 14, false);
                    string ageinput = Console.ReadLine();
                    int value;
                    if (int.TryParse(ageinput, out value)) {
                        movieage = Convert.ToInt32(ageinput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }

                tools.textColor("Film genre: ", 14, false);
                moviegenre = Console.ReadLine();

                tools.textColor("Film tijd: ", 14, false);
                movietime = Console.ReadLine();

                while(true) {
                    tools.textColor("Film duur: ", 14, false);
                    string durationinput = Console.ReadLine();
                    int value;
                    if (int.TryParse(durationinput, out value)) {
                        movieduration = Convert.ToInt32(durationinput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }   

                while(true) {
                    tools.textColor("Film zaal: ", 14, false);
                    string theatherinput = Console.ReadLine();
                    int value;
                    if (int.TryParse(theatherinput, out value)) {
                        movietheater = Convert.ToInt32(theatherinput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }                

                movies obj = new movies {
                    movieName = moviename,
                    movieDescription = moviedescription,
                    movieAge = movieage,
                    movieGenre = moviegenre,
                    movieTime = movietime,
                    movieDuration = movieduration,
                    movieTheater = movietheater,

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
                        tools.textColor("----------------------------", 14, false);
                        tools.textColor($"ID           | {i}\nNaam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
                    }

                    int selectedID = 0;
                    while(true){
                        tools.textColor("ID van het te verwijderen film: ", 14, true);
                        selectedID = Convert.ToInt32(Console.ReadLine());
                        if(selectedID > arrLen-1 || selectedID < 0) { // Als de ingevoerde ID hoger is dan de hoogste ID dan onderstaande uitgevoerd
                            tools.textColor("Dit is geen gelde film ID!", 12, false);
                        } else {
                            break;
                        }
                    }
                    string deletedMovie = obj.movie[selectedID].movieName;

                    dataStorageHandler.storage.movie.RemoveAt(selectedID); // verwijderd de object in de array van de gewenste index(selectedID)
                    dataStorageHandler.saveChanges();
                    Console.Clear();
                    tools.textColor("de film ", 15, true); tools.textColor($"{deletedMovie}", 11, true); tools.textColor(" is succesvol verwijderd\n", 15, false);                    

                }


                tools.textColor("[1] Nog een film verwijderen\n[2] Terug gaan\n", 15, false);
                var userinput = Console.ReadLine();
                if(userinput == "1") {
                    continue;
                } else if(userinput == "2") {
                    Console.Clear();
                    moviesMain();
                }
            }
        }
    }
}