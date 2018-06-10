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
              Method | EnumerateAfterwards |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
-------------------- |-------------------- |------------:|------------:|-----------:|-------:|----------:|
      Array_FastLinq |               False |  21.8587 ns |  14.6251 ns |  0.8263 ns | 0.0248 |     104 B |
        Array_System |               False |  25.5308 ns |   5.2119 ns |  0.2945 ns | 0.0381 |     160 B |

 Collection_FastLinq |               False |  39.2455 ns |   8.6869 ns |  0.4908 ns | 0.0457 |     192 B |
   Collection_System |               False |  26.5947 ns |  14.9681 ns |  0.8457 ns | 0.0381 |     160 B |

   Enumerable_System |               False |  25.9749 ns |  18.3976 ns |  1.0395 ns | 0.0381 |     160 B |

       List_FastLinq |               False |  19.3810 ns |   6.4793 ns |  0.3661 ns | 0.0248 |     104 B |
         List_System |               False |  25.7567 ns |   5.3586 ns |  0.3028 ns | 0.0381 |     160 B |

      Array_FastLinq |                True | 242.6555 ns |  96.8320 ns |  5.4712 ns | 0.0358 |     152 B |
       Array_Optimal |                True |   5.1286 ns |   1.6221 ns |  0.0917 ns |      - |       0 B |
        Array_System |                True | 298.7849 ns |   9.8949 ns |  0.5591 ns | 0.0529 |     224 B |

 Collection_FastLinq |                True | 425.1573 ns | 494.8287 ns | 27.9587 ns | 0.0644 |     272 B |
  Collection_Optimal |                True |  94.6849 ns |  10.0629 ns |  0.5686 ns |      - |       0 B |
   Collection_System |                True | 414.1860 ns |  57.8575 ns |  3.2691 ns | 0.0567 |     240 B |

  Enumerable_Optimal |                True | 181.1744 ns |  30.3436 ns |  1.7145 ns | 0.0226 |      96 B |
   Enumerable_System |                True | 320.2579 ns | 100.9610 ns |  5.7045 ns | 0.0606 |     256 B |

       List_FastLinq |                True | 242.7638 ns |  96.0144 ns |  5.4250 ns | 0.0358 |     152 B |
        List_Optimal |                True |  24.1503 ns |   8.6846 ns |  0.4907 ns |      - |       0 B |
         List_System |                True | 385.3970 ns | 150.7987 ns |  8.5204 ns | 0.0567 |     240 B |
     */

    /// <summary>
    /// <see cref="Enumerable.Zip{TFirst,TSecond,TResult}"/> just uses IEnumerable
    ///
    /// <see cref="FastLinq.Zip{TFirst,TSecond,TResult}"/> only handles collections
    /// </summary>
    public class ZipBenchmark
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
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var Zip = Enumerable.Zip(this.enumerable, this.enumerable, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var Zip = Enumerable.Zip(this.collection, this.collection, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var Zip = Enumerable.Zip(this.list, this.list, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var Zip = Enumerable.Zip(this.array, this.array, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }





        // Not implemented for FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var Zip = FastLinq.Zip(this.enumerable, this.enumerable, ZipAggregator);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void Collection_FastLinq()
        {
            var Zip = FastLinq.Zip(this.collection, this.collection, ZipAggregator);
            
            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var Zip = FastLinq.Zip(this.list, this.list, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var Zip = FastLinq.Zip(this.array, this.array, ZipAggregator);

            if (EnumerateAfterwards)
            {
                foreach (var item in Zip) ;
            }
        }



        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            if (this.EnumerateAfterwards)
            {
                using (var firstEnumerator = this.enumerable.GetEnumerator())
                {
                    using (var secondEnumerator = this.enumerable.GetEnumerator())
                    {
                        while (firstEnumerator.MoveNext()
                               && secondEnumerator.MoveNext())
                        {
                            var _ = ZipAggregator(
                                firstEnumerator.Current,
                                secondEnumerator.Current);
                        }
                    }
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            if (this.EnumerateAfterwards)
            {
                using (var firstEnumerator = this.collection.GetEnumerator())
                {
                    using (var secondEnumerator = this.collection.GetEnumerator())
                    {
                        while (firstEnumerator.MoveNext()
                               && secondEnumerator.MoveNext())
                        {
                            var _ = ZipAggregator(
                                firstEnumerator.Current,
                                secondEnumerator.Current);
                        }
                    }
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            if (this.EnumerateAfterwards)
            {
                var end = Math.Min(this.list.Count, this.list.Count);
                for (int i = 0; i < end; i++)
                {
                    var _ = ZipAggregator(this.list[i], this.list[i]);
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            if (this.EnumerateAfterwards)
            {
                var end = Math.Min(this.array.Length, this.array.Length);
                for (int i = 0; i < end; i++)
                {
                    var _ = ZipAggregator(this.array[i], this.array[i]);
                }
            }
        }

        private static double ZipAggregator(int one, int two)
        {
            return one + two;
        }
    }
}
