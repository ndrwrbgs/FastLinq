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
     * TODO: FastLinq_Collection is exclusively worse right now
     *
     *
              Method | EnumerateAfterwards |        Mean |       Error |    StdDev |  Gen 0 | Allocated |
-------------------- |-------------------- |------------:|------------:|----------:|-------:|----------:|
   System_Enumerable |               False |  10.4023 ns |   3.0397 ns | 0.1718 ns | 0.0152 |      64 B |
   System_Collection |               False |  10.3071 ns |   3.3213 ns | 0.1877 ns | 0.0152 |      64 B |
        System_IList |               False |  10.4914 ns |   2.0782 ns | 0.1174 ns | 0.0152 |      64 B |
         System_List |               False |  10.3955 ns |   0.8728 ns | 0.0493 ns | 0.0152 |      64 B |
        System_Array |               False |  10.5776 ns |   2.8206 ns | 0.1594 ns | 0.0152 |      64 B |

 FastLinq_Collection |               False |  18.8998 ns |   1.7319 ns | 0.0979 ns | 0.0229 |      96 B |
      FastLinq_IList |               False |   6.7834 ns |   4.7539 ns | 0.2686 ns | 0.0057 |      24 B |
       FastLinq_List |               False |   6.4412 ns |   0.8859 ns | 0.0501 ns | 0.0057 |      24 B |
      FastLinq_Array |               False |   6.5300 ns |   0.6132 ns | 0.0346 ns | 0.0057 |      24 B |

  Optimal_Enumerable |               False |          NA |          NA |        NA |    N/A |       N/A |
  Optimal_Collection |               False |          NA |          NA |        NA |    N/A |       N/A |
       Optimal_IList |               False |   0.3467 ns |   0.1056 ns | 0.0060 ns |      - |       0 B |
        Optimal_List |               False |   0.5163 ns |   0.1061 ns | 0.0060 ns |      - |       0 B |
       Optimal_Array |               False |   0.3980 ns |   0.5423 ns | 0.0306 ns |      - |       0 B |

   System_Enumerable |                True | 245.0424 ns | 108.7868 ns | 6.1467 ns | 0.0701 |     296 B |
   System_Collection |                True | 125.8152 ns |  35.2913 ns | 1.9940 ns | 0.0303 |     128 B |
        System_IList |                True | 140.7914 ns |  44.9456 ns | 2.5395 ns | 0.0303 |     128 B |
         System_List |                True | 140.5048 ns | 118.7165 ns | 6.7077 ns | 0.0303 |     128 B |
        System_Array |                True | 177.5284 ns | 123.7691 ns | 6.9932 ns | 0.0303 |     128 B |

 FastLinq_Collection |                True | 152.1570 ns |  16.7161 ns | 0.9445 ns | 0.0379 |     160 B |
      FastLinq_IList |                True | 130.0861 ns |  42.6976 ns | 2.4125 ns | 0.0055 |      24 B |
       FastLinq_List |                True |  83.8204 ns |  20.2484 ns | 1.1441 ns | 0.0056 |      24 B |
      FastLinq_Array |                True |  87.7939 ns |  17.7009 ns | 1.0001 ns | 0.0056 |      24 B |

  Optimal_Enumerable |                True |          NA |          NA |        NA |    N/A |       N/A |
  Optimal_Collection |                True |          NA |          NA |        NA |    N/A |       N/A |
       Optimal_IList |                True |  33.9781 ns |  15.8636 ns | 0.8963 ns |      - |       0 B |
        Optimal_List |                True |  12.1145 ns |   5.7872 ns | 0.3270 ns |      - |       0 B |
       Optimal_Array |                True |   7.0950 ns |   1.9165 ns | 0.1083 ns |      - |       0 B |
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
        public void System_Enumerable()
        {
            var _ = Enumerable.Reverse(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.Reverse(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void System_IList()
        {
            var _ = Enumerable.Reverse(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.Reverse(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
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

        // TODO: Pending
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void FastLinq_Collection()
        //{
        //    var _ = FastLinq.Reverse(this.collection);

        //    if (this.EnumerateAfterwards)
        //    {
        //        foreach (var item in _) ;
        //    }
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void FastLinq_IList()
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
        public void FastLinq_List()
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
        public void FastLinq_Array()
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
        public void Optimal_Enumerable()
        {
            // TODO:
            // could probably optimize further with an approach like that found in DefaultIfEmptyBenchmark
            // Optimized theoretical would do nearly nothing in the non-enumerate case
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Optimal_Collection()
        {
            // TODO:
            // could probably optimize further with an approach like that found in DefaultIfEmptyBenchmark
            // Optimized theoretical would do nearly nothing in the non-enumerate case
            throw new NotImplementedException();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void Optimal_IList()
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
        public void Optimal_List()
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
        public void Optimal_Array()
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
