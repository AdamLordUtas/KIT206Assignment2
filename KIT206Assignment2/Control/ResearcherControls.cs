using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206Assignment2.Research;
using System.Collections.ObjectModel;

namespace KIT206Assignment2.Control
{
    class ResearcherControls
    {
        public List<Researcher> list = new List<Researcher>();
        ObservableCollection<Researcher> displayList;



        public List<Researcher> FilterAlphabetically(List<Researcher> researchers) 

        {
            Console.WriteLine("\nFiltering...");

            IEnumerable<Researcher> filterRes = 
                from researcher in researchers 
                orderby researcher.givenName
                select researcher;

            return filterRes.ToList();
        }

        public void FilterByName(string searchText) 
        {
            
        }

        public void LoadResearcherDetails() 
        {
            Console.WriteLine("Loading researcher's details...");
        }
    }
}
