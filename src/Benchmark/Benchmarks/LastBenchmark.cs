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
            Method | SizeOfInput |          Mean |       Error |     StdDev |  Gen 0 | Allocated |
------------------ |------------ |--------------:|------------:|-----------:|-------:|----------:|
    Array_FastLinq |           1 |     6.1887 ns |   2.3918 ns |  0.1351 ns |      - |       0 B |
     Array_Optimal |           1 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
      Array_System |           1 |    31.7198 ns |  25.4003 ns |  1.4352 ns |      - |       0 B |

 Collection_System |           1 |    39.0971 ns |  14.6710 ns |  0.8289 ns | 0.0095 |      40 B |
 Enumerable_System |           1 |    35.9142 ns |   3.6370 ns |  0.2055 ns | 0.0114 |      48 B |

    IList_FastLinq |           1 |    10.0588 ns |   6.1762 ns |  0.3490 ns |      - |       0 B |
     IList_Optimal |           1 |     2.6255 ns |   0.3476 ns |  0.0196 ns |      - |       0 B |
      IList_System |           1 |    12.6381 ns |   8.4321 ns |  0.4764 ns |      - |       0 B |

     List_FastLinq |           1 |     6.2121 ns |   3.4564 ns |  0.1953 ns |      - |       0 B |
      List_Optimal |           1 |     0.6462 ns |   0.8116 ns |  0.0459 ns |      - |       0 B |
       List_System |           1 |     8.1161 ns |   5.6599 ns |  0.3198 ns |      - |       0 B |

    Array_FastLinq |          10 |     6.4521 ns |   2.1622 ns |  0.1222 ns |      - |       0 B |
     Array_Optimal |          10 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
      Array_System |          10 |    31.7134 ns |  12.4735 ns |  0.7048 ns |      - |       0 B |

 Collection_System |          10 |   145.6444 ns |  29.5708 ns |  1.6708 ns | 0.0093 |      40 B |
 Enumerable_System |          10 |    89.9560 ns |  78.2585 ns |  4.4218 ns | 0.0113 |      48 B |

    IList_FastLinq |          10 |    10.3721 ns |   7.7606 ns |  0.4385 ns |      - |       0 B |
     IList_Optimal |          10 |     2.7249 ns |   1.2406 ns |  0.0701 ns |      - |       0 B |
      IList_System |          10 |    12.3113 ns |   1.7228 ns |  0.0973 ns |      - |       0 B |

     List_FastLinq |          10 |     5.8708 ns |   1.5400 ns |  0.0870 ns |      - |       0 B |
      List_Optimal |          10 |     0.6686 ns |   1.3174 ns |  0.0744 ns |      - |       0 B |
       List_System |          10 |     8.3254 ns |   3.2903 ns |  0.1859 ns |      - |       0 B |

    Array_FastLinq |         100 |     6.6391 ns |   1.9385 ns |  0.1095 ns |      - |       0 B |
     Array_Optimal |         100 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
      Array_System |         100 |    31.5305 ns |  20.3124 ns |  1.1477 ns |      - |       0 B |

 Collection_System |         100 | 1,073.5330 ns | 229.5793 ns | 12.9717 ns | 0.0076 |      40 B |
 Enumerable_System |         100 |   602.4403 ns |  86.9625 ns |  4.9135 ns | 0.0105 |      48 B |

    IList_FastLinq |         100 |     9.6009 ns |   2.3517 ns |  0.1329 ns |      - |       0 B |
     IList_Optimal |         100 |     2.6295 ns |   0.4131 ns |  0.0233 ns |      - |       0 B |
      IList_System |         100 |    12.3120 ns |   3.0411 ns |  0.1718 ns |      - |       0 B |

     List_FastLinq |         100 |     6.1794 ns |   5.2296 ns |  0.2955 ns |      - |       0 B |
      List_Optimal |         100 |     0.5830 ns |   0.3311 ns |  0.0187 ns |      - |       0 B |
       List_System |         100 |     7.6921 ns |   3.0604 ns |  0.1729 ns |      - |       0 B |
     */

    /// <summary>
    /// BCL optimizes <see cref="IList{T}"/>
    /// FastLinq only accepts <see cref="IReadOnlyList{T}"/>
    /// </summary>
    public class LastBenchmark
    {
        [Params(1, 10, 100)] public int SizeOfInput;
        
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
            this.enumerable = Enumerable.Range(0, SizeOfInput);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.Last(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.Last(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.Last(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.Last(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.Last(this.array);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.Last(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.Last(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.Last(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.Last(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.Last(this.array);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.Last(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.Last(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var _ = this.ilist[0];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var _ = this.list[0];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            var _ = this.array[0];
        }
    }
}
