using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    class snacksAdmin
    {
        public static dataStorage storage { get; set; }
        public static void snacksMain() {
            Console.Clear();
            string movieMenu = Menu.Menubuilder($"Snacks beheren" + "\n", new string[] {"Snack toevoegen", "Snack verwijderen", "Snacks bekijken", "Terug naar hoofdmenu"}, 10, 14);
            if(movieMenu == "Snack toevoegen") {
               createSnack();
            } else if(movieMenu == "Snack verwijderen") {
                removeSnacks();
            } else if(movieMenu == "Snacks bekijken") {
                showSnacks();
            } else if(movieMenu == "Terug naar hoofdmenu") {
                Menu.dashboard();
            }
        }

        public static void showSnacks() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            var len = ((Newtonsoft.Json.Linq.JArray)obj.snack).Count;
            for(int i = 0; i < len; i++) {
                tools.textColor("----------------------------", 14, false);
                tools.textColor($"Naam         | {obj.snack[i].snackName}\nPrijs | {obj.snack[i].snackPrice}\nAantal | {obj.snack[i].snackQuantity}\n", 14, false);
            } 

            string back = Menu.Menubuilder($"" + "\n", new string[] {"Terug?"}, 14, 14);
            if(back == "Terug?") {
                snacksAdmin.snacksMain();
            }
        }

        public static void createSnack() {
            Console.Clear();
            string snackName;
            int snackQuantity;
            double snackPrice;

            while(true) {
                Console.Clear();
                tools.textColor("Snack naam: ", 14, false);
                snackName = Console.ReadLine();

                if(Regex.IsMatch(snackName, "^[\\w ]+$")) { break; }
                else { tools.textColor("Gebruik a.u.b alleen letters", 12, false); }
            }
            while(true) {
                Console.Clear();
                tools.textColor("Snack prijs: ", 14, false);
                string snackPriceInput = Console.ReadLine();

                double fakeDouble;
                if(double.TryParse(snackPriceInput, out fakeDouble)) { 
                    snackPrice = Convert.ToDouble(snackPriceInput);
                    break;
                }
                else { tools.textColor("Gebruik a.u.b alleen cijfers", 12, false); }
            }
            while(true) {
                Console.Clear();
                tools.textColor("Snack aantal: ", 14, false);
                string snackQuantityInput = Console.ReadLine();

                int fakeInt;
                if(int.TryParse(snackQuantityInput, out fakeInt)) { 
                    snackQuantity = Convert.ToInt32(snackQuantityInput);
                    break;
                }
                else { tools.textColor("Gebruik a.u.b alleen letters", 12, false); }
            }

            snacks obj = new snacks {
                snackName = snackName,
                snackPrice = snackPrice,
                snackQuantity = snackQuantity
            };

            dataStorageHandler.storage.snack.Add(obj);
            dataStorageHandler.saveChanges();

            string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een snack toevoegen", "Terug?"}, 14, 14);
            if(back == "Nog een snack toevoegen") {
                createSnack();
            } else if(back == "Terug?") {
                snacksMain();
            }
        }

        public static void removeSnacks() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            int arrLen = 0;

            try
            {
                if (((Newtonsoft.Json.Linq.JArray)obj.snack).Count > 0) {
                    arrLen = ((Newtonsoft.Json.Linq.JArray)obj.snack).Count; 
                }
            }
            catch
            {
                arrLen = 0;
            }

            if(arrLen == 0) {
                tools.textColor("Er zijn nog geen snacks geregistreerd", 12, false);
            } else {
                for(int i = 0; i < arrLen; i++) {
                    tools.textColor($"ID: {i}", 14, false);
                    tools.textColor($"Naam: {obj.snack[i].snackName}", 14, false);
                    tools.textColor($"Prijs: {obj.snack[i].snackPrice}", 14, false);
                    tools.textColor($"Aantal: {obj.snack[i].snackQuantity}", 14, false);
                }

                int selectedID = 0;
                while(true) {
                    tools.textColor("ID van de snack: ", 14, true);
                    selectedID = Convert.ToInt32(Console.ReadLine());
                    if(selectedID > arrLen-1 || selectedID < 0) {
                        tools.textColor("Dit is geen geldige snack ID", 12, false);
                    } else {
                        break;
                    }
                }
                string deleteSnack = obj.snack[selectedID].snackName;

                dataStorageHandler.storage.snack.RemoveAt(selectedID);
                dataStorageHandler.saveChanges();
                Console.Clear();
                tools.textColor("Snack naam ", 15, true); tools.textColor($"{deleteSnack}", 11, true); tools.textColor(" is succesvol verwijderd\n", 15, false); 
            
                string back = Menu.Menubuilder($"" + "\n", new string[] {"Nog een snack verwijderen", "Terug?"}, 14, 14);
                if(back == "Nog een snack verwijderen") {
                    removeSnacks();
                } else if(back == "Terug?") {
                    snacksMain();
                }
            }
        }
    }
}