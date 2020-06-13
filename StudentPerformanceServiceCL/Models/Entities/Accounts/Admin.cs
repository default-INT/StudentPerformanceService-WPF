using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Accounts
{
    public class Admin : Account
    {
        public Admin()
        {
        }

        public Admin(Account account) : base(account)
        {
        }
    }
}
