
using System;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace ProjectB
{
    public class Film
    {
        public string filmnaam { get; set; }
        public int filmleeftijd { get; set; }
    }
    class Program
    {
        //Black = 0, DarkBlue = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4, DarkMagenta = 5
        //DarkYellow = 6, Gray = 7, DarkGray = 8, Blue = 9, Green = 10
        //Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White = 15
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text); }
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }

        static void mainMenu()
        {
            textColor("Welcome, what would you like to do?", 14, false);
            textColor("[1] create account\n[2] login\n[3] buy ticket\n[4] film lijst\n[5] admin\n", 15, false);
            while (true)
            {
                var userinput = Console.ReadLine();
                if (userinput == "4")
                {
                    filmlijst();
                    mainMenu();
                    break;
                }
                if (userinput == "5")
                {
                    adminfilm();
                    mainMenu();
                }
                else
                {
                    textColor("Alleen optie 4 en 5 zijn beschikbaar", 4, false);
                }
            }
        }

        static void filmlijst()
        {
            Console.Clear();
            string path = "films.txt";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path;
            if (File.Exists(path) == false)
            {
                textColor("Er zijn nog geen films geregistreerd!", 4, false);
                mainMenu();
            }
            // read file into a string and deserialize JSON to a type
            Film movie1 = JsonConvert.DeserializeObject<Film>(File.ReadAllText(path));
            textColor("[1] Gehele filmlijst", 15, false);
            textColor("[2] Zoeken in filmlijst", 15, false);
            if (Console.ReadLine() == "1")
            {
                textColor($"Filmnaam : {movie1.filmnaam}\nFilmleeftijd : {movie1.filmleeftijd}\n", 14, false);
                textColor("[1] Zoeken in filmlijst", 15, false);
                textColor("[2] Terug gaan\n", 15, false);
                if (Console.ReadLine() == "1")
                {
                    FilmSearch();
                }
                if (Console.ReadLine() == "2")
                {
                    Console.Clear();
                    mainMenu();
                }
                else
                {
                    textColor("Alleen optie 1 en 2 zijn beschikbaar", 4, false);
                }
            }
            if (Console.ReadLine() == "2")
            {
                FilmSearch();
            }
            else if (Console.ReadLine() == "1")
            {
                filmlijst();
            }
            
            else
            {
                textColor("Alleen optie 1 en 2 zijn beschikbaar", 4, false);
            }
            static void FilmSearch()
            {
                textColor("Voer een tijd of naam van een film in:", 15, false);
                string strInput = Console.ReadLine();


                if (Regex.IsMatch(strInput, "[a-zA-Z]")) // Checks if there is a letter in the input to decide if it's a name or a time.
                {

                    textColor("Deze films zijn beschikbaar voor de zoekterm: " + strInput, 15, false);
                }

                else if (double.TryParse(strInput, out double result))


                {
                    Console.WriteLine("Deze films zijn beschikbaar om {0} uur:", result);

                }
                else
                {
                    textColor("Er zijn geen beschikbare films voor deze tijd of zoekterm " + strInput, 15, false);
                }
            }



            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                Film movie2 = (Film)serializer.Deserialize(file, typeof(Film));
            }
            textColor($"Filmnaam : {movie1.filmnaam}\nFilmleeftijd : {movie1.filmleeftijd}\n", 14, false);
            textColor("[1] Volledige filmlijst", 15, false);
            textColor("[2] Terug gaan\n", 15, false);
            if (Console.ReadLine() == "1")
            {
                filmlijst();
            }
            else if (Console.ReadLine() == "2")
            {
                Console.Clear();
                mainMenu();
            }

        }

        static void adminfilm()
        {
            string filmnaam;
            int filmleeftijd;
            while (true)
            {
                Console.Clear();
                textColor("film naam: ", 14, false);
                filmnaam = Console.ReadLine();
                textColor("leeftijd film: ", 14, false);
                filmleeftijd = Convert.ToInt32(Console.ReadLine());
                textColor("Nog een film toevoegen? [1]", 14, false);
                textColor("Menu afsluiten? [2]", 14, false);
                if (Console.ReadLine() == "2")
                {
                    Console.Clear();
                    break;
                }
            }
            var obj = new Film
            {
                filmnaam = filmnaam,
                filmleeftijd = filmleeftijd
            };

            string path = "films.txt";
            string filePath = Directory.GetCurrentDirectory() + "\\" + path;
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            if (File.Exists(path))
            {
                string storedData = System.IO.File.ReadAllText(path);
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(json);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(json);
                }
            }
        }
        static void Main(string[] args)
        {
            mainMenu();
        }
    }
}
