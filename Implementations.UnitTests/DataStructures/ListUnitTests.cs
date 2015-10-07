using System;
using System.Linq;
using Implementations.DataStructures;
using Implementations.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.UnitTests.DataStructures
{
    [TestClass]
    public class ListUnitTests
    {
        [TestMethod]
        public void DefaultConstructor_CountZero()
        {
            var list = new List<int>();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void DefaultConstructor_FirstAndLastElementAreNull()
        {
            var list = new List<int>();

            Assert.IsNull(list.First);
            Assert.IsNull(list.Last);
        }

        [TestMethod]
        public void ConsturctorWithIEnumerable_DoesNotChangeOrderOfInputCollection()
        {
            var inputArray = new[] { 1, 5, 2, 8, 3 };

            var list = new List<int>(inputArray);
            var output = list.ToEnumerable();

            CollectionAssert.AreEqual(inputArray, output.ToArray());
        }

        [TestMethod]
        public void AddLast_ToEmptyList_ListWithOnlyOneElement()
        {
            var list = new List<int>();

            list.AddLast(5);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(5, list.Last.Value);
        }

        [TestMethod]
        public void AddLast_ToNotEmptyList_ELementsInCorrectOrder()
        {
            var list = new List<int>();

            list.AddLast(6);
            list.AddLast(5);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(6, list.First.Value);
            Assert.AreEqual(5, list.Last.Value);
        }

        [TestMethod]
        public void ToArray_EmptyList_EmptyCollection()
        {
            var emptyList = new List<int>();

            var result = emptyList.ToEnumerable();

            Assert.IsTrue(result.Empty());
        }

        [TestMethod]
        public void ToArray_List_CorrectCollection()
        {
            var list = new List<int>();
            list.AddLast(1);
            list.AddLast(7);
            list.AddLast(101);
            list.AddLast(5);

            var result = list.ToEnumerable();

            CollectionAssert.AreEqual(new[] { 1, 7, 101, 5 }, result.ToArray());
        }

        [TestMethod]
        public void AddFirst_ToEmptyList_ListWithOnlyOneElement()
        {
            var list = new List<int>();

            list.AddFirst(5);

            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(5, list.Last.Value);
        }

        [TestMethod]
        public void AddFirst_ToNotEmptyList_ELementsInCorrectOrder()
        {
            var list = new List<int>();

            list.AddFirst(6);
            list.AddFirst(5);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(5, list.First.Value);
            Assert.AreEqual(6, list.Last.Value);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddAfter_ToNullNode_ArgumentException()
        {
            var list = new List<int>();

            list.AddAfter(list.First, 5);
        }

        [TestMethod]
        public void AddAfter_CorrectOrder()
        {
            var list = new List<int>(new[] { 1, 5 });

            list.AddAfter(list.First, 3);
            var output = list.ToEnumerable();

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, output.ToArray());
        }

        [TestMethod]
        public void AddAfter_AddAfterLast_BehaviourLikeAddLast()
        {
            var list = new List<int>(new[] { 1, 5 });

            list.AddAfter(list.Last, 3);
            var output = list.ToEnumerable();

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 1, 5, 3 }, output.ToArray());
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void AddBefore_ToNullNode_ArgumentException()
        {
            var list = new List<int>();

            list.AddBefore(list.First, 5);
        }

        [TestMethod]
        public void AddBefore_CorrectOrder()
        {
            var list = new List<int>(new[] { 1, 5 });

            list.AddBefore(list.Last, 3);
            var output = list.ToEnumerable();

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 1, 3, 5 }, output.ToArray());
        }

        [TestMethod]
        public void AddBefore_AddBeforeFirst_BehaviourLikeAddFirst()
        {
            var list = new List<int>(new[] { 1, 5 });

            list.AddBefore(list.First, 3);
            var output = list.ToEnumerable();

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 3, 1, 5 }, output.ToArray());
        }

        [TestMethod]
        public void Clear_NoExceptionWhenEmptyCollection()
        {
            var list = new List<int>();

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void Clear_CountIsZero()
        {
            var list = new List<int>(new[] { 1, 4, 0, 12, 1 });

            list.Clear();

            Assert.AreEqual(0, list.Count);
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void RemoveLast_EmptyCollection_InvalidOperationException()
        {
            var list = new List<int>();

            list.RemoveLast();
        }

        [TestMethod]
        public void RemoveLast_RemovesLastElement()
        {
            var list = new List<int>(new[] { 1, 4, 0, 12, 3 });

            list.RemoveLast();

            CollectionAssert.AreEqual(new[] { 1, 4, 0, 12 }, list.ToEnumerable().ToArray());
        }

        [TestMethod]
        public void RemoveLast_OnlyOneElement_RemovesOnlyElement()
        {
            var list = new List<int>(new[] { 1 });

            list.RemoveLast();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[] { }, list.ToEnumerable().ToArray());
        }

        [ExpectedException(typeof(InvalidOperationException))]
        [TestMethod]
        public void RemoveFirst_EmptyCollection_InvalidOperationException()
        {
            var list = new List<int>();

            list.RemoveFirst();
        }

        [TestMethod]
        public void RemoveFirst_RemovesLastElement()
        {
            var list = new List<int>(new[] { 1, 4, 0, 12, 3 });

            list.RemoveFirst();

            CollectionAssert.AreEqual(new[] { 4, 0, 12, 3 }, list.ToEnumerable().ToArray());
        }

        [TestMethod]
        public void RemoveFirst_OnlyOneElement_RemovesOnlyElement()
        {
            var list = new List<int>(new[] { 1 });

            list.RemoveFirst();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[] { }, list.ToEnumerable().ToArray());
        }

        [TestMethod]
        public void Contains_ElementNotInCollection_False()
        {
            var list = new List<int>(new[] { 1, 5, 1, 7 });

            var result = list.Contains(3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ElementInCollection_True()
        {
            var list = new List<int>(new[] { 1, 5, 1, 7 });

            var result = list.Contains(5);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Find_ElementNotInCollection_ReturnsNull()
        {
            var list = new List<int>(new[] { 1, 5, 1, 7 });

            var result = list.Find(3);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Find_ElementInCollection_ReturnsNode()
        {
            var list = new List<int>(new[] { 1, 5, 1, 7 });

            var result = list.Find(5);

            Assert.AreEqual(list.First.Next, result);
        }

        [TestMethod]
        public void Find_ElementTwiceInCollection_ReturnsFirstNode()
        {
            var list = new List<int>(new[] { 1, 5, 1, 7 });

            var result = list.Find(1);

            Assert.AreEqual(list.First, result);
            Assert.AreNotEqual(list.Last.Previous, result);
        }

        [TestMethod]
        public void RemoveItem_NotInCollection_ReturnsFalse()
        {
            var list = new List<int>(new[] { 5 });

            var result = list.Remove(3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveItem_InCollection_ReturnsTrueCorrectOrderOfElements()
        {
            var list = new List<int>(new[] { 5, 1, 6, 0, 8 });

            var result = list.Remove(6);
            var outputArray = list.ToEnumerable().ToArray();

            Assert.IsTrue(result);
            CollectionAssert.AreEqual(new[] { 5, 1, 0, 8 }, outputArray);
        }

        [TestMethod]
        public void RemoveNode_FromThisList_CorrectOrder()
        {
            var list = new List<int>(new[] { 5, 1, 6, 3 });
            var node = list.First.Next;

            list.Remove(node);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 5, 6, 3 }, list.ToEnumerable().ToArray());
        }

        [TestMethod]
        public void RemoveNode_RemoveFirst_CorrectOrder()
        {
            var list = new List<int>(new[] { 5, 1, 6, 3 });
            var node = list.First;

            list.Remove(node);

            Assert.AreEqual(3, list.Count);
            CollectionAssert.AreEqual(new[] { 1, 6, 3 }, list.ToEnumerable().ToArray());
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RemoveNode_NodeFromOtherList_ArgumentException()
        {
            var list = new List<int>(new[] { 5, 1, 6, 3 });
            var list2 = new List<int>(new[] { 5 });

            list.Remove(list2.First);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void RemoveNode_Null_ArgumentException()
        {
            var list = new List<int>(new[] { 5, 1, 6, 3 });

            list.Remove(null);
        }
    }
}
