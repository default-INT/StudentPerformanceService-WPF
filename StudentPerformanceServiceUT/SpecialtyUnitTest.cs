using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class SpecialtyUnitTest
    {
        private readonly DAOFactory db;

        public SpecialtyUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void Specialties_GetFormDB()
        {
            var specialties = db.SpecialtyDAO.Specialties;

            foreach (var spec in specialties)
            {
                Console.WriteLine(spec);
            }
            Assert.IsNotNull(specialties);
        }

        [TestMethod]
        public void Specialties_GetNavigatePropertiesFormDB()
        {
            var specialties = db.SpecialtyDAO.Specialties;

            foreach (var spec in specialties)
            {
                Console.WriteLine(spec.Faculty);
                Console.WriteLine(spec.Students);
                Console.WriteLine(spec.Subjects);
            }
            Assert.IsNotNull(specialties);
        }
    }
}
