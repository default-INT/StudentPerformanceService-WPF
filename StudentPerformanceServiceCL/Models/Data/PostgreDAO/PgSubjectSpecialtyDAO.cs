using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgSubjectSpecialtyDAO : ISubjectSpecialtyDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgSubjectSpecialtyDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<SubjectSpecialty> SubjectSpecialties => _context.SubjectSpecialties;

        public void Add(SubjectSpecialty subjectSpecialty)
        {
            _context.SubjectSpecialties.InsertOnSubmit(subjectSpecialty);

            _context.SubmitChanges();
        }
    }
}
