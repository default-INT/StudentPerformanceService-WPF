﻿using StudentPerformanceServiceCL.Models.Data;
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

        public Faculty Faculty { get; set; }
        public IEnumerable<Subject> Subjects => db.SubjectSpecialtyDAO.SubjectSpecialties
            .Where(s => s.SpecialtyId == Id)
            .Select(s => s.Subject);
        public IEnumerable<Student> Students => db.AccountDAO.Students
                    .Where(s => s.Group.SpecialtyId == Id);
    }
}