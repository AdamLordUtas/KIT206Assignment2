using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206Assignment2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-Start-\n");

            List<Position> dummyPositions = new List<Position>() 
            {
                new Position{
                    id = 500, 
                    level = Level.C, 
                    start = new DateTime(1999, 8, 21), 
                    end = new DateTime(2001, 8, 13) }
            };

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

            Console.WriteLine(dummyResearchers[0].jobTitle());
        }
    }
}
