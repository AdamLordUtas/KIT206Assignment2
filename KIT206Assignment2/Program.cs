﻿/*
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
            ResearcherControls resControl = new ResearcherControls();

            resControl.list = adapter.GetBasicResearcherDetails();
            //Loading Researchers

            Console.WriteLine("Researchers");
            foreach (Researcher item in resControl.list)
	        {
                Console.WriteLine(item.listDisplay());
	        }

            //Getting a specific researcher's details
            Researcher specRes = adapter.GetFullResearcherDetails(resControl.list[6]);
            Console.WriteLine("\nSpecific Researcher");
            Console.WriteLine(specRes.listDisplay() + "\n");

            //Loading Publications for first person
            List<Publication> foundPub = adapter.GetBasicPublicationDetails(resControl.list[0]);
            
            Console.WriteLine("Publications");
            foreach (var item in foundPub)
            {
                Console.WriteLine(item.title);
            }

            //Getting a specific publication's details
            Publication specPub = adapter.GetFullPublicationDetails(foundPub[0]);
            
            Console.WriteLine("\nSpecific Publication");
            Console.WriteLine(String.Format("{0},\n{1}\nThis publication is {2} year(s) old,", specPub.doi, specPub.title, specPub.Age()));

            //Get an alphabetically sorted list of researchers
            List<Researcher> resAlphabetically = resControl.FilterAlphabetically(resControl.list);

            //Display it
            foreach (var item in resAlphabetically)
	        {
                Console.WriteLine(item.listDisplay());
	        }
        }
    }
}
