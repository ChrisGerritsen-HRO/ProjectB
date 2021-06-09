using System;
using System.IO;
using System.Collections.Generic;
using ProjectB.classes;
using Newtonsoft.Json;

namespace ProjectB.pages
{
    class reserveRoom {
        // public static List<int> selectChair(string[] seatPrice, string[] room, int rows, int columns) //gebruiker kan stoellen uit de zaal kiezen
        public static int[] seats = new int[0];
        public static int roomNum = 0;
        public static void selectChair()
        {
            List<int> selectedChairs = new List<int>();

            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            string[] seatPrice = new string[0];
            string[] room = new string[0];
            int rows = 0;
            int columns = 0;

            int roomNumber = 0;
            for (int i = 0; i < obj.MoviePlanning.Count; i++)
            {
                int movieTimeID = obj.MoviePlanning[i].movieTimeID;
                if(reserveMovie.reserveMovieTimeID == movieTimeID) {
                    roomNumber = obj.MoviePlanning[i].movieTheater;
                }
            }
            for (int i = 0; i < obj.movieRoom.Count; i++)
            {
                int jRoomNumber = obj.movieRoom[i].roomNumber;
                if(roomNumber == jRoomNumber) {
                    rows = obj.movieRoom[i].rows;
                    columns = obj.movieRoom[i].columns;
                    Array.Resize(ref room, rows * columns);
                    Array.Resize(ref seatPrice, rows * columns);
                    for (int j = 0; j < obj.movieRoom[i].seats.Count; j++)
                    {
                        room[j] = obj.movieRoom[i].seats[j];
                    }
                }
            }
            for (int i = 0; i < obj.MoviePlanning.Count; i++)
            {
                int movieTimeID = obj.MoviePlanning[i].movieTimeID;
                if(reserveMovie.reserveMovieTimeID == movieTimeID) {
                    for (int j = 0; j < obj.MoviePlanning[i].seats.Count; j++)
                    {
                        seatPrice[j] = obj.MoviePlanning[i].seats[j];
                    }
                }
            }
            

            tools.textColor("Aantal stoellen reserveren: ", 14, true); //gebruiker geeft aan hoeveel stoellen hij wil reserveren
            int amountOfChairs = Convert.ToInt32(Console.ReadLine());
            int amountOfSelectedChairs = 0;
            int selected = 0;
            while (true)
            {
                Console.Clear();
                if (amountOfSelectedChairs == amountOfChairs) { break; } //while loop stopt wanneer het aantal stoellen is behaald
                int i = 0;
                foreach (var element in room) //print zaal uit
                {
                    Console.Write(" ");
                    if (i == selected)
                    {
                        Console.BackgroundColor = (ConsoleColor)8;
                    }
                    if (seatPrice[i] == "R") { tools.textColor(element, 12, true); }
                    else if (seatPrice[i] == "B") { tools.textColor(element, 9, true); }
                    else if (seatPrice[i] == "Y") { tools.textColor(element, 14, true); }
                    else if (seatPrice[i] == "") { tools.textColor(element, 0, true); }
                    else if (seatPrice[i] == "G") { tools.textColor(element, 7, true); }
                    i++;
                }
                ConsoleKeyInfo key;
                key = Console.ReadKey(true); //gebruiker kan met de pijltjes toetsen door de zaal heen om een stoel te kiezen
                if (key.Key.ToString() == "RightArrow") 
                {
                    selected++;
                    if (selected >= rows * columns) { selected = 0; }
                }
                else if (key.Key.ToString() == "DownArrow")
                {
                    selected = selected + columns;
                    if (selected > rows * columns) { selected = selected - columns; }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    selected = selected - columns;
                    if (selected < 0) { selected = selected + columns; }
                }
                else if (key.Key.ToString() == "LeftArrow")
                {
                    selected--;
                    if (selected < 0) { selected = 0; }
                }
                else if (key.Key.ToString() == "Enter")
                {
                    if (seatPrice[selected] == "G") {continue;}
                    else{seatPrice[selected] = "G"; //gekozen stoellen worden grijs in de array
                    selectedChairs.Add(selected+1);
                    amountOfSelectedChairs++;}
                }
            }
            Array.Resize(ref seats, amountOfChairs);
            seats = selectedChairs.ToArray();
            roomNum = roomNumber;
            reserveSnack.reserverSnackMain();
            // return selectedChairs;
        }
    }
}