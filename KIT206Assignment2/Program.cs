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
        }
    }
}
