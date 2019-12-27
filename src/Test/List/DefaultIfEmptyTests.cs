namespace Test.List {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DefaultIfEmptyTests
    {
        [TestMethod]
        public void NotEmpty()
        {
            IReadOnlyList<int> notEmpty = new[] { 1 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(notEmpty),
                FastLinq.DefaultIfEmpty(notEmpty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyObject()
        {
            IReadOnlyList<object> empty = new object[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyValueType()
        {
            IReadOnlyList<int> empty = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;
            new Action(
                    () => list.DefaultIfEmpty())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}