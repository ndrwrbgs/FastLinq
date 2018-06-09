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
     * TODO: Collection_FastLinq is worse - not meant to be faster alone but allows us to stay in the ICollection interface
     *
     *
              Method | EnumerateAfterwards |        Mean |       Error |    StdDev |  Gen 0 | Allocated |
-------------------- |-------------------- |------------:|------------:|----------:|-------:|----------:|
      Array_FastLinq |               False |   9.8161 ns |   2.9665 ns | 0.1676 ns | 0.0057 |      24 B |
       Array_Optimal |               False |   0.3111 ns |   0.1624 ns | 0.0092 ns |      - |       0 B |
        Array_System |               False |  14.1074 ns |   0.5684 ns | 0.0321 ns | 0.0152 |      64 B |

 Collection_FastLinq |               False |  23.7612 ns |   8.1960 ns | 0.4631 ns | 0.0229 |      96 B |
  Collection_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
   Collection_System |               False |  14.3760 ns |   5.0603 ns | 0.2859 ns | 0.0152 |      64 B |

  Enumerable_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
   Enumerable_System |               False |  14.1952 ns |   8.9952 ns | 0.5082 ns | 0.0152 |      64 B |

      IList_FastLinq |               False |   9.2317 ns |   6.6637 ns | 0.3765 ns | 0.0057 |      24 B |
       IList_Optimal |               False |   0.7194 ns |   1.1814 ns | 0.0668 ns |      - |       0 B |
        IList_System |               False |  14.2978 ns |   8.8880 ns | 0.5022 ns | 0.0152 |      64 B |

       List_FastLinq |               False |   8.7528 ns |   1.1154 ns | 0.0630 ns | 0.0057 |      24 B |
        List_Optimal |               False |   0.6375 ns |   0.6379 ns | 0.0360 ns |      - |       0 B |
         List_System |               False |  14.0248 ns |   2.6882 ns | 0.1519 ns | 0.0152 |      64 B |


      Array_FastLinq |                True | 147.4212 ns |  25.4948 ns | 1.4405 ns | 0.0150 |      64 B |
       Array_Optimal |                True |   5.5987 ns |   1.1732 ns | 0.0663 ns |      - |       0 B |
        Array_System |                True | 181.0404 ns |  46.1988 ns | 2.6103 ns | 0.0303 |     128 B |

 Collection_FastLinq |                True | 161.7787 ns |  96.2341 ns | 5.4374 ns | 0.0379 |     160 B |
  Collection_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |
   Collection_System |                True | 140.4907 ns |  38.2562 ns | 2.1615 ns | 0.0303 |     128 B |

  Enumerable_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |
   Enumerable_System |                True | 277.3531 ns | 102.9282 ns | 5.8156 ns | 0.0701 |     296 B |

      IList_FastLinq |                True | 167.5476 ns |  28.6078 ns | 1.6164 ns | 0.0150 |      64 B |
       IList_Optimal |                True |  45.9394 ns |  76.7305 ns | 4.3354 ns |      - |       0 B |
        IList_System |                True | 150.1909 ns |  39.5882 ns | 2.2368 ns | 0.0303 |     128 B |

       List_FastLinq |                True | 150.2385 ns |  91.8654 ns | 5.1906 ns | 0.0150 |      64 B |
        List_Optimal |                True |  13.5159 ns |   3.1870 ns | 0.1801 ns |      - |       0 B |
         List_System |                True | 140.7028 ns |  32.6095 ns | 1.8425 ns | 0.0303 |     128 B |

     *
     */

    /// <summary>
    /// <see cref="Enumerable.Reverse{TSource}"/> specially handles T[], ICollection, and falls back to IEnumerable
    /// .
    /// <see cref="FastLinq.Reverse{T}(System.Collections.Generic.IList{T})"/> specially handles IList
    /// </summary>
    public class ReverseBenchmark
    {
        [Params(true, false)] public bool EnumerateAfterwards;

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
            var _ = Enumerable.Reverse(this.enumerable);
            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.Reverse(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.Reverse(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.Reverse(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.Reverse(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
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
        public void Collection_FastLinq()
        {
            var _ = FastLinq.Reverse(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.Reverse(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.Reverse(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.Reverse(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }


        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            // TODO:
            // could probably optimize further with an approach like that found in DefaultIfEmptyBenchmark
            // Optimized theoretical would do nearly nothing in the non-enumerate case
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            // TODO:
            // could probably optimize further with an approach like that found in DefaultIfEmptyBenchmark
            // Optimized theoretical would do nearly nothing in the non-enumerate case
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.ilist.Count;
                for (int i = length - 1; i >= 0; i--)
                {
                    var item = this.ilist[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.list.Count;
                for (int i = length - 1; i >= 0; i--)
                {
                    var item = this.list[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.array.Length;
                for (int i = length - 1; i >= 0; i--)
                {
                    var item = this.array[i];
                }
            }
        }
    }
}
