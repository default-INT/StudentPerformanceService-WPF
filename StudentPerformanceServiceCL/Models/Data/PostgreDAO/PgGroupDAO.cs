using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgGroupDAO : IGroupDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgGroupDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Group> Groups => _context.Groups;

        public void Add(Group group)
        {
            _context.Groups.InsertOnSubmit(group);
            _context.SubmitChanges();
        }

        public void Update(Group group)
        {
            var updateGroup = _context.Groups.FirstOrDefault(g => g.Id == group.Id);
            
            updateGroup.Name = group.Name;
            updateGroup.Semester = group.Semester;
            updateGroup.SpecialtyId = group.SpecialtyId;

            _context.SubmitChanges();
        }
    }
}
