namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => i.ToString();

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
            Func<int, string> projection =
                i => null;

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
            Func<int, string> projection =
                i => i.ToString();

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
            Func<int, string> projection =
                i => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}