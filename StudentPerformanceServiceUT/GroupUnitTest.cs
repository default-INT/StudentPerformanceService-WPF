using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class GroupUnitTest
    {
        private readonly DAOFactory db;

        public GroupUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void Groups_GetFromDB()
        {
            var groups = db.GroupDAO.Groups;

            foreach (var group in groups)
            {
                Console.WriteLine(group);
            }
            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public void Groups_GetNavigatePropertysFromDB()
        {
            var groups = db.GroupDAO.Groups;

            foreach (var group in groups)
            {
                Console.WriteLine(group.Specialty);
                Console.WriteLine(group.Students);
            }
            Assert.IsNotNull(groups);
        }
    }
}
