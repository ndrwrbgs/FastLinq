using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.List
{
    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal static class ListCompareTestUtil
    {
        public static void ValidateEqual<T>(
            IEnumerable<T> expected,
            // TODO: Take a Func<> so the modifications can be done safely
            IReadOnlyList<T> actual,
            T itemNotInTheCollection,
            bool enforceWritable = false)
        {
            var expectedMaterialized = expected.ToList();

            // IList.this[int]
            if (actual.Count > 0)
            {
                var minItem = actual[0];
                Assert.AreEqual(expectedMaterialized[0], minItem);
                var maxItem = actual[actual.Count - 1];
                Assert.AreEqual(expectedMaterialized[actual.Count - 1], maxItem);
            }

            new Action(
                    () =>
                    {
                        var _ = actual[actual.Count + 1];
                    })
                .Should()
                .Throw<ArgumentOutOfRangeException>();
            
            // Modifies the input, so needs to be last
            CollectionCompareTestUtil.ValidateEqual(
                expected,
                actual,
                itemNotInTheCollection,
                enforceWritable);
        }
    }
}
