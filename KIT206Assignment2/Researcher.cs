﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    public enum Rtype { Staff, Student };
    public enum Campus { Hobart, Launceston, Cradle_Coast };
    public enum Level { A, B, C, D, E };

    class Researcher
    {
        public int id { get; set; }
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string title { get; set; }
        public string unit { get; set; }
        public Campus campus { get; set; }
        public string email { get; set; }
        public string photo { get; set; } //url of image
        public string degree { get; set; }
        public int superVisorId { get; set; }
        public Level level { get; set; }
        public DateTime utasStart { get; set; }
        public DateTime currentStart { get; set; }
    }
}
