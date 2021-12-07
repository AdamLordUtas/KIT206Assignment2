﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KIT206Assignment2.Research;
using KIT206Assignment2.Control;

namespace KIT206Assignment2.Database
{
    class erdAdapter
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private MySqlConnection conn = null;

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        public MySqlConnection SqlConnection()
        {
            if (conn == null) 
            { 
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2}; Password={3}", db, server, user, pass); 
                conn = new MySqlConnection(connectionString); 
            } 
            return conn; 
        }

        //Get the names of the researchers to be presented in a list
        public List<Researcher> GetBasicResearcherDetails() 
        {
            //Will store list of found researchers if any
            List<Researcher>foundResearchers = new List<Researcher>();

            //Creating a connection and a reader
            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try 
	        {	      
                //Opening connection
		        conn.Open();

                //Query gets basic researcher details, id can be used later to get more details in GetFullResearcherDetails()
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title from researcher", conn);
                rdr = cmd.ExecuteReader();

                //Add each valid researcher to our list
                while (rdr.Read())
	            {
                    //Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                    foundResearchers.Add(new Researcher
                    {
                        id = rdr.GetInt32(0), 
                        givenName = rdr.GetString(1), 
                        familyName = rdr.GetString(2),
                        title = rdr.GetString(3)
                    });
	            }

	        }
            finally 
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return foundResearchers;
        }
        
        //Get the full details of an individual researcher to be displayed
        public Researcher GetFullResearcherDetails(Researcher researcher) 
        {
            //For storing our researchers details
            Researcher foundResearcher = new Researcher();

            //Creating a connection and a reader
            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try
            {
                //Opening connection
                conn.Open();

                //Query uses the id of a researcher to get more of their details for display
                MySqlCommand cmd = new MySqlCommand(String.Format("select * from researcher where id = {0}", researcher.id), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Staff and students have different details stored so check their type and only store relevant details
                    if (rdr.GetString(1) == "Staff")
                    {
                        foundResearcher.id = rdr.GetInt32(0);
                        foundResearcher.type = ParseEnum<Rtype>(rdr.GetString(1));
                        foundResearcher.givenName = rdr.GetString(2);
                        foundResearcher.familyName = rdr.GetString(3);
                        foundResearcher.title = rdr.GetString(4);
                        foundResearcher.unit = rdr.GetString(5);
                        foundResearcher.campus = ParseEnum<Campus>(rdr.GetString(6));
                        foundResearcher.email = rdr.GetString(7);
                        foundResearcher.photo = rdr.GetString(8);
                        //Staff don't include degree
                        //Staff don't include supervisor
                        foundResearcher.position = new Position
                        {
                            id = foundResearcher.id,
                            level = ParseEnum<Level>(rdr.GetString(11)),
                            start = rdr.GetDateTime(12),
                            end = rdr.GetDateTime(13)
                        };
                    }
                    
                    else
                    {
                        foundResearcher.id = rdr.GetInt32(0);
                        foundResearcher.type = ParseEnum<Rtype>(rdr.GetString(1));
                        foundResearcher.givenName = rdr.GetString(2);
                        foundResearcher.familyName = rdr.GetString(3);
                        foundResearcher.title = rdr.GetString(4);
                        foundResearcher.unit = rdr.GetString(5);
                        foundResearcher.campus = ParseEnum<Campus>(rdr.GetString(6));
                        foundResearcher.email = rdr.GetString(6);
                        foundResearcher.photo = rdr.GetString(7);
                        foundResearcher.degree = rdr.GetString(9);
                        foundResearcher.supervisorId = rdr.GetInt32(10);
                        foundResearcher.position = new Position
                        {
                            id = foundResearcher.id,
                            //Students don't have a position level
                            start = rdr.GetDateTime(12),
                            end = rdr.GetDateTime(13)
                        };
                    }
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return foundResearcher;
        }

        //Get list of publications associated with a researcher
        public List<Publication> GetBasicPublicationDetails(Researcher researcher) 
        {
            //List to store found publications if any
            List<Publication> foundPublications = new List<Publication>();
            
            //Creating a connection and a reader
            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try
            {
                //Opening connection
                conn.Open();

                //Query creates a joined table of all the titles of pubilcations associated with the rsearcher mased on their id 
                MySqlCommand cmd = new MySqlCommand(String.Format("select publication.doi, publication.title from researcher_publication join publication on researcher_publication.doi = publication.doi where researcher_publication.researcher_id = {0}", researcher.id), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));

                    //Adds a relevant publication with a doi and title, doi can be used later to get specific details in GetFullPublicationDetails()
                    foundPublications.Add(new Publication
                    {
                        doi = rdr.GetString(0),
                        title = rdr.GetString(1)
                    });
                }

            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return foundPublications;
        }

        //Get the full details of a specific publication
        public Publication GetFullPublicationDetails(Publication publication) 
        {
            Publication foundPublication = null;

            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(String.Format("select * from publication where doi = {0}", publication.doi), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                    foundPublication.doi = rdr.GetString(0);
                    foundPublication.title = rdr.GetString(1);
                    foundPublication.authours = rdr.GetString(2);
                    foundPublication.year = rdr.GetInt32(3);
                    foundPublication.type = ParseEnum<Ptype>(rdr.GetString(4));
                    foundPublication.citeAs = rdr.GetString(5);
                    foundPublication.available = rdr.GetDateTime(6);
                }

            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return foundPublication;
        }

        //Count the amount of publications a researcher has
        public int GetPublicationsCount(DateTime startDate, DateTime endDate) 
        {
            return 0;
        }
    }
}
