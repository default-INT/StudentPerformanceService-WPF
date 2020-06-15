using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Tests
{
    /// <summary>
    /// Класс описыващий испытание в виде курсовой работы.
    /// </summary>
    public class CourseworkTest : Test
    {
        public CourseworkTest()
        {
            Type = 2;
        }

        public CourseworkTest(Test test) : base(test)
        {
            Type = 2;
        }

        public override string TypeStr => "Курсовая";
    }
}
