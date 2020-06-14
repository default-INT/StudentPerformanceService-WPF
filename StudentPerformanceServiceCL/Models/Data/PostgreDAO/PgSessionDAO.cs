using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgSessionDAO : ISessionDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgSessionDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Session> Sessions => _context.Sessions;

        public void Add(Session session)
        {
            _context.Sessions.InsertOnSubmit(session);

            _context.SubmitChanges();
        }
    }
}
