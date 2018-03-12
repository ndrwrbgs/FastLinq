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
     *
     *
                 Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
----------------------- |-----------:|-----------:|----------:|-------:|----------:|
  Enumerable_System_All |  96.315 ns | 18.7589 ns | 1.0599 ns | 0.0113 |      48 B |
 Enumerable_System_Some |  42.088 ns |  3.8882 ns | 0.2197 ns | 0.0114 |      48 B |
 Enumerable_System_None |  25.003 ns |  3.5195 ns | 0.1989 ns | 0.0114 |      48 B |
        7.0*(maches) + 26.4
        

       IList_System_All | 130.919 ns | 20.0015 ns | 1.1301 ns | 0.0093 |      40 B |
     IList_FastLinq_All |  74.551 ns | 15.7126 ns | 0.8878 ns |      - |       0 B |
      IList_System_Some |  46.611 ns | 15.0843 ns | 0.8523 ns | 0.0095 |      40 B |
        10.41*(matches) + 26.62
    IList_FastLinq_Some |  26.611 ns |  4.0361 ns | 0.2280 ns |      - |       0 B |
      IList_System_None |  27.301 ns |  3.1695 ns | 0.1791 ns | 0.0095 |      40 B |
    IList_FastLinq_None |  12.037 ns |  0.8750 ns | 0.0494 ns |      - |       0 B |
        6.17*(maches) + 13

        List_System_All | 128.597 ns | 45.1052 ns | 2.5485 ns | 0.0093 |      40 B |
      List_FastLinq_All |  64.499 ns | 45.3947 ns | 2.5649 ns |      - |       0 B |
       List_System_Some |  43.312 ns |  5.8156 ns | 0.3286 ns | 0.0095 |      40 B |
        10.41*(matches) + 24.2
     List_FastLinq_Some |  20.082 ns | 13.9290 ns | 0.7870 ns |      - |       0 B |
       List_System_None |  25.471 ns |  2.6195 ns | 0.1480 ns | 0.0095 |      40 B |
     List_FastLinq_None |   8.500 ns |  1.5802 ns | 0.0893 ns |      - |       0 B |
        5.56*(matches) + 8.7

       Array_System_All |  88.725 ns |  7.0373 ns | 0.3976 ns | 0.0075 |      32 B |
     Array_FastLinq_All |  66.599 ns |  5.3415 ns | 0.3018 ns |      - |       0 B |
      Array_System_Some |  36.030 ns |  3.3498 ns | 0.1893 ns | 0.0076 |      32 B |
        7*(matches) + 22.5
    Array_FastLinq_Some |  19.337 ns |  2.0757 ns | 0.1173 ns |      - |       0 B |
      Array_System_None |  20.925 ns |  5.9278 ns | 0.3349 ns | 0.0076 |      32 B |
    Array_FastLinq_None |   8.595 ns |  1.1516 ns | 0.0651 ns |      - |       0 B |
        6.1*(matches) + 8.4
     */

    /// <summary>
    /// BCL uses IEnumerable, FastLinq uses IList
    /// </summary>
    public class AllBenchmark
    {
        private int[] array;
        private List<int> list;
        // ReadOnlyCollection is IList, but has an object enumerator
        private ReadOnlyCollection<int> ilist;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("Enumerable", "System")]
        public bool Enumerable_System_All()
        {
            return Enumerable.All(this.enumerable, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Enumerable", "System")]
        public bool Enumerable_System_Some()
        {
            return Enumerable.All(this.enumerable, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Enumerable", "System")]
        public bool Enumerable_System_None()
        {
            return Enumerable.All(this.enumerable, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public bool IList_System_All()
        {
            return Enumerable.All(this.ilist, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public bool IList_System_Some()
        {
            return Enumerable.All(this.ilist, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public bool IList_System_None()
        {
            return Enumerable.All(this.ilist, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public bool List_System_All()
        {
            return Enumerable.All(this.list, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public bool List_System_Some()
        {
            return Enumerable.All(this.list, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public bool List_System_None()
        {
            return Enumerable.All(this.list, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public bool Array_System_All()
        {
            return Enumerable.All(this.array, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public bool Array_System_Some()
        {
            return Enumerable.All(this.array, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public bool Array_System_None()
        {
            return Enumerable.All(this.array, i => false);
        }






        

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public bool IList_FastLinq_All()
        {
            return FastLinq.All(this.ilist, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public bool IList_FastLinq_Some()
        {
            return FastLinq.All(this.ilist, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public bool IList_FastLinq_None()
        {
            return FastLinq.All(this.ilist, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public bool List_FastLinq_All()
        {
            return FastLinq.All(this.list, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public bool List_FastLinq_Some()
        {
            return FastLinq.All(this.list, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public bool List_FastLinq_None()
        {
            return FastLinq.All(this.list, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public bool Array_FastLinq_All()
        {
            return FastLinq.All(this.array, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public bool Array_FastLinq_Some()
        {
            return FastLinq.All(this.array, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public bool Array_FastLinq_None()
        {
            return FastLinq.All(this.array, i => false);
        }
    }
}
