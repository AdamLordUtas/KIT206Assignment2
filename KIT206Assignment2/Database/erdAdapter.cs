using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2.Database
{
    class erdAdapter
    {
        //Get the names of the researchers to be presented in a list
        public Researcher[] GetBasicResearcherDetails() 
        {
            return null;
        }
        
        //Get the full details of an individual researcher to be displayed
        public Researcher fetchFullResearcherDetails(int researcherId) 
        {
            return null;
        }

        //Get list of publications associated with a researcher
        public Publication[] GetBasicPublicationDetails(int researcherId) 
        {
            return null;
        }

        //Get the full details of a specific publication
        public Publication GetFullPublicationDetails(Publication publication) 
        {
            return null;
        }

        public int[] GetPublicationsCount(DateTime startDate, DateTime endDate) 
        {
            return null;
        }
    }
}
