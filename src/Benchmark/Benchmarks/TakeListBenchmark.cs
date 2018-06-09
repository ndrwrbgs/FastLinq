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
         Method | ItemType | SizeOfInput | TakeCount |     Mean |      Error |    StdDev | Allocated |
--------------- |--------- |------------ |---------- |---------:|-----------:|----------:|----------:|
          Count |    Array |         100 |         1 | 1.317 ns |  0.3716 ns | 0.0210 ns |       0 B |
 FastLinq_Count |    Array |         100 |         1 | 4.064 ns |  0.2065 ns | 0.0117 ns |       0 B |

          Index |    Array |         100 |         1 | 2.098 ns |  0.4099 ns | 0.0232 ns |       0 B |
 FastLinq_Index |    Array |         100 |         1 | 6.557 ns |  0.2744 ns | 0.0155 ns |       0 B |

          Count |     List |         100 |         1 | 1.294 ns |  0.2974 ns | 0.0168 ns |       0 B |
 FastLinq_Count |     List |         100 |         1 | 4.091 ns |  0.8680 ns | 0.0490 ns |       0 B |

          Index |     List |         100 |         1 | 1.866 ns |  0.3871 ns | 0.0219 ns |       0 B |
 FastLinq_Index |     List |         100 |         1 | 6.924 ns | 14.7530 ns | 0.8336 ns |       0 B |
     */

    public class TakeListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        [Params(1)] public int TakeCount;

        private IReadOnlyList<int> TakeList;
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

            this.TakeList = FastLinq.Take(
                this.underlying,
                this.TakeCount);
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
            var _ = this.TakeList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.TakeList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
