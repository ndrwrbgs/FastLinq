namespace Test.Array
{
    using System;
    using System.Linq;

    using DelMe.NBench.Demo.PerfAssert.Library;

    using FluentAssertions;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NBench;

    [TestClass]
    public class ReverseTests
    {
        [TestMethod]
        public void Null()
        {
            EnsureResultOrExceptionSame(
                (int[]) null,
                arr => Enumerable.Reverse(arr),
                arr => FastLinq.Reverse(arr));
        }

        [TestMethod]
        public void Empty()
        {
            EnsureResultOrExceptionSame(
                new int[] { },
                arr => Enumerable.Reverse(arr),
                arr => FastLinq.Reverse(arr));
        }

        [TestMethod]
        public void Nominal()
        {
            EnsureResultOrExceptionSame(
                new int[] {1, 2, 3},
                arr => Enumerable.Reverse(arr),
                arr => FastLinq.Reverse(arr));
        }

        [TestMethod]
        [Ignore]
        public void Faster_WhenEnumerating()
        {
            // Could set globally, but that would cause issues with concurrency
            // Though, we probably don't want concurrent execution during benchmarks, huh? :)
            using (PerfAssert.Context.UsingAssertionViolatedMethod((string message) => Assert.Fail(message)))
            using (PerfAssert.Context.UsingBenchmarkRunner(BenchmarkRunCache.Instance))
            {
                PerfAssert.That<ReverseTests>(t => t.FastLinq_Nominal_Enumerate())
                    .Is().FasterThan(t => t.Enumerable_Nominal_Enumerate());
            }
        }

        [TestMethod]
        [Ignore("This can fail, as we actually ARE slower when not enumerating")]
        public void NotMuchSlowerThan_WhenNotEnumerating()
        {
            // Could set globally, but that would cause issues with concurrency
            // Though, we probably don't want concurrent execution during benchmarks, huh? :)
            using (PerfAssert.Context.UsingAssertionViolatedMethod((string message) => Assert.Fail(message)))
            using (PerfAssert.Context.UsingBenchmarkRunner(BenchmarkRunCache.Instance))
            {
                PerfAssert.That<ReverseTests>(t => t.FastLinq_Nominal_IgnoreResult())
                    .Is().NotWorseRuntimeThan(t => t.Enumerable_Nominal_IgnoreResult());
            }
        }

        private int[] testData = new int[] { 1, 2, 3 };

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void FastLinq_Nominal_Enumerate()
        {
            foreach (int i in FastLinq.Reverse(this.testData))
            {

            }
        }

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void Enumerable_Nominal_Enumerate()
        {
            foreach (int i in Enumerable.Reverse(this.testData))
            {
            }
        }

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void FastLinq_Nominal_IgnoreResult()
        {
            FastLinq.Reverse(this.testData);
        }

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void Enumerable_Nominal_IgnoreResult()
        {
            Enumerable.Reverse(this.testData);
        }

        private static void EnsureResultOrExceptionSame<TIn, TOut>(
            TIn data,
            Func<TIn, TOut> first,
            Func<TIn, TOut> second)
        {
            var firstResult = Run(data, first);
            var secondResult = Run(data, second);

            secondResult.Item1.Should().BeEquivalentTo(firstResult.Item1);
            secondResult.Item2?.GetType().Should().Be(firstResult.Item2?.GetType());
            secondResult.Item2?.Message.Should().Be(firstResult.Item2?.Message);
        }

        private static (TOut, Exception) Run<TIn, TOut>(
            TIn data,
            Func<TIn, TOut> func)
        {
            try
            {
                var ret = func(data);
                return (ret, null);
            }
            catch (Exception e)
            {
                return (default(TOut), e);
            }
        }
    }
}