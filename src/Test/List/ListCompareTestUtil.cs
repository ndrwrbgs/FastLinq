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
            IList<T> actual,
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

            // IList.IndexOf
            {
                if (actual.Count > 0)
                {
                    var minItem = actual[0];

                    Assert.AreEqual(0, actual.IndexOf(minItem));
                }

                if (actual.Count > 1 && !Equals(actual[0], actual[1]))
                {
                    var item = actual[1];
                    Assert.AreEqual(1, actual.IndexOf(item));
                }

                Assert.AreEqual(-1, actual.IndexOf(itemNotInTheCollection));
            }

            var expectedWritable = expected is ICollection<T>
                ? !((ICollection<T>)expected).IsReadOnly
                : false;
            if (enforceWritable)
            {
                expectedWritable = true;
            }

            if (expectedWritable)
            {
                // IList.Insert
                var sizeBefore = actual.Count;
                var insertIndex = actual.Count > 0
                    ? 1
                    : 0;
                actual.Insert(insertIndex, itemNotInTheCollection);
                Assert.AreEqual(sizeBefore + 1, actual.Count);
                Assert.IsTrue(actual.Contains(itemNotInTheCollection));
                
                // IList.RemoveAt
                actual.RemoveAt(insertIndex);
                Assert.AreEqual(sizeBefore, actual.Count);
                Assert.IsFalse(actual.Contains(itemNotInTheCollection));

                // IList.this[int]
                if (actual.Count > 0)
                {
                    var before = actual[0];

                    actual[0] = itemNotInTheCollection;
                    Assert.AreEqual(sizeBefore, actual.Count);
                    Assert.AreEqual(itemNotInTheCollection, actual[0]);

                    actual[0] = before;
                }
            }
            else
            {
                new Action(() => actual.Insert(0, default(T))).Should().Throw<NotSupportedException>();
                new Action(() => actual.RemoveAt(0)).Should().Throw<NotSupportedException>();
                // Many of the IList implemenations that say ReadOnly actually allow setting by indexer
                //new Action(() => actual[0] = default(T)).Should().Throw<NotSupportedException>();
            }

            // Modifies the input, so needs to be last
            CollectionCompareTestUtil.ValidateEqual(
                expected,
                actual,
                itemNotInTheCollection,
                enforceWritable);
        }
    }
}
