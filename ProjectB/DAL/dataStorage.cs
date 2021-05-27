using ProjectB.classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.DAL
{
    public class dataStorage {
        public List<movies> movie { get; set; } = new List<movies>();
        public List<personAccounts> personAccount { get; set; } = new List<personAccounts>();
        public List<movieRooms> movieRoom { get; set; } = new List<movieRooms>();
        public List<moviesPlanning> MoviePlanning { get; set;} = new List<moviesPlanning>();
    }
}