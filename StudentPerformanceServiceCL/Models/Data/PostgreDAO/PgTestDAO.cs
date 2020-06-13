using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgTestDAO : ITestDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgTestDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Test> Tests => _context.Tests
            .AsEnumerable()
            .Select(t => t.Cast());

        public IEnumerable<ExamTest> ExamTests => _context.Tests
            .Where(t => t.Type == 1)
            .AsEnumerable()
            .Select(t => new ExamTest(t));

        public IEnumerable<OffsetTest> OffsetTests => _context.Tests
            .Where(t => t.Type == 0)
            .AsEnumerable()
            .Select(t => new OffsetTest(t));

        public IEnumerable<CourseworkTest> CourseworkTests => _context.Tests
            .Where(t => t.Type == 2)
            .AsEnumerable()
            .Select(t => new CourseworkTest(t));

        public IEnumerable<TestResult> TestResults => _context.TestResults;

        public void Add(Test test)
        {
            _context.Tests.InsertOnSubmit(new Test(test));

            _context.SubmitChanges();
        }

        public void Add(TestResult testResult)
        {
            _context.TestResults.InsertOnSubmit(testResult);

            _context.SubmitChanges();
        }

        public void Update(TestResult testResult)
        {
            var updateTestResult = _context.TestResults
                .FirstOrDefault(t => t.Id == testResult.Id);

            updateTestResult.Mark = testResult.Mark;
            updateTestResult.StudentId = testResult.StudentId;
            updateTestResult.TestId = testResult.TestId;
            updateTestResult.AttemptsNumber = testResult.AttemptsNumber;
            updateTestResult.CompletionDate = testResult.CompletionDate;

            _context.SubmitChanges();
        }
    }
}
