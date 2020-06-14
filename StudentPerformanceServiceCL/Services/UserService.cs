using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services
{
    public class UserService
    {
        private static UserService instance;

        private UserService() { }

        public static UserService Instance
        {
            get
            {
                if (instance != null) return instance;
                instance = new UserService();
                return instance;
            }
        }

        public Account Account { get; set; }

        public void LogOut()
        {
            Account = null;
        }
    }
}
