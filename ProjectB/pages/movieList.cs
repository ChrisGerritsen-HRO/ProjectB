using System;
using Newtonsoft.Json;
using ProjectB.classes;
using ProjectB.DAL;
using System.IO;
using System.Collections.Generic;

namespace ProjectB.pages 
{
    class movieList {
        public static dataStorage storage { get; set; }

        public static void listMain() {
            Console.Clear();
            string fileContent = File.ReadAllText("storage.json");
            dynamic obj = JsonConvert.DeserializeObject(fileContent);
            int arrLen = 0;

            try // Gaat hier controleren of er al een object bestaat in de JSON array
            {
                dynamic obj1 = JsonConvert.DeserializeObject(fileContent);

                if (((Newtonsoft.Json.Linq.JArray)obj1.movie).Count > 0) {  // Zo ja geef de aantal door
                    arrLen = ((Newtonsoft.Json.Linq.JArray)obj1.movie).Count; 
                }
            }
            catch
            {
                arrLen = 0;
            }
            if(arrLen == 0) {
                tools.textColor("Er zijn nog geen films geregistreerd!", 12, false);
            } else {
                for(int i = 0; i < arrLen; i++) {
                    tools.textColor($"Naam         | {obj.movie[i].movieName}\nBeschrijving | {obj.movie[i].movieDescription}\nLeeftijd     | {obj.movie[i].movieAge}+\nGenre        | {obj.movie[i].movieGenre}\nTijdstip     | {obj.movie[i].movieTime}\nDuur         | {obj.movie[i].movieDuration} minuten\nZaal         | {obj.movie[i].movieTheater}\n", 14, false);
                } 
            }

            tools.textColor("[1] Terug gaan\n", 15, false);
            if(Console.ReadLine() == "1") {
                Console.Clear();
                Menu.mainMenu();
            }

        }        
    }
}