namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SkipTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => list.Skip(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCaseArray()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IReadOnlyList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IReadOnlyList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAll()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 3),
                FastLinq.Skip(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipMoreThanExist()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 50),
                FastLinq.Skip(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNegative()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, -1),
                FastLinq.Skip(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNone()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }


        [TestMethod]
        public void SkipObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipObjectsContainsNull()
        {
            IReadOnlyList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAllObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 10),
                FastLinq.Skip(list, 10),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
    }
}