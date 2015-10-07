using Microsoft.VisualStudio.TestTools.UnitTesting;
using Implementations.Helpers;

namespace Implementations.UnitTests.Helpers
{
    [TestClass]
    public class NumbersHelperUnitTests
    {
        [TestMethod]
        public void OddLong_NumberIsOdd_True()
        {
            long a = 5;
            Assert.AreEqual(true, a.Odd());
        }

        [TestMethod]
        public void OddLong_NumberIsEven_False()
        {
            long a = 8;
            Assert.AreEqual(false, a.Odd());
        }

        [TestMethod]
        public void EvenLong_NumberIsEven_True()
        {
            long a = 6;
            Assert.AreEqual(true, a.Even());
        }

        [TestMethod]
        public void EvenLong_NumberIsOdd_False()
        {
            long a = 5;
            Assert.AreEqual(false, a.Even());
        }

        [TestMethod]
        public void OddInt_NumberIsOdd_True()
        {
            int a = 5;
            Assert.AreEqual(true, a.Odd());
        }

        [TestMethod]
        public void OddInt_NumberIsEven_False()
        {
            int a = 8;
            Assert.AreEqual(false, a.Odd());
        }

        [TestMethod]
        public void EvenInt_NumberIsEven_True()
        {
            int a = 6;
            Assert.AreEqual(true, a.Even());
        }

        [TestMethod]
        public void EvenInt_NumberIsOdd_False()
        {
            int a = 5;
            Assert.AreEqual(false, a.Even());
        }
    }
}
