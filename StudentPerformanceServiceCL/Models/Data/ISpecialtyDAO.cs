using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface ISpecialtyDAO
    {
        IEnumerable<Specialty> Specialties { get; }

        void Add(Specialty specialty);
    }
}
