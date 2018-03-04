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
     *
     *  The added latency of FastLinq_Collection is expected. This is the non-enumeration
     * case and preserving more information requires doing a bit more work.
     *
     *
              Method |      Mean |      Error |    StdDev |  Gen 0 | Allocated |
-------------------- |----------:|-----------:|----------:|-------:|----------:|
   System_Enumerable |  9.235 ns |  3.2408 ns | 0.1831 ns | 0.0152 |      64 B |
   System_Collection |  8.973 ns |  0.7620 ns | 0.0431 ns | 0.0152 |      64 B |
        System_IList |  9.572 ns |  3.4155 ns | 0.1930 ns | 0.0152 |      64 B |
         System_List | 10.143 ns |  1.6365 ns | 0.0925 ns | 0.0152 |      64 B |
        System_Array |  9.501 ns | 10.5293 ns | 0.5949 ns | 0.0152 |      64 B |
 FastLinq_Collection | 18.103 ns |  4.3171 ns | 0.2439 ns | 0.0229 |      96 B |
      FastLinq_IList |  5.324 ns |  3.4383 ns | 0.1943 ns | 0.0057 |      24 B |
       FastLinq_List |  5.069 ns |  5.0425 ns | 0.2849 ns | 0.0057 |      24 B |
      FastLinq_Array |  5.103 ns |  0.6279 ns | 0.0355 ns | 0.0057 |      24 B |
     *
     */

    /// <summary>
    /// <see cref="Enumerable.Reverse{TSource}"/> specially handles T[], ICollection, and falls back to IEnumerable
    /// .
    /// <see cref="FastLinq.Reverse{T}(System.Collections.Generic.IList{T})"/> specially handles IList
    /// </summary>
    public class ReverseBenchmark
    {
        private int[] array;
        private List<int> list;
        // HashSet is ICollection, not IList, and has a struct enumerator
        private HashSet<int> collection;
        // ReadOnlyCollection is IList, but has an object enumerator
        private ReadOnlyCollection<int> ilist;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var _ = Enumerable.Reverse(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.Reverse(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void System_IList()
        {
            var _ = Enumerable.Reverse(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.Reverse(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var _ = Enumerable.Reverse(this.array);
        }





        // Enumerable not implemented by FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.Reverse(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.Reverse(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void FastLinq_IList()
        {
            var _ = FastLinq.Reverse(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var _ = FastLinq.Reverse(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void FastLinq_Array()
        {
            var _ = FastLinq.Reverse(this.array);
        }


        // TODO: Optimal not worth implementing without enumeration
    }
}
