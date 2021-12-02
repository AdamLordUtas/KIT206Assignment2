﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    //Enum for differing employment levels
    public enum Level { Student, A, B, C, D, E};

    class Position
    {
        public int id { get; set; }
        public Level level { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        //Turn the level enum into a string
        public string Title()
        {
            switch (level)
            {
                case Level.Student:
                    return "Student";
                case Level.A:
                    return "Postdoc";
                case Level.B:
                    return "Lecturer";
                case Level.C:
                    return "Senior Lecturer";
                case Level.D:
                    return "Associate Professor";
                case Level.E:
                    return "Professor";
                default:
                    return "Invalid type";
            }
        }
    }
}