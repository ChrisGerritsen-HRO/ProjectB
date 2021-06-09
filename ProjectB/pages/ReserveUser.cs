using Newtonsoft.Json;
using ProjectB.classes;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ProjectB.DAL;
using System.Text;

namespace ProjectB.pages
{
    class reserveUser {
        public static dataStorage storage { get; set; }
        public static string reservationID { get; set; }
        public static void reserveUserMain() {
            makeReservationID();
            reserveMovie.reserveMain();
        }

        public static void makeReservationID() {
            int length = 8;
                StringBuilder str_build= new StringBuilder(); 
                Random random = new Random();  

                char letter;  

                for (int i = 0; i < length; i++)
                {
                    double flt = random.NextDouble();
                    int shift = Convert.ToInt32(Math.Floor(25 * flt));
                    letter = Convert.ToChar(shift + 65);
                    
                    str_build.Append(letter);  
                }  
                reservationID = str_build.ToString();
        }

        public static void finishReservation() {
            reservation obj = new reservation {
                userMail = Login.user.userEmail,
                movieID = reserveMovie.reserverMovieID,
                movieTimeID = reserveMovie.reserveMovieTimeID,
                roomNumber = reserveRoom.roomNum,
                roomSeats = reserveRoom.seats,
                snacks = reserveSnack.snacksList,
                reservationID = reservationID
            };

            dataStorageHandler.storage.Reservations.Add(obj);
            dataStorageHandler.saveChanges();
        }

        public static void viewUserReservation() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);
            string reservationList = "";

            if(storage.Reservations != null) {
                for (int i = 0; i < storage.Reservations.Count; i++)
                {
                    string storedEmail = storage.Reservations[i].userMail;
                    string userEmail = Login.user.userEmail;
                    int movieTimeID = storage.Reservations[i].movieTimeID;

                    string movieName = "";
                    string movieStartTime = "";
                    int movieRoom = 0;
                    
                    if(storedEmail == userEmail) {
                        for (int j = 0; j < storage.MoviePlanning.Count; j++)
                        {
                            if(movieTimeID == storage.MoviePlanning[j].movieTimeID) {
                                movieName = storage.MoviePlanning[j].movieName;
                                movieStartTime = storage.MoviePlanning[j].movieTime.ToString();
                                movieRoom = storage.MoviePlanning[j].movieTheater;
                            }
                        }
                        reservationList = reservationList + $"Reserverings Nummer: {storage.Reservations[i].reservationID}\nFilm: {movieName}\nDatum en tijd: {DateTime.Parse(movieStartTime)}\nZaal: {movieRoom}\n\n";
                    }
                }
                if(reservationList == "") {
                    Console.WriteLine("U heeft op het moment geen reserveringen.");
                } else {
                    Console.WriteLine(reservationList);
                }
            }
            tools.textColor("\n>> Terug naar hoofmenu", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {Console.Clear(); Menu.dashboard();}
                else {continue;}
            }
        }

        public static void cancelUserReservation() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);
            string reservationList = "";

            if(storage.Reservations != null) {
                for (int i = 0; i < storage.Reservations.Count; i++)
                {
                    string storedEmail = storage.Reservations[i].userMail;
                    string userEmail = Login.user.userEmail;
                    int movieTimeID = storage.Reservations[i].movieTimeID;

                    string movieName = "";
                    string movieStartTime = "";
                    int movieRoom = 0;
                    
                    if(storedEmail == userEmail) {
                        for (int j = 0; j < storage.MoviePlanning.Count; j++)
                        {
                            if(movieTimeID == storage.MoviePlanning[j].movieTimeID) {
                                movieName = storage.MoviePlanning[j].movieName;
                                movieStartTime = storage.MoviePlanning[j].movieTime.ToString();
                                movieRoom = storage.MoviePlanning[j].movieTheater;
                            }
                        }
                        reservationList = reservationList + $"Reserverings Nummer: {storage.Reservations[i].reservationID}\nFilm: {movieName}\nDatum en tijd: {DateTime.Parse(movieStartTime)}\nZaal: {movieRoom}\n";
                    }
                }
                if(reservationList == "") {
                    Console.WriteLine("U heeft op het moment geen reserveringen.");
                } else {
                    bool loop = true;
                    while(loop) {
                        Console.WriteLine(reservationList);
                        tools.textColor("Vul het Nummer in van de reservering die u wilt annuleren.", 14, false);
                        string cancelReservationID = Console.ReadLine();

                        for (int i = 0; i < storage.Reservations.Count; i++)
                        {
                            string storedReservationID = storage.Reservations[i].reservationID;
                            if(cancelReservationID == storedReservationID) {
                                dataStorageHandler.storage.Reservations.RemoveAt(i);
                                dataStorageHandler.saveChanges();
                                loop = false;
                            } else {
                                tools.textColor("Dit nummer bestaat niet.\n", 12, false);
                            }
                        }
                    }
                }
                string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een reservering annuleren", "Terug?"}, 14, 14);
                if(back == "Nog een reservering annuleren") {
                    reserveUser.cancelUserReservation();
                } else if(back == "Terug?") {
                    Menu.dashboard();
                }
            }
        }
    }
}