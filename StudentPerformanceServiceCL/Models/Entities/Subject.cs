using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    /// <summary>
    /// Класс описывает дисциплину / предмет.
    /// </summary>
    [Table(Name = "subjects")]
    public class Subject : Entity
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "teacher")]
        public string Teacher { get; set; }

        public IEnumerable<Test> Tests => db.TestDAO.Tests
            .Where(t => t.SubjectId == Id);

        public IEnumerable<TestResult> TestResults
        {
            get
            {
                IEnumerable<TestResult> outTestResults = new List<TestResult>();
                foreach (var testResults in Tests.Select(t => t.TestResults))
                {
                    outTestResults = outTestResults.Concat(testResults.ToList());
                }
                return outTestResults;
            }
        }

        public IEnumerable<Specialty> Specialties => db.SubjectSpecialtyDAO.SubjectSpecialties
            .Where(s => s.SubjectId == Id)
            .Select(s => s.Specialty);

        public IEnumerable<Group> Groups
        {
            get
            {
                IEnumerable<Group> outGroups = new List<Group>();
                foreach (var groups in Specialties.Select(s => s.Groups))
                {
                    outGroups = outGroups.Concat(groups);
                }
                return outGroups;
            }
        }

        public override string ToString() => Name;
    }
}
