using System;
using ProjectB.DAL;
using ProjectB.pages;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args) {
            dataStorageHandler.init("Storage.json");
            Menu.mainMenu(); 
        }
    }
}
