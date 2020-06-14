using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Accounts
{
    /// <summary>
    /// Класс описывающий студента определённого курса по определённой специальности.
    /// </summary>
    public class Student : Account
    {
        public int GroupId
        {
            get => __groupId.Value;
            set => __groupId = value;
        }
        private Group group;

        public Student()
        {
        }

        public Student(Account account) : base(account)
        {
        }

        public Group Group
        {
            get
            {
                if (group != null) return group;
                group = db.GroupDAO.Groups
                    .FirstOrDefault(g => g.Id == GroupId);
                return group;
            }
        }
        public IEnumerable<TestResult> TestResults => db.TestDAO.TestResults
            .Where(t => t.StudentId == Id);
    }
}
