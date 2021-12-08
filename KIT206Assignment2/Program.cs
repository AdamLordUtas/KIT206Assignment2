/*
 * KIT206 Assignment 2
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206Assignment2.Research;
using KIT206Assignment2.Database;
using KIT206Assignment2.Control;


namespace KIT206Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-Start-\n");

            //Adapter used to interact with database
            erdAdapter adapter = new erdAdapter();
            
            //Loading Researchers
            List<Researcher>found = adapter.GetBasicResearcherDetails();
            foreach (Researcher item in found)
	        {
                Console.WriteLine(item.listDisplay());
	        }

            //Getting a specific researcher's details
            Researcher specificResearcher = adapter.GetFullResearcherDetails(found[6]);
            Console.WriteLine("\n" + specificResearcher.listDisplay() + "\n");

            //Loading Publications for first person
            List<Publication> foundPub = adapter.GetBasicPublicationDetails(found[0]);
            foreach (var item in foundPub)
            {
                Console.WriteLine(item.title);
            }

            //Getting a specific publication
            Console.WriteLine("\n" + adapter.GetFullPublicationDetails(foundPub[0]).title + "\n");

        }
    }
}
