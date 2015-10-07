using System;
using Implementations.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.UnitTests.DataStructures
{
    [TestClass]
    public class StackUnitTests
    {
        [TestMethod]
        public void Count_EmptyStack_Zero()
        {
            var stack = new Stack<int>();

            var result = stack.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Count_NotEmptyStack_NumberOfElements()
        {
            var stack = new Stack<int>();
            stack.Push(5);
            stack.Push(8);

            var result = stack.Count;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void PushAndPop_ItemsInLIFOOrder()
        {
            var stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            Assert.AreEqual(4, stack.Count);
            
            var pop1 = stack.Pop();
            var pop2 = stack.Pop();
            var pop3 = stack.Pop();
            var pop4 = stack.Pop();

            Assert.AreEqual(4, pop1);
            Assert.AreEqual(3, pop2);
            Assert.AreEqual(2, pop3);
            Assert.AreEqual(1, pop4);
            Assert.AreEqual(0, stack.Count);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Pop_NoElementsInStack_InvalidOperationException()
        {
            var stack = new Stack<int>();

            stack.Pop();
        }
        
        [TestMethod]
        public void Clear_ClearsAllItems()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }
    }
}
