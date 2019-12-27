namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Empty()
        {
            IReadOnlyList<int> input = new int[] { };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Duplicates()
        {
            IReadOnlyList<int> input = new[] { 1, 1, 2 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Null()
        {
            IReadOnlyList<int> input = null;

            new Action(
                    () => FastLinq.Reverse(input))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}