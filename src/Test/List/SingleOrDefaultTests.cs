namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SingleOrDefaultTests
    {
        [TestMethod]
        public void JustOne()
        {
            IReadOnlyList<int> list = new[] { 2 };

            Assert.AreEqual(2, FastLinq.SingleOrDefault(list));
        }

        [TestMethod]
        public void MoreThanOne()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.SingleOrDefault(list))
                .Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void None()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.SingleOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.SingleOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}