using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities
{
    [Table(Name = "subjects_specialtys")]
    internal class SubjectSpecialty : Entity
    {
        [Column(Name = "subject_id")]
        public int SubjectId { get; set; }
        [Column(Name = "specialty_id")]
        public int SpecialtyId { get; set; }

        public Subject subject;
        public Specialty specialty;

        public Subject Subject
        {
            get
            {
                if (subject != null) return subject;
                subject = db.SubjectDAO.Subjects
                    .FirstOrDefault(s => s.Id == SubjectId);
                return subject;
            }
        }
        public Specialty Specialty
        {
            get
            {
                if (specialty != null) return specialty;
                specialty = db.SpecialtyDAO.Specialties
                    .FirstOrDefault(s => s.Id == SpecialtyId);
                return specialty;
            }
        }
    }
}
