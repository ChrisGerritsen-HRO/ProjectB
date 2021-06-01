using System;
using System.Collections.Generic;
using ProjectB.classes;

namespace ProjectB.pages
{
    class rooms
    {
        public static void createRoom()
        {
            int value, columns, rows;
            while (true)
            {
                tools.textColor("enter amount of rows: ", 14, true);
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
                tools.textColor("enter amount of collums: ", 14, true);
                string input = Console.ReadLine();
                if (int.TryParse(input, out value))
                {
                    columns = Convert.ToInt32(input);
                    break;
                }
                else { tools.textColor("please only use numbers", 12, false); }
            }

            Console.Clear();
            string[] room = new string[rows*columns];
            string[] seatPrice = new string[rows * columns];
            while (true)
            {
                for (int i = 0; i <= rows-1; i++)
                {
                    int j = 0;
                    while (j <= columns-1)
                    {
                        room[i*columns+j] = "X";
                        j++;
                    }
                    room[i*columns+j-1] += "\n";
                }
                break;
            }

            int selected = 0;
            while (selected < rows*columns)
            {
                int i = 0;
                foreach (var element in room)
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
                    else { Console.Write(element); }

                    i++;
                }

                Console.Write("\n select chair price(R/B/Y/none/back): ");
                string input = Console.ReadLine();
                if (input == "R") { seatPrice[selected] = "R"; }
                else if (input == "Y") { seatPrice[selected] = "Y"; }
                else if (input == "B") { seatPrice[selected] = "B"; }
                else if (input == "back") { selected -= 2; }
                else { seatPrice[selected] = ""; }
                selected++;
                Console.Clear();
            }
        }
    }
}