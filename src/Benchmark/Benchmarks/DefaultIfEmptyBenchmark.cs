using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Benchmark.Collection
{
    using System.Collections;

    /*
     * 
              Method | EnumerateAfterwards | InputLength |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
-------------------- |-------------------- |------------ |------------:|------------:|-----------:|-------:|----------:|
   System_Enumerable |               False |           0 |  12.5489 ns |   1.6550 ns |  0.0935 ns | 0.0152 |      64 B |
         System_List |               False |           0 |  12.9782 ns |   8.9452 ns |  0.5054 ns | 0.0152 |      64 B |
        System_IList |               False |           0 |  13.3086 ns |   6.8510 ns |  0.3871 ns | 0.0152 |      64 B |
        System_Array |               False |           0 |  14.8826 ns |  25.9634 ns |  1.4670 ns | 0.0152 |      64 B |
   System_Collection |               False |           0 |  13.3305 ns |   8.6455 ns |  0.4885 ns | 0.0152 |      64 B |

       FastLinq_List |               False |           0 |   8.7261 ns |   5.0882 ns |  0.2875 ns | 0.0076 |      32 B |
      FastLinq_IList |               False |           0 |  10.1927 ns |   5.4256 ns |  0.3066 ns | 0.0076 |      32 B |
      FastLinq_Array |               False |           0 |   8.0458 ns |   0.9344 ns |  0.0528 ns | 0.0076 |      32 B |
 FastLinq_Collection |               False |           0 |   7.7969 ns |   3.0828 ns |  0.1742 ns | 0.0076 |      32 B |

  Optimal_Enumerable |               False |           0 |   0.3338 ns |   0.8992 ns |  0.0508 ns |      - |       0 B |
        Optimal_List |               False |           0 |   1.3250 ns |   0.2273 ns |  0.0128 ns |      - |       0 B |
       Optimal_IList |               False |           0 |   3.6252 ns |   1.3467 ns |  0.0761 ns |      - |       0 B |
       Optimal_Array |               False |           0 |   0.6059 ns |   0.3844 ns |  0.0217 ns |      - |       0 B |
  Optimal_Collection |               False |           0 |   1.4220 ns |   1.0457 ns |  0.0591 ns |      - |       0 B |

   System_Enumerable |               False |          10 |  12.6622 ns |   2.9298 ns |  0.1655 ns | 0.0152 |      64 B |
         System_List |               False |          10 |  12.5524 ns |   3.1417 ns |  0.1775 ns | 0.0152 |      64 B |
        System_IList |               False |          10 |  13.0030 ns |   7.8303 ns |  0.4424 ns | 0.0152 |      64 B |
        System_Array |               False |          10 |  14.5893 ns |   7.2142 ns |  0.4076 ns | 0.0152 |      64 B |
   System_Collection |               False |          10 |  14.4041 ns |   4.7956 ns |  0.2710 ns | 0.0152 |      64 B |

       FastLinq_List |               False |          10 |   4.8174 ns |   2.2276 ns |  0.1259 ns |      - |       0 B |
      FastLinq_IList |               False |          10 |   6.7647 ns |   1.5745 ns |  0.0890 ns |      - |       0 B |
      FastLinq_Array |               False |          10 |   4.7707 ns |   0.9627 ns |  0.0544 ns |      - |       0 B |
 FastLinq_Collection |               False |          10 |   4.8859 ns |   1.9763 ns |  0.1117 ns |      - |       0 B |

  Optimal_Enumerable |               False |          10 |   0.1186 ns |   0.5631 ns |  0.0318 ns |      - |       0 B |
        Optimal_List |               False |          10 |   1.3360 ns |   0.4382 ns |  0.0248 ns |      - |       0 B |
       Optimal_IList |               False |          10 |   3.7130 ns |   1.2282 ns |  0.0694 ns |      - |       0 B |
       Optimal_Array |               False |          10 |   1.0468 ns |   0.5855 ns |  0.0331 ns |      - |       0 B |
  Optimal_Collection |               False |          10 |   1.4180 ns |   0.2396 ns |  0.0135 ns |      - |       0 B |

   System_Enumerable |                True |           0 |  56.8834 ns |  65.5621 ns |  3.7044 ns | 0.0266 |     112 B |
         System_List |                True |           0 |  60.9884 ns |  22.8238 ns |  1.2896 ns | 0.0247 |     104 B |
        System_IList |                True |           0 |  62.7523 ns |  76.4752 ns |  4.3210 ns | 0.0247 |     104 B |
        System_Array |                True |           0 |  54.0862 ns |  15.0445 ns |  0.8500 ns | 0.0152 |      64 B |
   System_Collection |                True |           0 |  57.6705 ns |  45.9210 ns |  2.5946 ns | 0.0247 |     104 B |

       FastLinq_List |                True |           0 |  14.6975 ns |  12.9976 ns |  0.7344 ns | 0.0076 |      32 B |
      FastLinq_IList |                True |           0 |  17.8223 ns |   7.4039 ns |  0.4183 ns | 0.0076 |      32 B |
      FastLinq_Array |                True |           0 |  12.1801 ns |   1.4066 ns |  0.0795 ns | 0.0076 |      32 B |
 FastLinq_Collection |                True |           0 |  28.1168 ns |   6.0600 ns |  0.3424 ns | 0.0152 |      64 B |

  Optimal_Enumerable |                True |           0 |  19.6933 ns |   6.3086 ns |  0.3564 ns | 0.0114 |      48 B |
        Optimal_List |                True |           0 |   1.6380 ns |   1.6214 ns |  0.0916 ns |      - |       0 B |
       Optimal_IList |                True |           0 |   9.4445 ns |   0.8392 ns |  0.0474 ns |      - |       0 B |
       Optimal_Array |                True |           0 |   1.4032 ns |   1.8500 ns |  0.1045 ns |      - |       0 B |
  Optimal_Collection |                True |           0 |  23.8572 ns |  15.5072 ns |  0.8762 ns | 0.0076 |      32 B |

   System_Enumerable |                True |          10 | 213.2053 ns | 155.0757 ns |  8.7621 ns | 0.0265 |     112 B |
         System_List |                True |          10 | 219.9381 ns | 238.2292 ns | 13.4604 ns | 0.0246 |     104 B |
        System_IList |                True |          10 | 215.4726 ns |  17.9148 ns |  1.0122 ns | 0.0246 |     104 B |
        System_Array |                True |          10 | 193.8226 ns |  38.2815 ns |  2.1630 ns | 0.0226 |      96 B |
   System_Collection |                True |          10 | 241.4553 ns | 200.2534 ns | 11.3147 ns | 0.0243 |     104 B |

       FastLinq_List |                True |          10 |  35.2858 ns |   6.4945 ns |  0.3670 ns |      - |       0 B |
      FastLinq_IList |                True |          10 |  63.6370 ns |  13.9053 ns |  0.7857 ns |      - |       0 B |
      FastLinq_Array |                True |          10 |  47.7762 ns |  33.1721 ns |  1.8743 ns |      - |       0 B |
 FastLinq_Collection |                True |          10 | 135.2044 ns |  14.9017 ns |  0.8420 ns | 0.0093 |      40 B |

  Optimal_Enumerable |                True |          10 |  73.5289 ns |  28.2432 ns |  1.5958 ns | 0.0113 |      48 B |
        Optimal_List |                True |          10 |  11.4560 ns |   4.0641 ns |  0.2296 ns |      - |       0 B |
       Optimal_IList |                True |          10 |  62.0657 ns |  24.8728 ns |  1.4054 ns |      - |       0 B |
       Optimal_Array |                True |          10 |   8.6061 ns |   2.3467 ns |  0.1326 ns |      - |       0 B |
  Optimal_Collection |                True |          10 | 125.8494 ns |  71.0979 ns |  4.0172 ns | 0.0093 |      40 B |
     */

    /// <summary>
    /// Enumerable.DefaultIfEmpty gets an enumerator.
    /// So Test Array, List, ICollection and IEnumerable
    /// .
    /// FastLinq behaves differently if there are no items
    /// </summary>
    public class DefaultIfEmptyBenchmark
    {
        // Only needed because of the lazy Optimal_Enumerable type's optimizations
        [Params(true, false)] public bool EnumerateAfterwards;

        [Params(0, 10)] public int InputLength;

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
            this.enumerable = Enumerable.Range(0, this.InputLength);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var _ = Enumerable.DefaultIfEmpty(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.DefaultIfEmpty(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void System_IList()
        {
            var _ = Enumerable.DefaultIfEmpty(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var _ = Enumerable.DefaultIfEmpty(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.DefaultIfEmpty(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.DefaultIfEmpty(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var _ = FastLinq.DefaultIfEmpty(this.list);

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
        [BenchmarkCategory("FastLinq", "IList")]
        public void FastLinq_IList()
        {
            var _ = FastLinq.DefaultIfEmpty(this.ilist);

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
            var _ = FastLinq.DefaultIfEmpty(this.array);

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
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.DefaultIfEmpty(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }
        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Optimal_Enumerable()
        {
            // System is pretty close to optimal for IEnumerable, good enough for now
            var _ = new DefaultOrEmptyEnumerable<int>(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        private struct DefaultOrEmptyEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> source;

            public DefaultOrEmptyEnumerable(IEnumerable<T> source)
            {
                this.source = source;
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return this.source.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable) this.source).GetEnumerator();
            }

            public struct Enumerator : IEnumerator<T>
            {
                private IEnumerator<T> enumerator;
                private bool hasAny;

                // TODO: Can be less memory if Current is a method instead of a property, how does that affect perf?
                public Enumerator(IEnumerable<T> source)
                {
                    this.Current = default(T);
                    this.enumerator = source.GetEnumerator();
                    this.hasAny = false;
                }

                public void Dispose()
                {
                    this.enumerator.Dispose();
                }

                // TODO: Should probably test this
                public bool MoveNext()
                {
                    bool moveNext = this.enumerator.MoveNext();
                    if (moveNext)
                    {
                        this.Current = this.enumerator.Current;
                        this.hasAny = true;
                        return true;
                    }
                    else
                    {
                        if (!this.hasAny)
                        {
                            this.Current = default(T);
                            this.hasAny = true;
                            return false;
                        }

                        this.Current = default(T);
                        return false;
                    }
                }

                public void Reset()
                {
                    this.Current = default(T);
                    this.enumerator.Reset();
                    this.hasAny = false;
                }

                public T Current { get; private set; }

                object IEnumerator.Current => this.Current;
            }

            private IEnumerable<T> GetEnumerable()
            {
                using (var enumerator = this.source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        do
                        {
                            yield return enumerator.Current;
                        } while (enumerator.MoveNext());
                    }
                    else
                    {
                        yield return default(T);
                    }
                }
            }
        }

        // TODO: For proper test, should be copy-on-write
        private static readonly List<int> DefaultList = new List<int>(1) { default(int) };

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void Optimal_List()
        {
            List<int> _;
            if (this.list.Count > 0)
            {
                _ = this.list;
            }
            else
            {
                _ = DefaultList;
            }

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
        [BenchmarkCategory("Optimal", "IList")]
        public void Optimal_IList()
        {
            IList<int> _;
            if (this.ilist.Count > 0)
            {
                _ = this.ilist;
            }
            else
            {
                _ = DefaultArray;
            }

            if (this.EnumerateAfterwards)
            {
                var length = _.Count;
                for (int i = 0; i < length; i++)
                {
                    var item = _[i];
                }
            }
        }

        private static readonly int[] DefaultArray = new int[1] { default(int) };

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Optimal_Array()
        {
            int[] _;
            if (this.array.Length > 0)
            {
                _ = this.array;
            }
            else
            {
                _ = DefaultArray;
            }

            if (this.EnumerateAfterwards)
            {
                var length = _.Length;
                for (int i = 0; i < length; i++)
                {
                    var item = _[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Optimal_Collection()
        {
            ICollection<int> _;
            if (this.collection.Count > 0)
            {
                _ = this.collection;
            }
            else
            {
                _ = DefaultArray;
            }

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }
    }
}
