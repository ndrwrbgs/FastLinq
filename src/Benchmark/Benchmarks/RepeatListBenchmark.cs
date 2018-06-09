using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
         Method | SizeOfInput |     Mean |     Error |    StdDev | Allocated |
--------------- |------------ |---------:|----------:|----------:|----------:|
 FastLinq_Count |         100 | 1.840 ns | 0.5039 ns | 0.0285 ns |       0 B |
 FastLinq_Index |         100 | 2.698 ns | 8.9912 ns | 0.5080 ns |       0 B |

          Count |    Array |         100 |  1.815 ns | 6.0516 ns | 0.3419 ns |
          Index |    Array |         100 |  2.629 ns | 1.3226 ns | 0.0747 ns |
     */

    public class RepeatListBenchmark
    {
        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<int> RepeatList;

        [GlobalSetup]
        public void Setup()
        {
            this.RepeatList = FastLinq.Repeat(
                1,
                this.SizeOfInput);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Count")]
        public void FastLinq_Count()
        {
            var _ = this.RepeatList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.RepeatList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
