using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /*
    TODO: Cost differential due to creating a new collection. BCL caches, even for T, so seems reasonable we do also.

   Method | EnumerateAfterwards |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
--------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
 FastLinq |               False |  4.444 ns | 0.6401 ns | 0.0362 ns | 0.0057 |      24 B |
   System |               False |  3.882 ns | 0.6009 ns | 0.0340 ns |      - |       0 B |
 FastLinq |                True | 20.972 ns | 5.3893 ns | 0.3045 ns | 0.0057 |      24 B |
   System |                True | 19.837 ns | 3.4047 ns | 0.1924 ns |      - |       0 B |
     */
    public class EmptyBenchmark
    {
        [Params(true, false)] public bool EnumerateAfterwards;

        [Benchmark]
        [BenchmarkCategory("System")]
        public void System()
        {
            var result = Enumerable.Empty<int>();
            if (this.EnumerateAfterwards)
            {
                foreach (var item in result) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq")]
        public void FastLinq()
        {
            var result = global::System.Linq.FastLinq.Empty<int>();
            if (this.EnumerateAfterwards)
            {
                foreach (var item in result) ;
            }
        }
    }
}
