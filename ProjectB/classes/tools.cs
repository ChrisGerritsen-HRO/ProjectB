using System;

namespace ProjectB.classes {
    class tools {
        /*
        Black = 0, DarkBlue = 1, DarkGreen = 2, DarkCyan = 3, DarkRed = 4, DarkMagenta = 5
        DarkYellow = 6, Gray = 7, DarkGray = 8, Blue = 9, Green = 10
        Cyan = 11, Red = 12, Magenta = 13, Yellow = 14, White = 15
        */
        public static void textColor(string text, int color, bool inputLocation)
        {
        Console.ForegroundColor = (ConsoleColor)color;
        if (inputLocation) { Console.Write(text); }
        else { Console.WriteLine(text); }
        Console.ResetColor();
        }
    }
}