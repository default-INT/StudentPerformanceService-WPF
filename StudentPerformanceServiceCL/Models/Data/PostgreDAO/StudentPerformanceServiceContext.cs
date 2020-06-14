using DbLinq.Data.Linq;
using DbLinq.PostgreSql;
using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class StudentPerformanceServiceContext : PgsqlDataContext
    {
        internal Table<Account> Accounts => GetTable<Account>();
        internal Table<Faculty> Faculties => GetTable<Faculty>();
        internal Table<Group> Groups => GetTable<Group>();
        internal Table<Specialty> Specialties => GetTable<Specialty>();
        internal Table<Subject> Subjects => GetTable<Subject>();
        internal Table<Test> Tests => GetTable<Test>();
        internal Table<TestResult> TestResults => GetTable<TestResult>();
        internal Table<SubjectSpecialty> SubjectSpecialties => GetTable<SubjectSpecialty>();
        internal Table<Session> Sessions => GetTable<Session>();

        public StudentPerformanceServiceContext(DbConnection conn) : base(conn)
        {
        }
    }
}
