using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// We are also benchmarking obsolete methods
#pragma warning disable CS0618 // Type or member is obsolete

namespace Benchmark.Benchmarks
{
    using System.Collections;
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /*

        TODO: Results are from 3 separate runs, rerun all together later.
     *
             Method | EnumerateAfterwards | SizeOfInput |          Mean |         Error |      StdDev |  Gen 0 | Allocated |
------------------- |-------------------- |------------ |--------------:|--------------:|------------:|-------:|----------:|
    Array_FastLinq1 |               False |           0 |      8.973 ns |     1.9162 ns |   0.1083 ns | 0.0057 |      24 B |
    Array_FastLinq2 |               False |           0 |      8.335 ns |     1.7730 ns |   0.1002 ns | 0.0057 |      24 B |
      Array_Optimal |               False |           0 |      5.504 ns |     4.3559 ns |   0.2461 ns | 0.0057 |      24 B |
       Array_System |               False |           0 |     62.318 ns |    17.2596 ns |   0.9752 ns | 0.0132 |      56 B |
    
 Collection_FastLinq1 |             False |           0 |   202.44  ns |     99.151  ns |   5.6022 ns | 0.0207 |      88 B |
 Collection_FastLinq2 |             False |           0 |   184.08  ns |     45.353  ns |   2.5625 ns | 0.0207 |      88 B |
   Collection_Optimal |             False |           0 |    16.66  ns |      1.633  ns |   0.0923 ns | 0.0057 |      24 B |
    Collection_System |             False |           0 |   168.99  ns |     13.491  ns |   0.7623 ns | 0.0131 |      56 B |

  Enumerable_System |               False |           0 |    155.207 ns |    58.5193 ns |   3.3064 ns | 0.0131 |      56 B |

    IList_FastLinq1 |               False |           0 |      8.492 ns |     2.1961 ns |   0.1241 ns | 0.0057 |      24 B |
    IList_FastLinq2 |               False |           0 |      8.274 ns |     2.3004 ns |   0.1300 ns | 0.0057 |      24 B |
      IList_Optimal |               False |           0 |      6.877 ns |     4.1854 ns |   0.2365 ns | 0.0057 |      24 B |
       IList_System |               False |           0 |    183.776 ns |   148.2629 ns |   8.3771 ns | 0.0131 |      56 B |

     List_FastLinq1 |               False |           0 |      8.461 ns |     1.8436 ns |   0.1042 ns | 0.0057 |      24 B |
     List_FastLinq2 |               False |           0 |      8.720 ns |     9.8238 ns |   0.5551 ns | 0.0057 |      24 B |
       List_Optimal |               False |           0 |      4.888 ns |     3.0814 ns |   0.1741 ns | 0.0057 |      24 B |
        List_System |               False |           0 |    191.358 ns |    18.8719 ns |   1.0663 ns | 0.0131 |      56 B |


    Array_FastLinq1 |               False |          10 |      9.037 ns |     5.5606 ns |   0.3142 ns | 0.0057 |      24 B |
    Array_FastLinq2 |               False |          10 |      8.276 ns |     1.1365 ns |   0.0642 ns | 0.0057 |      24 B |
       Array_System |               False |          10 |     65.526 ns |    11.2568 ns |   0.6360 ns | 0.0132 |      56 B |
       
 Collection_FastLinq1 |             False |          10 |   188.67  ns |     30.628  ns |   1.7305 ns | 0.0207 |      88 B |
 Collection_FastLinq2 |             False |          10 |   181.51  ns |     25.529  ns |   1.4424 ns | 0.0207 |      88 B |
   Collection_Optimal |             False |          10 |           NA |             NA |          NA |    N/A |       N/A |
    Collection_System |             False |          10 |   167.30  ns |     14.145  ns |   0.7992 ns | 0.0131 |      56 B |

  Enumerable_System |               False |          10 |    156.875 ns |    42.3906 ns |   2.3951 ns | 0.0131 |      56 B |

    IList_FastLinq1 |               False |          10 |      8.475 ns |     2.1507 ns |   0.1215 ns | 0.0057 |      24 B |
    IList_FastLinq2 |               False |          10 |      8.247 ns |     0.7171 ns |   0.0405 ns | 0.0057 |      24 B |
       IList_System |               False |          10 |    177.576 ns |     6.3242 ns |   0.3573 ns | 0.0131 |      56 B |

     List_FastLinq1 |               False |          10 |      8.427 ns |     7.0479 ns |   0.3982 ns | 0.0057 |      24 B |
     List_FastLinq2 |               False |          10 |      8.322 ns |     1.4921 ns |   0.0843 ns | 0.0057 |      24 B |
        List_System |               False |          10 |    176.228 ns |    58.9942 ns |   3.3333 ns | 0.0131 |      56 B |


    Array_FastLinq1 |               False |         100 |      8.168 ns |     2.5945 ns |   0.1466 ns | 0.0057 |      24 B |
    Array_FastLinq2 |               False |         100 |      8.261 ns |     4.6731 ns |   0.2640 ns | 0.0057 |      24 B |
       Array_System |               False |         100 |     63.809 ns |    18.3153 ns |   1.0348 ns | 0.0132 |      56 B |
       
 Collection_FastLinq1 |             False |         100 |   189.16  ns |     63.945  ns |   3.6130 ns | 0.0207 |      88 B |
 Collection_FastLinq2 |             False |         100 |   179.06  ns |      9.922  ns |   0.5606 ns | 0.0207 |      88 B |
   Collection_Optimal |             False |         100 |           NA |             NA |          NA |    N/A |       N/A |
    Collection_System |             False |         100 |   167.15  ns |      8.831  ns |   0.4990 ns | 0.0131 |      56 B |

  Enumerable_System |               False |         100 |    158.149 ns |   114.6056 ns |   6.4754 ns | 0.0131 |      56 B |

    IList_FastLinq1 |               False |         100 |      8.291 ns |     0.4311 ns |   0.0244 ns | 0.0057 |      24 B |
    IList_FastLinq2 |               False |         100 |      8.418 ns |     2.1982 ns |   0.1242 ns | 0.0057 |      24 B |
       IList_System |               False |         100 |    192.597 ns |   313.4177 ns |  17.7087 ns | 0.0131 |      56 B |

     List_FastLinq1 |               False |         100 |      8.297 ns |     2.1503 ns |   0.1215 ns | 0.0057 |      24 B |
     List_FastLinq2 |               False |         100 |      8.508 ns |     4.6874 ns |   0.2648 ns | 0.0057 |      24 B |
        List_System |               False |         100 |    179.031 ns |   161.5898 ns |   9.1301 ns | 0.0131 |      56 B |

        
    Array_FastLinq1 |                True |           0 |     42.71  ns |      79.91 ns |   4.5153 ns | 0.0172 |      72 B |
    Array_FastLinq2 |                True |           0 |     41.65  ns |      38.33 ns |   2.1659 ns | 0.0172 |      72 B |
      Array_FastLinqEager |          True |           0 |     12.14  ns |     9.026  ns |   0.5100 ns | 0.0057 |      24 B |
      Array_Optimal |                True |           0 |      5.226 ns |     0.7869 ns |   0.0445 ns | 0.0057 |      24 B |
       Array_System |                True |           0 |    119.537 ns |    42.1598 ns |   2.3821 ns | 0.0207 |      88 B |
       
 Collection_FastLinq1 |              True |           0 |    281.65 ns |    208.39   ns |  11.7744 ns | 0.0300 |     128 B |
 Collection_FastLinq2 |              True |           0 |    240.93 ns |     48.79   ns |   2.7565 ns | 0.0300 |     128 B |
 Collection_FastLinqEager |          True |           0 |     31.72  ns |    12.750  ns |   0.7204 ns | 0.0152 |      64 B |
   Collection_Optimal |              True |           0 |     16.91 ns |     14.96   ns |   0.8452 ns | 0.0057 |      24 B |
    Collection_System |              True |           0 |    228.47 ns |    175.86   ns |   9.9366 ns | 0.0226 |      96 B |

  Enumerable_System |                True |           0 |    205.970 ns |    18.3739 ns |   1.0382 ns | 0.0246 |     104 B |
  
    IList_FastLinq1 |                True |           0 |     43.34  ns |      27.63 ns |   1.5612 ns | 0.0172 |      72 B |
    IList_FastLinq2 |                True |           0 |     44.78  ns |      67.48 ns |   3.8127 ns | 0.0172 |      72 B |
      IList_FastLinqEager |          True |           0 |     14.56  ns |     2.967  ns |   0.1676 ns | 0.0057 |      24 B |
      IList_Optimal |                True |           0 |      7.771 ns |    14.2329 ns |   0.8042 ns | 0.0057 |      24 B |
       IList_System |                True |           0 |    229.667 ns |    72.9045 ns |   4.1192 ns | 0.0226 |      96 B |
       
     List_FastLinq1 |                True |           0 |     39.26  ns |      14.22 ns |   0.8037 ns | 0.0172 |      72 B |
     List_FastLinq2 |                True |           0 |     43.11  ns |      38.84 ns |   2.1947 ns | 0.0172 |      72 B |
       List_FastLinqEager |          True |           0 |     11.70  ns |     5.502  ns |   0.3109 ns | 0.0057 |      24 B |
       List_Optimal |                True |           0 |      4.899 ns |     2.8816 ns |   0.1628 ns | 0.0057 |      24 B |
        List_System |                True |           0 |    235.032 ns |    53.4636 ns |   3.0208 ns | 0.0226 |      96 B |

        
    Array_FastLinq1 |                True |          10 |    961.67  ns |     379.18 ns |  21.4245 ns | 0.0734 |     312 B |
    Array_FastLinq2 |                True |          10 |    309.29  ns |     365.56 ns |  20.6548 ns | 0.0739 |     312 B |
      Array_FastLinqEager |          True |          10 |    259.51  ns |    41.530  ns |   2.3465 ns | 0.0815 |     344 B |
      Array_Optimal |                True |          10 |     54.751 ns |    36.8685 ns |   2.0831 ns | 0.0533 |     224 B |
       Array_System |                True |          10 |  1,185.074 ns |   243.0475 ns |  13.7326 ns | 0.0763 |     328 B |
       
 Collection_FastLinq1 |              True |          10 |    609.86  ns |   321.47   ns |  18.1638 ns | 0.0868 |     368 B |
 Collection_FastLinq2 |              True |          10 |    584.25  ns |    26.90   ns |   1.5199 ns | 0.0868 |     368 B |
 Collection_FastLinqEager |          True |          10 |    316.78  ns |   509.499  ns |  28.7876 ns | 0.0911 |     384 B |
   Collection_Optimal |              True |          10 |    141.89  ns |    22.86   ns |   1.2918 ns | 0.0818 |     344 B |
    Collection_System |              True |          10 |    557.54  ns |    51.12   ns |   2.8886 ns | 0.0801 |     336 B |

  Enumerable_System |                True |          10 |    518.932 ns |   150.8249 ns |   8.5219 ns | 0.0811 |     344 B |
  
    IList_FastLinq1 |                True |          10 |    319.45  ns |     132.11 ns |   7.4647 ns | 0.0739 |     312 B |
    IList_FastLinq2 |                True |          10 |    284.22  ns |     133.90 ns |   7.5656 ns | 0.0739 |     312 B |
      IList_FastLinqEager |          True |          10 |    298.12  ns |    63.288  ns |   3.5759 ns | 0.0815 |     344 B |
      IList_Optimal |                True |          10 |     70.098 ns |    18.6882 ns |   1.0559 ns | 0.0533 |     224 B |
       IList_System |                True |          10 |    578.932 ns |   420.3889 ns |  23.7528 ns | 0.0801 |     336 B |
       
     List_FastLinq1 |                True |          10 |    267.58  ns |     143.46 ns |   8.1057 ns | 0.0739 |     312 B |
     List_FastLinq2 |                True |          10 |    259.81  ns |      34.34 ns |   1.9400 ns | 0.0739 |     312 B |
       List_FastLinqEager |          True |          10 |    255.45  ns |    95.489  ns |   5.3953 ns | 0.0815 |     344 B | TODO: How could this be slower than FastLinq2?
       List_Optimal |                True |          10 |     58.273 ns |    11.2320 ns |   0.6346 ns | 0.0533 |     224 B |
        List_System |                True |          10 |    588.647 ns |   521.5895 ns |  29.4708 ns | 0.0801 |     336 B |

        
    Array_FastLinq1 |                True |         100 |  9,287.84  ns |  10,385.13 ns | 586.7790 ns | 0.5798 |    2472 B |
    Array_FastLinq2 |                True |         100 |  2,581.00  ns |   1,977.07 ns | 111.7078 ns | 0.5875 |    2472 B |
      Array_FastLinqEager |          True |         100 |  2,618.63  ns | 3,572.471  ns | 201.8513 ns | 0.7668 |    3224 B |
      Array_Optimal |                True |         100 |    477.835 ns |    54.9507 ns |   3.1048 ns | 0.4816 |    2024 B |
       Array_System |                True |         100 | 10,247.428 ns | 1,985.1937 ns | 112.1671 ns | 0.5798 |    2488 B |
       
 Collection_FastLinq1 |              True |         100 |  3,134.22  ns |   499.81   ns |  28.2401 ns | 0.5989 |    2528 B |
 Collection_FastLinq2 |              True |         100 |  3,326.98  ns | 1,940.43   ns | 109.6381 ns | 0.5989 |    2528 B |
 Collection_FastLinqEager |          True |         100 |  2,617.80  ns |   506.436  ns |  28.6146 ns | 0.7744 |    3264 B |
   Collection_Optimal |              True |         100 |  1,178.34  ns | 1,392.01   ns |  78.6511 ns | 0.7668 |    3224 B |
    Collection_System |              True |         100 |  3,293.17  ns |    60.61   ns |   3.4247 ns | 0.5913 |    2496 B |

  Enumerable_System |                True |         100 |  2,938.318 ns |   496.3734 ns |  28.0460 ns | 0.5951 |    2504 B |
  
    IList_FastLinq1 |                True |         100 |  2,879.50  ns |   2,108.03 ns | 119.1077 ns | 0.5875 |    2472 B |
    IList_FastLinq2 |                True |         100 |  2,550.32  ns |     798.50 ns |  45.1170 ns | 0.5875 |    2472 B |
      IList_FastLinqEager |          True |         100 |  2,794.63  ns | 1,670.182  ns |  94.3684 ns | 0.7668 |    3224 B |
      IList_Optimal |                True |         100 |    637.413 ns |   122.9969 ns |   6.9496 ns | 0.4816 |    2024 B |
       IList_System |                True |         100 |  3,372.116 ns |   707.3350 ns |  39.9657 ns | 0.5913 |    2496 B |
       
     List_FastLinq1 |                True |         100 |  2,292.89  ns |     518.09 ns |  29.2729 ns | 0.5875 |    2472 B |
     List_FastLinq2 |                True |         100 |  2,476.30  ns |   2,752.76 ns | 155.5361 ns | 0.5875 |    2472 B |
       List_FastLinqEager |          True |         100 |  2,342.21  ns |   524.011  ns |  29.6076 ns | 0.7668 |    3224 B |
       List_Optimal |                True |         100 |    542.699 ns |   176.0695 ns |   9.9483 ns | 0.4816 |    2024 B |
        List_System |                True |         100 |  3,258.214 ns |   285.4893 ns |  16.1307 ns | 0.5913 |    2496 B |
     */

    /// <summary>
    /// BCL optimizes nothing
    /// FastLinq only accepts <see cref="System.Collections.IList"/>
    /// </summary>
    public class CastBenchmark
    {
        [Params(true)] public bool EnumerateAfterwards;

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
            var _ = Enumerable.Cast<object>(this.enumerable);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void Collection_System()
        {
            var _ = Enumerable.Cast<object>(this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "IList")]
        public void IList_System()
        {
            var _ = Enumerable.Cast<object>(this.ilist);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void List_System()
        {
            var _ = Enumerable.Cast<object>(this.list);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void Array_System()
        {
            var _ = Enumerable.Cast<object>(this.array);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }




        // Not implemented for IEnumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "FastLinq")]
        //public void FastLinq_FastLinq()
        //{
        //    var _ = FastLinq.Cast<object>(this.enumerable);
        //}
        
        [Benchmark]
        [BenchmarkCategory("FastLinq_2arg", "Collection")]
        public void Collection_FastLinq2()
        {
            var _ = FastLinq.Cast<int, object>(this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_2arg", "IList")]
        public void IList_FastLinq2()
        {
            var _ = FastLinq.Cast<int, object>(this.ilist);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_2arg", "List")]
        public void List_FastLinq2()
        {
            var _ = FastLinq.Cast<int, object>(this.list);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_2arg", "Array")]
        public void Array_FastLinq2()
        {
            var _ = FastLinq.Cast<int, object>(this.array);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_1arg", "Collection")]
        public void Collection_FastLinq1()
        {
            var _ = FastLinq.Cast<object>((ICollection)this.list);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_1arg", "IList")]
        public void IList_FastLinq1()
        {
            var _ = FastLinq.Cast<object>(this.ilist);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_1arg", "List")]
        public void List_FastLinq1()
        {
            var _ = FastLinq.Cast<object>(this.list);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_1arg", "Array")]
        public void Array_FastLinq1()
        {
            var _ = FastLinq.Cast<object>(this.array);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }


        [Benchmark]
        [BenchmarkCategory("FastLinq_Eager", "Collection")]
        public void Collection_FastLinqEager()
        {
            var _ = FastLinq.EagerCast<int, object>(this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_Eager", "IList")]
        public void IList_FastLinqEager()
        {
            var _ = FastLinq.EagerCast<int, object>(this.ilist);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_Eager", "List")]
        public void List_FastLinqEager()
        {
            var _ = FastLinq.EagerCast<int, object>(this.list);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq_Eager", "Array")]
        public void Array_FastLinqEager()
        {
            var _ = FastLinq.EagerCast<int, object>(this.array);

            if (EnumerateAfterwards)
            {
                foreach (var __ in _) ;
            }
        }




        // System is close enough
        //[Benchmark]
        //[BenchmarkCategory("Optimal", "Enumerable")]
        //public void Enumerable_Optimal()
        //{
        //    var _ = Enumerable.Cast<object>(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Collection_Optimal()
        {
            if (!this.EnumerateAfterwards && this.SizeOfInput > 0)
            {
                throw new InvalidOperationException("This method by it's nature enumerates");
            }

            var result = new object[this.collection.Count];
            int index = 0;
            foreach (var item in collection)
            {
                result[index++] = (object)item;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void IList_Optimal()
        {
            if (!this.EnumerateAfterwards && this.SizeOfInput > 0)
            {
                throw new InvalidOperationException("This method by it's nature enumerates");
            }

            int ilistCount = this.ilist.Count;
            var result = new object[ilistCount];
            for (int index = 0; index < ilistCount; index++)
            {
                var item = this.ilist[index];
                result[index++] = (object)item;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void List_Optimal()
        {
            if (!this.EnumerateAfterwards && this.SizeOfInput > 0)
            {
                throw new InvalidOperationException("This method by it's nature enumerates");
            }

            int listCount = this.list.Count;
            var result = new object[listCount];
            for (int index = 0; index < listCount; index++)
            {
                var item = this.list[index];
                result[index++] = (object)item;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Array_Optimal()
        {
            if (!this.EnumerateAfterwards && this.SizeOfInput > 0)
            {
                throw new InvalidOperationException("This method by it's nature enumerates");
            }

            int arrayCount = this.array.Length;
            var result = new object[arrayCount];
            for (int index = 0; index < arrayCount; index++)
            {
                var item = this.array[index];
                result[index++] = (object)item;
            }
        }
    }
}
