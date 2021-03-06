﻿using System;
using System.Collections.Generic;
using Implementations.DataStructures;
using Implementations.Helpers;

namespace Implementations.Algorithms
{
    public class BasicAlgorithms
    {
        public T Min<T>(T[] array) where T : IComparable
        {
            var min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }

        public (T Min, T Max) MinAndMax<T>(T[] array) where T : IComparable
        {
            return MinAndMax<T>(array, 0, array.Length - 1);
        }

        private (T Min, T Max) MinAndMax<T>(T[] array, int left, int right) where T : IComparable
        {
            if (left == right)
            {
                return (Min: array[left], Max: array[left]);
            }

            if (right - left == 1)
            {
                return SortTwoItems(array[left], array[right]);
            }

            var mid = (left + right) / 2;
            var leftResult = MinAndMax(array, left, mid);
            var rightResult = MinAndMax(array, mid + 1, right);

            return (Min: Min(leftResult.Min, rightResult.Min),
                    Max: Max(leftResult.Max, rightResult.Max));
        }

        private (T Min, T Max) SortTwoItems<T>(T first, T other) where T : IComparable
        {
            return first.CompareTo(other) <= 0
                ? (Min: first, Max: other)
                : (Min: other, Max: first);
        }

        private T Min<T>(T first, T other) where T : IComparable
        {
            return first.CompareTo(other) <= 0 ? first : other;
        }

        private T Max<T>(T first, T other) where T : IComparable
        {
            return first.CompareTo(other) >= 0 ? first : other;
        }

        public int BinarySearch<T>(T[] input, T element) where T : IComparable
        {
            var left = 0;
            var right = input.Length - 1;

            while (left <= right)
            {
                var mid = (left + right) / 2;

                if (element.Equals(input[mid]))
                {
                    return mid;
                }

                if (element.CompareTo(input[mid]) < 0)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return -1;
        }

        public IEnumerable<T> Merge<T>(T[] array1, T[] array2) where T : IComparable
        {
            var index1 = 0;
            var index2 = 0;
            while (index1 < array1.Length && index2 < array2.Length)
            {
                if (array1[index1].CompareTo(array2[index2]) <= 0)
                {
                    yield return array1[index1++];
                }
                else
                {
                    yield return array2[index2++];
                }
            }

            while (index1 < array1.Length)
            {
                yield return array1[index1++];
            }

            while (index2 < array2.Length)
            {
                yield return array2[index2++];
            }
        }

        public long RussianMultiplicate(long a, long b)
        {
            long result = 0;
            while (a > 0)
            {
                if (a.Odd())
                {
                    result += b;
                }

                a = a >> 1;
                b = b << 1;
            }

            return result;
        }

        public long GCD(long a, long b)
        {
            if (a == 0)
            {
                return b;
            }

            while (b != 0)
            {
                var c = a % b;
                a = b;
                b = c;
            }

            return a;
        }

        public long FibonacciNumber(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            var matrix = new Matrix(2, 2);
            matrix[0, 0] = matrix[0, 1] = matrix[1, 0] = 1;
            matrix[1, 1] = 0;

            matrix = matrix ^ (n - 1);
            return matrix[0, 0];
        }
    }
}
