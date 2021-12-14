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
    class PublicationControls
    {
        public List<Publication> masterList = new List<Publication>();
        ObservableCollection<Publication> displayList;
        erdAdapter adapter = new erdAdapter();

        //Loads the publications
        public void LoadPublications(int ID)
        {
            masterList = adapter.GetBasicPublicationDetails(ID);
            displayList = new ObservableCollection<Publication>(masterList);
        }

        //Get the display list as a list of publicatons
        public List<Publication> GetPublications()
        {
            return displayList.ToList();
        }

        public void OrderByYear()
        {
            Console.WriteLine("\nOrderbyYear...");

            IEnumerable<Publication> filterPub =
                from Publication in masterList
                orderby Publication
                select Publication;

            displayList.Clear();
            filterPub.ToList().ForEach(displayList.Add);
        }
    }
}
