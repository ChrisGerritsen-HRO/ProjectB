using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    class roomAdmin {
        public static dataStorage storage { get; set; }
        public static void roomMain() {
            Console.Clear();
            string roomMenu = Menu.Menubuilder($"Zalen beheren" + "\n", new string[] {"Zaal toevoegen", "Zalen verwijderen", "Zalen bekijken", "Terug naar hoofdmenu"}, 10, 14);
            if(roomMenu == "Zaal toevoegen") {
                createRoom();
            } else if(roomMenu == "Zalen verwijderen") {
                removeRoom();
            } else if(roomMenu == "Zalen bekijken") {
                showRoom();
            } else if(roomMenu == "Terug naar hoofdmenu") {
                Console.Clear();
                Menu.dashboard();
            }
        }

        public static void showRoom() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            if(dataStorageHandler.storage.movie.Count == 0) {
                tools.textColor("Er zijn nog geen zalen geregistreerd", 12, false);
            } else {
                for(int i = 0; i < dataStorageHandler.storage.movieRoom.Count; i++) {
                    tools.textColor($"Nummer: {obj.movieRoom[i].roomNumber}", 14, false);
                    tools.textColor($"Soort zaal: {obj.movieRoom[i].roomKind}", 14, false);
                    tools.textColor("----------------------------", 14, false);
                    }
                }
                string back = Menu.Menubuilder($"" + "\n", new string[] {"Terug?"}, 14, 14);
                if(back == "Terug?") {
                    roomMain();
            }
        }

        public static void createRoom() {
            Console.Clear();
            // int roomNumber, totalSeats, blueSeats, orangeSeats, redSeats;
            int roomNumber, value, columns, rows;
            string roomKind;
            while(true) {
                
                roomNumber = dataStorageHandler.storage.movieRoom.Count+1;
                roomKind = Menu.Menubuilder($"Soort zaal" + "\n", new string[] {"2D", "3D", "IMAX"}, 14, 14);

                Console.Clear();

                while (true)
            {
                tools.textColor("Aantal rijen: ", 14, true); // geef aantal rijen in de zaal
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    rows = Convert.ToInt32(input);
                    break;
                }
                else { tools.textColor("Alleen cijfers A.U.B", 12, false); }
            }

            while (true)
            {
                tools.textColor("Max aantal stoelen per rij: ", 14, true); //geef aantal stoellen per rij
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    columns = Convert.ToInt32(input);
                    break;
                }
                else { tools.textColor("Alleen cijfers A.U.B", 12, false); }
            }

            Console.Clear();
            string[] room = new string[rows * columns]; //maak een array aan van het aantal stoellen in de zaal
            string[] seatPrice = new string[rows * columns]; //een array die voor iedere index in room de kleur opslaat
            while (true)
            {
                for (int i = 0; i <= rows - 1; i++)
                {
                    int j = 0;
                    while (j <= columns - 1)
                    {
                        room[i * columns + j] = "X";
                        j++;
                    }
                    room[i * columns + j - 1] += "\n";
                }
                break;
            }

            int selected = 0;
            while (selected < rows * columns)
            {
                int i = 0;
                foreach (var element in room) //print de zaal uit met de juiste kleuren
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
                    else { Console.Write(element); }
                    Console.ResetColor();

                    i++;
                }

                Console.Write("\n Selecteer stoelen prijs(R/B/Y/none/back): "); //geef vooer iedere stoel aan welke prijs deze stoel is
                string input = Console.ReadLine();
                if (input == "R") { seatPrice[selected] = "R"; }
                else if (input == "Y") { seatPrice[selected] = "Y"; }
                else if (input == "B") { seatPrice[selected] = "B"; }
                else if (input == "back") { selected -= 2; }
                else { seatPrice[selected] = ""; }
                selected++;
                Console.Clear();
            }

            movieRooms obj = new movieRooms {
                roomNumber = roomNumber,
                roomKind = roomKind,
                rows = rows,
                columns = columns,
                seats = room,
                seatPrice = seatPrice
            };

            dataStorageHandler.storage.movieRoom.Add(obj);
            dataStorageHandler.saveChanges();

            string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een zaal toevoegen", "Terug?"}, 14, 14);
            if(back == "Nog een zaal toevoegen") {
                createRoom();
            } else if(back == "Terug?") {
                roomMain();
            }
        }
    }

        public static void removeRoom() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            int arrLen = dataStorageHandler.storage.movieRoom.Count;

            if(arrLen == 0) {
                tools.textColor("Er zijn nog geen zalen geregistreerd", 12, false);
            } else {
                for(int i = 0; i < arrLen; i++) {
                    tools.textColor($"Nummer: {obj.movieRoom[i].roomNumber}", 14, false);
                    tools.textColor($"Nummer: {obj.movieRoom[i].roomKind}", 14, false);
                    tools.textColor("----------------------------", 14, false);
                }

                int selectedID = 0;
                while(true) {
                    tools.textColor("Nummer van de zaal: ", 14, true);
                    selectedID = Convert.ToInt32(Console.ReadLine());
                    if(selectedID > arrLen || selectedID <= 0) {
                        tools.textColor("Dit is geen geldig zaal nummer", 12, false);
                    } else {
                        break;
                    }
                }
                string deletedRoom = obj.movieRoom[selectedID-1].roomNumber;

                dataStorageHandler.storage.movieRoom.RemoveAt(selectedID-1);
                dataStorageHandler.saveChanges();
                Console.Clear();
                tools.textColor("Zaal nummer ", 15, true); tools.textColor($"{deletedRoom}", 11, true); tools.textColor(" is succesvol verwijderd\n", 15, false); 
            }

            string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een zaal verwijderen", "Terug?"}, 14, 14);
            if(back == "Nog een zaal verwijderen") {
                removeRoom();
            } else if(back == "Terug?") {
                roomMain();
            }
        }        
    }
}