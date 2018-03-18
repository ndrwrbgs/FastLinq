using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Test.List;

    using Enumerable = System.Linq.Enumerable;

    [TestClass]
    public class EmptyTests
    {
        [TestMethod]
        public void NominalTest()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Empty<int>(),
                FastLinq.Empty<int>(),
                1);
        }

        [TestMethod]
        public void Objects()
        {
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Empty<object>(),
                FastLinq.Empty<object>(),
                1);
        }
    }
}
