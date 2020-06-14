using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal class CourseStudentFilter : StudentFilterDecorator
    {
        private int course;
        public CourseStudentFilter(StudentFilter studentFilter, int course) : base(studentFilter)
        {
            this.course = course;
        }

        public override IEnumerable<StudentViewModel> Students 
        {
            get => studentFilter.Students
                .Where(s => s.Course == course);
            set => base.Students = value; 
        }
    }
}
