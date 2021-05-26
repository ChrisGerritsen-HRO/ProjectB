using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectB.classes
{
    public class movies
    {

        public int movieID { get; set; }
        public string movieName { get; set; }

        public string movieDescription { get; set; }
        public int movieAge { get; set; }
        public string movieGenre { get; set; }

        public DateTime movieTime { get; set; }

        public int movieDuration { get; set; }
        public DateTime movieEndTime { get; set; }

        public int movieTheater { get; set; }
    }
}