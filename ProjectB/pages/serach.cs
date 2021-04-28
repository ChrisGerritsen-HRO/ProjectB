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
    class search {

        
        public static void filmlijst()
        {
            Console.Clear();
            string path = "storage.json";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path;
            if (File.Exists(path) == false)
            {
                tools.textColor("Er zijn nog geen films geregistreerd!", 4, false);
                Menu.mainmenu();
            }
            // read file into a string and deserialize JSON to a type
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);

            
            
            FilmSearch();
            
            tools.textColor("[1] Nog een film zoeken\n[2] Terug gaan\n", 15, false);   
                
            if (Console.ReadLine() == "1")
            {
                FilmSearch();
            }
            else
            {
                tools.textColor("Alleen optie 1 en 2 zijn beschikbaar", 4, false);
            }
            
            if (Console.ReadLine() == "2")
            {
                Console.Clear();
                Menu.mainmenu();
            }
            else if (Console.ReadLine() == "1")
            {
                filmlijst();
            }
            else if (Console.ReadLine() == "2")
            {
                Console.Clear();
                Menu.mainmenu();
            }
            else
            {
                tools.textColor("Alleen optie 1 t/m 3 zijn beschikbaar", 4, false);
            }
        }
        public static void FilmSearch()
        {   
            tools.textColor("Voer een tijd of naam van een film in:", 15, false);  
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
                for(int i = 0; i < len; i++) 
                {   
                    if(obj.movie[i].movieName == strInput)
                    {
                        tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
                        check = true;
                        break;
                    }

                    
                }
                if(!check) {
                    tools.textColor("Er zijn geen beschikbare films voor deze tijd of zoekterm.", 15, false);
                }
                
                
                   
            }       
                
                    
               
            
            if(double.TryParse(strInput,out double result))
            {   
                Console.Clear();
                bool check = false;
                for(int i = 0; i < len; i++) 
                {   
                    if(obj.movie[i].movieTime == strInput)
                    {
                        Console.WriteLine("Deze films zijn beschikbaar om {0} uur:", result);
                        tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
                        check = true;
                        break;
                    }

                    
                }
                if(!check) {
                    tools.textColor("Er zijn geen beschikbare films voor deze tijd of zoekterm.", 15, false);
                }
            }        
                
            
            
            tools.textColor("[1] Nog een keer zoeken", 15, false);
            tools.textColor("[2] Terug gaan\n", 15, false);
            string userinput = Console.ReadLine();
            if (userinput == "1")
            {
                filmlijst();
            }
            else if (userinput == "2")
            {
                Console.Clear();
                Menu.mainmenu();
            }
            }
            
        
        public static void MovieFind()
        {
            Console.Clear();
            string path = "storage.json";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path;
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            
            var userinput = Console.ReadLine();
            foreach (var item in obj)
            {

                Console.WriteLine("");

            }
        }
    }
}

    
