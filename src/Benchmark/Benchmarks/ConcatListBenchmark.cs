using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
    Unfair comparison, System is not doing Concat
    
         Method | ItemType | SizeOfInput |     Mean |     Error |    StdDev | Allocated |
--------------- |--------- |------------ |---------:|----------:|----------:|----------:|
          Count |    Array |         100 | 7.444 ns | 6.9677 ns | 0.3937 ns |       0 B |
 FastLinq_Count |    Array |         100 | 9.983 ns | 0.8014 ns | 0.0453 ns |       0 B |

          Index |    Array |         100 | 3.169 ns | 1.1070 ns | 0.0625 ns |       0 B |
 FastLinq_Index |    Array |         100 | 9.700 ns | 3.0202 ns | 0.1706 ns |       0 B |

          Count |     List |         100 | 4.063 ns | 0.8860 ns | 0.0501 ns |       0 B |
 FastLinq_Count |     List |         100 | 7.133 ns | 2.6915 ns | 0.1521 ns |       0 B |

          Index |     List |         100 | 2.340 ns | 2.7474 ns | 0.1552 ns |       0 B |
 FastLinq_Index |     List |         100 | 7.189 ns | 3.5523 ns | 0.2007 ns |       0 B |
     */

    public class ConcatListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<object> ConcatList;
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

            this.ConcatList = FastLinq.Concat(
                this.underlying,
                this.underlying);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Count")]
        public void Count()
        {
            var _ = this.underlying.Count + this.underlying.Count;
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
            var _ = this.ConcatList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.ConcatList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
