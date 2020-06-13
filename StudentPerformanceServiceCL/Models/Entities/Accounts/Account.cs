using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Accounts
{
    [Table(Name = "accounts")]
    [InheritanceMapping(Code = 0, Type = typeof(Admin))]
    [InheritanceMapping(Code = 1, Type = typeof(MethodistDeanery))]
    [InheritanceMapping(Code = 2, Type = typeof(Student), IsDefault = true)]
    public class Account : Entity, ICaster<Account>
    {
        public Account()
        {
        }

        public Account(Account account)
        {
            Login = account.Login;
            Password = account.Password;
            FullName = account.FullName;
            Role = account.Role;
            __groupId = account.__groupId;
        }
        [Column(Name = "login")]
        public string Login { get; set; }
        [Column(Name = "password")]
        public string Password { get; set; }
        [Column(Name = "full_name")]
        public string FullName { get; set; }
        [Column(Name = "role", IsDiscriminator = true)]
        public int Role { get; set; }
        [Column(Name = "group_id")]
        public int? __groupId { get; set; }

        public Account Cast()
        {
            switch (Role)
            {
                case 0:
                    return new Admin(this);
                case 1:
                    return new MethodistDeanery(this);
                case 2:
                    return new Student(this);
                default:
                    throw new InvalidCastException();
            }
        }
    }
}
