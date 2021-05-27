using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.classes
{
    public class moviesPlanning
    {
        public int movieTimeID { get; set; }
        public int movieID { get; set; }
        public string movieName { get; set; }
        public DateTime movieTime { get; set; }
        public int movieDuration { get; set; }
        public DateTime movieEndTime { get; set; }
        public int movieTheater { get; set; }
    }
}