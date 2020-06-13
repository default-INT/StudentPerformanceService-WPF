using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgSpecialtyDAO : ISpecialtyDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgSpecialtyDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Specialty> Specialties => _context.Specialties;

        public void Add(Specialty specialty)
        {
            _context.Specialties.InsertOnSubmit(specialty);

            _context.SubmitChanges();
        }
    }
}
