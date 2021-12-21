using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2.Research
{
    //Enums for the type of researcher and the campus they operate on
    public enum Rtype 
    { 
        Staff, 
        Student 
    }
    public enum Campus 
    { 
        Hobart, 
        Launceston, 
        Cradle_Coast 
    }

    class Researcher
    {
        public int id { get; set; }//uniquely identifier
        public Rtype type {get; set;}//type of researcher (either staff or student)
        public string givenName { get; set; }//researchers firstname
        public string familyName { get; set; }//researchers lastname
        public string title { get; set; }//researchers current job title
        public string unit { get; set; }//researchers unit
        public Campus campus { get; set; }//researchers campus
        public string email { get; set; }//researchers email address
        public string photo { get; set; } //URL to a photo of researcher
        public string degree { get; set; }//shows the degree if the researcher is student
        public int supervisorId { get; set; }//shows the ID of the student's supervisior 
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

        public string campusSting() 
        {
            switch (campus)
	        {
		        case Campus.Hobart:
                    return "Hobart";
                case Campus.Launceston:
                    return "Launceston";
                case Campus.Cradle_Coast:
                    return "Cradle Coast";
                default:
                    return "Invalid Campus";
	        }
        }
    }
}
