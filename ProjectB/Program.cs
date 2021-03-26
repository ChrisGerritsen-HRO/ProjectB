using ProjectB.DAL;
using ProjectB.pages;
using System;

namespace ProjectB
{
    class Program
    {
        static void Main(string[] args)
        {
            dataStorageHandler.init("storage.json");
            Register.registerMain();
        }
    }
}
