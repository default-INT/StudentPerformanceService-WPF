using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    /// <summary>
    /// Класс описывающий группу студента.
    /// </summary>
    [Table(Name = "groups")]
    public class Group : Entity
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "semester")]
        public int Semester { get; set; }
        [Column(Name = "specialty_id")]
        public int SpecialtyId { get; set; }

        public Specialty Specialty => db.SpecialtyDAO.Specialties
            .FirstOrDefault(s => s.Id == SpecialtyId);
        public IEnumerable<Student> Students => db.AccountDAO.Students
            .Where(s => s.GroupId == Id);

        public override string ToString() => Name;
    }
}
