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
            
            //Loading Researchers
            List<Researcher>foundRes = adapter.GetBasicResearcherDetails();

            Console.WriteLine("Researchers");
            foreach (Researcher item in foundRes)
	        {
                Console.WriteLine(item.listDisplay());
	        }

            //Getting a specific researcher's details
            Researcher specRes = adapter.GetFullResearcherDetails(foundRes[6]);
            Console.WriteLine("\nSpecific Researcher");
            Console.WriteLine(specRes.listDisplay() + "\n");

            //Loading Publications for first person
            List<Publication> foundPub = adapter.GetBasicPublicationDetails(foundRes[0]);
            
            Console.WriteLine("Publications");
            foreach (var item in foundPub)
            {
                Console.WriteLine(item.title);
            }

            //Getting a specific publication's details
            Publication specPub = adapter.GetFullPublicationDetails(foundPub[0]);
            
            Console.WriteLine("\nSpecific Publication");
            Console.WriteLine(String.Format("{0},\n{1}\nThis publication is {2} year(s) old,", specPub.doi, specPub.title, specPub.Age()));

        }
    }
}
