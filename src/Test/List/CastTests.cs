namespace Test.List {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CastTests
    {
        [TestMethod]
        public void Nominal()
        {
            int[] list = new[] { 1, 2, 3 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Cast<object>(list),
                FastLinq.Cast<object>(list),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
        [TestMethod]
        public void Nominal2()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Cast<object>(list),
                FastLinq.Cast<int, object>(list),
                itemNotInTheCollection: (object)0,
                enforceWritable: false);
        }

        [TestMethod]
        public void CannotCast()
        {
            IList list = new[] { 1, 2, 3 };
            new Action(
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    () => FastLinq.Cast<string>(list).ToArray())
                .Should()
                .Throw<InvalidCastException>();
        }

        [TestMethod]
        public void CannotCast2()
        {
            // Not possible because of the type constraint
            //IList<int> list = new[] { 1, 2, 3 };
            //new Action(
            //        () => FastLinq.Cast<int, string>(list))
            //    .Should()
            //    .Throw<NotSupportedException>();
        }

        [TestMethod]
        public void NullInput()
        {
            IList list = null;
            new Action(
                    () => FastLinq.Cast<string>(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullInput2()
        {
            IReadOnlyList<int> list = null;
            new Action(
                    () => FastLinq.Cast<int, object>(list))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}