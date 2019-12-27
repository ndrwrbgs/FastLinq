namespace Test.List {
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListCompareTestUtilTests
    {
        [TestMethod]
        public void List()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new List<int> { 1, 2, 3 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void OneItemList()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new List<int> { 1 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void EmptyList()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new List<int> { },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void ArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new ArraySegment<int>(new[] { 1, 2, 3 }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new ArraySegment<int>(new[] { 1 }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new ArraySegment<int>(new int[] { }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void Array()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArray()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new[] { 1 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArray()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new int[] { },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
    }
}