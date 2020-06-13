using StudentPerformanceServiceCL.Models.Data;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    public abstract class Entity
    {
        [Column(IsPrimaryKey = true, Name = "id", IsDbGenerated = true)]
        public int Id { get; set; }

        protected DAOFactory db => DAOFactory.GetDAOFactory();
    }
}
