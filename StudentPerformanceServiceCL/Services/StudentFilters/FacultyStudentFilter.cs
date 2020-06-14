using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal class FacultyStudentFilter : StudentFilterDecorator
    {
        private string facultyName;
        public FacultyStudentFilter(StudentFilter studentFilter, string facultyName) : base(studentFilter)
        {
            this.facultyName = facultyName;
        }

        public override IEnumerable<StudentViewModel> Students 
        {
            get => studentFilter.Students
                .Where(s => s.Faculty.Name == facultyName);
            set => base.Students = value; 
        }
    }
}
