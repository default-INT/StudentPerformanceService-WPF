using StudentPerformanceServiceCL.Models.Data;
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
    /// Класс описывающий специальность факультета.
    /// </summary>
    [Table(Name = "specialties")]
    public class Specialty : Entity
    {
        [Column(Name = "name")]
        public string Name { get; set; }
        [Column(Name = "faculty_id")]
        public int FacultyId { get; set; }

        public Subject HardSubject => Subjects
            .ToList()
            .Where(s => s.TestResults.Count() != 0)
            .OrderBy(s => s.TestResults.Average(t => t.Mark))
            .FirstOrDefault();

        public Subject EasySubject => Subjects
            .ToList()
            .Where(s => s.TestResults.Count() != 0)
            .OrderByDescending(s => s.TestResults.Average(t => t.Mark))
            .FirstOrDefault();

        public Faculty Faculty => db.FacultyDAO.Faculties
            .FirstOrDefault(f => f.Id == FacultyId);

        public IEnumerable<Subject> Subjects => db.SubjectSpecialtyDAO.SubjectSpecialties
            .Where(s => s.SpecialtyId == Id)
            .Select(s => s.Subject);
        public IEnumerable<Student> Students => db.AccountDAO.Students
                    .Where(s => s.Group.SpecialtyId == Id);

        public IEnumerable<Group> Groups => db.GroupDAO.Groups
            .Where(g => g.SpecialtyId == Id);

        public override string ToString() => Name;
    }
}
