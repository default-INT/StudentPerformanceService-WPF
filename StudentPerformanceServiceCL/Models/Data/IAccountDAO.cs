using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public interface IAccountDAO
    {
        IEnumerable<MethodistDeanery> MethodistDeaneries { get; }
        IEnumerable<Student> Students { get; }

        Account LogIn(string login, string password);
        void Remove(Student student);
    }
}
