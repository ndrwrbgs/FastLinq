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
    public class RangeTests
    {
        [TestMethod]
        public void NominalTest()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Range(5, 10),
                FastLinq.Range(5, 10),
                4);
        }

        [TestMethod]
        public void IntMaxCountNone()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Range(int.MaxValue, 0),
                FastLinq.Range(int.MaxValue, 0),
                1);
        }

        [TestMethod]
        public void IntMaxCountOne()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Range(int.MaxValue, 1),
                FastLinq.Range(int.MaxValue, 1),
                1);
        }
        
        [TestMethod]
        public void TwoCountIntMax()
        {
            new Action(
                    () => FastLinq.Range(2, int.MaxValue))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IntMaxCountTwo()
        {
            new Action(
                    () => FastLinq.Range(int.MaxValue, 2))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void CountNegative()
        {
            new Action(
                    () => FastLinq.Range(0, -100))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IntMin()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Range(int.MinValue, 10),
                FastLinq.Range(int.MinValue, 10),
                4);
        }
    }
}
