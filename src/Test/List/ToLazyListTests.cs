namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ToLazyListTests
    {
        [TestMethod]
        public void IsLazy()
        {
            bool any = false;
            var result = FastLinq.ToLazyList(
                // Need an IList for the Select
                FastLinq.Select(
                    new[] { 0 },
                    _ => any = true));

            Assert.IsFalse(any, "ToLazyList should be lazy");
        }

        [TestMethod]
        public void NominalCase()
        {
            var input = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(input),
                (IReadOnlyList<int>)FastLinq.ToLazyList(input),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NoItems()
        {
            IReadOnlyList<int> list = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(list),
                (IReadOnlyList<int>)FastLinq.ToLazyList(list),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;
            new Action(
                    () => list.ToLazyList())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WriteToResultDoNotChangeInput()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };

            var result = FastLinq.ToLazyList(input);
            result[0] = 0;
            result[1] = 1;
            result[2] = 2;

            Assert.IsTrue(new[] { 1, 2, 3 }.SequenceEqual(input));
            Assert.IsTrue(new[] { 0, 1, 2 }.SequenceEqual(result));
        }
    }
}