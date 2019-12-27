namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ElementAtTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.ElementAt(list, 2));
        }

        [TestMethod]
        public void NegativeIndex()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, -1))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IndexEqualsLength()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, 3))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IndexTooLarge()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, 100))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.ElementAt(list, 0))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.ElementAt(list, 0))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }
    }
}