using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    public class movieAdmin {
        public static dataStorage storage { get; set; }
        public static void moviesMain() {
            Console.Clear();
            string movieMenu = Menu.Menubuilder($"Films beheren" + "\n", new string[] {"Film toevoegen", "Films verwijderen", "Films bekijken", "Terug naar hoofdmenu"}, 10, 14);
            if(movieMenu == "Film toevoegen") {
                createMovie();
            } else if(movieMenu == "Films verwijderen") {
                removeMovie();
            } else if(movieMenu == "Films bekijken") {
                movieList.choice();
            } else if(movieMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }
        public static void listMain() {
            Console.Clear();

            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

         //   var len = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count;
            foreach(var item in dataStorageHandler.storage.movie)
{
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Naam         | {item.movieName}\nBeschrijving | {item.movieDescription}\nLeeftijd     | {item.movieAge}+\nGenre        | {item.movieGenre}\nTijdstip     | " + movieAdmin.movieSequence(item) + $"\nDuur         | {item.movieDuration} minuten\nZaal         | {item.movieTheater}\n", 14, false);
            }  

            string back = Menu.Menubuilder($"" + "\n", new string[] {"Terug?"}, 14, 14);
            if(back == "Terug?") {
                movieAdmin.moviesMain();
            }
        }        
        public static void createMovie() {
            Console.Clear();
            string moviename, moviegenre, moviedescription;
            int movieage, movietheater, movieduration;
            DateTime movietime;
            string fileContent = File.ReadAllText("storage.json");
            dynamic room = JsonConvert.DeserializeObject(fileContent);
            var lenRoom = ((Newtonsoft.Json.Linq.JArray)room.movieRoom).Count;

            if(lenRoom == 0) {
                tools.textColor("Er zijn nog geen zalen, maak een zaal aan!", 12, false);
                string back = Menu.Menubuilder($"" + "\n", new string[] {"Terug?"}, 14, 14);
                if(back == "Terug?") {
                    moviesMain();
                }
            } 
            while(true){
                Console.Clear();
                tools.textColor("Film naam: ", 14, false);
                moviename = Console.ReadLine();

                tools.textColor("Film beschrijving: ", 14, false);
                moviedescription = Console.ReadLine();

                while(true) {
                    tools.textColor("Film minumum leeftijd: ", 14, false);
                    string ageinput = Console.ReadLine();
                    int avalue;
                    if (int.TryParse(ageinput, out avalue)) {
                        movieage = Convert.ToInt32(ageinput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }

                tools.textColor("Film genre: ", 14, false);
                moviegenre = Console.ReadLine();

                while(true) {
                    tools.textColor("Film duur (in minuten): ", 14, false);
                    string durationinput = Console.ReadLine();
                    int value;
                    if (int.TryParse(durationinput, out value)) {
                        movieduration = Convert.ToInt32(durationinput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }   

                while(true) {
                    tools.textColor("Begintijd (HH:MM): ", 14, false);
                    string timeinput = Console.ReadLine();
                    try 
                    {
                        movietime = DateTime.Parse(timeinput);
                        break;
                    }
                    catch (FormatException) 
                    {
                        tools.textColor("Verkeerde opmaak, gebruik HH:mm", 12, false);
                    }
                    
                }  

                

                while(true) {
                    var len = ((Newtonsoft.Json.Linq.JArray)room.movieRoom).Count;
                    for(int i = 0; i < len; i++) {
                        tools.textColor("----------------------------", 14, false);
                        tools.textColor($"Zaal nummer  | {room.movieRoom[i].roomNumber}\nSoort zaal   | {room.movieRoom[i].roomKind}", 14, false);
                    }

                    tools.textColor("Film zaal nummer: ", 14, false);
                    string theatherinput = Console.ReadLine();
                    int value;
                    if (int.TryParse(theatherinput, out value)) {
                        movietheater = Convert.ToInt32(theatherinput);
                        bool check = false;
                        for(int i = 0; i < len; i++) {
                            int roomNumber = room.movieRoom[i].roomNumber;
                            if(movietheater == roomNumber ) {
                                check = true;
                                break;
                            }
                        }
                        if(check == false) {
                            tools.textColor("De zaal bestaat niet probeer het opnieuw", 12, false);
                            continue;
                        } else {
                            break;
                        }
                    } else { 
                        tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); 
                    }
                } 

                movies obj = new movies {
                    movieName = moviename,
                    movieID = moviename.GetHashCode(),
                    movieDescription = moviedescription,
                    movieAge = movieage,
                    movieGenre = moviegenre,
                    movieTime = movietime,
                    movieEndTime = movietime.Add(new TimeSpan(0,movieduration,0)),
                    movieDuration = movieduration,
                    movieTheater = movietheater,

                };            

                // JSON
                dataStorageHandler.storage.movie.Add(obj);
                dataStorageHandler.saveChanges();
                
                Console.Clear();
                string back = Menu.Menubuilder("Film " + moviename + " is toegevoegd" + "\n", new string[] {"Nog een film toevoegen", "Film lijst bekijken", "Terug?"}, 10, 14);
                if(back == "Nog een zaal toevoegen") {
                    createMovie();
                } else if(back == "Terug?") {
                    moviesMain();
                } else if(back == "Film lijst bekijken") {
                    movieList.listMain();
                }
            }
        }

        public static void removeMovie() {
            while(true) {
                Console.Clear();
                string fileContent = File.ReadAllText("storage.json");
                dynamic obj = JsonConvert.DeserializeObject(fileContent);
                int arrLen = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count; 
                if(arrLen == 0) {
                    tools.textColor("Er zijn nog geen films geregistreerd!", 12, false);

                } else {
                    for(int i = 0; i < arrLen; i++) {
                        tools.textColor("----------------------------", 14, false);
                        tools.textColor($"ID           | {i}\nNaam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijden     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
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
                
                string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een film verwijderen", "Terug?"}, 14, 14);
                if(back == "Nog een film verwijderen") {
                    createMovie();
                } else if(back == "Terug?") {
                    moviesMain();
                }
            }
        }
        public static string movieSequence(movies thename) {
        //     string fileContent = File.ReadAllText("storage.json");
        //     dynamic movie = JsonConvert.DeserializeObject(fileContent);
        //     movies themovie = dataStorageHandler.storage.movie[0];
        //   //  var len = ((Newtonsoft.Json.Linq.JArray)movie.movie).Count;
        //     // foreach(var item in dataStorageHandler.storage.movie)
        //     // {
        //     //     if(item.movieName == thename);
        //     //         themovie = item;
        //     //         break;
        //     // }
        //     DateTime endDay = new DateTime(2021, 4 , 2, 22, 00, 00);
        // //    DateTime thetime = themovie.movieTime;
        //     // int hour = themovie.movieDuration / 60;
        //     // int minutes = (hour * 60) - themovie.movieDuration;
        //     // if (minutes >= 60) {
        //     //     minutes =- 60;
        //     //     hour++;
        //     // }
            
        //   //  DateTime startnewmovie = themovie.movieEndTime.Add(new TimeSpan(0,30,0));

        //     string thewholestring = themovie.movieTime;
        string thewholestring = thename.movieTime.Add()
           
             
            
            return thewholestring;
        }
    }
}
