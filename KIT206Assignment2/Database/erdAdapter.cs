using System;
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
            List<Researcher>foundResearchers = new List<Researcher>();

            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try 
	        {	        
		        conn.Open();
                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name, title from researcher", conn);
                rdr = cmd.ExecuteReader();

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
        public Researcher GetFullResearcherDetails(Researcher find) 
        {
            Researcher foundResearcher = null;

            conn = SqlConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(String.Format("select * from researcher where id = {0}", find.id), conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine("{0} {1}", rdr[0], rdr.GetString(1));
                    foundResearcher = new Researcher
                    {
                        id = rdr.GetInt32(0),
                        givenName = rdr.GetString(1),
                        familyName = rdr.GetString(2),
                        title = rdr.GetString(3),
                        unit = rdr.GetString(4),
                        //campus = rdr.GetEnumerator(), //5
                        email = rdr.GetString(6),
                        photo = rdr.GetString(7),
                        degree = rdr.GetString(8),
                        supervisorId = rdr.GetInt32(9),
                        //position = rdr.GetEnumerator(), //10
                    };
                    foundResearcher.position.start = rdr.GetDateTime(11);
                    foundResearcher.position.end = rdr.GetDateTime(12);
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
        public Publication[] GetBasicPublicationDetails(int researcherId) 
        {
            return null;
        }

        //Get the full details of a specific publication
        public Publication GetFullPublicationDetails(Publication publication) 
        {
            return null;
        }

        public int[] GetPublicationsCount(DateTime startDate, DateTime endDate) 
        {
            return null;
        }
    }
}
