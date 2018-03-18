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
            Method | SizeOfInput | ElementToRequest |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
------------------ |------------ |----------------- |-----------:|-----------:|----------:|-------:|----------:|
    Array_FastLinq |          10 |                0 |  3.2944 ns |  0.3564 ns | 0.0201 ns |      - |       0 B |
     Array_Optimal |          10 |                0 |  0.0118 ns |  0.3615 ns | 0.0204 ns |      - |       0 B |
      Array_System |          10 |                0 | 26.4505 ns |  2.9885 ns | 0.1689 ns |      - |       0 B |

 Collection_System |          10 |                0 | 31.2954 ns |  2.4819 ns | 0.1402 ns | 0.0095 |      40 B |
 Enumerable_System |          10 |                0 | 26.9855 ns |  4.1030 ns | 0.2318 ns | 0.0114 |      48 B |

    IList_FastLinq |          10 |                0 |  4.9065 ns |  1.1220 ns | 0.0634 ns |      - |       0 B |
     IList_Optimal |          10 |                0 |  2.7034 ns |  0.5077 ns | 0.0287 ns |      - |       0 B |
      IList_System |          10 |                0 |  7.3174 ns |  1.4088 ns | 0.0796 ns |      - |       0 B |

     List_FastLinq |          10 |                0 |  3.0285 ns |  1.4040 ns | 0.0793 ns |      - |       0 B |
      List_Optimal |          10 |                0 |  0.9244 ns |  0.1411 ns | 0.0080 ns |      - |       0 B |
       List_System |          10 |                0 |  6.4562 ns |  7.7658 ns | 0.4388 ns |      - |       0 B |


    Array_FastLinq |         100 |                0 |  3.4021 ns |  1.1001 ns | 0.0622 ns |      - |       0 B |
     Array_Optimal |         100 |                0 |  0.0000 ns |  0.0000 ns | 0.0000 ns |      - |       0 B |
      Array_System |         100 |                0 | 26.2204 ns |  4.6332 ns | 0.2618 ns |      - |       0 B |

 Collection_System |         100 |                0 | 31.3848 ns | 11.1408 ns | 0.6295 ns | 0.0095 |      40 B |
 Enumerable_System |         100 |                0 | 27.2543 ns | 10.2884 ns | 0.5813 ns | 0.0114 |      48 B |

    IList_FastLinq |         100 |                0 |  4.9154 ns |  1.8627 ns | 0.1052 ns |      - |       0 B |
     IList_Optimal |         100 |                0 |  2.7095 ns |  1.1141 ns | 0.0629 ns |      - |       0 B |
      IList_System |         100 |                0 |  7.3454 ns |  3.6709 ns | 0.2074 ns |      - |       0 B |

     List_FastLinq |         100 |                0 |  3.1795 ns |  0.6295 ns | 0.0356 ns |      - |       0 B |
      List_Optimal |         100 |                0 |  0.8884 ns |  0.3460 ns | 0.0195 ns |      - |       0 B |
       List_System |         100 |                0 |  5.5621 ns |  0.3487 ns | 0.0197 ns |      - |       0 B |


    Array_FastLinq |         100 |               10 |  3.4214 ns |  0.9154 ns | 0.0517 ns |      - |       0 B |
     Array_Optimal |         100 |               10 |  0.0049 ns |  0.1509 ns | 0.0085 ns |      - |       0 B |
      Array_System |         100 |               10 | 26.7411 ns |  1.7738 ns | 0.1002 ns |      - |       0 B |

 Collection_System |         100 |               10 | 98.7018 ns |  7.4392 ns | 0.4203 ns | 0.0094 |      40 B |
 Enumerable_System |         100 |               10 | 71.4222 ns | 17.7444 ns | 1.0026 ns | 0.0113 |      48 B |

    IList_FastLinq |         100 |               10 |  5.3454 ns |  1.3898 ns | 0.0785 ns |      - |       0 B |
     IList_Optimal |         100 |               10 |  2.5413 ns |  1.5475 ns | 0.0874 ns |      - |       0 B |
      IList_System |         100 |               10 |  7.4514 ns |  4.9186 ns | 0.2779 ns |      - |       0 B |

     List_FastLinq |         100 |               10 |  3.1513 ns |  2.1317 ns | 0.1204 ns |      - |       0 B |
      List_Optimal |         100 |               10 |  1.0347 ns |  3.0742 ns | 0.1737 ns |      - |       0 B |
       List_System |         100 |               10 |  5.5033 ns |  0.7899 ns | 0.0446 ns |      - |       0 B |
     */

    /// <summary>
    /// BCL optimizes <see cref="IList{T}"/>
    /// FastLinq only accepts <see cref="IReadOnlyList{T}"/>
    /// </summary>
    public class ElementAtBenchmark
    {
        [Params(0, 10, 100)] public int SizeOfInput;
        [Params(0, 10, 100)] public int ElementToRequest;

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
            var _ = Enumerable.ElementAt(this.enumerable, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.ElementAt(this.collection, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.ElementAt(this.ilist, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.ElementAt(this.list, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.ElementAt(this.array, ElementToRequest);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.ElementAt(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.ElementAt(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.ElementAt(this.ilist, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.ElementAt(this.list, ElementToRequest);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.ElementAt(this.array, ElementToRequest);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.ElementAt(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.ElementAt(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var _ = this.ilist[ElementToRequest];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var _ = this.list[ElementToRequest];
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            var _ = this.array[ElementToRequest];
        }
    }
}
