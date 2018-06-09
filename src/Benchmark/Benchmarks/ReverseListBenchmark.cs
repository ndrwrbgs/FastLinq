using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
         Method | ItemType | SizeOfInput |     Mean |     Error |    StdDev |
--------------- |--------- |------------ |---------:|----------:|----------:|
          Count |    Array |         100 | 1.758 ns | 0.2569 ns | 0.0145 ns |
 FastLinq_Count |    Array |         100 | 3.158 ns | 0.5434 ns | 0.0307 ns |

          Index |    Array |         100 | 2.207 ns | 2.6130 ns | 0.1476 ns |
 FastLinq_Index |    Array |         100 | 6.247 ns | 0.8132 ns | 0.0459 ns |

          Count |     List |         100 | 1.925 ns | 0.6515 ns | 0.0368 ns |
 FastLinq_Count |     List |         100 | 3.003 ns | 0.5841 ns | 0.0330 ns |

          Index |     List |         100 | 2.111 ns | 2.1939 ns | 0.1240 ns |
 FastLinq_Index |     List |         100 | 6.063 ns | 3.2890 ns | 0.1858 ns |
     */

    public class ReverseListBenchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<int> ReverseList;
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

            this.ReverseList = FastLinq.Reverse(
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
            var _ = this.ReverseList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.ReverseList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
