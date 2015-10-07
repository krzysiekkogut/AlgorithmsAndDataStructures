using System;
using Algorytmy.Controllers;
using Algorytmy.Models;
using Implementations.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Algorytmy.UnitTests.Controllers
{
    [TestClass]
    public class BasicAlgorithmsControllerUnitTests
    {
        [TestMethod]
        public void MinPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.Min("a");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void MinPost_CorrectString_ReturnsPartialViewWithFlagTrueAndResultFromImplementations()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.Min(It.IsAny<int[]>())).Returns(0);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.Min("12 1 0 3");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("0", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void MinAndMaxPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.MinAndMax("a");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void MinAndMaxPost_CorrectString_ReturnsPartialViewWithFlagTrueAndResultFromImplementations()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.MinAndMax(It.IsAny<int[]>())).Returns(new Tuple<int, int>(0, 12));
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.MinAndMax("12 1 0 3");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("minimum 0, maksimum 12", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void BinarySearchPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.BinarySearch("a", 3);

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void BinarySearchPost_CorrectString_NoElementInCollection_ReturnsPartialViewWithFlagTrueAndNoFoundMessage()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.BinarySearch(It.IsAny<int[]>(), It.IsAny<int>())).Returns(-1);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.BinarySearch("0 1 3 12", 6);

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("elementu 6 nie ma w zbiorze", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void BinarySearchPost_CorrectString_ElementInCollection_ReturnsPartialViewWithFlagTrueAndFoundMessage()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.BinarySearch(It.IsAny<int[]>(), It.IsAny<int>())).Returns(2);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.BinarySearch("0 1 6 12", 6);

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("element 6 znajduje się na pozycji 2", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void MergePost_IncorrectFirstString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.Merge("a", "1 2");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void MergePost_IncorrectSecondString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.Merge("1 2", "b");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void MergePost_IncorrectBothStrings_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.Merge("a", "b");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void MergePost_CorrectString_ReturnsMergedArrays()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.Merge(new[] { 1, 2, 6 }, new[] { 3, 5, 9 })).Returns(new[] { 1, 2, 3, 5, 6, 9 });
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.Merge("1 2 6", "3 5 9");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("1, 2, 3, 5, 6, 9", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void RussianMultiplicationPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.RussianMultiplication("10a", "x");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void RussianMultiplicationPost_CorrectString_ReturnsPartialViewWithFlagTrueAndResultFromImplementations()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.RussianMultiplicate(10, 312)).Returns(3120);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.RussianMultiplication("10", "312");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("3120", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void GCDPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.GCD("10a", "x");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void GCDPost_CorrectString_ReturnsPartialViewWithFlagTrueAndResultFromImplementations()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.GCD(10, 312)).Returns(2);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.GCD("10", "312");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("2", ((ResultsViewModel)partialView.Model).Result);
        }

        [TestMethod]
        public void FibonacciMatrixPost_IncorrectString_ReturnsPartialViewWithFlagFalse()
        {
            var controller = new BasicAlgorithmsController();

            var partialView = controller.FibonacciMatrix("10a");

            Assert.AreEqual(false, ((ResultsViewModel)partialView.Model).Success);
        }

        [TestMethod]
        public void FibonacciMatrixPost_CorrectString_ReturnsPartialViewWithFlagTrueAndResultFromImplementations()
        {
            var basicAlgorithmsMock = new Mock<BasicAlgorithms>();
            basicAlgorithmsMock.Setup(m => m.FibonacciNumber(10)).Returns(55);
            var controller = new BasicAlgorithmsController(basicAlgorithmsMock.Object);

            var partialView = controller.FibonacciMatrix("10");

            Assert.AreEqual(true, ((ResultsViewModel)partialView.Model).Success);
            Assert.AreEqual("55", ((ResultsViewModel)partialView.Model).Result);
        }
    }
}
