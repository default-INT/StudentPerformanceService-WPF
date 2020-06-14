using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface ISubjectDAO
    {
        IEnumerable<Subject> Subjects { get; }

        void Add(Subject subject, Specialty specialty);
    }
}
