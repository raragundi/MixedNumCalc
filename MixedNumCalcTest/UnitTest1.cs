using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MixedNumCalcTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestAdd()
        {
            string result = MixedNumCalc.Program.CalcOp("? 3_5/4 + 1_1/8");
            Assert.AreEqual("Your Result = 5_3/8", result);
        }
        [TestMethod]
        public void TestSub()
        {
            string result = MixedNumCalc.Program.CalcOp("? 2_3/5 - 4_7/8");
            Assert.AreEqual("Your Result = -2_11/40", result);
        }
        [TestMethod]
        public void TestMult()
        {
            string result = MixedNumCalc.Program.CalcOp("? 1/2 * 3_3/4");
            Assert.AreEqual("Your Result = 1_7/8", result);
        }
        [TestMethod]
        public void TestDiv()
        {
            string result = MixedNumCalc.Program.CalcOp("? 15 / 2/3");
            Assert.AreEqual("Your Result = 22_1/2", result);
        }
        [TestMethod]
        public void InvalidOp()
        {
            string result = MixedNumCalc.Program.CalcOp("? 5 ^ 5");
            Assert.AreEqual("Thas was not a valid option1", result);
        }
        [TestMethod]
        public void BadFormat()
        {
            string result = MixedNumCalc.Program.CalcOp("?20/4");
            Assert.AreEqual("Bad Format.", result);
        }
        [TestMethod]
        public void StringNoNum()
        {
            string result = MixedNumCalc.Program.CalcOp("? apple * pears");
            Assert.AreEqual("Input string was not in a correct format.", result);
        }

    }
}
