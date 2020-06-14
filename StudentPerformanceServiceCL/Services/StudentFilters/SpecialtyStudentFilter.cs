using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal class SpecialtyStudentFilter : StudentFilterDecorator
    {
        private string specialtyName;
        public SpecialtyStudentFilter(StudentFilter studentFilter, string specialty) : base(studentFilter)
        {
            this.specialtyName = specialty;
        }

        public override IEnumerable<StudentViewModel> Students 
        {
            get => studentFilter.Students
                .Where(s => s.Group.Specialty.Name == specialtyName);
            set => base.Students = value; 
        }
    }
}
