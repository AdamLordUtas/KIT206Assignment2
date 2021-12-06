using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    class ResearcherControls
    {
        public void LoadResearchers() 
        {
            Console.WriteLine("Loading researchers...");
        }

        public void FilterBy() 
        {
            Console.WriteLine("Filtering...");
        }

        public void FilterByName(string searchText) 
        {
            Console.WriteLine(searchText);
        }

        public void LoadResearcherDetails() 
        {
            Console.WriteLine("Loading researcher's details...");
        }
    }
}
