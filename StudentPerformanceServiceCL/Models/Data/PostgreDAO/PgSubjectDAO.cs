﻿using StudentPerformanceServiceCL.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgSubjectDAO : ISubjectDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgSubjectDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<Subject> Subjects => _context.Subjects;

        public void Add(Subject subject, Specialty specialty)
        {
            var exitSubject = _context.Subjects
                .FirstOrDefault(s => s.Name == subject.Name && s.Teacher == subject.Teacher);
            if (exitSubject != null)
            {
                subject = exitSubject;
            }
            else
            {
                _context.Subjects.InsertOnSubmit(subject);

                _context.SubmitChanges();
            }
            

            _context.SubjectSpecialties
                .InsertOnSubmit(new SubjectSpecialty()
                {
                    SpecialtyId = specialty.Id,
                    SubjectId = subject.Id
                });

            _context.SubmitChanges();
        }
    }
}
