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
   Enumerable_System |               False |  10.4023 ns |   3.0397 ns | 0.1718 ns | 0.0152 |      64 B |
  Enumerable_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
   Enumerable_System |                True | 245.0424 ns | 108.7868 ns | 6.1467 ns | 0.0701 |     296 B |
  Enumerable_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |

   Collection_System |               False |  10.3071 ns |   3.3213 ns | 0.1877 ns | 0.0152 |      64 B |
 Collection_FastLinq |               False |  18.8998 ns |   1.7319 ns | 0.0979 ns | 0.0229 |      96 B |
  Collection_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
   Collection_System |                True | 125.8152 ns |  35.2913 ns | 1.9940 ns | 0.0303 |     128 B |
 Collection_FastLinq |                True | 152.1570 ns |  16.7161 ns | 0.9445 ns | 0.0379 |     160 B |
  Collection_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |

        IList_System |               False |  10.4914 ns |   2.0782 ns | 0.1174 ns | 0.0152 |      64 B |
      IList_FastLinq |               False |   6.7834 ns |   4.7539 ns | 0.2686 ns | 0.0057 |      24 B |
       IList_Optimal |               False |   0.3467 ns |   0.1056 ns | 0.0060 ns |      - |       0 B |
        IList_System |                True | 140.7914 ns |  44.9456 ns | 2.5395 ns | 0.0303 |     128 B |
      IList_FastLinq |                True | 130.0861 ns |  42.6976 ns | 2.4125 ns | 0.0055 |      24 B |
       IList_Optimal |                True |  33.9781 ns |  15.8636 ns | 0.8963 ns |      - |       0 B |

         List_System |               False |  10.3955 ns |   0.8728 ns | 0.0493 ns | 0.0152 |      64 B |
       List_FastLinq |               False |   6.4412 ns |   0.8859 ns | 0.0501 ns | 0.0057 |      24 B |
        List_Optimal |               False |   0.5163 ns |   0.1061 ns | 0.0060 ns |      - |       0 B |
         List_System |                True | 140.5048 ns | 118.7165 ns | 6.7077 ns | 0.0303 |     128 B |
       List_FastLinq |                True |  83.8204 ns |  20.2484 ns | 1.1441 ns | 0.0056 |      24 B |
        List_Optimal |                True |  12.1145 ns |   5.7872 ns | 0.3270 ns |      - |       0 B |

        Array_System |               False |  10.5776 ns |   2.8206 ns | 0.1594 ns | 0.0152 |      64 B |
      Array_FastLinq |               False |   6.5300 ns |   0.6132 ns | 0.0346 ns | 0.0057 |      24 B |
       Array_Optimal |               False |   0.3980 ns |   0.5423 ns | 0.0306 ns |      - |       0 B |
        Array_System |                True | 177.5284 ns | 123.7691 ns | 6.9932 ns | 0.0303 |     128 B |
      Array_FastLinq |                True |  87.7939 ns |  17.7009 ns | 1.0001 ns | 0.0056 |      24 B |
       Array_Optimal |                True |   7.0950 ns |   1.9165 ns | 0.1083 ns |      - |       0 B |

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
                var length = _.Count;
                for (int i = 0; i < length; i++)
                {
                    var item = _[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.Reverse(this.list);

            if (this.EnumerateAfterwards)
            {
                var length = _.Count;
                for (int i = 0; i < length; i++)
                {
                    var item = _[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.Reverse(this.array);

            if (this.EnumerateAfterwards)
            {
                var length = _.Count;
                for (int i = 0; i < length; i++)
                {
                    var item = _[i];
                }
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
