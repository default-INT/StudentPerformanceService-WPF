using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface IFacultyDAO
    {
        IEnumerable<Faculty> Faculties { get; }

        void Add(Faculty faculty);
    }
}
