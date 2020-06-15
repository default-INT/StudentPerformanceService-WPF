using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Tests
{
    /// <summary>
    /// Класс описывающий испытание в виде зачёта.
    /// </summary>
    public class OffsetTest : Test
    {
        public OffsetTest()
        {
            Type = 0;
        }

        public OffsetTest(Test test) : base(test)
        {
            Type = 0;
        }

        public override string TypeStr => "Зачёт";
    }
}
