using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    public class SkipTakeListBenchmark
    {
        [Params(true, false)] public bool EnumerateAfterwards;

        [Params(10, 10000)] public int collectionSize;

        [Params(5, 1000)] public int skip;
        [Params(5, 5000)] public int take;

        [Params("list", "array", "readonlycollection")] public string realType;

        private IList<string> source;

        [GlobalSetup]
        public void Setup()
        {
            var sourceEnumerable = Enumerable.Range(0, this.collectionSize).Select(i => i.ToString());
            switch (this.realType)
            {
                case "list":
                    this.source = sourceEnumerable.ToList();
                    break;
                case "array":
                    this.source = sourceEnumerable.ToArray();
                    break;
                case "readonlycollection":
                    this.source = new ReadOnlyCollection<string>(sourceEnumerable.ToList());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(realType), this.realType, "Unknown type");
            }
        }

        [Benchmark]
        public void BaseClassLibrary()
        {
            var result = Enumerable.ToList(
                Enumerable.Take(
                    Enumerable.Skip(
                        this.source,
                        this.skip),
                    this.take));
            if (this.EnumerateAfterwards)
            {
                int i = 0;
                foreach (var item in result)
                {
                    i++;
                }
            }
        }

        /// <summary>
        /// # Memory cost
        /// 2 x object references
        /// 1 x T[takeCount] size allocation inside List
        /// </summary>
        [Benchmark]
        public void FastLinq()
        {
            // TODO: Could keep the existing IList's if we do a kind of copy-on-write IList result
            // note though, that exposing IList from ToList() would be a breaking change (less specific
            // than today's LINQ, rather than more specific)
            var result = System.Linq.FastLinq.ToList(
                System.Linq.FastLinq.Take(
                    System.Linq.FastLinq.Skip(
                        this.source,
                        this.skip),
                    this.take));
            if (this.EnumerateAfterwards)
            {
                int i = 0;
                foreach (var item in result)
                {
                    i++;
                }
            }
        }
    }
}
