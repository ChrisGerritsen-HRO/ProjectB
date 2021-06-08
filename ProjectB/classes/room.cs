using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.classes
{
    public class movieRooms {
        public int roomNumber { get; set; }
        public string roomKind { get; set; }
        public int rows { get; set; }
        public int columns { get; set; }
        public string[] seats { get; set; }
        public string[] seatPrice { get; set; }
    }
}