using LessonWpf.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLessonWpf
{
    [TestClass]
    public class SummerTest
    {
        [TestMethod]
        public void TestSum_TwoValues()
        {
            Summer summer = new Summer();
            Assert.AreEqual(3, summer.Sum(1, 2));
        }
        [TestMethod]
        public void TestSum_ZeroValues()
        {
            Summer summer = new Summer();
            Assert.AreEqual(0, summer.Sum());
        }
        [TestMethod]
        public void TestSum_OneValue()
        {
            Summer summer = new Summer();
            Assert.AreEqual(1, summer.Sum(1));
        }
        [TestMethod]
        public void TestSum_InfinityValues()
        {
            Summer summer = new Summer();
            Assert.AreEqual(10, summer.Sum(1, 1, 1, 1, 1, 1, 1, 1, 1, 1));
        }
        [TestMethod]
        public void TestSum_NegotiveValue()
        {
            Summer summer = new Summer();
            Assert.AreEqual(-7, summer.Sum(1, -10, 2));
        }
    }
}
