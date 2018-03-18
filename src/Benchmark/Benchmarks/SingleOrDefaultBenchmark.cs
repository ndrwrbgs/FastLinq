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
            Method | HasAny |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
------------------ |------- |-----------:|-----------:|----------:|-------:|----------:|
    Array_FastLinq |  False |  3.5967 ns |  0.3359 ns | 0.0190 ns |      - |       0 B |
     Array_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
      Array_System |  False | 27.6127 ns |  1.5557 ns | 0.0879 ns |      - |       0 B |
 Collection_System |  False | 29.4083 ns |  5.7786 ns | 0.3265 ns | 0.0095 |      40 B |
 Enumerable_System |  False | 26.1367 ns | 10.1251 ns | 0.5721 ns | 0.0114 |      48 B |
    IList_FastLinq |  False |  5.3702 ns |  0.8012 ns | 0.0453 ns |      - |       0 B |
     IList_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
      IList_System |  False |  8.0901 ns |  3.8251 ns | 0.2161 ns |      - |       0 B |
     List_FastLinq |  False |  3.5794 ns |  1.8754 ns | 0.1060 ns |      - |       0 B |
      List_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
       List_System |  False |  6.3053 ns |  0.9930 ns | 0.0561 ns |      - |       0 B |
    Array_FastLinq |   True |  6.1103 ns |  2.1494 ns | 0.1214 ns |      - |       0 B |
     Array_Optimal |   True |  0.1357 ns |  0.6642 ns | 0.0375 ns |      - |       0 B |
      Array_System |   True | 30.0653 ns |  7.5179 ns | 0.4248 ns |      - |       0 B |
 Collection_System |   True | 38.0938 ns |  0.8362 ns | 0.0472 ns | 0.0095 |      40 B |
 Enumerable_System |   True | 34.0055 ns | 23.5945 ns | 1.3331 ns | 0.0114 |      48 B |
    IList_FastLinq |   True |  9.2071 ns |  1.2783 ns | 0.0722 ns |      - |       0 B |
     IList_Optimal |   True |  2.8094 ns |  3.3399 ns | 0.1887 ns |      - |       0 B |
      IList_System |   True | 13.6689 ns | 12.8757 ns | 0.7275 ns |      - |       0 B |
     List_FastLinq |   True |  5.6761 ns |  3.0811 ns | 0.1741 ns |      - |       0 B |
      List_Optimal |   True |  0.7386 ns |  0.8877 ns | 0.0502 ns |      - |       0 B |
       List_System |   True |  8.9761 ns |  2.4567 ns | 0.1388 ns |      - |       0 B |
     */
    /// <summary>
    /// BCL optimizes <see cref="IList{T}"/>
    /// FastLinq only accepts <see cref="IReadOnlyList{T}"/>
    /// </summary>
    public class SingleOrDefaultBenchmark
    {
        [Params(true, false)] public bool HasAny;

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
            this.enumerable = Enumerable.Range(0, this.HasAny ? 1 : 0);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.SingleOrDefault(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.SingleOrDefault(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.SingleOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.SingleOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.SingleOrDefault(this.array);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.SingleOrDefault(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.SingleOrDefault(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.SingleOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.SingleOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.SingleOrDefault(this.array);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.SingleOrDefault(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.SingleOrDefault(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var _ = this.ilist[0];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var _ = this.list[0];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            var _ = this.array[0];
        }
    }
}
