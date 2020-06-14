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
            Role = 0;
        }

        public Admin(Account account) : base(account)
        {
            Role = 0;
        }

        public override string Status => "Администратор";
    }
}
