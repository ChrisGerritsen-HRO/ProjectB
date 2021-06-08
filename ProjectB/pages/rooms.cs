using System;
using System.Collections.Generic;
using ProjectB.classes;

namespace ProjectB.pages
{
    class rooms
    {
        public static List<int> createRoom() //maak als admin een visuele room aan
        {
            int value, columns, rows;
            while (true)
            {
                tools.textColor("enter amount of rows: ", 14, true); // geef aantal rijen in de zaal
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    rows = Convert.ToInt32(input);
                    break;
                }
                else { tools.textColor("please only use numbers", 12, false); }
            }

            while (true)
            {
                tools.textColor("enter amount of collums: ", 14, true); //geef aantal stoellen per rij
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    columns = Convert.ToInt32(input);
                    break;
                }
                else { tools.textColor("please only use numbers", 12, false); }
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

                Console.Write("\n select chair price(R/B/Y/none/back): "); //geef vooer iedere stoel aan welke prijs deze stoel is
                string input = Console.ReadLine();
                if (input == "R") { seatPrice[selected] = "R"; }
                else if (input == "Y") { seatPrice[selected] = "Y"; }
                else if (input == "B") { seatPrice[selected] = "B"; }
                else if (input == "back") { selected -= 2; }
                else { seatPrice[selected] = ""; }
                selected++;
                Console.Clear();
            }
            return(selectChair(seatPrice, room, rows, columns));
        }

        public static List<int> selectChair(string[] seatPrice, string[] room, int rows, int columns) //gebruiker kan stoellen uit de zaal kiezen
        {
            List<int> selectedChairs = new List<int>();
            tools.textColor("aantal stoellen reserveren: ", 14, true); //gebruiker geeft aan hoeveel stoellen hij wil reserveren
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
                    seatPrice[selected] = "G"; //gekozen stoellen worden grijs in de array
                    selectedChairs.Add(selected+1);
                    amountOfSelectedChairs++;
                }
            }
            return selectedChairs;
        }
    }
}