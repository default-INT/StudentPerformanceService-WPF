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
        [Column(Name = "test_id")]
        public int TestId { get; set; }
        [Column(Name = "student_id")]
        public int StudentId { get; set; }
        [Column(Name = "completion_date")]
        public DateTime CompletionDate { get; set; }
        [Column(Name = "mark")]
        public int Mark { get; set; }
        [Column(Name = "retake")]
        public bool Retake { get; set; }
        [Column(Name = "attempts_number")]
        public int AttemptsNumber { get; set; }

        public Test Test => db.TestDAO.Tests
            .FirstOrDefault(t => t.Id == TestId);
        public Student Student => db.AccountDAO.Students
            .FirstOrDefault(s => s.Id == StudentId);
    }
}
