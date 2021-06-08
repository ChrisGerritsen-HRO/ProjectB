using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectB.pages
{
    class reserveMovie {
        public static int reserverMovieID { get; set; }
        public static int reserveMovieTimeID { get; set; }
        public static void reserveMain() {
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            for(int i = 0; i < dataStorageHandler.storage.movie.Count; i++)
            {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"ID           | {i}\nNaam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nDuur         | {obj.movie[i].movieDuration} minuten", 14, false);
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
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            tools.textColor("Hieronder de beschikbare films", 14, false);

            foreach(var item in dataStorageHandler.storage.MoviePlanning) {
                if(item.movieID == movieID) {
                    tools.textColor("----------------------------", 14, false);
                    tools.textColor($"Naam       | {item.movieName}\nTijdstip   | {item.movieTime.ToString("HH:mm")}", 14, false);
                }
            }

            tools.textColor("Type de gewenste tijd over", 14, false);
            string timeSelected = Console.ReadLine();
            foreach(var item in dataStorageHandler.storage.MoviePlanning) {
                if(timeSelected == item.movieTime.ToString("HH:mm") && item.movieID == movieID) {
                    reserverMovieID = movieID;
                    reserveMovieTimeID = item.movieTimeID;
                    Console.WriteLine(timeSelected); // hier kan je naar de functie gaan van stoel selecteren en aantal
                    string[] seats = new string[0];
                    int rows = 0;
                    int columns = 0;
                    string[] seatPrice = new string[0];
                    int moviePlanLen = ((Newtonsoft.Json.Linq.JArray)obj.MoviePlanning).Count;
                    for (var i = 0; i < moviePlanLen; i++)
                    {
                        if (reserveMovieTimeID == obj.MoviePlanning[i].movieTimeID)
                        {
                            foreach (var items in obj.movieRoom)
                            {
                                if (obj.MoviePlanning[i].movieTheater == items.roomNumber)
                                {
                                    rows = items.rows;
                                    columns = items.columns;
                                    Array.Resize(ref seats, rows * columns);
                                    Array.Resize(ref seatPrice, rows * columns);
                                    for (var j = 0; j < obj.movieRoom.seats.Count; j++)
                                    {
                                        seats[j] = obj.movieRoom[i].seats[j];
                                        seatPrice[j] = obj.MoviePlanning[i].seatPrice[j];
                                    }
                                }
                            }
                        }
                    }
                    rooms.selectChair(seatPrice, seats, rows, columns);



                    /*for (int i = 0; i < arrLen; i++)
            {
                int roomNumber = objContent.movieRoom[i].roomNumber;
                if(movieTheater == roomNumber) {
                    int rows = objContent.movieRoom[i].rows;
                    int columns = objContent.movieRoom[i].columns;
                    Array.Resize(ref roomSeats, rows * columns);
                    // roomSeats = objContent.movieRoom[i].seats;
                    // foreach (var item in objContent.movieRoom[i].seats)
                    // {
                    //     roomSeatsList.Add(item);
                    // }
                    for (int j = 0; j < objContent.movieRoom[i].seatPrice.Count; j++)
                    {
                        roomSeats[j] = objContent.movieRoom[i].seatPrice[j];
                    }
                }
            }*/

                    //string[] seatPrice, string[] room, int rows, int columns
                    break;
                }
            }
            tools.textColor("Dit is geen geldig tijdstip!", 12, false);
        }
    }
}