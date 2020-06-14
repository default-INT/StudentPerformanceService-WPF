using StudentPerformanceServiceCL.Models.Data;
using StudentPerformanceServiceCL.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Services.StudentFilters
{
    internal class StudentFilter
    {
        public virtual IEnumerable<StudentViewModel> Students { get; set; }
        public void SetDefaultData()
        {
            var db = DAOFactory.GetDAOFactory();
            Students = db.AccountDAO.Students
                .Select(s => new StudentViewModel()
                {
                    Id = s.Id,
                    Student = s,
                    StudentFullName = s.FullName,
                    Group = s.Group,
                    GroupName = s.Group.Name,
                    Course = s.Course.Value,
                    AvgMark = s.TestResults.Count() != 0 ? s.TestResults.Sum(t => t.Mark) / s.TestResults.Count() : 0,
                    Faculty = s.Group.Specialty.Faculty,
                    FacultyName = s.Group.Specialty.Faculty.Name,
                    TestResults = s.TestResults
                });
        }
    }
}
