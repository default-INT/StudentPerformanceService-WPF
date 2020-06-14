using StudentPerformanceServiceCL.Models.Entities;
using StudentPerformanceServiceCL.Services.StudentFilters;
using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services
{
    public class StudentFilterService
    {
        public IEnumerable<StudentViewModel> StudentViews { get; set; }

        public IEnumerable<StudentViewModel> GetStudents(string facultyName = null, string specialtyName = null,
            int? course = null, Session session = null)
        {
            var studentFilter = new StudentFilter();
            studentFilter.SetDefaultData();

            if (facultyName != null)
                studentFilter = new FacultyStudentFilter(studentFilter, facultyName);
            if (specialtyName != null)
                studentFilter = new SpecialtyStudentFilter(studentFilter, specialtyName);
            if (course != null)
                studentFilter = new CourseStudentFilter(studentFilter, course.Value);
            if (session != null)
                studentFilter = new SessionStudentFilter(studentFilter, session);

            StudentViews = studentFilter.Students;

            return StudentViews;
        }
    }
}
