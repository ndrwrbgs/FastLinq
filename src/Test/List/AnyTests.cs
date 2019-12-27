namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void WhenAny()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsTrue(list.Any(i => i == 1));
        }

        [TestMethod]
        public void WhenNone()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsFalse(list.Any(i => i == 0));
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            new Action(
                    () => list.Any(i => true))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicate()
        {
            IList<int> list = new[] { 1, 2, 3 };
            new Action(
                    () => list.Any(null))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}