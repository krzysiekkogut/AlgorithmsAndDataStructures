using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.Algorithms.UnitTests
{
    [TestClass]
    public class _basicAlgorithmsUnitTests
    {
        private BasicAlgorithms _basicAlgorithms;

        public _basicAlgorithmsUnitTests()
        {
            _basicAlgorithms = new BasicAlgorithms();
        }

        [TestMethod]
        public void Min_OneElementCollection_ReturnsValueOfThisElement()
        {
            var result = _basicAlgorithms.Min(new int[] { 1 });

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Min_ManyElements_ReturnsValueOfMinimalElement()
        {
            var result = _basicAlgorithms.Min(new int[] { 1, 1, -1, 3, 9, -18, 200, int.MaxValue });

            Assert.AreEqual(-18, result);
        }

        [TestMethod]
        public void MinAndMax_OneElement_MinEqualsMax()
        {
            var result = _basicAlgorithms.MinAndMax(new int[] { 1 });

            Assert.AreEqual((Min: 1, Max: 1), result);
        }

        [TestMethod]
        public void MinAndMax_ManyElements_MinAndMaxValuesReturned()
        {
            var result = _basicAlgorithms.MinAndMax(new int[] { 1, 10, -19, 7, 3 });

            Assert.AreEqual((Min: -19, Max: 10), result);
        }

        [TestMethod]
        public void BinarySearch_ElementNoInCollection_ReturnsMinus1()
        {
            var result = _basicAlgorithms.BinarySearch(new int[] { -19, 1, 3, 7, 10 }, 0);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void BinarySearch_ElementInCollection_Returns0BasedIndex()
        {
            var result = _basicAlgorithms.BinarySearch(new int[] { -19, 1, 3, 7, 10 }, 10);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Merge_SeperableCollections_Merged()
        {
            var result = _basicAlgorithms.Merge(new int[] { 1, 2 }, new int[] { 3, 4 });

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4 }, result.ToArray());
        }

        [TestMethod]
        public void Merge_NotSeperableCollections_Merged()
        {
            var result = _basicAlgorithms.Merge(new int[] { 1, 5}, new int[] { 3, 4, 21 });

            CollectionAssert.AreEqual(new[] { 1, 3, 4, 5, 21 }, result.ToArray());
        }

         [TestMethod] 
         public void RussianMultiplicate_By_0_Returns_0() 
         { 
             var result = _basicAlgorithms.RussianMultiplicate(167, 0); 
 
             Assert.AreEqual(0, result); 
         } 
 

         [TestMethod] 
         public void Multiplicate_12341234_and_897123() 
         { 
             long a = 12341234; 
             long b = 897123; 

             var result = _basicAlgorithms.RussianMultiplicate(a, b); 

             Assert.AreEqual(a * b, result); 
         }

         [TestMethod]
         public void GCD_AIsZero_ReturnsB()
         {
             var result = _basicAlgorithms.GCD(0, 10);

             Assert.AreEqual(10, result);
         }

         [TestMethod]
         public void GCD_BIsZero_ReturnsA()
         {
             var result = _basicAlgorithms.GCD(10, 0);

             Assert.AreEqual(10, result);
         }

         [TestMethod]
         public void GCD_ALessThanB_ReturnsGCD()
         {
             var result = _basicAlgorithms.GCD(10, 15);

             Assert.AreEqual(5, result);
         }

         [TestMethod]
         public void GCD_BLessThanA_ReturnsGCD()
         {
             var result = _basicAlgorithms.GCD(15, 10);

             Assert.AreEqual(5, result);
         }

         [TestMethod]
         public void FibonacciNumber_0_Returns0()
         {
             var result = _basicAlgorithms.FibonacciNumber(0);

             Assert.AreEqual(0, result);
         }

         [TestMethod]
         public void FibonacciNumber_1_Returns1()
         {
             var result = _basicAlgorithms.FibonacciNumber(1);

             Assert.AreEqual(1, result);
         }

         [TestMethod]
         public void FibonacciNumber_10_Returns55()
         {
             var result = _basicAlgorithms.FibonacciNumber(10);

             Assert.AreEqual(55, result);
         }
    }
}
