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

        static string Menu(string[] menu, int menuColor)
        {
            int currentItem = 0;
            while (true)
            {
                Console.Clear();
                for(int i = 0; i < menu.Length; i++)
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
        }
        public static void Main()
        {
            Console.WriteLine(Menu(new string[] { "this", "is", "a", "test" }, 11));
        }
    }
}