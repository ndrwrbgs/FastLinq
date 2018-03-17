namespace Test
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal static class CollectionCompareTestUtil
    {
        private static void CollectionAssertAreEqual<T>(
            IReadOnlyCollection<T> first,
            IReadOnlyCollection<T> second,
            string message)
        {
            Assert.AreEqual(first.Count, second.Count);
            var firstGrouped = first.ToLookup(item => item);
            var secondGrouped = second.ToLookup(item => item);

            foreach (var firstGroup in firstGrouped)
            {
                Assert.IsTrue(secondGrouped.Contains(firstGroup.Key));
                var secondGroup = secondGrouped[firstGroup.Key];

                Assert.AreEqual(firstGroup.Count(), secondGroup.Count());
            }
        }

        public static void ValidateEqual<T>(
            IEnumerable<T> expected,
            // TODO: Take a Func<> so the modifications can be done safely
            // DON'T MODIFY YOUR INPUTS :(
            IReadOnlyCollection<T> actual,
            T itemNotInTheCollection,
            // Allows writability to match the BCL. Pass true if you want to ensure the ICollection implements ICollection.write methods
            bool enforceWritable = false)
        {
            var expectedMaterialized = expected.ToList();

            // IEnumerable.GetEnumerator
            int itemIndex = 0;
            foreach (var item in (IEnumerable) actual)
            {
                Assert.AreEqual(expectedMaterialized[itemIndex], item);
                itemIndex++;
            }

            // IEnumerable<T>.GetEnumerator
            // TODO: This implies order but ICollection does not require order
            Assert.IsTrue(
                expectedMaterialized.SequenceEqual(actual),
                "The items should be the same");

            // ICollection.Count
            Assert.AreEqual(expectedMaterialized.Count, actual.Count, "The counts should be the same");
            Assert.AreEqual(actual.Count, Enumerable.ToList(actual).Count, "Count should be accurate");
            
            // IReadOnlyCollection.Contains
            if (actual.Count > 0)
            {
                var itemPresent = actual.First();
                Assert.IsTrue(actual.Contains(itemPresent), "The item came from the collection, it should be present");
            }

            Assert.IsFalse(actual.Contains(itemNotInTheCollection), "Item expected to not be present");
        }

        private enum ValidateCopyToArrayIndexMode
        {
            Zero,
            LessThanArrayLength,
            EqualsArrayLength,
            GreaterThanArrayLength
        }

        private enum ValidateCopyToFitMode
        {
            Zero,
            DoesNotFit,
            FitsPerfectly,
            FitsEasily
        }
    }
}
 