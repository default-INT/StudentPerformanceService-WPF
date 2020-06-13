using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class SubjectUnitTest
    {
        private readonly DAOFactory db;

        public SubjectUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void Subjects_GetFormDB()
        {
            var subjects = db.SubjectDAO.Subjects;

            foreach (var subject in subjects)
            {
                Console.WriteLine(subject);
            }

            Assert.IsNotNull(subjects);
        }

        [TestMethod]
        public void Subjects_GetNavigatePropertiesFormDB()
        {
            var subjects = db.SubjectDAO.Subjects;

            foreach (var subject in subjects)
            {
                Console.WriteLine(subject.Specialties);
            }

            Assert.IsNotNull(subjects);
        }
    }
}
