using StudentPerformanceServiceCL.Models.Data.PostgreDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Data
{
    public abstract class DAOFactory
    {
        public abstract IAccountDAO AccountDAO { get; }
        public abstract IFacultyDAO FacultyDAO { get; }
        public abstract IGroupDAO GroupDAO { get; }
        public abstract ISpecialtyDAO SpecialtyDAO { get; }
        public abstract ISubjectDAO SubjectDAO { get; }
        public abstract ITestDAO TestDAO { get; }
        public abstract ISessionDAO SessionDAO { get;  }
        internal abstract ISubjectSpecialtyDAO SubjectSpecialtyDAO { get; }

        public static DAOFactory GetDAOFactory(Database database = Database.PostgreSQL)
        {
            switch (database)
            {
                case Database.PostgreSQL:
                    return new PgDAOFactory();
                default: return null;
            }
        } 
    }
}
