namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => list.Take(3))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NominalCaseArray()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IReadOnlyList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IReadOnlyList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeAll()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 3),
                FastLinq.Take(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeMoreThanExist()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 50),
                FastLinq.Take(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNegative()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, -1),
                FastLinq.Take(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNone()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjectsContainsNull()
        {
            IReadOnlyList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNoneObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
    }
}