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
             Method | EnumerateAfterwards | InputSize |       Mean |       Error |     StdDev |  Gen 0 | Allocated |
------------------- |-------------------- |---------- |-----------:|------------:|-----------:|-------:|----------:|
     Array_FastLinq |               False |         0 |  21.477 ns |   8.1253 ns |  0.4591 ns | 0.0229 |      96 B |
      Array_Optimal |               False |         0 |   6.155 ns |   6.6962 ns |  0.3783 ns | 0.0057 |      24 B |
       Array_System |               False |         0 |  36.357 ns |  18.5575 ns |  1.0485 ns | 0.0305 |     128 B |

 Enumerable_Optimal |               False |         0 |   6.036 ns |   3.5670 ns |  0.2015 ns | 0.0057 |      24 B |
  Enumerable_System |               False |         0 |  35.847 ns |  41.9314 ns |  2.3692 ns | 0.0305 |     128 B |

     IList_FastLinq |               False |         0 |  17.720 ns |   4.7375 ns |  0.2677 ns | 0.0229 |      96 B |
      IList_Optimal |               False |         0 |   5.698 ns |   4.2685 ns |  0.2412 ns | 0.0057 |      24 B |
       IList_System |               False |         0 |  34.847 ns |  13.0967 ns |  0.7400 ns | 0.0305 |     128 B |

      List_FastLinq |               False |         0 |  18.145 ns |   6.8152 ns |  0.3851 ns | 0.0229 |      96 B |
       List_Optimal |               False |         0 |   5.929 ns |   4.9209 ns |  0.2780 ns | 0.0057 |      24 B |
        List_System |               False |         0 |  33.214 ns |  13.2271 ns |  0.7474 ns | 0.0343 |     144 B |


     Array_FastLinq |               False |        10 |  18.950 ns |  18.2255 ns |  1.0298 ns | 0.0229 |      96 B |
      Array_Optimal |               False |        10 |   5.789 ns |   0.6604 ns |  0.0373 ns | 0.0057 |      24 B |
       Array_System |               False |        10 |  33.679 ns |  31.8617 ns |  1.8002 ns | 0.0305 |     128 B |

 Enumerable_Optimal |               False |        10 |   6.924 ns |   6.0212 ns |  0.3402 ns | 0.0057 |      24 B |
  Enumerable_System |               False |        10 |  33.592 ns |   4.4005 ns |  0.2486 ns | 0.0305 |     128 B |

     IList_FastLinq |               False |        10 |  17.043 ns |   3.9010 ns |  0.2204 ns | 0.0229 |      96 B |
      IList_Optimal |               False |        10 |   5.328 ns |   0.8438 ns |  0.0477 ns | 0.0057 |      24 B |
       IList_System |               False |        10 |  36.710 ns |  86.8058 ns |  4.9047 ns | 0.0305 |     128 B |

      List_FastLinq |               False |        10 |  17.842 ns |   3.9812 ns |  0.2249 ns | 0.0229 |      96 B |
       List_Optimal |               False |        10 |   5.499 ns |   3.4639 ns |  0.1957 ns | 0.0057 |      24 B |
        List_System |               False |        10 |  32.632 ns |   6.3260 ns |  0.3574 ns | 0.0343 |     144 B |


     Array_FastLinq |               False |       100 |  18.103 ns |   2.2697 ns |  0.1282 ns | 0.0229 |      96 B |
      Array_Optimal |               False |       100 |   5.754 ns |   0.8849 ns |  0.0500 ns | 0.0057 |      24 B |
       Array_System |               False |       100 |  33.616 ns |   9.9165 ns |  0.5603 ns | 0.0305 |     128 B |

 Enumerable_Optimal |               False |       100 |   6.364 ns |   1.6122 ns |  0.0911 ns | 0.0057 |      24 B |
  Enumerable_System |               False |       100 |  36.612 ns |  20.5604 ns |  1.1617 ns | 0.0305 |     128 B |

     IList_FastLinq |               False |       100 |  18.352 ns |   6.7830 ns |  0.3833 ns | 0.0229 |      96 B |
      IList_Optimal |               False |       100 |   5.464 ns |   0.4600 ns |  0.0260 ns | 0.0057 |      24 B |
       IList_System |               False |       100 |  34.271 ns |  10.2746 ns |  0.5805 ns | 0.0305 |     128 B |

      List_FastLinq |               False |       100 |  18.146 ns |   3.1248 ns |  0.1766 ns | 0.0229 |      96 B |
       List_Optimal |               False |       100 |   5.992 ns |   5.5135 ns |  0.3115 ns | 0.0057 |      24 B |
        List_System |               False |       100 |  32.878 ns |  12.2259 ns |  0.6908 ns | 0.0343 |     144 B |


     Array_FastLinq |                True |         0 | 105.689 ns | 118.0631 ns |  6.6708 ns | 0.0228 |      96 B |
      Array_Optimal |                True |         0 |  11.659 ns |   5.6401 ns |  0.3187 ns | 0.0057 |      24 B |
       Array_System |                True |         0 | 161.386 ns |  25.0878 ns |  1.4175 ns | 0.0303 |     128 B |

 Enumerable_Optimal |                True |         0 |  88.760 ns |  33.7177 ns |  1.9051 ns | 0.0172 |      72 B |
  Enumerable_System |                True |         0 | 241.998 ns |  59.2788 ns |  3.3494 ns | 0.0415 |     176 B |

     IList_FastLinq |                True |         0 | 129.024 ns |  74.7975 ns |  4.2262 ns | 0.0226 |      96 B |
      IList_Optimal |                True |         0 |  41.466 ns |  19.7955 ns |  1.1185 ns | 0.0057 |      24 B |
       IList_System |                True |         0 | 278.143 ns |   0.9236 ns |  0.0522 ns | 0.0401 |     168 B |

      List_FastLinq |                True |         0 | 100.380 ns |  77.9519 ns |  4.4044 ns | 0.0228 |      96 B |
       List_Optimal |                True |         0 |  16.274 ns |   2.0697 ns |  0.1169 ns | 0.0057 |      24 B |
        List_System |                True |         0 | 203.611 ns |  97.7782 ns |  5.5246 ns | 0.0341 |     144 B |


     Array_FastLinq |                True |        10 | 110.086 ns | 195.2452 ns | 11.0317 ns | 0.0228 |      96 B |
      Array_Optimal |                True |        10 |  11.843 ns |   3.1984 ns |  0.1807 ns | 0.0057 |      24 B |
       Array_System |                True |        10 | 164.088 ns | 143.7950 ns |  8.1247 ns | 0.0303 |     128 B |

 Enumerable_Optimal |                True |        10 |  95.095 ns |  69.4916 ns |  3.9264 ns | 0.0172 |      72 B |
  Enumerable_System |                True |        10 | 240.406 ns |  56.0366 ns |  3.1662 ns | 0.0415 |     176 B |

     IList_FastLinq |                True |        10 | 128.288 ns |  15.8878 ns |  0.8977 ns | 0.0226 |      96 B |
      IList_Optimal |                True |        10 |  41.389 ns |  13.3079 ns |  0.7519 ns | 0.0057 |      24 B |
       IList_System |                True |        10 | 278.714 ns |  71.9187 ns |  4.0635 ns | 0.0401 |     168 B |

      List_FastLinq |                True |        10 |  98.801 ns |  24.2228 ns |  1.3686 ns | 0.0228 |      96 B |
       List_Optimal |                True |        10 |  16.388 ns |   9.1082 ns |  0.5146 ns | 0.0057 |      24 B |
        List_System |                True |        10 | 197.121 ns |   2.3071 ns |  0.1304 ns | 0.0341 |     144 B |


     Array_FastLinq |                True |       100 | 101.618 ns |  32.5642 ns |  1.8399 ns | 0.0228 |      96 B |
      Array_Optimal |                True |       100 |  12.174 ns |   3.6020 ns |  0.2035 ns | 0.0057 |      24 B |
       Array_System |                True |       100 | 163.144 ns |  43.4213 ns |  2.4534 ns | 0.0303 |     128 B |

 Enumerable_Optimal |                True |       100 |  88.877 ns |  34.3399 ns |  1.9403 ns | 0.0172 |      72 B |
  Enumerable_System |                True |       100 | 237.391 ns |  74.9627 ns |  4.2355 ns | 0.0417 |     176 B |

     IList_FastLinq |                True |       100 | 126.543 ns |  31.2571 ns |  1.7661 ns | 0.0226 |      96 B |
      IList_Optimal |                True |       100 |  40.873 ns |   9.6269 ns |  0.5439 ns | 0.0057 |      24 B |
       IList_System |                True |       100 | 283.443 ns | 115.2415 ns |  6.5114 ns | 0.0401 |     168 B |

      List_FastLinq |                True |       100 | 100.004 ns |  40.1650 ns |  2.2694 ns | 0.0228 |      96 B |
       List_Optimal |                True |       100 |  16.434 ns |   8.7873 ns |  0.4965 ns | 0.0057 |      24 B |
        List_System |                True |       100 | 198.707 ns |  32.5476 ns |  1.8390 ns | 0.0341 |     144 B |
     */

    /// <summary>
    /// <see cref="Enumerable.Select"/> optimizes Array and List (in some cases), and falls back to Enumerable.
    /// <see cref="FastLinq.Select"/> does not special handle any type TODO: It could though!
    /// </summary>
    public class SelectBenchmark
    {
        [Params(true, false)] public bool EnumerateAfterwards;

        [Params(0, 10, 100)] public int InputSize;

        private int[] array;
        private List<int> list;
        // ReadOnlyCollection is IList, but has an object enumerator
        private ReadOnlyCollection<int> ilist;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.ilist = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void Enumerable_System()
        {
            var _ = Enumerable.Select(this.enumerable, SelectMethod);
            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.Select(this.ilist, SelectMethod);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.Select(this.list, SelectMethod);

            if (this.EnumerateAfterwards)
            {
                foreach (var item in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.Select(this.array, SelectMethod);

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
        //    var _ = FastLinq.Select(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "IList")]
        public void IList_FastLinq()
        {
            var _ = FastLinq.Select(this.ilist, SelectMethod);

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
            var _ = FastLinq.Select(this.list, SelectMethod);

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
            var _ = FastLinq.Select(this.array, SelectMethod);

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
            // TODO: This is not accounting for the return type that must be given
            var fakeReturnType = new { this.enumerable };
            if (this.EnumerateAfterwards)
            {
                foreach (var item in this.enumerable)
                {
                    var _ = SelectMethod(item);
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            var fakeReturnType = new { this.ilist };
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.ilist.Count;
                for (int i = length - 1; i >= 0; i--)
                {
                    var _ = SelectMethod(this.ilist[i]);
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            var fakeReturnType = new { this.list };
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.list.Count;
                for (int i = length - 1; i >= 0; i--)
                {
                    var _ = SelectMethod(this.list[i]);
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            var fakeReturnType = new { this.array };
            // TODO: This is not accounting for the return type that must be given
            if (this.EnumerateAfterwards)
            {
                var length = this.array.Length;
                for (int i = length - 1; i >= 0; i--)
                {
                    var _ = SelectMethod(this.array[i]);
                }
            }
        }

        private static double SelectMethod(int input)
        {
            return (double) input;
        }
    }
}
