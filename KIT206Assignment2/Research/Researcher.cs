using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2.Research
{
    //Enums for the type of researcher and the campus they operate on
    public enum Rtype { Staff, Student }
    public enum Campus { Hobart, Launceston, Cradle_Coast }

    class Researcher
    {
        public int id { get; set; }
        public Rtype type {get; set;}
        public string givenName { get; set; }
        public string familyName { get; set; }
        public string title { get; set; }
        public string unit { get; set; }
        public Campus campus { get; set; }
        public string email { get; set; }
        public string photo { get; set; } //url of image
        public string degree { get; set; }
        public int supervisorId { get; set; }
        public Position position { get; set; } //A researcher can have multiple positions, current position should be used for details

        //Get the title for the current position
        public string JobTitle() 
        {
            return position.Title();
        }

        //Formatted display for a list eg. Mr John Smith
        public string listDisplay()
        {
            return String.Format("{0} {1} {2}", title, givenName, familyName);
        }

        //Get the earliest position a researcher held
        public Position firstPosition() 
        {
            return null;
        }

        //Calculate tenure
        public float Tenure() 
        {
            return DateTime.Now.Year - firstPosition().start.Year;
        }

        //Get the amount of publications a researcher has
        public int PublicationsCount() 
        {
            return 0;
        }
    }
}
