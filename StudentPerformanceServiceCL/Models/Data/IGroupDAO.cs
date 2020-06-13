using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface IGroupDAO
    {
        IEnumerable<Group> Groups { get; }

        void Add(Group group);
        void Update(Group group);
    }
}
