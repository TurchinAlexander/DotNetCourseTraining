﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BasicAlgorithms.Tests.Comparers;

namespace BasicAlgorithms.Tests
{
    [TestClass]
    public class SortClassTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeMethod_NullArray_ReturnThrowArgumentNullException()
        {
            Sort<int>.Merge(null, new IntAscendComparer());
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void MergeMethod_NullComparer_ReturnThrowArgumentNullException()
		{
			Sort<int>.Merge(new int[] {1, 2, 3 }, null);
		}

		[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MergeMethod_ZeroLenghtArray_ReturnThrowArgumentException()
        {
			Sort<int>.Merge(new int[] { }, new IntAscendComparer());
        }

        [TestMethod]
        public void MergeMethod_SmallUnsortedArray_ReturnSortedArray()
        {
            int[] array = new int[] { 1, 2, 21, 19, 0, -1 };

			Sort<int>.Merge(array, new IntAscendComparer());

            Assert.IsTrue(CheckArrayNotDecreasing(array));
        }

        [TestMethod]
        public void MergeMethod_BigRandomArray_ReturnSortedArray()
        {
			int[] array = RandomBigArray();

			Sort<int>.Merge(array, new IntAscendComparer());

            Assert.IsTrue(CheckArrayNotDecreasing(array));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickMethod_NullArray_ReturnThrowArgumentNullException()
        {
			Sort<int>.Quick(null, new IntAscendComparer());
        }

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void QuickMethod_NullComparer_ReturnThrowArgumentNullException()
		{
			Sort<int>.Quick(new int[] { 1, 2, 3}, null);
		}

		[TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void QuickMethod_ZeroLenghtArray_ReturnThrowArgumentNullException()
        {
			Sort<int>.Quick(new int[] { }, new IntAscendComparer());
        }

        [TestMethod]
        public void QuickMethod_SmallUnsortedArray_ReturnSortedArray()
        {
            int[] array = new int[] { 1, 2, 21, 19, 0, -1 };

			Sort<int>.Quick(array, new IntAscendComparer());

            Assert.IsTrue(CheckArrayNotDecreasing(array));
        }

        [TestMethod]
        public void QuickMethod_BigRandomArray_ReturnSortedArray()
		{
			int[] array = RandomBigArray();

			Sort<int>.Quick(array, new IntAscendComparer());

            Assert.IsTrue(CheckArrayNotDecreasing(array));
        }

		/// <summary>
		/// Create a big random array.
		/// </summary>
		/// <returns>The pointer to the array.</returns>
		private int[] RandomBigArray()
		{
			const int Min = -100;
			const int Max = 100;

			int[] array = new int[100000];

			Random randNum = new Random();
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = randNum.Next(Min, Max);
			}

			return array;
		}

		/// <summary>
		/// Check that the sequence of the array is not decreasing
		/// </summary>
		/// <param name="array">The array to be checked.</param>
		/// <returns>If the array is sorted.</returns>
		private bool CheckArrayNotDecreasing(int[] array)
		{
			bool isNotDecreasing = true;

			for (int i = 0; (i < array.Length - 1) && isNotDecreasing; i++)
			{
				isNotDecreasing = (array[i] <= array[i + 1]);
			}

			return isNotDecreasing;
		}
	}
}
