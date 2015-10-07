using System;
using Implementations.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.UnitTests.DataStructures
{
    [TestClass]
    public class QueueUnitTests
    {
        [TestMethod]
        public void Count_EmptyQueue_Zero()
        {
            var queue = new Queue<int>();

            var result = queue.Count;

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Count_NotEmptyQueue_NumberOfElements()
        {
            var queue = new Queue<int>();
            queue.Enqueue(5);
            queue.Enqueue(8);

            var result = queue.Count;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EnqueueAndDequeue_ItemsInFIFOOrder()
        {
            var queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            Assert.AreEqual(4, queue.Count);

            var dequeue1 = queue.Dequeue();
            var dequeue2 = queue.Dequeue();
            var dequeue3 = queue.Dequeue();
            var dequeue4 = queue.Dequeue();

            Assert.AreEqual(1, dequeue1);
            Assert.AreEqual(2, dequeue2);
            Assert.AreEqual(3, dequeue3);
            Assert.AreEqual(4, dequeue4);
            Assert.AreEqual(0, queue.Count);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void Dequeue_NoElementsInQueue_InvalidOperationException()
        {
            var queue = new Queue<int>();

            queue.Dequeue();
        }

        [TestMethod]
        public void Clear_ClearsAllItems()
        {
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            queue.Clear();

            Assert.AreEqual(0, queue.Count);
        }
    }
}
