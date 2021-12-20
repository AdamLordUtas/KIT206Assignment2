using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2.Research
{
    //Enum for types of publications
    public enum Ptype 
    { 
        Conference, 
        Journal, 
        Other
    }

    class Publication
    {
        public string doi { get; set; }//uniquely identifiable doi
        public string title { get; set; }//publication title
        public string authours { get; set; }//shows author
        public int year { get; set; }//year of publication
        public Ptype type { get; set; }//one of the Conference, Journal or Other
        public string citeAs { get; set; }//shows the details from database
        public DateTime available { get; set; }//the date when the publication was first available

        //Number of years the since the first publication year
        public int Age() 
        {
            return DateTime.Now.Year - year;
        }
    }
}
