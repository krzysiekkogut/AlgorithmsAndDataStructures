using Implementations.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.UnitTests.Helpers
{
    [TestClass]
    public class CollectionsHelperUnitTests
    {
        [TestMethod]
        public void Empty_EmptyCollection_True()
        {
            var collection = new int[] { };

            Assert.IsTrue(collection.Empty());
        }

        [TestMethod]
        public void Empty_NotEmptyCollection_False()
        {
            var collection = new int[] { 1 };

            Assert.IsFalse(collection.Empty());
        }
    }
}
