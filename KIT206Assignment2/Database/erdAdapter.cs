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
		private const string db = "kit206";
		private const string user = "kit206";
		private const string pass = "kit206";
		private const string server = "alacritas.cis.utas.edu.au";

		private MySqlConnection conn = null;
		
		//Used to get the values of enums out of the database
		public static T ParseEnum<T>(string value)
		{
			return (T)Enum.Parse(typeof(T), value);
		}

		//Special parse enum for campus as cradle coast is called crade_coast in code
		public static T ParseCampusEnum<T>(string value)
		{
           return (T)Enum.Parse(typeof(T), value.Replace(" ","_"));
		}

		//Creates the connection
		public MySqlConnection SqlConnection()
		{
			if (conn == null) 
			{ 
				string connectionString = String.Format("Database={0};Data Source={1};User Id={2}; Password={3}", db, server, user, pass); 
				conn = new MySqlConnection(connectionString); 
			} 
			return conn; 
		}

		/*
		 * Researcher interactions with database
		 */
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
				MySqlCommand cmd = new MySqlCommand("select id, type, given_name, family_name, title, current_start from researcher", conn);
				rdr = cmd.ExecuteReader();

				//Add each valid researcher to our list
				while (rdr.Read())
				{
					foundResearchers.Add(new Researcher
					{
						id = rdr.GetInt32(0), 
						type = ParseEnum<Rtype>(rdr.GetString(1)),
						givenName = rdr.GetString(2), 
						familyName = rdr.GetString(3),
						title = rdr.GetString(4),
						position = new Position 
						{
							start = rdr.GetDateTime(5)
						}
					});
				}

				rdr.Close();

				//Getting the current position of a researcher
				foreach (var researcher in foundResearchers)
				{
					//Sql for getting there current position
					cmd = new MySqlCommand(String.Format("select * from position where id = {0} and start = '{1}'", researcher.id, researcher.position.start.ToString("yyyy/MM/dd")), conn);

					rdr = cmd.ExecuteReader();

					//If something is found
					if (rdr.Read())
					{
						researcher.position.id = researcher.id;
						researcher.position.level = ParseEnum<Level>(rdr.GetString(1));
						if (!rdr.IsDBNull(3))
						{
							researcher.position.end = rdr.GetDateTime(3);
						}
					}

					rdr.Close();
				}	
			}
            catch(Exception e)
			{
				Console.WriteLine("Something went wrong " + e);
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
					/*Column numbers for rdr.Get****():
					 * 0 = id
					 * 1 = type
					 * 2 = given_name
					 * 3 = family_name
					 * 4 = title
					 * 5 = unit
					 * 6 = campus
					 * 7 = email
					 * 8 = photo
					 * 9 = degree
					 * 10 = supervisorid
					 * 11 = level
					 * 12 = start date
					 * 13 = end date
					 */

					//Staff and students have different details stored so check their type and only store relevant details
					if (rdr.GetString(1) == "Staff")
					{
						foundResearcher.id = rdr.GetInt32(0);
						foundResearcher.type = ParseEnum<Rtype>(rdr.GetString(1));
						foundResearcher.givenName = rdr.GetString(2);
						foundResearcher.familyName = rdr.GetString(3);
						foundResearcher.title = rdr.GetString(4);
						foundResearcher.unit = rdr.GetString(5);
						foundResearcher.campus = ParseCampusEnum<Campus>(rdr.GetString(6));
						foundResearcher.email = rdr.GetString(7);
						foundResearcher.photo = rdr.GetString(8);
						//Staff don't include degree
						//Staff don't include supervisor
						foundResearcher.position = new Position();
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
						foundResearcher.position = new Position();
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Something went wrong " + e);
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

		/*
		 * Publication interactions with database
		 */
		//Get a basic list of publications associated with a researcher
		public List<Publication> GetBasicPublicationDetails(int researcherId) 

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
				MySqlCommand cmd = new MySqlCommand(String.Format("select publication.doi, publication.title, publication.year from researcher_publication join publication on researcher_publication.doi = publication.doi where researcher_publication.researcher_id = {0}", researcherId), conn);
				rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					//Adds a relevant publication with a doi and title, doi can be used later to get specific details in GetFullPublicationDetails()
					foundPublications.Add(new Publication
					{
						doi = rdr.GetString(0),
						title = rdr.GetString(1),
						year = rdr.GetInt32(2)
					});
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Something went wrong " + e);
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
			//For storing the publications details
			Publication foundPublication = new Publication();

			//Create a connection and a reader
			conn = SqlConnection();
			MySqlDataReader rdr = null;

			try
			{
				//Open the connection
				conn.Open();
				MySqlCommand cmd = new MySqlCommand(String.Format("select * from publication where doi = '{0}'", publication.doi), conn);
				rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					/*Column numbers for rdr.Get****():
					 * 0 = doi
					 * 1 = title
					 * 2 = authors
					 * 3 = year
					 * 4 = type
					 * 5 = citeAs
					 * 6 = available
					 */

					foundPublication.doi = rdr.GetString(0);
					foundPublication.title = rdr.GetString(1);
					foundPublication.authours = rdr.GetString(2);
					foundPublication.year = rdr.GetInt32(3);
					foundPublication.type = ParseEnum<Ptype>(rdr.GetString(4));
					foundPublication.citeAs = rdr.GetString(5);
					foundPublication.available = rdr.GetDateTime(6);
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Something went wrong " + e);
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

		
		public int GetPublicationCount(int researcherId)

		{
			//List to store found publications if any
			List<Publication> foundPublications = new List<Publication>();
			
			DateTime threeYears = DateTime.Today.AddYears(-3);

			Console.WriteLine(threeYears);

			int count = 0;

			//Creating a connection and a reader
			conn = SqlConnection();
			MySqlDataReader rdr = null;

			try
			{
				//Opening connection
				conn.Open();

				//Query creates a joined table of all the titles of pubilcations associated with the rsearcher based on their id 
				MySqlCommand cmd = new MySqlCommand(String.Format("select publication.doi from researcher_publication join publication on researcher_publication.doi = publication.doi where researcher_publication.researcher_id = {0} and publication.available >= {1}", researcherId, threeYears.ToString("yyyy/MM/dd")), conn);
				rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					count++;
				}

			}
			catch (Exception e)
			{
				Console.WriteLine("Something went wrong " + e);
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

			return count;
		}


		}
	}

