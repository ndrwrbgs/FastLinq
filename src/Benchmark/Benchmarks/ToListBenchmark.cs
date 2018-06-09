using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using System.Collections.ObjectModel;
    using System.Reflection;

    using BenchmarkDotNet.Attributes;

    /*
    NOTE - not nearly as useful nor important as ToLazyList - since ToList has to materialize to a List{T}
    
                      Method | InputSize |      Mean |       Error |    StdDev |  Gen 0 | Allocated |
---------------------------- |---------- |----------:|------------:|----------:|-------:|----------:|
              Array_FastLinq |         0 |  83.00 ns |  63.9002 ns | 3.6105 ns | 0.0094 |      40 B | TODO: Much slower - more than a single cast should be
               Array_Optimal |         0 |  47.86 ns |  12.2063 ns | 0.6897 ns | 0.0095 |      40 B |
                Array_System |         0 |  48.89 ns |  20.3014 ns | 1.1471 ns | 0.0095 |      40 B |

         Collection_FastLinq |         0 |  23.08 ns |   5.2115 ns | 0.2945 ns | 0.0095 |      40 B |
          Collection_Optimal |         0 |  19.34 ns |   3.3946 ns | 0.1918 ns | 0.0095 |      40 B |
           Collection_System |         0 |  20.06 ns |   0.8659 ns | 0.0489 ns | 0.0095 |      40 B |

          Enumerable_Optimal |         0 |  44.65 ns |  13.9030 ns | 0.7855 ns | 0.0209 |      88 B |
           Enumerable_System |         0 |  44.77 ns |   7.9915 ns | 0.4515 ns | 0.0209 |      88 B |

              IList_FastLinq |         0 |  26.46 ns |   7.5530 ns | 0.4268 ns | 0.0095 |      40 B |
               IList_Optimal |         0 |  22.63 ns |  14.8706 ns | 0.8402 ns | 0.0095 |      40 B |
                IList_System |         0 |  23.17 ns |   6.1463 ns | 0.3473 ns | 0.0095 |      40 B |

               List_FastLinq |         0 |  25.39 ns |   8.8629 ns | 0.5008 ns | 0.0095 |      40 B |
                List_Optimal |         0 |  20.53 ns |   5.5242 ns | 0.3121 ns | 0.0095 |      40 B |
                 List_System |         0 |  21.26 ns |   1.3896 ns | 0.0785 ns | 0.0095 |      40 B |

 ReadOnlyCollection_FastLinq |         0 |  58.16 ns |  20.3337 ns | 1.1489 ns | 0.0266 |     112 B |
  ReadOnlyCollection_Optimal |         0 |  37.00 ns |  14.4620 ns | 0.8171 ns | 0.0228 |      96 B |
   ReadOnlyCollection_System |         0 |  54.08 ns |  14.8957 ns | 0.8416 ns | 0.0266 |     112 B |


              Array_FastLinq |         2 |  96.60 ns |  26.5462 ns | 1.4999 ns | 0.0170 |      72 B |
               Array_Optimal |         2 |  69.51 ns |  53.3955 ns | 3.0169 ns | 0.0170 |      72 B |
                Array_System |         2 |  64.95 ns |   7.7192 ns | 0.4361 ns | 0.0170 |      72 B |

         Collection_FastLinq |         2 |  32.78 ns |  56.0588 ns | 3.1674 ns | 0.0171 |      72 B |
          Collection_Optimal |         2 |  26.61 ns |   5.4803 ns | 0.3096 ns | 0.0171 |      72 B |
           Collection_System |         2 |  40.57 ns |  15.8893 ns | 0.8978 ns | 0.0171 |      72 B |

          Enumerable_Optimal |         2 |  80.04 ns |  50.6980 ns | 2.8645 ns | 0.0304 |     128 B |
           Enumerable_System |         2 |  88.30 ns |  11.6452 ns | 0.6580 ns | 0.0304 |     128 B |

              IList_FastLinq |         2 |  42.48 ns |  20.9677 ns | 1.1847 ns | 0.0171 |      72 B |
               IList_Optimal |         2 |  37.18 ns |  15.5136 ns | 0.8765 ns | 0.0171 |      72 B |
                IList_System |         2 |  38.49 ns |   9.4918 ns | 0.5363 ns | 0.0171 |      72 B |

               List_FastLinq |         2 |  40.69 ns |  40.4142 ns | 2.2835 ns | 0.0171 |      72 B |
                List_Optimal |         2 |  34.09 ns |   6.6429 ns | 0.3753 ns | 0.0171 |      72 B |
                 List_System |         2 |  36.55 ns |  41.9169 ns | 2.3684 ns | 0.0171 |      72 B |

 ReadOnlyCollection_FastLinq |         2 |  82.07 ns |  13.5209 ns | 0.7640 ns | 0.0342 |     144 B |
  ReadOnlyCollection_Optimal |         2 |  57.65 ns |  36.2483 ns | 2.0481 ns | 0.0247 |     104 B |
   ReadOnlyCollection_System |         2 |  91.74 ns |  15.2333 ns | 0.8607 ns | 0.0361 |     152 B |


              Array_FastLinq |        10 | 116.23 ns |  30.7397 ns | 1.7369 ns | 0.0247 |     104 B |
               Array_Optimal |        10 |  85.12 ns |  10.6996 ns | 0.6045 ns | 0.0247 |     104 B |
                Array_System |        10 |  85.38 ns |  49.6085 ns | 2.8030 ns | 0.0247 |     104 B |

         Collection_FastLinq |        10 |  44.19 ns |  14.9454 ns | 0.8444 ns | 0.0247 |     104 B |
          Collection_Optimal |        10 |  41.08 ns |  10.5757 ns | 0.5975 ns | 0.0247 |     104 B |
           Collection_System |        10 |  58.00 ns |  20.7767 ns | 1.1739 ns | 0.0247 |     104 B |

          Enumerable_Optimal |        10 | 235.80 ns |  97.1066 ns | 5.4867 ns | 0.0646 |     272 B |
           Enumerable_System |        10 | 230.48 ns | 109.2158 ns | 6.1709 ns | 0.0646 |     272 B |

              IList_FastLinq |        10 |  54.06 ns |   4.5973 ns | 0.2598 ns | 0.0247 |     104 B |
               IList_Optimal |        10 |  51.04 ns |   7.9590 ns | 0.4497 ns | 0.0247 |     104 B |
                IList_System |        10 |  54.39 ns | 108.6650 ns | 6.1398 ns | 0.0247 |     104 B |

               List_FastLinq |        10 |  49.83 ns |  18.5865 ns | 1.0502 ns | 0.0247 |     104 B |
                List_Optimal |        10 |  47.74 ns |  28.5973 ns | 1.6158 ns | 0.0247 |     104 B |
                 List_System |        10 |  48.43 ns |   4.0313 ns | 0.2278 ns | 0.0247 |     104 B |

 ReadOnlyCollection_FastLinq |        10 | 195.51 ns |  51.5675 ns | 2.9137 ns | 0.0417 |     176 B |
  ReadOnlyCollection_Optimal |        10 | 129.63 ns |  30.7629 ns | 1.7382 ns | 0.0322 |     136 B |
   ReadOnlyCollection_System |        10 | 265.21 ns | 136.4158 ns | 7.7077 ns | 0.0701 |     296 B |
     */


    /// <summary>
    /// Enumerable.ToList optimizes ICollection and EMPTY, and falls back to Enumerable
    /// </summary>
    public class ToListBenchmark
    {
        [Params(0, 2, 10)] public int InputSize;

        private int[] array;
        private List<int> list;
        // HashSet is ICollection, not IList, and has a struct enumerator
        private HashSet<int> collection;
        // Needs to be IReadOnlyCollection but NOT ICollection
        private EnumerableWithCount<int> readOnlyCollection;
        // ReadOnlyCollection is IList, but has an object enumerator
        private ReadOnlyCollection<int> ilist;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, this.InputSize);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.readOnlyCollection = new EnumerableWithCount<int>(this.enumerable.ToList(), this.InputSize);
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.ToList(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.ToList(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.ToList(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.ToList(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.ToList(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("System", "ReadOnlyCollection")]
        public void ReadOnlyCollection_System()
        {
            var _ = Enumerable.ToList(this.readOnlyCollection);
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.ToList(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.ToList(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.ToList(this.ilist);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.ToList(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void Collection_FastLinq()
        {
            var _ = FastLinq.ToList(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "ReadOnlyCollection")]
        public void ReadOnlyCollection_FastLinq()
        {
            var _ = FastLinq.ToList(this.readOnlyCollection);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            // System is pretty close to optimal for IEnumerable, good enough for now
            Enumerable_System();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var _ = new List<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var _ = new List<int>(this.ilist);
        }
        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Array", "Test")]
        public void Array_Optimal()
        {
            // TODO: Optimal here can probably actually be better
            var _ = new List<int>(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            var _ = new List<int>(this.collection);
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "ReadOnlyCollection")]
        public void ReadOnlyCollection_Optimal()
        {
            int[] _ = new int[((IReadOnlyCollection<int>)this.readOnlyCollection).Count];
            int idx = 0;
            foreach (var item in this.readOnlyCollection)
            {
                _[idx] = item;
            }
        }
    }
}
