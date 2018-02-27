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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> input = new int[] { };
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
            IList<int> input = null;
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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> input = new int[] { };
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
            IList<int> input = null;
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
            IList<int> input = new[] { 1, 2, 3 };
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
            IList<int> list = new[] { 1, 2, 3 };
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
            IList<int> list = null;
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
            IList<int> first = new[] { 1, 2 };
            IList<int> second = new[] { 1, 2, 3, 4 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyFirst()
        {
            IList<int> first = new int[] { };
            IList<int> second = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptySecond()
        {
            IList<int> first = new[] { 1, 2, 3 };
            IList<int> second = new int[] {  };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void EmptyBoth()
        {
            IList<int> first = new int[] {  };
            IList<int> second = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Concat(first, second),
                FastLinq.Concat(first, second),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NullFirst()
        {
            IList<int> first = null;
            IList<int> second = new[] { 1, 2, 3 };

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullSecond()
        {
            IList<int> first = new[] { 1, 2, 3 };
            IList<int> second = null;

            new Action(
                    () => FastLinq.Concat(first, second))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NullBoth()
        {
            IList<int> first = null;
            IList<int> second = null;

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
            IList<int> input = new[] { 1, 2, 3 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Empty()
        {
            IList<int> input = new int[] { };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Duplicates()
        {
            IList<int> input = new[] { 1, 1, 2 };
            ListCompareTestUtil.ValidateEqual(
                Enumerable.Reverse(input),
                FastLinq.Reverse(input),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void Null()
        {
            IList<int> input = null;

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
            IList<int> notEmpty = new[] { 1 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(notEmpty),
                FastLinq.DefaultIfEmpty(notEmpty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyObject()
        {
            IList<object> empty = new object[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void EmptyValueType()
        {
            IList<int> empty = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.DefaultIfEmpty(empty),
                FastLinq.DefaultIfEmpty(empty),
                itemNotInTheCollection: 1,
                enforceWritable: false);
        }

        [TestMethod]
        public void MutationsDoNotAffectReturnValue()
        {
            IList<int> empty = new int[] { };
            var defaultIfEmpty = empty.DefaultIfEmpty();

            if (defaultIfEmpty.IsReadOnly)
            {
                Assert.Inconclusive("Cannot test mutation because the return type is read only, preventing mutations - implicitly this test passes as in the absence of the ability to mutate, side effects of mutation are impossible");
            }

            // Mutate
            defaultIfEmpty.Clear();
            Assert.AreEqual(0, defaultIfEmpty.Count);

            // Get default again
            var second = empty.DefaultIfEmpty();
            Assert.AreEqual(1, second.Count, "The result should not be affected by previous operations");
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
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
                FastLinq.ToLazyList(input),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NoItems()
        {
            IList<int> list = new int[] { };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.ToList(list),
                FastLinq.ToLazyList(list),
                itemNotInTheCollection: 0,
                enforceWritable: true);
        }

        [TestMethod]
        public void NullInput()
        {
            IList<int> list = null;
            new Action(
                    () => list.ToLazyList())
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void WriteToResultDoNotChangeInput()
        {
            IList<int> input = new[] { 1, 2, 3 };

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
            IList<int> list = null;

            new Action(
                    () => list.Skip(3))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void NominalCaseArray()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 1),
                FastLinq.Skip(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAll()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 3),
                FastLinq.Skip(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipMoreThanExist()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 50),
                FastLinq.Skip(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNegative()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, -1),
                FastLinq.Skip(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipNone()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }


        [TestMethod]
        public void SkipObjects()
        {
            IList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipObjectsContainsNull()
        {
            IList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Skip(list, 0),
                FastLinq.Skip(list, 0),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void SkipAllObjects()
        {
            IList<object> list = new object[] { "a", "b" };

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
            IList<int> list = null;

            new Action(
                    () => list.Take(3))
                .Should()
                .Throw<ArgumentNullException>();
        }
        [TestMethod]
        public void NominalCaseArray()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseList()
        {
            IList<int> list = new List<int> { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }
        [TestMethod]
        public void NominalCaseOther()
        {
            IList<int> list = new ArraySegment<int>(new int[] { 1, 2, 3 });

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 1),
                FastLinq.Take(list, 1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeAll()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 3),
                FastLinq.Take(list, 3),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeMoreThanExist()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 50),
                FastLinq.Take(list, 50),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNegative()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, -1),
                FastLinq.Take(list, -1),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNone()
        {
            IList<int> list = new[] { 1, 2, 3 };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: 0,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjects()
        {
            IList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeObjectsContainsNull()
        {
            IList<object> list = new object[] { null, "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 10),
                FastLinq.Take(list, 10),
                itemNotInTheCollection: "a",
                enforceWritable: false);
        }

        [TestMethod]
        public void TakeNoneObjects()
        {
            IList<object> list = new object[] { "a", "b" };

            ListCompareTestUtil.ValidateEqual(
                Enumerable.Take(list, 0),
                FastLinq.Take(list, 0),
                itemNotInTheCollection: null,
                enforceWritable: false);
        }
    }
}
