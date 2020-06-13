using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    /// <summary>
    /// Класс описывает дисциплину / предмет.
    /// </summary>
    [Table(Name = "subjects")]
    public class Subject : Entity
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "teacher")]
        public string Teacher { get; set; }

        public IEnumerable<Specialty> Specialties => db.SubjectSpecialtyDAO.SubjectSpecialties
            .Where(s => s.SubjectId == Id)
            .Select(s => s.Specialty);
    }
}
