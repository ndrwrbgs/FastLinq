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
   System_Enumerable | 19.7539 ns | 9.3771 ns | 0.5298 ns | 0.0114 |      48 B |
  Optimal_Enumerable | 17.6235 ns | 0.3254 ns | 0.0184 ns | 0.0114 |      48 B |

        System_Array | 14.9774 ns | 1.5518 ns | 0.0877 ns | 0.0076 |      32 B |
      FastLinq_Array |  3.5408 ns | 1.0875 ns | 0.0614 ns |      - |       0 B |
       Optimal_Array |  0.0105 ns | 0.0420 ns | 0.0024 ns |      - |       0 B |

         System_List | 17.9975 ns | 1.5755 ns | 0.0890 ns | 0.0095 |      40 B |
       FastLinq_List |  3.7935 ns | 4.9809 ns | 0.2814 ns |      - |       0 B |
        Optimal_List |  0.1389 ns | 4.1395 ns | 0.2339 ns |      - |       0 B |

   System_Collection | 19.4652 ns | 3.4085 ns | 0.1926 ns | 0.0095 |      40 B |
 FastLinq_Collection |  3.4876 ns | 0.1320 ns | 0.0075 ns |      - |       0 B |
  Optimal_Collection |  0.0000 ns | 0.0000 ns | 0.0000 ns |      - |       0 B |

        System_IList | 19.5201 ns | 3.8279 ns | 0.2163 ns | 0.0095 |      40 B |
      FastLinq_IList |  5.5374 ns | 1.1636 ns | 0.0657 ns |      - |       0 B |
       Optimal_IList |  2.2295 ns | 0.4013 ns | 0.0227 ns |      - |       0 B |


Strongly typed potential:  
     *FastLinq_Array |  1.1149 ns | 0.7106 ns | 0.0401 ns |      - |       0 B | * Array[] impl
      *FastLinq_List |  1.2466 ns | 1.1133 ns | 0.0629 ns |      - |       0 B | * List impl
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
        [BenchmarkCategory("System", "IList")]
        public bool System_IList()
        {
            return Enumerable.Any(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public bool FastLinq_IList()
        {
            return FastLinq.Any(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public bool Optimal_IList()
        {
            return this.ilist.Count > 0;
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
