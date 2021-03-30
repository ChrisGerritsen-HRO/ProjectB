using System;
using System.Text.RegularExpressions;
namespace ProjectB
{
    class Movies {




        static void Main()
        {


            Console.WriteLine("Voer een tijd of naam van een film in:");
            string strInput = Console.ReadLine();
            

            if (Regex.IsMatch(strInput, "[a-zA-Z]"))
            {
                Console.WriteLine("Deze films zijn beschikbaar voor de zoekterm: " + strInput);
            }

             else if (double.TryParse(strInput, out double result))


             {
                 Console.WriteLine("Deze films zijn beschikbaar om {0} uur:", result);

             }
             else
             {
                 Console.WriteLine("Er zijn geen beschikbare films voor deze tijd of zoekterm " + strInput);
             }

            }
        }      
    }
     