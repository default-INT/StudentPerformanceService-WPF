using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Accounts
{
    public class MethodistDeanery : Account
    {
        public int FacultyId
        {
            get => __facultyId.Value;
            set => __facultyId = value;

        }
        public MethodistDeanery()
        {
            Role = 1;
        }

        public MethodistDeanery(Account account) : base(account)
        {
            Role = 1;
        }

        public override string Status => "Методист деканата";
    }
}
