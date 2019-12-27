namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void Nominal()
        {
            IReadOnlyList<int> first = new[] { 1, 2 };
            IReadOnlyList<int> second = new[] { 1, 2, 3, 4 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyFirst()
        {
            IReadOnlyList<int> first = new int[] { };
            IReadOnlyList<int> second = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptySecond()
        {
            IReadOnlyList<int> first = new[] { 1, 2, 3 };
            IReadOnlyList<int> second = new int[] {  };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyBoth()
        {
            IReadOnlyList<int> first = new int[] {  };
            IReadOnlyList<int> second = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NullFirst()
        {
            IReadOnlyList<int> first = null;
            IReadOnlyList<int> second = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullSecond()
        {
            IReadOnlyList<int> first = new[] { 1, 2, 3 };
            IReadOnlyList<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullBoth()
        {
            IReadOnlyList<int> first = null;
            IReadOnlyList<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}