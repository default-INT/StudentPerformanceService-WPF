using DbLinq.Data.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data.PostgreDAO
{
    internal class PgDAOFactory : DAOFactory
    {
        private const string ConnectionString = @"Server=localhost;Port=5432;Database=student_performance_service;User Id=postgres;" +
            "Password=1806;Integrated Security=true;";
        private readonly StudentPerformanceServiceContext _context;

        internal PgDAOFactory()
        {
            var connection = new NpgsqlConnection(ConnectionString);
            _context = new StudentPerformanceServiceContext(connection);
        }

        public override IAccountDAO AccountDAO => new PgAccountDAO(_context);

        public override IFacultyDAO FacultyDAO => new PgFacultyDAO(_context);

        public override IGroupDAO GroupDAO => new PgGroupDAO(_context);

        public override ISpecialtyDAO SpecialtyDAO => new PgSpecialtyDAO(_context);

        public override ISubjectDAO SubjectDAO => new PgSubjectDAO(_context);

        public override ITestDAO TestDAO => new PgTestDAO(_context);

        internal override ISubjectSpecialtyDAO SubjectSpecialtyDAO => new PgSubjectSpecialtyDAO(_context);
    }
}
