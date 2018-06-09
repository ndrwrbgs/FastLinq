using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
     * 
         Method | ItemType | SizeOfInput | SkipCount |     Mean |     Error |    StdDev | Allocated |
--------------- |--------- |------------ |---------- |---------:|----------:|----------:|----------:|
          Count |    Array |         100 |         1 | 1.556 ns | 5.1096 ns | 0.2887 ns |       0 B |
 FastLinq_Count |    Array |         100 |         1 | 4.028 ns | 1.8162 ns | 0.1026 ns |       0 B | TODO: Could cache, but that'd be more memory

          Index |    Array |         100 |         1 | 2.373 ns | 3.3910 ns | 0.1916 ns |       0 B |
 FastLinq_Index |    Array |         100 |         1 | 4.166 ns | 0.1564 ns | 0.0088 ns |       0 B |

          Count |     List |         100 |         1 | 1.470 ns | 1.6440 ns | 0.0929 ns |       0 B |
 FastLinq_Count |     List |         100 |         1 | 4.130 ns | 4.7524 ns | 0.2685 ns |       0 B |

          Index |     List |         100 |         1 | 2.013 ns | 0.5917 ns | 0.0334 ns |       0 B |
 FastLinq_Index |     List |         100 |         1 | 3.826 ns | 0.7911 ns | 0.0447 ns |       0 B |
     */

    public class SkipListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        [Params(1)] public int SkipCount;

        private IReadOnlyList<int> skipList;
        private IReadOnlyList<int> underlying;

        [GlobalSetup]
        public void Setup()
        {
            switch (this.ItemType)
            {
                case UnderlyingItemType.Array:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).ToArray();
                    break;
                case UnderlyingItemType.List:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.skipList = FastLinq.Skip(
                this.underlying,
                this.SkipCount);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Count")]
        public void Count()
        {
            var _ = this.underlying.Count;
        }

        [Benchmark]
        [BenchmarkCategory("System", "Index")]
        public void Index()
        {
            var _ = this.underlying[0];
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Count")]
        public void FastLinq_Count()
        {
            var _ = this.skipList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.skipList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
