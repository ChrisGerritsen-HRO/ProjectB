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
            tools.textColor("[1] Zaal toevoegen\n[2] Zaal verwijderen\n[3] Terug naar hoofdmenu\n", 15, false);
            while(true) {
                var userinput = Console.ReadLine();
                if (userinput == "1") {
                    createRoom();
                } else if (userinput == "2") {
                    
                } else if (userinput == "3") {
                    Console.Clear();                    
                    Menu.dashboard();
                } else {
                    tools.textColor("Deze optie is niet beschikbaar", 4, false);
                }
            }
        }

        public static void createRoom() {
            Console.Clear();
            int roomNumber, totalSeats, blueSeats, orangeSeats, redSeats;
            while(true) {
                while(true) {
                    tools.textColor("Zaal nummer: ", 14, true);
                    string roomNumberInput = Console.ReadLine();
                    int value;
                    if (int.TryParse(roomNumberInput, out value)) {
                        roomNumber = Convert.ToInt32(roomNumberInput);
                        break;
                    } else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
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
    }
}