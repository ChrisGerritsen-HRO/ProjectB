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
                    foreach (var item in storage.Reservations)
                    {
                        if(item.userMail == Login.user.userEmail) {
                            reservationList = reservationList + $"Reserverings Nummer: {item.reservationID}\n";
                        } else {
                            tools.textColor("Er staan geen reserveringen op uw naam!", 12, false);
                        }
                    }
                }

                tools.textColor("\n>> Terug", 14, false);
                while (true) {
                    var key = Console.ReadKey();
                    if (key.Key.ToString() == "Enter" && Login.user == null) {Console.Clear(); Menu.Mainmenu();}
                    else {continue;}
                }
            }
        }
    }
}