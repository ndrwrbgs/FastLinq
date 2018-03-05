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
                  Method |      Mean |      Error |    StdDev |  Gen 0 | Allocated |
------------------------ |----------:|-----------:|----------:|-------:|----------:|
        Array_System_All |  87.88 ns |   6.258 ns | 0.3536 ns | 0.0075 |      32 B |
      Array_FastLinq_All |  55.25 ns |  11.646 ns | 0.6580 ns |      - |       0 B |
       Array_System_None |  94.53 ns |   2.684 ns | 0.1517 ns | 0.0075 |      32 B |
     Array_FastLinq_None |  66.15 ns |   5.686 ns | 0.3213 ns |      - |       0 B |
       Array_System_Some | 101.80 ns | 111.867 ns | 6.3207 ns | 0.0075 |      32 B |
     Array_FastLinq_Some |  56.89 ns |   9.285 ns | 0.5246 ns |      - |       0 B |
       
   Enumerable_System_All |  93.22 ns |  10.162 ns | 0.5742 ns | 0.0113 |      48 B |
  Enumerable_System_None | 106.59 ns |  21.047 ns | 1.1892 ns | 0.0113 |      48 B |
  Enumerable_System_Some | 103.93 ns |  96.672 ns | 5.4621 ns | 0.0113 |      48 B |
  
        IList_System_All | 127.64 ns |  27.564 ns | 1.5574 ns | 0.0093 |      40 B |
      IList_FastLinq_All |  72.45 ns |   9.916 ns | 0.5603 ns |      - |       0 B |
       IList_System_None | 129.86 ns |  17.593 ns | 0.9940 ns | 0.0093 |      40 B |
     IList_FastLinq_None |  82.36 ns |  16.603 ns | 0.9381 ns |      - |       0 B |
       IList_System_Some | 135.26 ns |  35.130 ns | 1.9849 ns | 0.0093 |      40 B |
     IList_FastLinq_Some |  78.06 ns |   2.670 ns | 0.1509 ns |      - |       0 B |
     
         List_System_All | 135.48 ns |  41.207 ns | 2.3283 ns | 0.0093 |      40 B |
       List_FastLinq_All |  58.76 ns |   1.241 ns | 0.0701 ns |      - |       0 B |
        List_System_None | 134.07 ns |  55.056 ns | 3.1107 ns | 0.0093 |      40 B |
      List_FastLinq_None |  69.51 ns |   6.308 ns | 0.3564 ns |      - |       0 B |
        List_System_Some | 138.21 ns | 147.153 ns | 8.3144 ns | 0.0093 |      40 B |
      List_FastLinq_Some |  64.57 ns |  21.024 ns | 1.1879 ns |      - |       0 B |
     */

    /// <summary>
    /// BCL uses IEnumerable, FastLinq uses IList
    /// </summary>
    public class CountBenchmark
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
        public int Enumerable_System_All()
        {
            return Enumerable.Count(this.enumerable, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Enumerable", "System")]
        public int Enumerable_System_Some()
        {
            return Enumerable.Count(this.enumerable, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Enumerable", "System")]
        public int Enumerable_System_None()
        {
            return Enumerable.Count(this.enumerable, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public int IList_System_All()
        {
            return Enumerable.Count(this.ilist, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public int IList_System_Some()
        {
            return Enumerable.Count(this.ilist, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "System")]
        public int IList_System_None()
        {
            return Enumerable.Count(this.ilist, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public int List_System_All()
        {
            return Enumerable.Count(this.list, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public int List_System_Some()
        {
            return Enumerable.Count(this.list, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("List", "System")]
        public int List_System_None()
        {
            return Enumerable.Count(this.list, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public int Array_System_All()
        {
            return Enumerable.Count(this.array, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public int Array_System_Some()
        {
            return Enumerable.Count(this.array, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "System")]
        public int Array_System_None()
        {
            return Enumerable.Count(this.array, i => false);
        }






        

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public int IList_FastLinq_All()
        {
            return FastLinq.Count(this.ilist, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public int IList_FastLinq_Some()
        {
            return FastLinq.Count(this.ilist, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("IList", "FastLinq")]
        public int IList_FastLinq_None()
        {
            return FastLinq.Count(this.ilist, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public int List_FastLinq_All()
        {
            return FastLinq.Count(this.list, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public int List_FastLinq_Some()
        {
            return FastLinq.Count(this.list, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("List", "FastLinq")]
        public int List_FastLinq_None()
        {
            return FastLinq.Count(this.list, i => false);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public int Array_FastLinq_All()
        {
            return FastLinq.Count(this.array, i => true);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public int Array_FastLinq_Some()
        {
            return FastLinq.Count(this.array, i => i < 2);
        }

        [Benchmark]
        [BenchmarkCategory("Array", "FastLinq")]
        public int Array_FastLinq_None()
        {
            return FastLinq.Count(this.array, i => false);
        }
    }
}
