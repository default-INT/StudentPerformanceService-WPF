using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgSubjectDAO : ISubjectDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgSubjectDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> Subjects => _context.Subjects;

        public void Add(Subject subject)
        {
            _context.Subjects.InsertOnSubmit(subject);

            _context.SubmitChanges();
        }
    }
}
