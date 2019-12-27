namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void AllMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i > 0);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoneMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i == 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SomeMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i < 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EmptyInput()
        {
            IList<int> list = new int[] { };

            var result = list.Count(i => i < 3);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            Func<int, bool> predicate = i => i < 3;

            new Action(
                    () => list.Count(predicate))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicate()
        {
            IList<int> list = new int[] { };
            Func<int, bool> predicate = null;

            new Action(
                    () => list.Count(predicate))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}