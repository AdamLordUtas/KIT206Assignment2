using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    //Enums for the type of researcher and the campus they operate on
    public enum Rtype { Staff, Student };
    public enum Campus { Hobart, Launceston, Cradle_Coast };

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
        public int supervisorId { get; set; } //A researcher can have multiple positions, the current position is used by default
        public Position position { get; set; }

        public string jobTitle() 
        {
            return position.title();
        }

/*        public Position firstPosition() 
        {
            
        }*/
    }
}
