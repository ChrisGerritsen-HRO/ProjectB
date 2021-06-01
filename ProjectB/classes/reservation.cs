using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.classes
{
    public class reservation {
        public string userMail { get; set; }
        public int movieID { get; set; }
        public int movieTimeID { get; set; }
        public int roomNumber { get; set; }
        public static List<string> snacks = new List<string>();
        public string reservationID { get; set; }
    }
}