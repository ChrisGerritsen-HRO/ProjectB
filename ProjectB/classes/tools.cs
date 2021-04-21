using System;

namespace ProjectB.classes {
    class tools {
        public static void textColor(string text, int color, bool inputLocation)
        {
        Console.ForegroundColor = (ConsoleColor)color;
        if (inputLocation) { Console.Write(text); }
        else { Console.WriteLine(text); }
        Console.ResetColor();
        }
    }
}
