using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Tests
{
    /// <summary>
    /// Результаты сдачи испытания для конкретного студента.
    /// </summary>
    [Table(Name = "test_results")]
    public class TestResult : Entity
    {
        public int TestId { get; set; }
        public int StudentId { get; set; }
        public DateTime CompletionDate { get; set; }
        public int Mark { get; set; }
        public int AttemptsNumber { get; set; }

        public Test Test => db.TestDAO.Tests
            .FirstOrDefault(t => t.Id == TestId);
        public Student Student => db.AccountDAO.Students
            .FirstOrDefault(s => s.Id == StudentId);
    }
}
