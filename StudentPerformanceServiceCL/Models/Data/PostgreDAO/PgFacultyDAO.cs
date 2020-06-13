using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgFacultyDAO : IFacultyDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgFacultyDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Faculty> Faculties => _context.Faculties;

        public void Add(Faculty faculty)
        {
            _context.Faculties.InsertOnSubmit(faculty);
            _context.SubmitChanges();
        }
    }
}
