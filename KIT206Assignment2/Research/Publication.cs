using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    //Enum for types of publications
    public enum Ptype { Conferance, Journal, Other};

    class Publication
    {
        public string doi { get; set; }
        public string title { get; set; }
        public string authours { get; set; }
        public int year { get; set; }
        public Ptype type { get; set; }
        public string citeAs { get; set; }
        public DateTime available { get; set; }

        //Number of years the since the first publication year
        public int Age() 
        {
            return DateTime.Now.Year - year;
        }
    }
}
