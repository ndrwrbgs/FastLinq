namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FirstOrDefaultTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(1, FastLinq.FirstOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.FirstOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.FirstOrDefault(list));
        }
    }
}