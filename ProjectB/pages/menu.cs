using System;

namespace ConsoleApp1
{
    public class Program
    {
        static void textColor(string text, int color, bool inputLocation)
        {
            Console.ForegroundColor = (ConsoleColor)color;
            if (inputLocation) { Console.Write(text);}
            else { Console.WriteLine(text); }
            Console.ResetColor();
        }

        /*static string Menu(string[] menu, int menuColor)
        {
            int currentItem = 0;
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < menu.Length; i++)
                {
                    if (currentItem == i)
                    {
                        textColor(">>" + menu[i], menuColor, false);
                    }
                    else
                    {
                        textColor(menu[i], 15, false);
                    }
                }
                ConsoleKeyInfo key;
                key = Console.ReadKey(true);
                if (key.Key.ToString() == "DownArrow")
                {
                    currentItem++;
                    if (currentItem > menu.Length - 1) { currentItem = 0; }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentItem--;
                    if (currentItem < 0) { currentItem = 0; }
                }
                else if (key.Key.ToString() == "Enter")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.Clear();
            return menu[currentItem];
        }*/
        static string Menu(string title, string[] items, int titleColor, int SelectColor)
        {
            int currentItem = 0; //geselecteerde item
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                textColor(title, titleColor, false); //print title
                for (int i = 0; i < items.Length; i++) //print alle items uit het menu, met de geselecteerde item gekleurd
                {
                    if (currentItem == i)
                    {
                        textColor(">>" + items[i] + "  ", SelectColor, false);
                    }
                    else
                    {
                        textColor("  " + items[i] + "  ", 15, false);
                    }
                }
                ConsoleKeyInfo key;
                key = Console.ReadKey(true); //wacht tot de user een input geeft
                if (key.Key.ToString() == "DownArrow")
                {
                    currentItem++;
                    if (currentItem > items.Length - 1) { currentItem = 0; }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    currentItem--;
                    if (currentItem < 0) { currentItem = items.Length - 1; }
                }
                else if (key.Key.ToString() == "Enter")
                {
                    break;
                }
                else { continue; }
            }
            Console.Clear();
            return items[currentItem]; //geeft de naam van de item dat geselecteerd is terug 
        }
        public static void Main()
        {
            Console.WriteLine(Menu("Test", new string[] { "this", "is", "a", "test" }, 11, 9));
        }
    }
}