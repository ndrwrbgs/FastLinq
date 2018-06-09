using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
         Method | Start | SizeOfInput |     Mean |     Error |    StdDev |
--------------- |------ |------------ |---------:|----------:|----------:|
 FastLinq_Count |    50 |         100 | 1.709 ns | 1.7539 ns | 0.0991 ns |
 FastLinq_Index |    50 |         100 | 1.802 ns | 0.8561 ns | 0.0484 ns |


          Count |    Array |         100 |  1.815 ns | 6.0516 ns | 0.3419 ns |
          Index |    Array |         100 |  2.629 ns | 1.3226 ns | 0.0747 ns |
     */

    public class RangeListBenchmark
    {
        [Params(50)] public int Start;
        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<int> RangeList;

        [GlobalSetup]
        public void Setup()
        {
            this.RangeList = FastLinq.Range(
                this.Start,
                this.SizeOfInput);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Count")]
        public void FastLinq_Count()
        {
            var _ = this.RangeList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.RangeList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
