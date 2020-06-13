using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    internal interface ISubjectSpecialtyDAO
    {
        IEnumerable<SubjectSpecialty> SubjectSpecialties { get; }

        void Add(SubjectSpecialty subjectSpecialty);
    }
}
