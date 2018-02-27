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
            ICollection<T> first,
            ICollection<T> second,
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
            ICollection<T> actual,
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
            Assert.AreEqual(actual.Count, actual.ToList().Count, "Count should be accurate");

            // ICollection.IsReadOnly
            var expectedIsReadOnly = expected is ICollection<T>
                ? ((ICollection<T>) expected).IsReadOnly
                : true;
            if (enforceWritable)
            {
                expectedIsReadOnly = false;
            }

            if (!expectedIsReadOnly)
            {
                // Becoming writable when it wasn't before should not be 'breaking', as far as we are considering it
                // (e.g. it is a functional change but we deem it an unreasonable expectation)
                // TODO: Note this in the library documentation
                Assert.IsFalse(actual.IsReadOnly, "ReadOnly nature should equal that of expected, specifically -- be writable");
            }
            else
            {
                // At minimum, read the value
                new Action(
                        () =>
                        {
                            var _ = ((ICollection<T>)actual).IsReadOnly;
                        })
                    .Should()
                    .NotThrow();
            }

            // ICollection.Contains
            if (actual.Count > 0)
            {
                var itemPresent = actual.First();
                Assert.IsTrue(actual.Contains(itemPresent), "The item came from the collection, it should be present");
            }

            Assert.IsFalse(actual.Contains(itemNotInTheCollection), "Item expected to not be present");

            // ICollection.CopyTo
            foreach (var index in new[] { 10, Math.Max(0, actual.Count - 1), actual.Count, actual.Count + 1 })
            {
                new Action(() => ValidateCopyTo(actual, index, actual.Count + index + 100)).Should().NotThrow();
                new Action(() => ValidateCopyTo(actual, index, actual.Count + index)).Should().NotThrow();
                if (actual.Count > index + 1)
                {
                    new Action(() => ValidateCopyTo(actual, 0, actual.Count + index - 1)).Should().Throw<ArgumentException>("it does not fit");
                }

                if (actual.Count > 0)
                {
                    new Action(() => ValidateCopyTo(actual, index, 0)).Should().Throw<ArgumentException>("it does not fit");
                }
                else
                {
                    new Action(() => ValidateCopyTo(actual, 0, 0)).Should().NotThrow();
                }
            }

            // If the expected was not read only, then writes should work
            if (!expectedIsReadOnly)
            {
                // ICollection.Add
                var sizeBefore = actual.Count;
                actual.Add(itemNotInTheCollection);
                Assert.AreEqual(sizeBefore + 1, actual.Count);
                Assert.IsTrue(actual.Contains(itemNotInTheCollection));
                // TODO: Refactor to allow validation of everything except this recursion and itemNotInTheCollection for the collection after .Add() [e.g. to capture copy-on-write logic]

                // ICollection.Remove
                actual.Remove(itemNotInTheCollection);
                Assert.AreEqual(sizeBefore, actual.Count);
                Assert.IsFalse(actual.Contains(itemNotInTheCollection));

                // ICollection.Clear
                actual.Clear();
                Assert.AreEqual(0, actual.Count);
                CollectionAssertAreEqual(new T[] { }, actual, "Should be empty");
            }
            else
            {
                new Action(() => actual.Add(default(T))).Should().Throw<NotSupportedException>();
                new Action(() => actual.Remove(default(T))).Should().Throw<NotSupportedException>();
                new Action(() => actual.Clear()).Should().Throw<NotSupportedException>();
            }
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

        private static void ValidateCopyTo<T>(
            ICollection<T> collection,
            int arrayindex,
            int targetSize)
        {
            var target = new T[targetSize];
            collection.CopyTo(target, arrayindex);

            int index = arrayindex;
            foreach (var item in collection)
            {
                var targetItem = target[index];
                if (!Equals(item, targetItem))
                {
                    throw new InvalidOperationException("Copy did not work correctly");
                }

                index++;
            }
        }
    }
}
 