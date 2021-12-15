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

            //Load Researchers
            resControl.LoadResearchers();

            //Display the master list
            foreach (var item in resControl.masterList)
            {
                Console.WriteLine(item.listDisplay());
            }

            //Run filter
            resControl.FilterAlphabetically();

            //Display filter
            foreach (var item in resControl.GetResearchers())
            {
                Console.WriteLine(item.listDisplay());
            }

            //filterbyName
            resControl.FilterByName("John");
            foreach (var item in resControl.GetResearchers())
            {
                Console.WriteLine(item.listDisplay());
            }
            //filterbyLevel
            resControl.FilterByLevel(Level.B);
            foreach (var item in resControl.GetResearchers())
            {
                Console.WriteLine(item.listDisplay());
            }
            //load Publication
            pubControl.LoadPublications(123460);

            //orderbyyear
            pubControl.OrderByYear();
            foreach (var item in pubControl.GetPublications())
            {
                Console.WriteLine(item.title + item.year);
            }
            //OrderByDescending
            pubControl.OrderByDescending();
            foreach (var item in pubControl.GetPublications())
            {
                Console.WriteLine(item.title + item.year);
            }
        }
    }
}
