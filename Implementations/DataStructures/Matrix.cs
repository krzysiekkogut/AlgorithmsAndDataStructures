using System;
using Implementations.Helpers;

namespace Implementations.DataStructures
{
    public class Matrix
    {
        private int RowsCount { get; set; }
        private int ColumnsCount { get; set; }

        private static int mod = 100_000_000;

        private long[,] matrixData;

        public Matrix() : this(1, 1) { }

        public Matrix(int rows, int columns)
        {
            RowsCount = rows;
            ColumnsCount = columns;
            matrixData = new long[rows, columns];
            matrixData.Initialize();
        }

        public long this[int row, int column]
        {
            get => matrixData[row, column];
            set => matrixData[row, column] = value % mod;
        }

        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.RowsCount != b.RowsCount || a.ColumnsCount != b.ColumnsCount)
            {
                throw new ArgumentException("Matricies must be the same size to add them.");
            }

            var result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < a.RowsCount; i++)
            {
                for (int j = 0; j < a.ColumnsCount; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.RowsCount != b.RowsCount || a.ColumnsCount != b.ColumnsCount)
            {
                throw new ArgumentException("Matricies must be the same size to substract them.");
            }

            var result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < a.RowsCount; i++)
            {
                for (int j = 0; j < a.ColumnsCount; j++)
                {
                    result[i, j] = a[i, j] - b[i, j];
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColumnsCount != b.RowsCount)
            {
                throw new ArgumentException("Number of columns in the first matrix has to equal number of rows in the second matrix.");
            }

            var result = new Matrix(a.RowsCount, b.ColumnsCount);

            for (int r = 0; r < a.RowsCount; r++)
            {
                for (int c = 0; c < b.ColumnsCount; c++)
                {
                    for (int i = 0; i < a.ColumnsCount; i++)
                    {
                        result[r, c] += (a[r, i] * b[i, c]) % mod;
                    }
                }
            }

            return result;
        }

        public static Matrix operator *(Matrix a, long k)
        {
            var result = new Matrix(a.RowsCount, a.ColumnsCount);
            for (int i = 0; i < a.RowsCount; i++)
            {
                for (int j = 0; j < a.ColumnsCount; j++)
                {
                    result[i, j] = a[i, j] * k;
                }
            }

            return result;
        }

        public static Matrix operator *(long k, Matrix a)
        {
            return a * k;
        }

        public static Matrix operator ^(Matrix matrix, int power)
        {
            if (power == 1)
            {
                return matrix;
            }

            var m = (matrix ^ (power / 2));
            return power.Even() ? m * m : m * m * matrix;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var other = obj as Matrix;
            if (RowsCount != other.RowsCount || ColumnsCount != other.ColumnsCount)
            {
                return false;
            }

            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}