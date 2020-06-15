using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPerformanceServiceCL.Models.Entities.Tests
{
    /// <summary>
    /// Класс описывающий испытание в виде экзамена.
    /// </summary>
    public class ExamTest : Test
    {
        public ExamTest()
        {
            Type = 1;
        }

        public ExamTest(Test test) : base(test)
        {
            Type = 1;
        }

        public override string TypeStr => "Экзамен";
    }
}
