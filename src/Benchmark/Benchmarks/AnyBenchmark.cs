using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Collection
{
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /* RESULTS
     *
     * Array[] and List impls are removed, since they only work as the first method today
     * Pending work will address this by wrapping them.
     * Benchmarks of those included here for comparison
     *
              Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
-------------------- |-----------:|----------:|----------:|-------:|----------:|
        System_Array | 13.7806 ns | 1.4208 ns | 0.0803 ns | 0.0076 |      32 B |
         System_List | 17.4251 ns | 0.3125 ns | 0.0177 ns | 0.0095 |      40 B |
   System_Collection | 19.0480 ns | 7.8985 ns | 0.4463 ns | 0.0095 |      40 B |
      FastLinq_Array |  3.2544 ns | 1.5400 ns | 0.0870 ns |      - |       0 B | * ICollection impl
     *FastLinq_Array |  1.1149 ns | 0.7106 ns | 0.0401 ns |      - |       0 B | * Array[] impl
       FastLinq_List |  3.1807 ns | 0.2191 ns | 0.0124 ns |      - |       0 B | * ICollection impl
      *FastLinq_List |  1.2466 ns | 1.1133 ns | 0.0629 ns |      - |       0 B | * List impl
 FastLinq_Collection |  4.7087 ns | 0.6736 ns | 0.0381 ns |      - |       0 B |
       Optimal_Array |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |       0 B | < JIT optimized
        Optimal_List |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |       0 B | < JIT optimized
  Optimal_Collection |  2.0561 ns | 1.5728 ns | 0.0889 ns |      - |       0 B |
     */

    /// <summary>
    /// Enumerable.Any gets an enumerator. This means we expect
    /// types that have a struct enumerator or have optimizations
    /// in the BCL to perform better
    /// .
    /// There are no optimizations around size
    /// </summary>
    public class AnyBenchmark
    {
        private int[] array;
        private List<int> list;
        private ReadOnlyCollection<int> collection;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public bool System_Enumerable()
        {
            return Enumerable.Any(this.enumerable);
        }

        // NOTE: FastLinq does not implement Any for Enumerable

        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public bool Optimal_Enumerable()
        {
            using (var enumerator = this.enumerable.GetEnumerator())
            {
                return enumerator.MoveNext();
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public bool System_Array()
        {
            return Enumerable.Any(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public bool System_List()
        {
            return Enumerable.Any(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public bool System_Collection()
        {
            return Enumerable.Any(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public bool FastLinq_Array()
        {
            return FastLinq.Any(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public bool FastLinq_List()
        {
            return FastLinq.Any(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public bool FastLinq_Collection()
        {
            return FastLinq.Any(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public bool Optimal_Array()
        {
            return this.array.Length > 0;
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public bool Optimal_List()
        {
            return this.list.Count > 0;
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public bool Optimal_Collection()
        {
            return this.collection.Count > 0;
        }
    }
}
