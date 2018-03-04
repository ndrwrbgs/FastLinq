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
              Method | InputSize |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
-------------------- |---------- |-----------:|-----------:|----------:|-------:|----------:|
   System_Enumerable |         0 |  44.007 ns |  0.8675 ns | 0.0490 ns | 0.0172 |      72 B |
         System_List |         0 |  25.582 ns |  0.9213 ns | 0.0521 ns | 0.0057 |      24 B |
        System_IList |         0 |  27.521 ns |  3.8648 ns | 0.2184 ns | 0.0057 |      24 B |
        System_Array |         0 |  48.849 ns |  3.6630 ns | 0.2070 ns | 0.0057 |      24 B |
   System_Collection |         0 |  24.310 ns |  6.1613 ns | 0.3481 ns | 0.0057 |      24 B |

       FastLinq_List |         0 |  15.445 ns |  0.5014 ns | 0.0283 ns | 0.0057 |      24 B |
      FastLinq_IList |         0 |  18.989 ns |  1.5803 ns | 0.0893 ns | 0.0057 |      24 B |
      FastLinq_Array |         0 |  18.010 ns |  2.6272 ns | 0.1484 ns | 0.0057 |      24 B |
 FastLinq_Collection |         0 |  10.446 ns |  0.6638 ns | 0.0375 ns | 0.0057 |      24 B |

  Optimal_Enumerable |         0 |  44.169 ns |  5.8122 ns | 0.3284 ns | 0.0172 |      72 B |
        Optimal_List |         0 |  10.719 ns |  0.6816 ns | 0.0385 ns | 0.0057 |      24 B |
       Optimal_IList |         0 |  15.111 ns |  1.4850 ns | 0.0839 ns | 0.0057 |      24 B |
       Optimal_Array |         0 |  10.909 ns |  3.3887 ns | 0.1915 ns | 0.0057 |      24 B |
  Optimal_Collection |         0 |   6.503 ns |  1.5092 ns | 0.0853 ns | 0.0057 |      24 B |

   System_Enumerable |         2 |  72.461 ns |  5.4312 ns | 0.3069 ns | 0.0285 |     120 B |
         System_List |         2 |  38.285 ns |  5.6190 ns | 0.3175 ns | 0.0076 |      32 B |
        System_IList |         2 |  43.195 ns | 21.7884 ns | 1.2311 ns | 0.0076 |      32 B |
        System_Array |         2 |  65.359 ns |  6.1968 ns | 0.3501 ns | 0.0075 |      32 B |
   System_Collection |         2 |  32.253 ns |  5.6065 ns | 0.3168 ns | 0.0076 |      32 B |

       FastLinq_List |         2 |  18.716 ns |  0.9515 ns | 0.0538 ns | 0.0076 |      32 B |
      FastLinq_IList |         2 |  22.055 ns | 10.9649 ns | 0.6195 ns | 0.0076 |      32 B |
      FastLinq_Array |         2 |  21.377 ns |  6.0607 ns | 0.3424 ns | 0.0076 |      32 B |
 FastLinq_Collection |         2 |  13.999 ns |  1.5651 ns | 0.0884 ns | 0.0076 |      32 B |

  Optimal_Enumerable |         2 |  71.736 ns |  6.1611 ns | 0.3481 ns | 0.0285 |     120 B |
        Optimal_List |         2 |  14.592 ns |  4.2471 ns | 0.2400 ns | 0.0076 |      32 B |
       Optimal_IList |         2 |  18.073 ns |  1.2161 ns | 0.0687 ns | 0.0076 |      32 B |
       Optimal_Array |         2 |  14.073 ns |  2.0312 ns | 0.1148 ns | 0.0076 |      32 B |
  Optimal_Collection |         2 |   9.990 ns |  2.8442 ns | 0.1607 ns | 0.0076 |      32 B |

   System_Enumerable |        10 | 181.784 ns | 21.9832 ns | 1.2421 ns | 0.0703 |     296 B |
         System_List |        10 |  50.707 ns |  6.2693 ns | 0.3542 ns | 0.0152 |      64 B |
        System_IList |        10 |  52.689 ns |  6.2819 ns | 0.3549 ns | 0.0152 |      64 B |
        System_Array |        10 |  76.434 ns |  4.5352 ns | 0.2562 ns | 0.0151 |      64 B |
   System_Collection |        10 |  57.239 ns |  9.7128 ns | 0.5488 ns | 0.0151 |      64 B |

       FastLinq_List |        10 |  38.488 ns | 48.7421 ns | 2.7540 ns | 0.0152 |      64 B |
      FastLinq_IList |        10 |  40.266 ns | 53.8318 ns | 3.0416 ns | 0.0152 |      64 B |
      FastLinq_Array |        10 |  34.226 ns |  6.0829 ns | 0.3437 ns | 0.0152 |      64 B |
 FastLinq_Collection |        10 |  29.089 ns |  8.0901 ns | 0.4571 ns | 0.0152 |      64 B |

  Optimal_Enumerable |        10 | 181.446 ns | 23.5724 ns | 1.3319 ns | 0.0703 |     296 B |
        Optimal_List |        10 |  26.365 ns |  2.3986 ns | 0.1355 ns | 0.0152 |      64 B |
       Optimal_IList |        10 |  30.628 ns |  6.2932 ns | 0.3556 ns | 0.0152 |      64 B |
       Optimal_Array |        10 |  26.419 ns |  0.6017 ns | 0.0340 ns | 0.0152 |      64 B |
  Optimal_Collection |        10 |  24.873 ns |  2.4088 ns | 0.1361 ns | 0.0152 |      64 B |
     */


    /// <summary>
    /// Enumerable.ToArray optimizes Array, ICollection, and falls back to Enumerable
    /// </summary>
    public class ToArrayBenchmark
    {
        [Params(0, 2, 10)] public int InputSize;

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
            this.enumerable = Enumerable.Range(0, this.InputSize);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
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
        [BenchmarkCategory("System", "IList")]
        public void System_IList()
        {
            var _ = Enumerable.ToArray(this.ilist);
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
        [BenchmarkCategory("FastLinq", "IList")]
        public void FastLinq_IList()
        {
            var _ = FastLinq.ToArray(this.ilist);
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

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void Optimal_IList()
        {
            int[] _ = new int[this.ilist.Count];
            this.ilist.CopyTo(_, 0);
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
