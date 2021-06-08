using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace ProjectB.pages
{
    class reserveSnack
    {
        public static string snacksList { get; set; }
        public static void reserverSnackMain() {
            Console.Clear();

            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            int snacksObjLength = ((Newtonsoft.Json.Linq.JArray)obj.snack).Count;

            while(true) {
                for (int i = 0; i < snacksObjLength; i++) {
                    tools.textColor("----------------------------", 14, false);
                    tools.textColor($"ID           | {i}\n{obj.snack[i].snackName}", 14, false);
                }
                tools.textColor("Kies een snack ID: ", 14, true);
                int selectedID;
                selectedID = Convert.ToInt32(Console.ReadLine());
                if (selectedID > snacksObjLength-1 || selectedID < 0) {
                    tools.textColor("Dit is geen geldig ID!", 12, false);
                } else {
                    string selectedSnackName = obj.snack[selectedID].snackName;
                    string selectedSnackPrice = obj.snack[selectedID].snackPrice;
                    snacksList = snacksList + selectedSnackName + " " + selectedSnackPrice + "\n";
                }

                if(snacksList == null) {
                    Console.WriteLine("Mandje:\nGeen snacks gevonden");
                } else {
                    Console.WriteLine("Mandje:");
                    Console.WriteLine(snacksList);
                }

                string next = Menu.Menubuilder($"" + "\n", new string[] {"Nog een snack toevoegen", "Verder"}, 14, 14);
                if(next == "Nog een snack toevoegen") {
                } else if(next == "Verder") {
                    // Reserveren afronden en alles gegevens opslaan.
                    reserveUser.finishReservation();
                    tools.textColor($"Bedankt voor de reservering! Reserverings nummer: {reserveUser.reservationID}", 10, false);
                    break;
                }
            }

            tools.textColor("\n>> Terug naar hoofmenu", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter") {Console.Clear(); Menu.dashboard();}
                else {continue;}
            }
        }
    }
}