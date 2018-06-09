using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
    Unfair comparison, System is not doing Cast
    
         Method | ItemType | SizeOfInput |      Mean |     Error |    StdDev |
--------------- |--------- |------------ |----------:|----------:|----------:|
          Count |    Array |         100 |  3.078 ns | 0.2947 ns | 0.0167 ns |
 FastLinq_Count |    Array |         100 |  5.201 ns | 1.7888 ns | 0.1011 ns |

          Index |    Array |         100 |  3.180 ns | 1.9171 ns | 0.1083 ns |
 FastLinq_Index |    Array |         100 | 18.627 ns | 3.0802 ns | 0.1740 ns |

          Count |     List |         100 |  1.363 ns | 1.2183 ns | 0.0688 ns |
 FastLinq_Count |     List |         100 |  3.444 ns | 0.6790 ns | 0.0384 ns |

          Index |     List |         100 |  1.976 ns | 0.3642 ns | 0.0206 ns |
 FastLinq_Index |     List |         100 | 16.115 ns | 3.3330 ns | 0.1883 ns |
     */

    public class CastListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<object> CastList;
        private IReadOnlyList<string> underlying;

        [GlobalSetup]
        public void Setup()
        {
            switch (this.ItemType)
            {
                case UnderlyingItemType.Array:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).Select(i => i.ToString()).ToArray();
                    break;
                case UnderlyingItemType.List:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).Select(i => i.ToString()).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.CastList = FastLinq.Cast<string, object>(
                this.underlying);
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
            var _ = this.CastList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.CastList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
