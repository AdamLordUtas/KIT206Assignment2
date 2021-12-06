using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace KIT206Assignment2
{
    //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
    private const string db = "kit206";
    private const string user = "kit206";
    private const string pass = "kit206";
    private const string server = "alacritas.cis.utas.edu.au";

    private SqlConnection conn;

    class erdAdapter
    {
        public static SqlConnection()
        {
            if (conn == null) 
            { 
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2}; Password={3}", db, server, user, pass); 
                conn = new MySqlConnection(connectionString); 
            } 
            return conn; 
        }

        //Get the names of the researchers to be presented in a list
        public Researcher[] GetBasicResearcherDetails() 
        {

        }
        
        //Get the full details of an individual researcher to be displayed
        public Researcher fetchFullResearcherDetails(int researcherId) 
        {
            return null;
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
