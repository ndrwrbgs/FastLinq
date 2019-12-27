namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelectWithIndexTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (item, index) => item.ToString() + index.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (i, _) => null;

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> input = new int[] { };
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> input = null;
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}