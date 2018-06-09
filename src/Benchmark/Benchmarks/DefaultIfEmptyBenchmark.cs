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
      Array_FastLinq |               False |           0 |   9.7592 ns |   8.6037 ns |  0.4861 ns | 0.0076 |      32 B |
       Array_Optimal |               False |           0 |   0.7057 ns |   0.4901 ns |  0.0277 ns |      - |       0 B |
        Array_System |               False |           0 |  14.7740 ns |   4.0725 ns |  0.2301 ns | 0.0152 |      64 B |

 Collection_FastLinq |               False |           0 |   8.5978 ns |   1.6100 ns |  0.0910 ns | 0.0076 |      32 B |
  Collection_Optimal |               False |           0 |   0.7336 ns |   0.7168 ns |  0.0405 ns |      - |       0 B |
   Collection_System |               False |           0 |  15.4322 ns |  17.0460 ns |  0.9631 ns | 0.0152 |      64 B |

  Enumerable_Optimal |               False |           0 |   0.3367 ns |   0.7259 ns |  0.0410 ns |      - |       0 B |
   Enumerable_System |               False |           0 |  14.8862 ns |  16.1536 ns |  0.9127 ns | 0.0152 |      64 B |

      IList_FastLinq |               False |           0 |  10.4649 ns |   4.5943 ns |  0.2596 ns | 0.0076 |      32 B |
       IList_Optimal |               False |           0 |   3.3809 ns |   1.8106 ns |  0.1023 ns |      - |       0 B |
        IList_System |               False |           0 |  14.5683 ns |   4.3351 ns |  0.2449 ns | 0.0152 |      64 B |

       List_FastLinq |               False |           0 |   8.7346 ns |   3.5473 ns |  0.2004 ns | 0.0076 |      32 B |
        List_Optimal |               False |           0 |  11.5193 ns |   2.5751 ns |  0.1455 ns |      - |       0 B |
         List_System |               False |           0 |  14.7623 ns |  21.0090 ns |  1.1870 ns | 0.0152 |      64 B |


      Array_FastLinq |               False |          10 |   4.6649 ns |   4.8826 ns |  0.2759 ns |      - |       0 B |
       Array_Optimal |               False |          10 |   0.7437 ns |   0.4570 ns |  0.0258 ns |      - |       0 B |
        Array_System |               False |          10 |  14.6940 ns |   4.8973 ns |  0.2767 ns | 0.0152 |      64 B |

 Collection_FastLinq |               False |          10 |   4.5541 ns |   1.0967 ns |  0.0620 ns |      - |       0 B |
  Collection_Optimal |               False |          10 |   0.7019 ns |   0.9723 ns |  0.0549 ns |      - |       0 B |
   Collection_System |               False |          10 |  14.5742 ns |   8.6961 ns |  0.4913 ns | 0.0152 |      64 B |

  Enumerable_Optimal |               False |          10 |   0.2687 ns |   0.2688 ns |  0.0152 ns |      - |       0 B |
   Enumerable_System |               False |          10 |  14.0284 ns |   1.9217 ns |  0.1086 ns | 0.0152 |      64 B |

      IList_FastLinq |               False |          10 |   6.4787 ns |   2.7131 ns |  0.1533 ns |      - |       0 B |
       IList_Optimal |               False |          10 |   2.8537 ns |   0.9565 ns |  0.0540 ns |      - |       0 B |
        IList_System |               False |          10 |  14.5189 ns |   6.4031 ns |  0.3618 ns | 0.0152 |      64 B |

       List_FastLinq |               False |          10 |   4.5578 ns |   1.4143 ns |  0.0799 ns |      - |       0 B |
        List_Optimal |               False |          10 |  11.6070 ns |   3.8171 ns |  0.2157 ns |      - |       0 B |
         List_System |               False |          10 |  14.7615 ns |   4.6213 ns |  0.2611 ns | 0.0152 |      64 B |


      Array_FastLinq |                True |           0 |  30.6067 ns |   9.1635 ns |  0.5178 ns | 0.0152 |      64 B |
       Array_Optimal |                True |           0 |   0.3508 ns |   0.3917 ns |  0.0221 ns |      - |       0 B |
        Array_System |                True |           0 |  57.9924 ns |  37.0305 ns |  2.0923 ns | 0.0151 |      64 B |

 Collection_FastLinq |                True |           0 |  28.0783 ns |   5.5848 ns |  0.3156 ns | 0.0152 |      64 B |
  Collection_Optimal |                True |           0 |  22.9991 ns |   5.7982 ns |  0.3276 ns | 0.0076 |      32 B |
   Collection_System |                True |           0 |  61.9298 ns |  29.6365 ns |  1.6745 ns | 0.0247 |     104 B |

  Enumerable_Optimal |                True |           0 |  21.0441 ns |  10.8552 ns |  0.6133 ns | 0.0114 |      48 B |
   Enumerable_System |                True |           0 |  63.5000 ns |  27.3632 ns |  1.5461 ns | 0.0266 |     112 B |

      IList_FastLinq |                True |           0 |  30.1538 ns |  11.9435 ns |  0.6748 ns | 0.0152 |      64 B |
       IList_Optimal |                True |           0 |  23.6997 ns |   4.7555 ns |  0.2687 ns | 0.0076 |      32 B |
        IList_System |                True |           0 |  63.2599 ns |  12.2351 ns |  0.6913 ns | 0.0247 |     104 B |

       List_FastLinq |                True |           0 |  29.5773 ns |  21.1187 ns |  1.1932 ns | 0.0152 |      64 B |
        List_Optimal |                True |           0 |  16.0919 ns |   5.0370 ns |  0.2846 ns |      - |       0 B |
         List_System |                True |           0 |  61.7598 ns |  14.7019 ns |  0.8307 ns | 0.0247 |     104 B |


      Array_FastLinq |                True |          10 |  88.7186 ns |  40.8949 ns |  2.3106 ns | 0.0075 |      32 B |
       Array_Optimal |                True |          10 |   4.7436 ns |   2.4440 ns |  0.1381 ns |      - |       0 B |
        Array_System |                True |          10 | 212.6165 ns | 231.5976 ns | 13.0857 ns | 0.0226 |      96 B |

 Collection_FastLinq |                True |          10 | 146.5642 ns |  80.6573 ns |  4.5573 ns | 0.0093 |      40 B |
  Collection_Optimal |                True |          10 | 135.1920 ns |  16.5806 ns |  0.9368 ns | 0.0093 |      40 B |
   Collection_System |                True |          10 | 258.6162 ns | 131.9950 ns |  7.4580 ns | 0.0243 |     104 B |

  Enumerable_Optimal |                True |          10 |  81.6963 ns |  34.4836 ns |  1.9484 ns | 0.0113 |      48 B |
   Enumerable_System |                True |          10 | 218.5005 ns |  91.9473 ns |  5.1952 ns | 0.0265 |     112 B |

      IList_FastLinq |                True |          10 | 123.1094 ns |  18.3319 ns |  1.0358 ns | 0.0093 |      40 B |
       IList_Optimal |                True |          10 | 138.2999 ns | 126.0854 ns |  7.1241 ns | 0.0093 |      40 B |
        IList_System |                True |          10 | 234.9248 ns |  95.2472 ns |  5.3816 ns | 0.0246 |     104 B |

       List_FastLinq |                True |          10 | 120.3226 ns |  11.8126 ns |  0.6674 ns | 0.0093 |      40 B |
        List_Optimal |                True |          10 |  36.9859 ns |   1.2998 ns |  0.0734 ns |      - |       0 B |
         List_System |                True |          10 | 233.3961 ns | 136.6453 ns |  7.7207 ns | 0.0246 |     104 B |


     */

    /// <summary>
    /// Enumerable.DefaultIfEmpty gets an enumerator.
    /// So Test Array, List, ICollection and IEnumerable
    /// .
    /// FastLinq behaves differently if there are no items
    /// </summary>
    public class DefaultIfEmptyBenchmark
    {
        // Only needed because of the lazy Enumerable_Optimal type's optimizations
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
        public void Enumerable_System()
        {
            var _ = Enumerable.DefaultIfEmpty(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.DefaultIfEmpty(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.DefaultIfEmpty(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.DefaultIfEmpty(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
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
        public void List_FastLinq()
        {
            var _ = FastLinq.DefaultIfEmpty(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.DefaultIfEmpty(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.DefaultIfEmpty(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void Collection_FastLinq()
        {
            var _ = FastLinq.DefaultIfEmpty(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }
        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
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
        public void List_Optimal()
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
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
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
                foreach (var __ in _) ;
            }
        }

        private static readonly int[] DefaultArray = new int[1] { default(int) };

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
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
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
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
