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
            erdAdapter adapter = new erdAdapter();

            Console.WriteLine("-Start-\n");

            //Testing
            List<Position> dummyPositions = new List<Position>() 
            {
                new Position{
                    id = 500, 
                    level = Level.C, 
                    start = new DateTime(1999, 8, 21), 
                    end = new DateTime(2001, 8, 13) }
            };

            //Testing
            List<Researcher> dummyResearchers = new List<Researcher>()
            {
                new Researcher{ 
                    id = 500, 
                    givenName = "John", familyName = "Johnson",
                    title = "Mr", unit = "Maths", 
                    campus = Campus.Hobart, degree = "Maths", 
                    email = "jjohnson@email.com", photo = "image.jpg", 
                    position = dummyPositions[0], supervisorId = 100}
            };

            //Testing
            List<Publication> dummyPublications = new List<Publication>()
            {
                new Publication{
                    doi = "55.2000xp", title = "Real Journal about something",
                    authours = "John Johnson", year = 2009,
                    type = Ptype.Journal, citeAs = "real paper, 2009",
                    available = new DateTime(2021, 4, 21) }
            };

            //Console.WriteLine(dummyResearchers[0].givenName +"'s position is " + dummyResearchers[0].JobTitle());
            //Console.WriteLine("The age of " + dummyPublications[0].title + " is " + dummyPublications[0].Age() + " years old");
            List<Researcher>found = adapter.GetBasicResearcherDetails();
            foreach (Researcher item in found)
	        {
                Console.WriteLine(item.listDisplay());
	        }

            //List<Publication> foundPub = adapter.GetBasicPublicationDetails(found[0]);

            //foreach (var item in foundPub)
            //{
              //  Console.WriteLine(item.title);
            //}

            Researcher specificResearcher = adapter.GetFullResearcherDetails(found[0]);


            Console.WriteLine(specificResearcher.listDisplay());
        }
    }
}
