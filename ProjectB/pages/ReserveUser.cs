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
                roomNumber = 1,
                reservationID = reservationID
            };

            dataStorageHandler.storage.Reservations.Add(obj);
            dataStorageHandler.saveChanges();
        }
    }
}