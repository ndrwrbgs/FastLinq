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
           
              Method | EnumerateAfterwards |       Mean |      Error |     StdDev |  Gen 0 | Allocated |
-------------------- |-------------------- |-----------:|-----------:|-----------:|-------:|----------:|
      Array_FastLinq |               False |  48.455 ns |  56.519 ns |  3.1934 ns | 0.0457 |     192 B |
        Array_System |               False |  28.673 ns |   7.082 ns |  0.4002 ns | 0.0381 |     160 B |

 Collection_FastLinq |               False |  49.847 ns |  17.141 ns |  0.9685 ns | 0.0457 |     192 B |
   Collection_System |               False |  27.293 ns |   8.098 ns |  0.4575 ns | 0.0381 |     160 B |

   Enumerable_System |               False |  26.992 ns |  23.033 ns |  1.3014 ns | 0.0381 |     160 B |

       List_FastLinq |               False |  42.184 ns |   8.016 ns |  0.4529 ns | 0.0457 |     192 B |
         List_System |               False |  27.323 ns |   8.900 ns |  0.5029 ns | 0.0381 |     160 B |


      Array_FastLinq |                True | 344.202 ns | 223.769 ns | 12.6434 ns | 0.0606 |     256 B |
       Array_Optimal |                True |   6.544 ns |   3.436 ns |  0.1941 ns |      - |       0 B |
        Array_System |                True | 330.602 ns | 187.118 ns | 10.5725 ns | 0.0529 |     224 B |

 Collection_FastLinq |                True | 439.463 ns |  52.993 ns |  2.9942 ns | 0.0644 |     272 B |
  Collection_Optimal |                True |  94.496 ns |  13.320 ns |  0.7526 ns |      - |       0 B |
   Collection_System |                True | 455.892 ns | 501.172 ns | 28.3172 ns | 0.0567 |     240 B |

  Enumerable_Optimal |                True | 202.422 ns | 172.803 ns |  9.7637 ns | 0.0226 |      96 B |
   Enumerable_System |                True | 372.010 ns | 505.457 ns | 28.5592 ns | 0.0606 |     256 B |

       List_FastLinq |                True | 406.709 ns |  74.256 ns |  4.1956 ns | 0.0644 |     272 B |
        List_Optimal |                True |  25.073 ns |  14.648 ns |  0.8277 ns |      - |       0 B |
         List_System |                True | 376.699 ns | 155.722 ns |  8.7986 ns | 0.0567 |     240 B |
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
