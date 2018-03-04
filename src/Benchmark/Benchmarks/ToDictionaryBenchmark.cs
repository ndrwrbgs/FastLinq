using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /* Main gain: memory via avoiding dictionary resizing
     * 
              Method | SizeOfInput |         Mean |        Error |      StdDev |   Gen 0 | Allocated |
-------------------- |------------ |-------------:|-------------:|------------:|--------:|----------:|
   System_Enumerable |           0 |     43.27 ns |     8.083 ns |   0.4567 ns |  0.0305 |     128 B |
   System_Collection |           0 |     46.27 ns |    93.713 ns |   5.2950 ns |  0.0286 |     120 B |
 FastLinq_Collection |           0 |     38.96 ns |    29.941 ns |   1.6917 ns |  0.0286 |     120 B |
   System_Enumerable |           1 |     89.02 ns |    13.139 ns |   0.7424 ns |  0.0571 |     240 B |
   System_Collection |           1 |     93.46 ns |    16.092 ns |   0.9092 ns |  0.0552 |     232 B |
 FastLinq_Collection |           1 |     86.23 ns |     9.906 ns |   0.5597 ns |  0.0552 |     232 B |
   System_Enumerable |          10 |    436.26 ns |    27.159 ns |   1.5345 ns |  0.1960 |     824 B |
   System_Collection |          10 |    476.25 ns |   107.423 ns |   6.0696 ns |  0.1936 |     816 B |
 FastLinq_Collection |          10 |    320.54 ns |    20.134 ns |   1.1376 ns |  0.0930 |     392 B |
   System_Enumerable |        1000 | 30,894.74 ns | 6,072.433 ns | 343.1037 ns | 17.3340 |   73264 B |
   System_Collection |        1000 | 34,712.92 ns | 7,053.229 ns | 398.5205 ns | 17.3340 |   73264 B |
 FastLinq_Collection |        1000 | 24,825.70 ns | 2,124.592 ns | 120.0434 ns |  5.2795 |   22247 B |
     */

    /// <summary>
    /// BCL just makes a dictionary, and then adds via an Enumerable
    /// FastLinq optimizes ICollection
    /// </summary>
    public class ToDictionaryBenchmark
    {
        [Params(0, 1, 10, 1000)] public int SizeOfInput;

        private HashSet<int> collection;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, this.SizeOfInput);
            this.collection = new HashSet<int>(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var _ = Enumerable.ToDictionary(this.enumerable, i => i);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.ToDictionary(this.collection, i => i);
        }

        // Enumerable not implemented by FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.ToDictionary(this.enumerable, i => i);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.ToDictionary(this.collection, i => i);
        }
    }
}
