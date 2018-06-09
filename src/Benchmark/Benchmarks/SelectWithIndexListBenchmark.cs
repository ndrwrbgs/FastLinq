using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
    Unfair comparison, System is not doing Select
    
         Method | ItemType | SizeOfInput |      Mean |     Error |    StdDev |
--------------- |--------- |------------ |----------:|----------:|----------:|
          Count |    Array |         100 |  1.815 ns | 6.0516 ns | 0.3419 ns |
 FastLinq_Count |    Array |         100 |  3.426 ns | 1.1384 ns | 0.0643 ns |

          Index |    Array |         100 |  2.629 ns | 1.3226 ns | 0.0747 ns |
 FastLinq_Index |    Array |         100 | 10.018 ns | 4.6981 ns | 0.2654 ns |

          Count |     List |         100 |  1.489 ns | 1.7677 ns | 0.0999 ns |
 FastLinq_Count |     List |         100 |  3.267 ns | 1.0700 ns | 0.0605 ns |

          Index |     List |         100 |  2.262 ns | 0.0479 ns | 0.0027 ns |
 FastLinq_Index |     List |         100 |  5.489 ns | 1.5323 ns | 0.0866 ns |
     */

    public class SelectWithIndexListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<int> SelectList;
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

            this.SelectList = FastLinq.Select(
                this.underlying,
                (i, index) => i);
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
            var _ = this.SelectList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.SelectList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
