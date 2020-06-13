using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentPerformanceServiceCL.Models.Data;

namespace StudentPerformanceServiceUT
{
    [TestClass]
    public class AccountUnitTest
    {
        private readonly DAOFactory db;

        public AccountUnitTest()
        {
            db = DAOFactory.GetDAOFactory();
        }

        [TestMethod]
        public void MethodistDeanerys_GetFromDB()
        {
            var accounts = db.AccountDAO.MethodistDeaneries;

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
            Assert.IsNotNull(accounts);
        }

        [TestMethod]
        public void Students_GetFromDB()
        {
            var accounts = db.AccountDAO.Students;

            foreach (var account in accounts)
            {
                Console.WriteLine(account);
            }
            Assert.IsNotNull(accounts);
        }

        [TestMethod]
        public void LogInAdmin_GetFromDB()
        {
            var account = db.AccountDAO.LogIn("admin", "a1806"); ;

            Console.WriteLine(account);

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void LogInMethodistDeanery_GetFromDB()
        {
            var account = db.AccountDAO.LogIn("methodist", "m1806"); ;

            Console.WriteLine(account);

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void LogInStudent_GetFromDB()
        {
            var account = db.AccountDAO.LogIn("ropot", "s1806"); ;

            Console.WriteLine(account);

            Assert.IsNotNull(account);
        }

        [TestMethod]
        public void Students_GetNavigatePropertysFromDB()
        {
            var accounts = db.AccountDAO.Students;

            foreach (var account in accounts)
            {
                Console.WriteLine(account.Group);
                Console.WriteLine(account.TestResults);
            }
            Assert.IsNotNull(accounts);
        }
    }
}
