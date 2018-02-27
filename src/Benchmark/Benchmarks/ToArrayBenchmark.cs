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
     * @ size = 10
         Method |     Mean |    Error |    StdDev |  Gen 0 | Allocated |
--------------- |---------:|---------:|----------:|-------:|----------:|
   System_Array | 78.11 ns | 5.508 ns | 0.3112 ns | 0.0151 |      64 B |
 FastLinq_Array | 33.72 ns | 5.411 ns | 0.3057 ns | 0.0152 |      64 B |
  Optimal_Array | 26.37 ns | 1.693 ns | 0.0957 ns | 0.0152 |      64 B |
     */


    /// <summary>
    /// Enumerable.ToArray optimizes Array, ICollection, and falls back to Enumerable
    /// </summary>
    public class ToArrayBenchmark
    {
        [Params(0, 2, 10)] public int InputSize;

        private int[] array;
        private List<int> list;
        private ReadOnlyCollection<int> collection;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, this.InputSize);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var _ = Enumerable.ToArray(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.ToArray(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var _ = Enumerable.ToArray(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.ToArray(this.collection);
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.ToArray(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var _ = FastLinq.ToArray(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void FastLinq_Array()
        {
            var _ = FastLinq.ToArray(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.ToArray(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Optimal_Enumerable()
        {
            // System is pretty close to optimal for IEnumerable, good enough for now
            System_Enumerable();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void Optimal_List()
        {
            int[] _ = new int[this.list.Count];
            this.list.CopyTo(_, 0);
        }

        private static readonly int[] DefaultArray = new int[1] { default(int) };

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Optimal_Array()
        {
            int[] _ = new int[this.array.Length];
            this.list.CopyTo(_, 0);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Optimal_Collection()
        {
            int[] _ = new int[this.collection.Count];
            this.collection.CopyTo(_, 0);
        }
    }
}
