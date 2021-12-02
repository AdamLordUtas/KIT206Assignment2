using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    public enum Level { Student, A, B, C, D, E};

    class Position
    {
        public int id { get; set; }
        public Level level { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
