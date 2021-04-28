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
            tools.textColor("Welkom beheerder, wat wilt u doen?", 14, false);
            tools.textColor("[1] Zaal toevoegen\n[2] Zaal verwijderen\n[3] Bekijk zalen\n[4] Terug naar hoofdmenu\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "1") {
                    createRoom();
                } else if (userinput == "2") {
                    removeRoom();
                } else if (userinput == "3") {
                    showRoom();
                } else if (userinput == "4") {
                    Console.Clear();                    
                    // Menu.dashboard();
                } else {
                    tools.textColor("Deze optie is niet beschikbaar", 4, false);
                }
            }
        }

        public static void showRoom() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            int arrLen = 0;

            try
            {
                if (((Newtonsoft.Json.Linq.JArray)obj.movieRoom).Count > 0) {
                    arrLen = ((Newtonsoft.Json.Linq.JArray)obj.movieRoom).Count; 
                }
            }
            catch
            {
                arrLen = 0;
            }

            if(arrLen == 0) {
                tools.textColor("Er zijn nog geen zalen geregistreerd", 12, false);
            } else {
                while(true) {
                    for(int i = 0; i < arrLen; i++) {
                    tools.textColor($"Nummer: {obj.movieRoom[i].roomNumber}", 14, false);
                    tools.textColor($"Totale stoelen: {obj.movieRoom[i].totalSeats}", 14, false);
                    tools.textColor($"Blauwe stoelen: {obj.movieRoom[i].blueSeats}", 14, false);
                    tools.textColor($"Oranje stoelen: {obj.movieRoom[i].orangeSeats}", 14, false);
                    tools.textColor($"Rode stoelen: {obj.movieRoom[i].redSeats}\n", 14, false);
                    }

                    Console.WriteLine("[1] Terug?\n");
                    string userInput = Console.ReadLine();

                    if (userInput == "1") {
                        break;
                    }
                }
                roomMain();
            }
        }

        public static void createRoom() {
            Console.Clear();
            int roomNumber, totalSeats, blueSeats, orangeSeats, redSeats;
            while(true) {
                while(true) {
                    string fileContent = File.ReadAllText("storage.json");
                    storage = JsonConvert.DeserializeObject<dataStorage>(fileContent);

                    tools.textColor("Zaal nummer: ", 14, true);
                    string roomNumberInput = Console.ReadLine();
                    int value;
                    var storedNumber = 0;
                    foreach (var item in storage.movieRoom)
                    {
                        storedNumber = item.roomNumber;
                    }
                    if(storedNumber == Convert.ToInt32(roomNumberInput)) {
                        Console.WriteLine("Het ingevoerde zaal nummer bestaat al");
                    } else {
                        if (int.TryParse(roomNumberInput, out value)) {
                            roomNumber = Convert.ToInt32(roomNumberInput);
                            break;
                        } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                    }
                }
                while(true) {
                    tools.textColor("Totaal aantal stoelen: ", 14, true);
                    string totalSeatsInput = Console.ReadLine();
                    int value;
                    if (int.TryParse(totalSeatsInput, out value)) {
                        totalSeats = Convert.ToInt32(totalSeatsInput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }
                while(true) {
                    tools.textColor("Aantal blauwe stoelen: ", 14, true);
                    string blueSeatsInput = Console.ReadLine();
                    int value;
                    if (int.TryParse(blueSeatsInput, out value)) {
                        blueSeats = Convert.ToInt32(blueSeatsInput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }
                while(true) {
                    tools.textColor("Aantal oranje stoelen: ", 14, true);
                    string orangeSeatsInput = Console.ReadLine();
                    int value;
                    if (int.TryParse(orangeSeatsInput, out value)) {
                        orangeSeats = Convert.ToInt32(orangeSeatsInput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }
                while(true) {
                    tools.textColor("Aantal rode stoelen: ", 14, true);
                    string redSeatsInput = Console.ReadLine();
                    int value;
                    if (int.TryParse(redSeatsInput, out value)) {
                        redSeats = Convert.ToInt32(redSeatsInput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
                }
                if(redSeats + orangeSeats + blueSeats != totalSeats) {
                    Console.Clear();
                    tools.textColor($"De kleur stoelen komen niet tot het aantal van de totaal stoelen! Probeer het opnieuw! ({redSeats} + {orangeSeats} + {blueSeats} != {totalSeats})", 12, false);
                } else { break;}
            }

            movieRooms obj = new movieRooms {
                roomNumber = roomNumber,
                totalSeats = totalSeats,
                blueSeats = blueSeats,
                orangeSeats = orangeSeats,
                redSeats = redSeats
            };

            dataStorageHandler.storage.movieRoom.Add(obj);
            dataStorageHandler.saveChanges();

            tools.textColor("Nog een film toevoegen [1]", 14, false);
            tools.textColor("Terug gaan [2]", 14, false);
            if(Console.ReadLine() == "1"){
                Console.Clear();
                createRoom();
            } else {
                Console.Clear();
                roomMain();
            }
        }

        public static void removeRoom() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            int arrLen = 0;

            try
            {
                if (((Newtonsoft.Json.Linq.JArray)obj.movieRoom).Count > 0) {
                    arrLen = ((Newtonsoft.Json.Linq.JArray)obj.movieRoom).Count; 
                }
            }
            catch
            {
                arrLen = 0;
            }

            if(arrLen == 0) {
                tools.textColor("Er zijn nog geen zalen geregistreerd", 12, false);
            } else {
                for(int i = 0; i < arrLen; i++) {
                    tools.textColor($"ID: {i}", 14, false);
                    tools.textColor($"Nummer: {obj.movieRoom[i].roomNumber}", 14, false);
                    tools.textColor($"Totale stoelen: {obj.movieRoom[i].totalSeats}", 14, false);
                    tools.textColor($"Blauwe stoelen: {obj.movieRoom[i].blueSeats}", 14, false);
                    tools.textColor($"Oranje stoelen: {obj.movieRoom[i].orangeSeats}", 14, false);
                    tools.textColor($"Rode stoelen: {obj.movieRoom[i].redSeats}\n", 14, false);
                }

                int selectedID = 0;
                while(true) {
                    tools.textColor("ID van de zaal: ", 14, true);
                    selectedID = Convert.ToInt32(Console.ReadLine());
                    if(selectedID > arrLen-1 || selectedID < 0) {
                        tools.textColor("Dit is geen geldig zaal nummer", 12, false);
                    } else {
                        break;
                    }
                }
                string deletedRoom = obj.movieRoom[selectedID].roomNumber;

                dataStorageHandler.storage.movieRoom.RemoveAt(selectedID);
                dataStorageHandler.saveChanges();
                Console.Clear();
                tools.textColor("Zaal nummer ", 15, true); tools.textColor($"{deletedRoom}", 11, true); tools.textColor(" is succesvol verwijderd\n", 15, false); 
            }
            tools.textColor("Nog een zaal verwijderen [1]", 14, false);
            tools.textColor("Terug gaan [2]", 14, false);
            if(Console.ReadLine() == "1"){
                Console.Clear();
                removeRoom();
            } else {
                Console.Clear();
                roomMain();
            }
        }        
    }
}