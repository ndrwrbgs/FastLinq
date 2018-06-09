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
             Method | EnumerateAfterwards | InputSize |      Mean |      Error |     StdDev |  Gen 0 | Allocated |
------------------- |-------------------- |---------- |----------:|-----------:|-----------:|-------:|----------:|
     Array_FastLinq |               False |         0 |  15.24 ns |   4.215 ns |  0.2382 ns | 0.0152 |      64 B | TODO: More memory?
      Array_Optimal |               False |         0 |  65.15 ns |  21.021 ns |  1.1878 ns | 0.0094 |      40 B |
       Array_System |               False |         0 |  62.42 ns |  47.371 ns |  2.6766 ns | 0.0094 |      40 B |

 Collection_Optimal |               False |         0 |  30.34 ns |  11.897 ns |  0.6722 ns | 0.0095 |      40 B |
  Collection_System |               False |         0 |  33.22 ns |   5.859 ns |  0.3310 ns | 0.0095 |      40 B |

 Enumerable_Optimal |               False |         0 |  59.03 ns |  21.388 ns |  1.2084 ns | 0.0209 |      88 B |
  Enumerable_System |               False |         0 |  57.59 ns |  25.130 ns |  1.4199 ns | 0.0209 |      88 B |

     IList_FastLinq |               False |         0 |  13.66 ns |  10.490 ns |  0.5927 ns | 0.0152 |      64 B |
      IList_Optimal |               False |         0 |  32.54 ns |   8.873 ns |  0.5014 ns | 0.0095 |      40 B |
       IList_System |               False |         0 |  33.78 ns |   6.998 ns |  0.3954 ns | 0.0095 |      40 B |

      List_FastLinq |               False |         0 |  13.36 ns |   2.946 ns |  0.1665 ns | 0.0152 |      64 B |
       List_Optimal |               False |         0 |  30.51 ns |  17.880 ns |  1.0103 ns | 0.0095 |      40 B |
        List_System |               False |         0 |  33.38 ns |  12.166 ns |  0.6874 ns | 0.0095 |      40 B |


     Array_FastLinq |               False |         2 |  13.47 ns |   5.020 ns |  0.2836 ns | 0.0152 |      64 B |
      Array_Optimal |               False |         2 |  79.83 ns |  90.409 ns |  5.1083 ns | 0.0170 |      72 B |
       Array_System |               False |         2 |  85.82 ns |   8.471 ns |  0.4786 ns | 0.0170 |      72 B |

 Collection_Optimal |               False |         2 |  42.78 ns | 107.992 ns |  6.1017 ns | 0.0171 |      72 B |
  Collection_System |               False |         2 |  40.60 ns |  14.876 ns |  0.8405 ns | 0.0171 |      72 B |

 Enumerable_Optimal |               False |         2 |  97.05 ns | 104.555 ns |  5.9075 ns | 0.0304 |     128 B |
  Enumerable_System |               False |         2 |  98.16 ns |  72.931 ns |  4.1207 ns | 0.0304 |     128 B |

     IList_FastLinq |               False |         2 |  14.65 ns |  18.771 ns |  1.0606 ns | 0.0152 |      64 B |
      IList_Optimal |               False |         2 |  49.28 ns |  11.995 ns |  0.6778 ns | 0.0171 |      72 B |
       IList_System |               False |         2 |  50.34 ns |   6.378 ns |  0.3603 ns | 0.0171 |      72 B |

      List_FastLinq |               False |         2 |  13.42 ns |   3.331 ns |  0.1882 ns | 0.0152 |      64 B |
       List_Optimal |               False |         2 |  45.67 ns |   9.143 ns |  0.5166 ns | 0.0171 |      72 B |
        List_System |               False |         2 |  47.09 ns |  21.385 ns |  1.2083 ns | 0.0171 |      72 B |


     Array_FastLinq |               False |        10 |  13.33 ns |   5.391 ns |  0.3046 ns | 0.0152 |      64 B |
      Array_Optimal |               False |        10 |  91.00 ns |   3.039 ns |  0.1717 ns | 0.0247 |     104 B |
       Array_System |               False |        10 |  93.22 ns |  28.840 ns |  1.6295 ns | 0.0247 |     104 B |

 Collection_Optimal |               False |        10 |  54.45 ns |  49.798 ns |  2.8137 ns | 0.0247 |     104 B |
  Collection_System |               False |        10 |  53.95 ns |  16.699 ns |  0.9435 ns | 0.0247 |     104 B |

 Enumerable_Optimal |               False |        10 | 253.87 ns | 140.709 ns |  7.9503 ns | 0.0644 |     272 B |
  Enumerable_System |               False |        10 | 237.86 ns | 123.540 ns |  6.9802 ns | 0.0644 |     272 B |

     IList_FastLinq |               False |        10 |  13.42 ns |  10.510 ns |  0.5939 ns | 0.0152 |      64 B |
      IList_Optimal |               False |        10 |  61.68 ns |   5.706 ns |  0.3224 ns | 0.0247 |     104 B |
       IList_System |               False |        10 |  64.10 ns |  17.070 ns |  0.9645 ns | 0.0247 |     104 B |

      List_FastLinq |               False |        10 |  13.56 ns |   6.930 ns |  0.3915 ns | 0.0152 |      64 B |
       List_Optimal |               False |        10 |  58.05 ns |   3.140 ns |  0.1774 ns | 0.0247 |     104 B |
        List_System |               False |        10 |  58.35 ns |  22.612 ns |  1.2776 ns | 0.0247 |     104 B |


     Array_FastLinq |                True |         0 |  31.61 ns |   9.160 ns |  0.5176 ns | 0.0152 |      64 B |
      Array_Optimal |                True |         0 |  63.68 ns |  36.155 ns |  2.0428 ns | 0.0094 |      40 B |
       Array_System |                True |         0 |  64.89 ns |   9.181 ns |  0.5187 ns | 0.0094 |      40 B |

 Collection_Optimal |                True |         0 |  33.43 ns |   7.175 ns |  0.4054 ns | 0.0095 |      40 B |
  Collection_System |                True |         0 |  36.14 ns |  17.918 ns |  1.0124 ns | 0.0095 |      40 B |

 Enumerable_Optimal |                True |         0 |  60.51 ns |  17.802 ns |  1.0058 ns | 0.0209 |      88 B |
  Enumerable_System |                True |         0 |  63.15 ns |  82.177 ns |  4.6432 ns | 0.0209 |      88 B |

     IList_FastLinq |                True |         0 |  38.10 ns |   7.726 ns |  0.4365 ns | 0.0247 |     104 B | TODO: More memory
      IList_Optimal |                True |         0 |  36.55 ns |  35.991 ns |  2.0336 ns | 0.0095 |      40 B |
       IList_System |                True |         0 |  37.22 ns |  18.956 ns |  1.0711 ns | 0.0095 |      40 B |

      List_FastLinq |                True |         0 |  35.07 ns |   3.701 ns |  0.2091 ns | 0.0247 |     104 B | TODO: More memory
       List_Optimal |                True |         0 |  35.57 ns |   9.290 ns |  0.5249 ns | 0.0095 |      40 B |
        List_System |                True |         0 |  36.24 ns |  21.677 ns |  1.2248 ns | 0.0095 |      40 B |


     Array_FastLinq |                True |         2 |  41.33 ns |  10.412 ns |  0.5883 ns | 0.0228 |      96 B | TODO: More memory
      Array_Optimal |                True |         2 |  85.68 ns |  30.494 ns |  1.7229 ns | 0.0170 |      72 B |
       Array_System |                True |         2 |  90.32 ns |  28.134 ns |  1.5896 ns | 0.0170 |      72 B |

 Collection_Optimal |                True |         2 |  47.01 ns |   8.937 ns |  0.5050 ns | 0.0171 |      72 B |
  Collection_System |                True |         2 |  59.34 ns |  29.360 ns |  1.6589 ns | 0.0170 |      72 B |

 Enumerable_Optimal |                True |         2 | 100.82 ns |  23.658 ns |  1.3367 ns | 0.0304 |     128 B |
  Enumerable_System |                True |         2 | 101.58 ns |  20.508 ns |  1.1588 ns | 0.0304 |     128 B |

     IList_FastLinq |                True |         2 |  56.08 ns |  30.405 ns |  1.7179 ns | 0.0247 |     104 B |
      IList_Optimal |                True |         2 |  57.18 ns |  31.580 ns |  1.7843 ns | 0.0170 |      72 B |
       IList_System |                True |         2 |  59.19 ns |   6.227 ns |  0.3519 ns | 0.0170 |      72 B |

      List_FastLinq |                True |         2 |  53.62 ns |  29.194 ns |  1.6495 ns | 0.0247 |     104 B |
       List_Optimal |                True |         2 |  55.92 ns |  33.174 ns |  1.8744 ns | 0.0171 |      72 B |
        List_System |                True |         2 |  56.86 ns |  13.316 ns |  0.7524 ns | 0.0170 |      72 B |


     Array_FastLinq |                True |        10 | 104.92 ns | 149.259 ns |  8.4334 ns | 0.0228 |      96 B |
      Array_Optimal |                True |        10 | 128.48 ns |  73.479 ns |  4.1517 ns | 0.0246 |     104 B |
       Array_System |                True |        10 | 125.74 ns |  53.282 ns |  3.0105 ns | 0.0246 |     104 B |

 Collection_Optimal |                True |        10 |  93.82 ns |  28.223 ns |  1.5947 ns | 0.0247 |     104 B |
  Collection_System |                True |        10 |  95.04 ns |  14.681 ns |  0.8295 ns | 0.0247 |     104 B |

 Enumerable_Optimal |                True |        10 | 272.83 ns |  13.636 ns |  0.7705 ns | 0.0644 |     272 B |
  Enumerable_System |                True |        10 | 314.54 ns | 304.028 ns | 17.1781 ns | 0.0644 |     272 B |

     IList_FastLinq |                True |        10 | 134.82 ns |  45.321 ns |  2.5607 ns | 0.0246 |     104 B | TODO: slower - enumeration would be faster with a struct enumerator, but that would require exposing CopyOnWriteList?
      IList_Optimal |                True |        10 |  91.55 ns |  32.556 ns |  1.8394 ns | 0.0247 |     104 B |
       IList_System |                True |        10 |  92.62 ns |  20.921 ns |  1.1821 ns | 0.0247 |     104 B |

      List_FastLinq |                True |        10 | 134.54 ns |  25.537 ns |  1.4429 ns | 0.0246 |     104 B | TODO: slower
       List_Optimal |                True |        10 |  87.54 ns |  17.523 ns |  0.9901 ns | 0.0247 |     104 B |
        List_System |                True |        10 |  88.59 ns |  14.195 ns |  0.8020 ns | 0.0247 |     104 B |
     */


    /// <summary>
    /// Enumerable.ToLazyList optimizes ICollection and EMPTY, and falls back to Enumerable
    /// </summary>
    public class ToLazyListBenchmark
    {
        [Params(true/*, false*/)] public bool EnumerateAfterwards;

        [Params(/*0, 2, 10*/ 1000)] public int InputSize;

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
            this.enumerable = Enumerable.Range(0, this.InputSize);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new HashSet<int>(this.list);
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.ToList(this.enumerable);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.ToList(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.ToList(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.ToList(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.ToList(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.ToLazyList(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void List_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void Array_FastLinq()
        {
            var _ = FastLinq.ToLazyList(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        // Not implemented by FastLinq for ICollection
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Collection")]
        //public void Collection_FastLinq()
        //{
        //    var _ = FastLinq.ToLazyList(this.collection);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Enumerable_Optimal()
        {
            // TODO: Optimal should be lazy also
            // System is pretty close to optimal for IEnumerable, good enough for now
            Enumerable_System();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.list);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.ilist);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }
        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.array);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            // TODO: Optimal should be lazy also
            var _ = new List<int>(this.collection);

            if (this.EnumerateAfterwards)
            {
                foreach (var __ in _)
                {
                }
            }
        }
    }
}
