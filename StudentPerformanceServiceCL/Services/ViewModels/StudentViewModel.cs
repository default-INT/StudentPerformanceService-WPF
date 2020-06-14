using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string StudentFullName { get; set; }
        public string FacultyName { get; set; }
        public string GroupName { get; set; }
        public int Course { get; set; }
        public double AvgMark { get; set; }
        public Faculty Faculty { get; set; }
        public Group Group { get; set; }
        public Student Student { get; set; }
        public IEnumerable<TestResult> TestResults { get; set; }
    }
}
