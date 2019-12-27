namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LastOrDefaultTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.LastOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.LastOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.LastOrDefault(list));
        }
    }
}