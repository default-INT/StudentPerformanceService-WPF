using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class FacultyUnitTest
    {
        private readonly DAOFactory db;

        public FacultyUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void Faculties_GetFromDB()
        {
            var faculties = db.FacultyDAO.Faculties;

            foreach (var faculty in faculties)
            {
                Console.WriteLine(faculty);
            }

            Assert.IsNotNull(faculties);
        }

        [TestMethod]
        public void Faculties_GetNavigatePropertiesFromDB()
        {
            var faculties = db.FacultyDAO.Faculties;

            foreach (var faculty in faculties)
            {
                Console.WriteLine(faculty.Specialties);
            }

            Assert.IsNotNull(faculties);
        }
    }
}
