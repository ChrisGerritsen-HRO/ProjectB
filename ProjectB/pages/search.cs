using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using ProjectB.pages;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ProjectB.pages
{
    public class search {
        public static void movieSearch() {   
            tools.textColor("Voer een tijd (HH:mm) of naam van een film in:", 15, false);  
            string path = "storage.json";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path;
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);           
            var len = ((Newtonsoft.Json.Linq.JArray)obj.movie).Count;
            string strInput = Console.ReadLine();
            

            if (Regex.IsMatch(strInput, "[a-zA-Z]")) // Checks if there is a letter in the input to decide if it's a name or a time.
            {   
                Console.Clear();   
                tools.textColor("Deze films zijn beschikbaar voor de zoekterm: " + strInput, 15, false);
                bool check = false;
                foreach(var item in dataStorageHandler.storage.movie) {   
                    if(string.Equals(item.movieName, strInput, StringComparison.CurrentCultureIgnoreCase))
                    {
                        tools.textColor("----------------------------", 14, false);
                        tools.textColor($"Naam         | {item.movieName}\nBeschrijving | {item.movieDescription}\nLeeftijd     | {item.movieAge}+\nGenre        | {item.movieGenre}\nTijdstip     | {movieAdmin.movieSequence(item)}\nDuur         | {item.movieDuration} minuten\nZaal         | {item.movieTheater}\n", 14, false);
                        check = true;
                        break;
                    } 

                    
                }
                if(!check) {
                    tools.textColor("Er zijn geen beschikbare films voor deze tijd of zoekterm.", 15, false);
                }
                
                
                   
            }       
                
                    
               
            
            if(Regex.IsMatch(strInput, "^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$"))
            {   
                Console.Clear();
                bool check = false;
                DateTime myDate = DateTime.ParseExact(strInput, "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                for(int i = 0; i < len; i++) 
                {   
                    if(obj.movie[i].movieTime == myDate)
                    {
                        Console.WriteLine("Deze films zijn beschikbaar om {0} uur:", obj.movie[i].movieTime.ToString("HH:mm"));
                        tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
                        check = true;
                        break;
                    }

                    
                }
                if(!check) {
                    tools.textColor("Er zijn geen beschikbare films voor deze tijd of zoekterm.", 15, false);
                }
            }        
                
            
            
            // tools.textColor("[1] Nog een keer zoeken", 15, false);
            // tools.textColor("[2] Terug gaan\n", 15, false);
            // string userinput = Console.ReadLine();
            // if (userinput == "1")
            // {
            //     movieList.choice();
            // }
            // else if (userinput == "2")
            // {
            //     Console.Clear();
            //     Menu.Mainmenu();
            // }
            // }
            tools.textColor("\n>> Terug", 14, false);
            while (true) {
                var key = Console.ReadKey();
                if (key.Key.ToString() == "Enter" && Login.user == null) {Console.Clear(); movieList.choice();}
                else {movieList.choice();}
            }  
        }
    }
}

    
