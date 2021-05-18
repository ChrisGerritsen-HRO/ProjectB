using System;
using ProjectB.DAL;
using ProjectB.pages;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            dataStorageHandler.init("storage.json");
            dataStorageHandler.saveChanges();
            Console.Clear();
            Menu.Mainmenu();
        }
    }
}