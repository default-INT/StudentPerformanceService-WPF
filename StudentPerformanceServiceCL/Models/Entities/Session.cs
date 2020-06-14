using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    [Table(Name = "sessions")]
    public class Session : Entity
    {
        [Column(Name = "year")]
        public int Year { get; set; }
        [Column(Name = "season")]
        public bool Season { get; set; }

        public IEnumerable<Test> Tests => db.TestDAO.Tests
            .Where(t => t.SessionId == Id);
    }
}