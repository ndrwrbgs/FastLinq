using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.List
{
    using System.Collections;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AllTests
    {
        [TestMethod]
        public void WhenAll()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsTrue(list.All(i => i > 0));
        }

        [TestMethod]
        public void WhenOneNot()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsFalse(
                list.All(i => i < 3));
        }

        [TestMethod]
        public void WhenNone()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsFalse(list.All(i => i < 0));
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            new Action(
                    () => list.All(i => true))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicate()
        {
            IList<int> list = new[] { 1, 2, 3 };
            new Action(
                    () => list.All(null))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class AnyTests
    {
        [TestMethod]
        public void WhenAny()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsTrue(list.Any(i => i == 1));
        }

        [TestMethod]
        public void WhenNone()
        {
            IList<int> list = new[] { 1, 2, 3 };
            Assert.IsFalse(list.Any(i => i == 0));
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            new Action(
                    () => list.Any(i => true))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicate()
        {
            IList<int> list = new[] { 1, 2, 3 };
            new Action(
                    () => list.Any(null))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }


    [TestClass]
    public class SelectTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => i.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, string> projection =
                i => null;

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> input = new int[] { };
            Func<int, string> projection =
                i => i.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> input = null;
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
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
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
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (item, index) => item.ToString() + index.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void SelectProducesNulls()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection =
                (i, _) => null;

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> input = new int[] { };
            Func<int, int, string> projection =
                (i, _) => i.ToString();

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Select(input, projection),
                FastLinq.Select(input, projection),
                itemNotInTheCollection: "",
                enforceWritable: false);
        }
        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> input = null;
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
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            Func<int, int, string> projection = null;

            new Action(
                    () => FastLinq.Select(input, projection))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

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

    [TestClass]
    public class ConcatTests
    {
        [TestMethod]
        public void Nominal()
        {
            IReadOnlyList<int> first = new[] { 1, 2 };
            IReadOnlyList<int> second = new[] { 1, 2, 3, 4 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyFirst()
        {
            IReadOnlyList<int> first = new int[] { };
            IReadOnlyList<int> second = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptySecond()
        {
            IReadOnlyList<int> first = new[] { 1, 2, 3 };
            IReadOnlyList<int> second = new int[] {  };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyBoth()
        {
            IReadOnlyList<int> first = new int[] {  };
            IReadOnlyList<int> second = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NullFirst()
        {
            IReadOnlyList<int> first = null;
            IReadOnlyList<int> second = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullSecond()
        {
            IReadOnlyList<int> first = new[] { 1, 2, 3 };
            IReadOnlyList<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullBoth()
        {
            IReadOnlyList<int> first = null;
            IReadOnlyList<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class CountTests
    {
        [TestMethod]
        public void AllMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i > 0);
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void NoneMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i == 0);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void SomeMatch()
        {
            IList<int> list = new[] { 1, 2, 3 };

            var result = list.Count(i => i < 3);
            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void EmptyInput()
        {
            IList<int> list = new int[] { };

            var result = list.Count(i => i < 3);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            Func<int, bool> predicate = i => i < 3;

            new Action(
                    () => list.Count(predicate))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NullPredicate()
        {
            IList<int> list = new int[] { };
            Func<int, bool> predicate = null;

            new Action(
                    () => list.Count(predicate))
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
            IReadOnlyList<int> input = new[] { 1, 2, 3 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Empty()
        {
            IReadOnlyList<int> input = new int[] { };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Duplicates()
        {
            IReadOnlyList<int> input = new[] { 1, 1, 2 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Null()
        {
            IReadOnlyList<int> input = null;

            new Action(
                    () => FastLinq.Reverse(input))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

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

    [TestClass]
    public class ListCompareTestUtilTests
    {
        [TestMethod]
        public void List()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new List<int> { 1, 2, 3 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void OneItemList()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new List<int> { 1 },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void EmptyList()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new List<int> { },
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }
        [TestMethod]
        public void ArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new ArraySegment<int>(new[] { 1, 2, 3 }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new ArraySegment<int>(new[] { 1 }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArraySegment()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new ArraySegment<int>(new int[] { }),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void Array()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void OneItemArray()
        {
            ListCompareTestUtil.ValidateEqual(
                new[] { 1 },
                new[] { 1 },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyArray()
        {
            ListCompareTestUtil.ValidateEqual(
                new int[] { },
                new int[] { },
                itemNotInTheCollection: 0,
                // arrays are readonly
                enforceWritable: false);
        }
    }


    [TestClass]
    public class ToLazyListTests
    {
        [TestMethod]
        public void IsLazy()
        {
            bool any = false;
            var result = FastLinq.ToLazyList(
                // Need an IList for the Select
                FastLinq.Select(
                    new[] { 0 },
                    _ => any = true));

            Assert.IsFalse(any, "ToLazyList should be lazy");
        }

        [TestMethod]
        public void NominalCase()
        {
            var input = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(input),
                (IReadOnlyList<int>)FastLinq.ToLazyList(input),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NoItems()
        {
            IReadOnlyList<int> list = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(list),
                (IReadOnlyList<int>)FastLinq.ToLazyList(list),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;
            new Action(
                    () => list.ToLazyList())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WriteToResultDoNotChangeInput()
        {
            IReadOnlyList<int> input = new[] { 1, 2, 3 };

            var result = FastLinq.ToLazyList(input);
            result[0] = 0;
            result[1] = 1;
            result[2] = 2;

            Assert.IsTrue(new[] { 1, 2, 3 }.SequenceEqual(input));
            Assert.IsTrue(new[] { 0, 1, 2 }.SequenceEqual(result));
        }
    }

    [TestClass]
    public class SkipTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => list.Skip(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCaseArray()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IReadOnlyList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IReadOnlyList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAll()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 3),
                FastLinq.Skip(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipMoreThanExist()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 50),
                FastLinq.Skip(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNegative()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, -1),
                FastLinq.Skip(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNone()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }


        [TestMethod]
        public void SkipObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipObjectsContainsNull()
        {
            IReadOnlyList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAllObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 10),
                FastLinq.Skip(list, 10),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
    }


    [TestClass]
    public class TakeTests
    {
        [TestMethod]
        public void NullInput()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => list.Take(3))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NominalCaseArray()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IReadOnlyList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IReadOnlyList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeAll()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 3),
                FastLinq.Take(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeMoreThanExist()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 50),
                FastLinq.Take(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNegative()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, -1),
                FastLinq.Take(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNone()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjectsContainsNull()
        {
            IReadOnlyList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNoneObjects()
        {
            IReadOnlyList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
    }

    [TestClass]
    public class ElementAtTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.ElementAt(list, 2));
        }

        [TestMethod]
        public void NegativeIndex()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, -1))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IndexEqualsLength()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, 3))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void IndexTooLarge()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.ElementAt(list, 100))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.ElementAt(list, 0))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.ElementAt(list, 0))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }
    }

    [TestClass]
    public class ElementAtOrDefaultTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.ElementAtOrDefault(list, 2));
        }

        [TestMethod]
        public void NegativeIndex()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(default(int), FastLinq.ElementAtOrDefault(list, -1));
        }

        [TestMethod]
        public void IndexEqualsLength()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(default(int), FastLinq.ElementAtOrDefault(list, 3));
        }

        [TestMethod]
        public void IndexTooLarge()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(default(int), FastLinq.ElementAtOrDefault(list, 100));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.ElementAtOrDefault(list, 0))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.ElementAt(list, 0))
                .Should()
                .Throw<ArgumentOutOfRangeException>();
        }
    }

    [TestClass]
    public class FirstTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(1, FastLinq.First(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.First(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.First(list))
                .Should()
                .Throw<InvalidOperationException>();
        }
    }

    [TestClass]
    public class FirstOrDefaultTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(1, FastLinq.FirstOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.FirstOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.FirstOrDefault(list));
        }
    }

    [TestClass]
    public class LastTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.Last(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.Last(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.Last(list))
                .Should()
                .Throw<InvalidOperationException>();
        }
    }

    [TestClass]
    public class LastOrDefaultTests
    {
        [TestMethod]
        public void NominalCase()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            Assert.AreEqual(3, FastLinq.LastOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.LastOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void InputEmpty()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.LastOrDefault(list));
        }
    }

    [TestClass]
    public class SingleTests
    {
        [TestMethod]
        public void JustOne()
        {
            IReadOnlyList<int> list = new[] { 2 };

            Assert.AreEqual(2, FastLinq.Single(list));
        }

        [TestMethod]
        public void MoreThanOne()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Single(list))
                .Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void None()
        {
            IReadOnlyList<int> list = new int[] { };

            new Action(
                    () => FastLinq.Single(list))
                .Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.Single(list))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }

    [TestClass]
    public class SingleOrDefaultTests
    {
        [TestMethod]
        public void JustOne()
        {
            IReadOnlyList<int> list = new[] { 2 };

            Assert.AreEqual(2, FastLinq.SingleOrDefault(list));
        }

        [TestMethod]
        public void MoreThanOne()
        {
            IReadOnlyList<int> list = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.SingleOrDefault(list))
                .Should()
                .Throw<InvalidOperationException>();
        }

        [TestMethod]
        public void None()
        {
            IReadOnlyList<int> list = new int[] { };

            Assert.AreEqual(default(int), FastLinq.SingleOrDefault(list));
        }

        [TestMethod]
        public void InputNull()
        {
            IReadOnlyList<int> list = null;

            new Action(
                    () => FastLinq.SingleOrDefault(list))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
