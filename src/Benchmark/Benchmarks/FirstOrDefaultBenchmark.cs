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
            Method | HasAny |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
------------------ |------- |-----------:|-----------:|----------:|-------:|----------:|
    Array_FastLinq |  False |  3.7506 ns |  1.7448 ns | 0.0986 ns |      - |       0 B |
     Array_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
      Array_System |  False | 28.6670 ns |  2.9491 ns | 0.1666 ns |      - |       0 B |

 Collection_System |  False | 28.1842 ns | 11.1193 ns | 0.6283 ns | 0.0095 |      40 B |
 Enumerable_System |  False | 28.4303 ns | 24.6394 ns | 1.3922 ns | 0.0114 |      48 B |

    IList_FastLinq |  False |  5.9616 ns | 11.1510 ns | 0.6301 ns |      - |       0 B |
     IList_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
      IList_System |  False |  7.8960 ns |  1.3654 ns | 0.0771 ns |      - |       0 B |

     List_FastLinq |  False |  3.5190 ns |  1.3889 ns | 0.0785 ns |      - |       0 B |
      List_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
       List_System |  False |  6.3368 ns |  1.7689 ns | 0.0999 ns |      - |       0 B |

    Array_FastLinq |   True |  6.1318 ns |  2.3143 ns | 0.1308 ns |      - |       0 B |
     Array_Optimal |   True |  0.0248 ns |  0.1570 ns | 0.0089 ns |      - |       0 B |
      Array_System |   True | 36.5153 ns | 99.1339 ns | 5.6012 ns |      - |       0 B |

 Collection_System |   True | 40.1723 ns | 73.8663 ns | 4.1736 ns | 0.0095 |      40 B |
 Enumerable_System |   True | 30.8741 ns | 16.9167 ns | 0.9558 ns | 0.0114 |      48 B |

    IList_FastLinq |   True |  9.8742 ns | 13.7507 ns | 0.7769 ns |      - |       0 B |
     IList_Optimal |   True |  2.8608 ns |  0.7335 ns | 0.0414 ns |      - |       0 B |
      IList_System |   True | 12.4725 ns |  4.6488 ns | 0.2627 ns |      - |       0 B |

     List_FastLinq |   True |  6.1468 ns |  1.9280 ns | 0.1089 ns |      - |       0 B |
      List_Optimal |   True |  0.7859 ns |  0.4348 ns | 0.0246 ns |      - |       0 B |
       List_System |   True |  8.7282 ns |  2.2273 ns | 0.1258 ns |      - |       0 B |
     */
    /// <summary>
    /// BCL optimizes <see cref="IList{T}"/>
    /// FastLinq only accepts <see cref="IReadOnlyList{T}"/>
    /// </summary>
    public class FirstOrDefaultBenchmark
    {
        [Params(true, false)] public bool HasAny;

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
            this.enumerable = Enumerable.Range(0, this.HasAny ? 10 : 0);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.FirstOrDefault(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.FirstOrDefault(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.FirstOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.FirstOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.FirstOrDefault(this.array);
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.FirstOrDefault(this.enumerable);
        //}

        // Not implemented for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.FirstOrDefault(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.FirstOrDefault(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.FirstOrDefault(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.FirstOrDefault(this.array);
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.FirstOrDefault(this.enumerable);
        //}

        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Collection")]
        //public void Collection_Optimal()
        //{
        //    var _ = Enumerable.FirstOrDefault(this.collection);
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
