using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206Assignment2.Research;

namespace KIT206Assignment2.Control
{
    class ResearcherControls
    {
        public void FilterAlphabetically(List<Researcher> researchers) 
        {
            Console.WriteLine("\nFiltering...");

            IEnumerable<Researcher> filterRes = 
                from researcher in researchers 
                orderby researcher.givenName
                select researcher;

            foreach (var item in filterRes)
	        {
                Console.WriteLine(item.givenName);
        	}
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
