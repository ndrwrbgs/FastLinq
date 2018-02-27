using System.Collections.Generic;
using System.Linq;

namespace Benchmark.Benchmarks
{
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /// <summary>
    /// Enumerable.Concat just uses IEnumerator, so List, Array, IEnumerable
    /// 
    /// FastLinq optimizes ICollection and IList+IList
    /// </summary>
    public class ConcatBenchmark
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
        public void System_Enumerable()
        {
            var _ = Enumerable.Concat(this.enumerable, this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.Concat(this.collection, this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void System_CollectionList()
        {
            var _ = Enumerable.Concat(this.collection, this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void System_ListCollection()
        {
            var _ = Enumerable.Concat(this.list, this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.Concat(this.list, this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var _ = Enumerable.Concat(this.array, this.array);
        }





        // Not implemented for FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.Concat(this.enumerable, this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.Concat(this.collection, this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void FastLinq_CollectionList()
        {
            var _ = FastLinq.Concat(this.collection, this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void FastLinq_ListCollection()
        {
            var _ = FastLinq.Concat(this.list, this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var _ = FastLinq.Concat(this.list, this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void FastLinq_Array()
        {
            var _ = FastLinq.Concat(this.array, this.array);
        }



        // TODO: Tests regarding iteration
    }
}
