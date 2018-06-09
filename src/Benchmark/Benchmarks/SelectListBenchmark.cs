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
    
         Method | ItemType | SizeOfInput |     Mean |      Error |    StdDev |
--------------- |--------- |------------ |---------:|-----------:|----------:|
          Count |    Array |         100 | 1.485 ns |  1.4620 ns | 0.0826 ns |
 FastLinq_Count |    Array |         100 | 3.769 ns |  4.8384 ns | 0.2734 ns |

          Index |    Array |         100 | 2.976 ns |  1.7518 ns | 0.0990 ns |
 FastLinq_Index |    Array |         100 | 5.657 ns |  2.9515 ns | 0.1668 ns |

          Count |     List |         100 | 2.494 ns |  2.3219 ns | 0.1312 ns |
 FastLinq_Count |     List |         100 | 5.797 ns |  0.8336 ns | 0.0471 ns |

          Index |     List |         100 | 3.281 ns |  6.0883 ns | 0.3440 ns |
 FastLinq_Index |     List |         100 | 6.025 ns | 11.6135 ns | 0.6562 ns |
     */

    public class SelectListBenchmark
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
                i => i);
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
