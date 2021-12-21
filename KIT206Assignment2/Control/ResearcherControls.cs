using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206Assignment2.Research;
using KIT206Assignment2.Database;
using System.Collections.ObjectModel;

namespace KIT206Assignment2.Control
{
    class ResearcherControls
    {
        public List<Researcher> masterList = new List<Researcher>();
        public ObservableCollection<Researcher> displayList;
        erdAdapter adapter = new erdAdapter();

        //Loads the researchers
        public void LoadResearchers() 
        {
            masterList = adapter.GetBasicResearcherDetails();
            displayList = new ObservableCollection<Researcher>(masterList);
        }

        public void ResetList() 
        {
            displayList.Clear();
            foreach (var item in masterList)
            {
                displayList.Add(item);
            }
        }

        public Researcher GetFullDetails(int id) 
        {
            return adapter.GetFullResearcherDetails(id);
        }

        //Get the display list as a list of researchers
        public List<Researcher> GetResearchers() 
        {
            return displayList.ToList();
        }

        public void FilterAlphabetically() 
        {
            Console.WriteLine("\nFiltering alphabetically");

            IEnumerable<Researcher> filterRes = 
                from researcher in masterList 
                orderby researcher.givenName
                select researcher;

            displayList.Clear();
            filterRes.ToList().ForEach(displayList.Add);
        }

        //Filter the list by name
        public void FilterByName(string searchText) 
        {
            var filterRes = from researcher in masterList
                           where researcher.listDisplay().ToLower().Contains(searchText.ToLower())
                           select researcher;
            displayList.Clear();
            filterRes.ToList().ForEach(displayList.Add);
        }

        //Filter the list by level
        public void FilterByLevel(Level level)
        {
            var filterRes = from researcher in masterList
                            where researcher.position.level.Equals(level)
                            select researcher;
            displayList.Clear();
            filterRes.ToList().ForEach(displayList.Add);
        }


        public double Performance(Researcher researcher) 
        {
            switch (researcher.position.level)
            {
                case Level.A:
                    return adapter.GetPublicationCount(researcher.id) / 0.5;
                case Level.B:
                    return adapter.GetPublicationCount(researcher.id) / 1;
                case Level.C:
                    return adapter.GetPublicationCount(researcher.id) / 2;
                case Level.D:
                    return adapter.GetPublicationCount(researcher.id) / 3.2;
                case Level.E:
                    return adapter.GetPublicationCount(researcher.id) / 4;
                default:
                    return 0;
            }
        }
    }
}
