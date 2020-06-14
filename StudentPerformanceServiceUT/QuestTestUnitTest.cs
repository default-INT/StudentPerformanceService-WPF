using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class QuestTestUnitTest
    {
        private readonly DAOFactory db;

        public QuestTestUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void Tests_GetFromDB()
        {
            var tests = db.TestDAO.Tests;

            foreach (var test in tests)
            {
                Console.WriteLine(test);
            }
            Assert.IsNotNull(tests);
        }

        [TestMethod]
        public void ExamTests_GetFromDB()
        {
            var tests = db.TestDAO.ExamTests;

            foreach (var test in tests)
            {
                Console.WriteLine(test);
            }
            Assert.IsNotNull(tests);
        }

        [TestMethod]
        public void OffsetTests_GetFromDB()
        {
            var tests = db.TestDAO.OffsetTests;

            foreach (var test in tests)
            {
                Console.WriteLine(test);
            }
            Assert.IsNotNull(tests);
        }

        [TestMethod]
        public void CourseworkTests_GetFromDB()
        {
            var tests = db.TestDAO.CourseworkTests;

            foreach (var test in tests)
            {
                Console.WriteLine(test);
            }
            Assert.IsNotNull(tests);
        }

        [TestMethod]
        public void Test_GroupGetFromDB()
        {
            var test = db.TestDAO.Tests.First();

            Console.WriteLine(test.Group);

            Assert.IsNotNull(test.Group);
        }

        [TestMethod]
        public void Test_SubjectGetFromDB()
        {
            var test = db.TestDAO.Tests.First();

            Console.WriteLine(test.Subject);

            Assert.IsNotNull(test.Subject);
        }

        [TestMethod]
        public void Test_StudentsGetFromDB()
        {
            var test = db.TestDAO.Tests.First();

            Console.WriteLine(test.Students);

            Assert.IsNotNull(test.Students);
        }

        [TestMethod]
        public void Test_SessionGetFromDB()
        {
            var test = db.TestDAO.Tests.First();

            Console.WriteLine(test.Session);

            Assert.IsNotNull(test.Session);
        }
    }
}
