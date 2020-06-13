using StudentPerformanceServiceCL.Models.Entities.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    public class Session : Entity
    {
        public int Year { get; set; }
        public bool Season { get; set; }

        public IEnumerable<Test> Tests { get; }
    }
}