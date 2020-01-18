using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonWpf.Service
{
    public class TestableService
    {
        public int CorrectSumMethod(int a, int b)
        {
            return a + b;
        }
        public int IncorrectSumMethod(int a, int b)
        {
            return a - b;
        }
    }
}
