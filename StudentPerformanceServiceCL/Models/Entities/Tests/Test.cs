using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Tests
{
    /// <summary>
    /// Общий класс для всех испытаний (курсовая, зачёт и экзамен).
    /// </summary>
    [Table(Name = "tests")]
    [InheritanceMapping(Code = 0, IsDefault = true, Type = typeof(OffsetTest))]
    [InheritanceMapping(Code = 1, Type = typeof(ExamTest))]
    [InheritanceMapping(Code = 2, Type = typeof(CourseworkTest))]
    public class Test : Entity, ICaster<Test>
    {
        [Column(Name = "date")]
        public DateTime Date { get; set; }
        [Column(Name = "subject_id")]
        public int SubjectId { get; set; }
        [Column(Name = "group_id")]
        public int GroupId { get; set; }
        [Column(Name = "type", IsDiscriminator = true)]
        public int Type { get; set; }
        [Column(Name = "semester")]
        public int Semester { get; set; }
        [Column(Name = "session_id")]
        public int SessionId { get; set; }

        private Subject subject;
        private Group group;
        private Session session;

        public Test()
        {
        }

        public Test(Test test)
        {
            Date = test.Date;
            SubjectId = test.SubjectId;
            GroupId = test.GroupId;
            Type = test.Type;
            Semester = test.Semester;
            SessionId = test.SessionId;
        }

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
        public Group Group
        {
            get
            {
                if (group != null) return group;
                group = db.GroupDAO.Groups
                    .FirstOrDefault(g => g.Id == GroupId);
                return group;
            }
        }
        public Session Session
        {
            get
            {
                if (session != null) return session;
                session = db.SessionDAO.Sessions
                    .FirstOrDefault(s => s.Id == SessionId);
                return session;
            }
        }
        public IEnumerable<Student> Students
        {
            get
            {
                var groups = db.GroupDAO.Groups.Where(g => g.Semester == Semester);
                IEnumerable<Student> students = new List<Student>(); ;
                foreach (var group in groups)
                {
                    students.Concat(group.Students);
                }
                return students;
            }
        }

        public Test Cast()
        {
            switch (Type)
            {
                case 0:
                    return new OffsetTest(this);
                case 1:
                    return new ExamTest(this);
                case 2:
                    return new CourseworkTest(this);
                default:
                    throw new InvalidCastException();
            }
        }
    }
}
