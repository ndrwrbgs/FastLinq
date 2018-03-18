using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Test.List;

    using Enumerable = System.Linq.Enumerable;

    [TestClass]
    public class RepeatTests
    {
        [TestMethod]
        public void NominalTest()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Repeat(5, 10),
                FastLinq.Repeat(5, 10),
                4);
        }

        [TestMethod]
        public void RepeatObject()
        {
            var o = new object();
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Repeat(o, 3),
                FastLinq.Repeat(o, 3),
                1);
        }

        [TestMethod]
        public void RepeatNull()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Repeat<object>(null, 3),
                FastLinq.Repeat<object>(null, 3),
                1);
        }

        [TestMethod]
        public void RepeatNone()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Repeat(5, 0),
                FastLinq.Repeat(5, 0),
                1);
        }
        
        [TestMethod]
        public void CountIntMax()
        {
            // Cannot use ListCompare due to memory constraints (in x86 at least)
            new Action(
                    () => FastLinq.Repeat(2, int.MaxValue))
                .Should()
                .NotThrow();
        }

        [TestMethod]
        public void CountNegative()
        {
            new Action(
                    () => FastLinq.Repeat(0, -100))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }
    }
}
