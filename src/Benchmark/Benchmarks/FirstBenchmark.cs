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
            Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
------------------ |-----------:|-----------:|----------:|-------:|----------:|
    Array_FastLinq |  5.9220 ns |  0.3545 ns | 0.0200 ns |      - |       0 B |
     Array_Optimal |  0.0000 ns |  0.0000 ns | 0.0000 ns |      - |       0 B |
      Array_System | 30.8196 ns |  7.9123 ns | 0.4471 ns |      - |       0 B |

 Collection_System | 32.6562 ns | 19.9903 ns | 1.1295 ns | 0.0095 |      40 B |
 Enumerable_System | 29.0500 ns |  9.0051 ns | 0.5088 ns | 0.0114 |      48 B |

    IList_FastLinq |  9.2755 ns |  4.0314 ns | 0.2278 ns |      - |       0 B |
     IList_Optimal |  2.4384 ns |  0.0902 ns | 0.0051 ns |      - |       0 B |
      IList_System | 11.5500 ns |  4.3098 ns | 0.2435 ns |      - |       0 B |

     List_FastLinq |  5.6014 ns |  0.9020 ns | 0.0510 ns |      - |       0 B |
      List_Optimal |  0.6222 ns |  0.6949 ns | 0.0393 ns |      - |       0 B |
       List_System |  8.1241 ns |  2.1128 ns | 0.1194 ns |      - |       0 B |
     */
    public class FirstBenchmark
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
        public void Enumerable_System()
        {
            var _ = Enumerable.First(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.First(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.First(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.First(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.First(this.array);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.First(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.First(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.First(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.First(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.First(this.array);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.First(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.First(this.collection);
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
