using System.Collections.Generic;
using System.Linq;

namespace Benchmark.Benchmarks
{
    using System;
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /*
     * TODO: Collection_FastLinq is worse - not meant to be faster alone but allows us to stay in the ICollection interface
     *
     * 
                  Method | EnumerateAfterwards |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
------------------------ |-------------------- |------------:|------------:|-----------:|-------:|----------:|
       Enumerable_System |               False |  13.8531 ns |   7.6531 ns |  0.4324 ns | 0.0171 |      72 B |
      Enumerable_Optimal |               False |   0.8169 ns |   0.5360 ns |  0.0303 ns |      - |       0 B |

       Enumerable_System |                True | 404.1512 ns | 370.9796 ns | 20.9610 ns | 0.0401 |     168 B |
      Enumerable_Optimal |                True | 153.9279 ns |  28.9223 ns |  1.6342 ns | 0.0226 |      96 B |


       Collection_System |               False |  14.1781 ns |   3.7421 ns |  0.2114 ns | 0.0171 |      72 B |
     Collection_FastLinq |               False |  28.3557 ns |  22.0482 ns |  1.2458 ns | 0.0247 |     104 B |
      Collection_Optimal |               False |  10.3005 ns |   0.9645 ns |  0.0545 ns |      - |       0 B |

       Collection_System |                True | 489.9000 ns | 363.5197 ns | 20.5395 ns | 0.0362 |     152 B |
     Collection_FastLinq |                True | 493.7783 ns | 145.6884 ns |  8.2317 ns | 0.0429 |     184 B |
      Collection_Optimal |                True |  80.9507 ns |   6.1558 ns |  0.3478 ns |      - |       0 B |


   CollectionList_System |               False |  13.8261 ns |   5.8454 ns |  0.3303 ns | 0.0171 |      72 B |
 CollectionList_FastLinq |               False |  27.1457 ns |  26.6151 ns |  1.5038 ns | 0.0247 |     104 B |
  CollectionList_Optimal |               False |  10.4806 ns |   0.7217 ns |  0.0408 ns |      - |       0 B |

   CollectionList_System |                True | 433.2741 ns | 184.5974 ns | 10.4301 ns | 0.0362 |     152 B |
 CollectionList_FastLinq |                True | 451.3501 ns | 290.2735 ns | 16.4010 ns | 0.0434 |     184 B |
  CollectionList_Optimal |                True |  54.3423 ns |  17.5528 ns |  0.9918 ns |      - |       0 B |


   ListCollection_System |               False |  13.6549 ns |   8.0486 ns |  0.4548 ns | 0.0171 |      72 B |
 ListCollection_FastLinq |               False |  28.0917 ns |  20.5107 ns |  1.1589 ns | 0.0247 |     104 B |
  ListCollection_Optimal |               False |   9.9016 ns |   1.7115 ns |  0.0967 ns |      - |       0 B |

   ListCollection_System |                True | 422.8167 ns |  50.3091 ns |  2.8426 ns | 0.0362 |     152 B |
 ListCollection_FastLinq |                True | 505.0638 ns |  54.8945 ns |  3.1016 ns | 0.0434 |     184 B |
  ListCollection_Optimal |                True |  54.1247 ns |  22.5877 ns |  1.2762 ns |      - |       0 B |


             List_System |               False |  13.6497 ns |   3.8314 ns |  0.2165 ns | 0.0171 |      72 B |
           List_FastLinq |               False |   9.7044 ns |   3.9397 ns |  0.2226 ns | 0.0076 |      32 B |
            List_Optimal |               False |   0.6208 ns |   2.1544 ns |  0.1217 ns |      - |       0 B |

             List_System |                True | 441.1774 ns | 353.3933 ns | 19.9674 ns | 0.0362 |     152 B |
           List_FastLinq |                True | 212.2858 ns |  83.4322 ns |  4.7141 ns | 0.0074 |      32 B |
            List_Optimal |                True |  18.7904 ns |   8.2715 ns |  0.4674 ns |      - |       0 B |


            IList_System |               False |  14.0431 ns |   5.8969 ns |  0.3332 ns | 0.0171 |      72 B |
          IList_FastLinq |               False |   9.3813 ns |   4.8397 ns |  0.2735 ns | 0.0076 |      32 B |
           IList_Optimal |               False |   0.5302 ns |   0.1910 ns |  0.0108 ns |      - |       0 B |

            IList_System |                True | 409.2205 ns |  27.0639 ns |  1.5292 ns | 0.0362 |     152 B |
          IList_FastLinq |                True | 317.3828 ns | 235.1893 ns | 13.2886 ns | 0.0072 |      32 B |
           IList_Optimal |                True |  62.3989 ns |  23.3150 ns |  1.3173 ns |      - |       0 B |


            Array_System |               False |  13.6173 ns |   6.2241 ns |  0.3517 ns | 0.0171 |      72 B |
          Array_FastLinq |               False |   9.2286 ns |   2.5248 ns |  0.1427 ns | 0.0076 |      32 B |
           Array_Optimal |               False |   0.3518 ns |   1.3517 ns |  0.0764 ns |      - |       0 B |

            Array_System |                True | 400.9441 ns |  39.4488 ns |  2.2289 ns | 0.0319 |     136 B |
          Array_FastLinq |                True | 205.7276 ns | 108.8946 ns |  6.1527 ns | 0.0074 |      32 B |
           Array_Optimal |                True |  11.2031 ns |   1.2035 ns |  0.0680 ns |      - |       0 B |
           
     */

    /// <summary>
    /// Enumerable.Concat just uses IEnumerator, so List, Array, IEnumerable
    /// 
    /// FastLinq optimizes ICollection and IList+IList
    /// </summary>
    public class ConcatBenchmark
    {
        /// <summary>
        /// Probably best to isolate the testing of the enumeration to the underlying class
        /// but since I'm here right now and thinking about the implementation of ICollection+IList,
        /// adding the test here
        /// </summary>
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
            var concat = Enumerable.Concat(this.enumerable, this.enumerable);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var concat = Enumerable.Concat(this.collection, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void CollectionList_System()
        {
            var concat = Enumerable.Concat(this.collection, this.list);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void ListCollection_System()
        {
            var concat = Enumerable.Concat(this.list, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var concat = Enumerable.Concat(this.list, this.list);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var concat = Enumerable.Concat(this.ilist, this.ilist);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var concat = Enumerable.Concat(this.array, this.array);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }





        // Not implemented for FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var concat = FastLinq.Concat(this.enumerable, this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void Collection_FastLinq()
        {
            var concat = FastLinq.Concat(this.collection, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void CollectionList_FastLinq()
        {
            var concat = FastLinq.Concat(this.collection, this.list);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void ListCollection_FastLinq()
        {
            var concat = FastLinq.Concat(this.list, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var concat = FastLinq.Concat(this.ilist, this.ilist);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var concat = FastLinq.Concat(this.list, this.list);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var concat = FastLinq.Concat(this.array, this.array);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }



        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            var first = this.enumerable;
            var second = this.enumerable;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;
                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            var first = this.collection;
            var second = this.collection;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;
                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var first = this.ilist;
            var second = this.ilist;

            if (this.EnumerateAfterwards)
            {
                var firstCount = first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                var secondCount = second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection", "List")]
        public void CollectionList_Optimal()
        {
            var first = this.collection;
            var second = this.list;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;

                var secondCount = second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection", "List")]
        public void ListCollection_Optimal()
        {
            var first = this.list;
            var second = this.collection;

            if (this.EnumerateAfterwards)
            {
                var firstCount = first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var first = this.list;
            var second = this.list;

            if (EnumerateAfterwards)
            {
                var firstCount = first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                var secondCount = second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            var first = this.array;
            var second = this.array;

            if (EnumerateAfterwards)
            {
                var firstCount = first.Length;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                var secondCount = second.Length;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }
    }
}
