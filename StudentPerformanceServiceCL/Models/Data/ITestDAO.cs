using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface ITestDAO
    {
        IEnumerable<Test> Tests { get; }
        IEnumerable<ExamTest> ExamTests { get; }
        IEnumerable<OffsetTest> OffsetTests { get; }
        IEnumerable<CourseworkTest> CourseworkTests { get; }
        IEnumerable<TestResult> TestResults { get; }

        void Add(Test test);
        void Add(TestResult testResult);
        void Update(TestResult testResult);
    }
}
