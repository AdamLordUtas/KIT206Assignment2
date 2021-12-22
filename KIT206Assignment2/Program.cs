/*
 * KIT206 Assignment 2
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206Assignment2.Research;
using KIT206Assignment2.Control;


namespace KIT206Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-Start-\n");

            ResearcherControls resControl = new ResearcherControls();
            PublicationControls pubControl = new PublicationControls();

            resControl.LoadResearchers();
            pubControl.LoadPublications(resControl.masterList[0].id);

            foreach (var item in pubControl.displayList)
	        {
                Console.WriteLine(item.title);
	        }

            Console.WriteLine(resControl.Performance(resControl.masterList[1]));
        }
    }
}
