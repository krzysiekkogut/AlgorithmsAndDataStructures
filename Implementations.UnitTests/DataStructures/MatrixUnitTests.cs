using System;
using Implementations.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Implementations.UnitTests.DataStructures
{
    [TestClass]
    public class MatrixUnitTests
    {
        [TestMethod]
        public void Indexer_ValueLowerThanModThreshold()
        {
            var matrix = new Matrix(1, 1);

            matrix[0, 0] = 123;
            var get = matrix[0, 0];

            Assert.AreEqual(123, get);
        }

        [TestMethod]
        public void Indexer_ValueHigherThanModThreshold()
        {
            var matrix = new Matrix(1, 1);

            matrix[0, 0] = 100000123;
            var get = matrix[0, 0];

            Assert.AreEqual(123, get);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixAddition_WriogSizes_ArgumentException()
        {
            var matrix1 = new Matrix(1, 1);
            var matrix2 = new Matrix(2, 2);

            var result = matrix1 + matrix2;
        }

        [TestMethod]
        public void MatrixAddition_CorrectSizes_CorrectResult()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            var matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 4; matrix2[0, 1] = 3;
            matrix2[1, 0] = 2; matrix2[1, 1] = 1;

            var expected = new Matrix(2, 2);
            expected[0, 0] = 5; expected[0, 1] = 5;
            expected[1, 0] = 5; expected[1, 1] = 5;

            var result = matrix1 + matrix2;

            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixSubstraction_WriogSizes_ArgumentException()
        {
            var matrix1 = new Matrix(1, 1);
            var matrix2 = new Matrix(2, 2);

            var result = matrix1 - matrix2;
        }

        [TestMethod]
        public void MatrixSubstraction_CorrectSizes_CorrectResult()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            var matrix2 = new Matrix(2, 2);
            matrix2[0, 0] = 4; matrix2[0, 1] = 3;
            matrix2[1, 0] = 2; matrix2[1, 1] = 1;

            var expected = new Matrix(2, 2);
            expected[0, 0] = -3; expected[0, 1] = -1;
            expected[1, 0] = 1; expected[1, 1] = 3;

            var result = matrix1 - matrix2;

            Assert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void MatrixMultiplication_WrongSizes_ArgumentException()
        {
            var matrix1 = new Matrix(1, 1);
            var matrix2 = new Matrix(2, 2);

            var result = matrix1 * matrix2;
        }

        [TestMethod]
        public void MatrixMultiplication_CorrectSizes_CorrectResult()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            var matrix2 = new Matrix(2, 1);
            matrix2[0, 0] = 5;
            matrix2[1, 0] = 10;

            var expected = new Matrix(2, 1);
            expected[0, 0] = 25;
            expected[1, 0] = 55;

            var result = matrix1 * matrix2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixExponentiation_CorrectResult()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            var expected = new Matrix(2, 2);
            expected[0, 0] = 199; expected[0, 1] = 290;
            expected[1, 0] = 435; expected[1, 1] = 634;

            var result = matrix1 ^ 4;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixScalarMultiplication_CorrectResult()
        {
            var matrix1 = new Matrix(2, 2);
            matrix1[0, 0] = 1; matrix1[0, 1] = 2;
            matrix1[1, 0] = 3; matrix1[1, 1] = 4;

            var expected = new Matrix(2, 2);
            expected[0, 0] = 2; expected[0, 1] = 4;
            expected[1, 0] = 6; expected[1, 1] = 8;

            var result = matrix1 * 2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void MatrixScalarMultiplication_DifferentOrder_CorrectResult()
        {
            var matrix = new Matrix(2, 2);
            matrix[0, 0] = 1; matrix[0, 1] = 2;
            matrix[1, 0] = 3; matrix[1, 1] = 4;

            var expected = new Matrix(2, 2);
            expected[0, 0] = 2; expected[0, 1] = 4;
            expected[1, 0] = 6; expected[1, 1] = 8;

            var result = 2 * matrix;

            Assert.AreEqual(expected, result);
        }
    }
}
