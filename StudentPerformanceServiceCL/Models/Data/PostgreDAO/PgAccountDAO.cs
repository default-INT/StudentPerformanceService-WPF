using StudentPerformanceServiceCL.Models.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgAccountDAO : IAccountDAO
    {
        private readonly StudentPerformanceServiceContext _context;

        public PgAccountDAO(StudentPerformanceServiceContext context)
        {
            _context = context;
        }

        public IEnumerable<MethodistDeanery> MethodistDeaneries => _context.Accounts
            .Where(a => a.Role == 1)
            .AsEnumerable()
            .Select(a => new MethodistDeanery(a));

        public IEnumerable<Student> Students => _context.Accounts
            .Where(a => a.Role == 2)
            .AsEnumerable()
            .Select(a => new Student(a));

        public void Add(Account account)
        {
            _context.Accounts.InsertOnSubmit(new Account(account));

            _context.SubmitChanges();
        }

        public Account LogIn(string login, string password)
        {
            var account = _context.Accounts
                .FirstOrDefault(a => a.Login == login && a.Password == password);
            if (account == null) throw new Exception("Неверный логин или пароль");
            return account.Cast();
        }

        public void Remove(Student student)
        {
            var account = _context.Accounts.FirstOrDefault(a => a.Id == student.Id);
            _context.Accounts.DeleteOnSubmit(account);
            _context.SubmitChanges();
        }
    }
}
