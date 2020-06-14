using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    /// <summary>
    /// Класс описывающий сущность "Факультет"
    /// </summary>
    [Table(Name = "faculties")]
    public class Faculty : Entity
    {
        [Column(Name = "name")]
        public string Name { get; set; }

        public IEnumerable<Specialty> Specialties => db.SpecialtyDAO.Specialties
            .Where(s => s.FacultyId == Id);

        public override string ToString() => Name;
    }
}
