using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    using System.Collections.Generic;
    using System.Linq;

    using FluentAssertions;

    using Test.List;

    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void WhenAny()
        {
            ICollection<int> collection = new[] { 1, 2, 3 };
            Assert.IsTrue(collection.Any());
        }

        [TestMethod]
        public void WhenNone()
        {
            ICollection<int> collection = new int[] { };
            Assert.IsFalse(collection.Any());
        }

        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;
            new Action(
                    () => collection.Any())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class CollectionCompareTestUtilTests
    {
        [TestMethod]
        public void List()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new List<int> { 1, 2, 3 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void OneItemList()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new List<int> { 1 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void EmptyList()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new int[] { },
                new List<int> { },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void Array()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArray()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new[] { 1},
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArray()
        {
            CollectionCompareTestUtil.ValidateEqual(
                new int[] { },
                new int[] { },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
    }

    [TestClass]
    public class DefaultIfEmptyTests
    {
        [TestMethod]
        public void NotEmpty()
        {
            IReadOnlyCollection<int> notEmpty = new[] { 1 };
            
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(notEmpty),
                FastLinq.DefaultIfEmpty(notEmpty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyObject()
        {
            IReadOnlyCollection<object> empty = new object[] { };
            
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyValueType()
        {
            IReadOnlyCollection<int> empty = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyCollection<int> collection = null;
            new Action(
                () => collection.DefaultIfEmpty())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ToArrayTests
    {
        [TestMethod]
        public void NominalCase()
        {
            var input = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.ToArray(input),
                FastLinq.ToArray(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void NoItems()
        {
            IReadOnlyCollection<int> collection = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.ToArray(collection),
                FastLinq.ToArray<int>(collection),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void NullInput()
        {
            ICollection<int> collection = null;
            new Action(
                    () => collection.ToArray())
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class EnumerableWithCountTests
    {
        // Tested via other methods
        // TODO: Should likely test explicitly
    }

    [TestClass]
    public class SkipTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyCollection<int> collection = null;

            new Action(
                    () => collection.Skip(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 1),
                FastLinq.Skip(collection, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAll()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 3),
                FastLinq.Skip(collection, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipMoreThanExist()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 50),
                FastLinq.Skip(collection, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNegative()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, -1),
                FastLinq.Skip(collection, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNone()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Skip(collection, 0),
                FastLinq.Skip(collection, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
    }


    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyCollection<int> collection = null;

            new Action(
                    () => collection.Take(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 1),
                FastLinq.Take(collection, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeAll()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 3),
                FastLinq.Take(collection, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeMoreThanExist()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 50),
                FastLinq.Take(collection, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNegative()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, -1),
                FastLinq.Take(collection, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNone()
        {
            IReadOnlyCollection<int> collection = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Take(collection, 0),
                FastLinq.Take(collection, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
    }

    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void NominalCase()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstLarger()
        {
            var first = new int[] { 1, 2, 3, 4, 5, 6 };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondLarger()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { 4, 5, 6, 7, 8, 9 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstEmpty()
        {
            var first = new int[] { };
            var second = new int[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondEmpty()
        {
            var first = new int[] { 1, 2, 3 };
            var second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void BothEmpty()
        {
            var first = new int[] { };
            var second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Zip(first, second, (i, j) => i + j),
                FastLinq.Zip(first, second, (i, j) => i + j),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstNull()
        {
            IReadOnlyCollection<int> first = null;
            IReadOnlyCollection<int> second = new int[] { };
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void SecondNull()
        {
            IReadOnlyCollection<int> first = new int[] { };
            IReadOnlyCollection<int> second = null;
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void BothNull()
        {
            IReadOnlyCollection<int> first = null;
            IReadOnlyCollection<int> second = null;
            Func<int, int, object> projection = (i, j) => i + j;

            new Action(
                () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void ProjectionNull()
        {
            IReadOnlyCollection<int> first = new int[] { };
            IReadOnlyCollection<int> second = new int[] { };
            Func<int, int, object> projection = null;

            new Action(
                    () => FastLinq.Zip(first, second, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ToDictionaryTests
    {
        [TestClass]
        public class JustKeySelector
        {
            [TestClass]
            public class DefaultComparer
            {
                [TestMethod]
                public void NominalCase()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 2),
                            new KeyValuePair<string, int>("3", 3),
                        },
                        result);
                }

                [TestMethod]
                public void NullSource()
                {
                    ICollection<int> source = null;
                    Func<int, string> keySelector = i => i.ToString();
                    
                    new Action(
                        () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullKeySelector()
                {
                    ICollection<int> source = new [] {1,2,3};
                    Func<int, string> keySelector = null;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void EmptySource()
                {
                    ICollection<int> source = new int[] { };
                    Func<int, string> keySelector = i => i.ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector);

                    Assert.AreEqual(0, result.Count);
                }

                [TestMethod]
                public void DuplicateKeys()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => "duplicate";

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void DuplicateValues()
                {
                    ICollection<int> source = new[] { 1, 1, 1 };
                    int key = 0;
                    Func<int, string> keySelector = _ => (key++).ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("0", 1),
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 1),
                        },
                        result);
                }
            }

            [TestClass]
            public class ExplicitComparer
            {
                [TestMethod]
                public void NominalCase()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 2),
                            new KeyValuePair<string, int>("3", 3),
                        },
                        result);
                }

                [TestMethod]
                public void NullSource()
                {
                    ICollection<int> source = null;
                    Func<int, string> keySelector = i => i.ToString();

                    new Action(
                        () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullKeySelector()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = null;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    IEqualityComparer<string> keyComparer = null;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, keyComparer);
                    Assert.AreEqual(EqualityComparer<string>.Default, result.Comparer);
                }

                [TestMethod]
                public void EmptySource()
                {
                    ICollection<int> source = new int[] { };
                    Func<int, string> keySelector = i => i.ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal);

                    Assert.AreEqual(0, result.Count);
                }

                [TestMethod]
                public void DuplicateKeysNoMatterWhatComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => "duplicate";

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void DuplicateKeysIfComparerHonored()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i =>
                    {
                        switch (i)
                        {
                            case 1:
                                return "a";
                            case 2:
                                // Duplicate, if we ignore the case
                                return "A";
                            case 3:
                                return "c";
                            default:
                                throw new Exception();
                        }
                    };

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.OrdinalIgnoreCase))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void NotDuplicateBecauseOfComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i =>
                    {
                        switch (i)
                        {
                            case 1:
                                return "a";
                            case 2:
                                // Not duplicate, because we consider the case
                                return "A";
                            case 3:
                                return "c";
                            default:
                                throw new Exception();
                        }
                    };

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("a", 1),
                            new KeyValuePair<string, int>("A", 2),
                            new KeyValuePair<string, int>("c", 3),
                        },
                        result);
                }

                [TestMethod]
                public void DuplicateValues()
                {
                    ICollection<int> source = new[] { 1, 1, 1 };
                    int key = 0;
                    Func<int, string> keySelector = _ => (key++).ToString();

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("0", 1),
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 1),
                        },
                        result);
                }
            }
        }

        [TestClass]
        public class KeyAndValueSelector
        {
            [TestClass]
            public class DefaultComparer
            {
                [TestMethod]
                public void NominalCase()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 2),
                            new KeyValuePair<string, int>("2", 4),
                            new KeyValuePair<string, int>("3", 6),
                        },
                        result);
                }

                [TestMethod]
                public void NullSource()
                {
                    ICollection<int> source = null;
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                        () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullKeySelector()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = null;
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullValueSelector()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = null;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void EmptySource()
                {
                    ICollection<int> source = new int[] { };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector);

                    Assert.AreEqual(0, result.Count);
                }

                [TestMethod]
                public void DuplicateKeys()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => "duplicate";
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void DuplicateValues()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => 1;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 1),
                            new KeyValuePair<string, int>("3", 1),
                        },
                        result);
                }
            }

            [TestClass]
            public class ExplicitComparer
            {
                [TestMethod]
                public void NominalCase()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 2),
                            new KeyValuePair<string, int>("2", 4),
                            new KeyValuePair<string, int>("3", 6),
                        },
                        result);
                }

                [TestMethod]
                public void NullSource()
                {
                    ICollection<int> source = null;
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                        () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullKeySelector()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = null;
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullValueSelector()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = null;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentNullException>();
                }

                [TestMethod]
                public void NullComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;
                    IEqualityComparer<string> keyComparer = null;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, keyComparer);
                    Assert.AreEqual(EqualityComparer<string>.Default, result.Comparer);
                }

                [TestMethod]
                public void EmptySource()
                {
                    ICollection<int> source = new int[] { };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => i * 2;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal);

                    Assert.AreEqual(0, result.Count);
                }

                [TestMethod]
                public void DuplicateKeysNoMatterWhatComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => "duplicate";
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void DuplicateKeysIfComparerHonored()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i =>
                    {
                        switch (i)
                        {
                            case 1:
                                return "a";
                            case 2:
                                // Duplicate, if we ignore the case
                                return "A";
                            case 3:
                                return "c";
                            default:
                                throw new Exception();
                        }
                    };
                    Func<int, int> valueSelector = i => i * 2;

                    new Action(
                            () => FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.OrdinalIgnoreCase))
                        .Should()
                        .Throw<ArgumentException>()
                        .WithMessage("An item with the same key has already been added.");
                }

                [TestMethod]
                public void NotDuplicateBecauseOfComparer()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i =>
                    {
                        switch (i)
                        {
                            case 1:
                                return "a";
                            case 2:
                                // Not duplicate, because we consider the case
                                return "A";
                            case 3:
                                return "c";
                            default:
                                throw new Exception();
                        }
                    };
                    Func<int, int> valueSelector = i => i * 2;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("a", 2),
                            new KeyValuePair<string, int>("A", 4),
                            new KeyValuePair<string, int>("c", 6),
                        },
                        result);
                }

                [TestMethod]
                public void DuplicateValues()
                {
                    ICollection<int> source = new[] { 1, 2, 3 };
                    Func<int, string> keySelector = i => i.ToString();
                    Func<int, int> valueSelector = i => 1;

                    var result = FastLinq.ToDictionary(source.AsReadOnly(), keySelector, valueSelector, StringComparer.Ordinal);

                    Assert.AreEqual(source.Count, result.Count);
                    CollectionAssert.AreEqual(
                        new[]
                        {
                            new KeyValuePair<string, int>("1", 1),
                            new KeyValuePair<string, int>("2", 1),
                            new KeyValuePair<string, int>("3", 1),
                        },
                        result);
                }
            }
        }
    }

    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => null;

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyCollection<int> input = new int[] { };
            Func<int, string> projection =
                i => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            IReadOnlyCollection<int> input = null;
            Func<int, string> projection =
                i => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class SelectWithIndexTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (item, index) => item.ToString() + index.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (i, _) => null;

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyCollection<int> input = new int[] { };
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            IReadOnlyCollection<int> input = null;
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void ProjectionNull()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Empty()
        {
            IReadOnlyCollection<int> input = new int[] { };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Duplicates()
        {
            IReadOnlyCollection<int> input = new[] { 1, 1, 2 };
            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Null()
        {
            IReadOnlyCollection<int> input = null;

            new Action(
                    () => FastLinq.Reverse(input))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> first = new[] { 1, 2, 3 };
            IReadOnlyCollection<int> second = new[] { 4, 5, 6 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);

        }

        [TestMethod]
        public void Duplicates()
        {
            IReadOnlyCollection<int> first = new[] { 1, 2, 3 };
            IReadOnlyCollection<int> second = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void FirstEmpty()
        {
            IReadOnlyCollection<int> first = new int[] { };
            IReadOnlyCollection<int> second = new[] { 1, 2, 3 };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SecondEmpty()
        {
            IReadOnlyCollection<int> first = new[] { 1, 2, 3 };
            IReadOnlyCollection<int> second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void BothEmpty()
        {
            IReadOnlyCollection<int> first = new int[] { };
            IReadOnlyCollection<int> second = new int[] { };

            CollectionCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        
        [TestMethod]
        public void FirstNull()
        {
            IReadOnlyCollection<int> first = null;
            IReadOnlyCollection<int> second = new int[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void SecondNull()
        {
            IReadOnlyCollection<int> first = new int[] { 1, 2, 3 };
            IReadOnlyCollection<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void BothNull()
        {
            IReadOnlyCollection<int> first = null;
            IReadOnlyCollection<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class ToListTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyCollection<int> input = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(input),
                FastLinq.ToList(input),
                4,
                enforceWritable: true);
        }

        [TestMethod]
        public void Empty()
        {
            IReadOnlyCollection<int> input = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(input),
                FastLinq.ToList(input),
                4,
                enforceWritable: true);
        }

        [TestMethod]
        public void NullInput()
        {
            IReadOnlyCollection<int> input = null;

            new Action(
                    () => FastLinq.ToList(input))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
