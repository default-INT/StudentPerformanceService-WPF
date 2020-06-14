using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal class SessionStudentFilter : StudentFilterDecorator
    {
        private Session _session;
        public SessionStudentFilter(StudentFilter studentFilter, Session session) : base(studentFilter)
        {
            _session = session;
        }

        public override IEnumerable<StudentViewModel> Students 
        {
            get => studentFilter.Students
                .Select(s => 
                {
                    var testResult = s.Student.TestResults
                        .Where(t => t.Test.SessionId == _session.Id);
                    return new StudentViewModel()
                    {
                        Id = s.Id,
                        StudentFullName = s.StudentFullName,
                        Student = s.Student,
                        Course = s.Course,
                        Group = s.Group,
                        GroupName = s.GroupName,
                        Faculty = s.Faculty,
                        FacultyName = s.FacultyName,
                        AvgMark = testResult.Count() != 0 ? testResult.Sum(t => t.Mark) / testResult.Count() : 0,
                        TestResults = testResult
                    };
                });
            set => base.Students = value; 
        }
    }
}
