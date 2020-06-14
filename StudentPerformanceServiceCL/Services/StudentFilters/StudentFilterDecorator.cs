using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal abstract class StudentFilterDecorator : StudentFilter
    {
        protected StudentFilter studentFilter;

        protected StudentFilterDecorator(StudentFilter studentFilter)
        {
            this.studentFilter = studentFilter;
        }
    }
}
