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
            Method | SizeOfInput |          Mean |       Error |     StdDev |  Gen 0 | Allocated |
------------------ |------------ |--------------:|------------:|-----------:|-------:|----------:|
    Array_FastLinq |           0 |     3.8857 ns |   0.8845 ns |  0.0500 ns |      - |       0 B |
      Array_System |           0 |    29.5666 ns |  12.1735 ns |  0.6878 ns |      - |       0 B |

 Collection_System |           0 |    30.3699 ns |  12.7360 ns |  0.7196 ns | 0.0095 |      40 B |
 Enumerable_System |           0 |    27.4478 ns |   4.1181 ns |  0.2327 ns | 0.0114 |      48 B |

    IList_FastLinq |           0 |     5.8073 ns |   2.0966 ns |  0.1185 ns |      - |       0 B |
      IList_System |           0 |     8.0774 ns |   2.3579 ns |  0.1332 ns |      - |       0 B |

     List_FastLinq |           0 |     3.9073 ns |   0.4196 ns |  0.0237 ns |      - |       0 B |
       List_System |           0 |     5.8919 ns |   2.8879 ns |  0.1632 ns |      - |       0 B |


    Array_FastLinq |          10 |     6.6284 ns |   0.3755 ns |  0.0212 ns |      - |       0 B |
     Array_Optimal |          10 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
      Array_System |          10 |    32.1709 ns |  24.3418 ns |  1.3754 ns |      - |       0 B |

 Collection_System |          10 |   145.9413 ns |  27.5198 ns |  1.5549 ns | 0.0093 |      40 B |
 Enumerable_System |          10 |    88.8811 ns |  41.2796 ns |  2.3324 ns | 0.0113 |      48 B |

    IList_FastLinq |          10 |    10.2221 ns |   5.0905 ns |  0.2876 ns |      - |       0 B |
     IList_Optimal |          10 |     2.6038 ns |   0.5865 ns |  0.0331 ns |      - |       0 B |
      IList_System |          10 |    12.6960 ns |   1.8035 ns |  0.1019 ns |      - |       0 B |

     List_FastLinq |          10 |     6.6573 ns |   1.4950 ns |  0.0845 ns |      - |       0 B |
      List_Optimal |          10 |     0.6315 ns |   1.4481 ns |  0.0818 ns |      - |       0 B |
       List_System |          10 |     8.7706 ns |   0.3691 ns |  0.0209 ns |      - |       0 B |


    Array_FastLinq |         100 |     6.8980 ns |   5.9138 ns |  0.3341 ns |      - |       0 B |
     Array_Optimal |         100 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
      Array_System |         100 |    31.6090 ns |  10.3476 ns |  0.5847 ns |      - |       0 B |

 Collection_System |         100 | 1,109.2456 ns | 573.8515 ns | 32.4237 ns | 0.0076 |      40 B |
 Enumerable_System |         100 |   610.9531 ns | 275.0794 ns | 15.5425 ns | 0.0105 |      48 B |

    IList_FastLinq |         100 |    10.0860 ns |   2.5571 ns |  0.1445 ns |      - |       0 B |
     IList_Optimal |         100 |     2.6492 ns |   3.2040 ns |  0.1810 ns |      - |       0 B |
      IList_System |         100 |    13.4733 ns |   4.1687 ns |  0.2355 ns |      - |       0 B |

     List_FastLinq |         100 |     6.4194 ns |   8.2699 ns |  0.4673 ns |      - |       0 B |
      List_Optimal |         100 |     0.6032 ns |   0.8173 ns |  0.0462 ns |      - |       0 B |
       List_System |         100 |     8.2385 ns |   4.9239 ns |  0.2782 ns |      - |       0 B |
     */
    /// <summary>
    /// BCL optimizes <see cref="IList{T}"/>
    /// FastLinq only accepts <see cref="IReadOnlyList{T}"/>
    /// </summary>
    public class LastOrDefaultBenchmark
    {
        [Params(0, 10, 100)] public int SizeOfInput;

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
            this.enumerable = Enumerable.Range(0, this.SizeOfInput);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.LastOrDefault(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.LastOrDefault(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.LastOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.LastOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.LastOrDefault(this.array);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.LastOrDefault(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.LastOrDefault(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.LastOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.LastOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.LastOrDefault(this.array);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.LastOrDefault(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.LastOrDefault(this.collection);
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
