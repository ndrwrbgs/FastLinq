// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RealWorldBenchmark.cs" company="Microsoft Corporation">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Benchmark.Benchmarks
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using BenchmarkDotNet.Attributes;

    /*
     * 
                                  Method |         Mean |       Error |        StdDev |       Median |   Gen 0 | Allocated |
---------------------------------------- |-------------:|------------:|--------------:|-------------:|--------:|----------:|
                        FastLinq_LastTen |     28.25 ns |   0.5984 ns |     0.8582 ns |     28.08 ns |  0.0190 |      80 B |
                      Enumerable_LastTen |     37.59 ns |   0.7922 ns |     1.6182 ns |     37.05 ns |  0.0457 |     192 B |
              FastLinq_LastTen_Enumerate |    284.05 ns |   4.0441 ns |     3.7828 ns |    284.84 ns |  0.0286 |     120 B |
            Enumerable_LastTen_Enumerate |    661.66 ns |  13.1656 ns |    24.4034 ns |    660.82 ns |  0.1898 |     800 B |
            
                       FastLinq_Paginate |    130.29 ns |   0.6083 ns |     0.5079 ns |    130.09 ns |  0.0360 |     152 B |
                     Enumerable_Paginate |    318.50 ns |   6.8013 ns |     6.3620 ns |    316.55 ns |  0.0491 |     208 B |
             FastLinq_Paginate_Enumerate |    122.35 ns |   2.4658 ns |     3.4567 ns |    121.91 ns |  0.0360 |     152 B |
           Enumerable_Paginate_Enumerate |    331.32 ns |   4.1782 ns |     3.7039 ns |    331.14 ns |  0.0491 |     208 B |
           
          FastLinq_SecondToLastItemArray |     36.34 ns |   0.6906 ns |     0.6122 ns |     36.37 ns |  0.0133 |      56 B |
        Enumerable_SecondToLastItemArray |    195.74 ns |   3.8662 ns |     6.7713 ns |    193.82 ns |  0.1314 |     552 B |

     FastLinq_SecondToLastItemCollection |    179.09 ns |   3.8956 ns |     8.0450 ns |    176.79 ns |  0.0646 |     272 B |
   Enumerable_SecondToLastItemCollection |    149.97 ns |   2.8392 ns |     2.9157 ns |    149.45 ns |  0.0494 |     208 B |
   
                   FastLinq_SelectAField |    475.86 ns |   9.4237 ns |    10.4745 ns |    475.57 ns |  0.0582 |     248 B |
                 Enumerable_SelectAField |    682.23 ns |  13.5250 ns |    17.1047 ns |    677.61 ns |  0.1087 |     456 B |
         FastLinq_SelectAField_Enumerate |    563.32 ns |  10.3914 ns |     9.7201 ns |    562.11 ns |  0.0582 |     248 B |
       Enumerable_SelectAField_Enumerate |    750.47 ns |  11.3607 ns |     9.4867 ns |    747.93 ns |  0.1087 |     456 B |


     */
    public class RealWorldBenchmark
    {
        private IReadOnlyCollection<char> allLetters;
        private int[] intArray;
        private List<string> stringList;

        [GlobalSetup]
        public void Setup()
        {
            this.intArray = Enumerable.Range(0, 100).ToArray();
            this.allLetters = new HashSet<char>(Enumerable.Range((int) 'a', 'z' - 'a').Select(i => ((char) i)));
            this.stringList = this.allLetters.Select(c => c.ToString()).ToList();
        }

        [Benchmark]
        public void FastLinq_SelectAField_Lazy()
        {
            var _ = FastLinq.Select(this.stringList, str => str.Length);
        }

        [Benchmark]
        public void FastLinq_SelectAField_ToList()
        {
            List<int> _ = FastLinq.ToList(
                FastLinq.Select(this.stringList, str => str.Length));
        }

        [Benchmark]
        public void FastLinq_SelectAField_AndEnumerate()
        {
            var _ = FastLinq.Select(this.stringList, str => str.Length);

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }

        [Benchmark]
        public void FastLinq_LastTen_Lazy()
        {
            IReadOnlyList<int> _ = FastLinq.Reverse(
                FastLinq.Take(
                    FastLinq.Reverse(this.intArray),
                    10));
        }

        [Benchmark]
        public void FastLinq_LastTen_ToList()
        {
            IReadOnlyList<int> _ = FastLinq.ToList(
                FastLinq.Reverse(
                    FastLinq.Take(
                        FastLinq.Reverse(this.intArray),
                        10)));
        }

        [Benchmark]
        public void FastLinq_LastTen_AndEnumerate()
        {
            IReadOnlyList<int> _ = FastLinq.Reverse(
                FastLinq.Take(
                    FastLinq.Reverse(this.intArray),
                    10));

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }

        [Benchmark]
        public void FastLinq_SecondToLastItemCollection()
        {
            char _ = Enumerable.FirstOrDefault(
                FastLinq.Skip(
                    FastLinq.Reverse(this.allLetters),
                    1));
        }

        [Benchmark]
        public void FastLinq_SecondToLastItemArray()
        {
            int _ = FastLinq.FirstOrDefault(
                FastLinq.Skip(
                    FastLinq.Reverse(this.intArray),
                    1));
        }

        [Benchmark]
        public void FastLinq_Paginate_Lazy()
        {
            var _ = FastLinq.Take(
                FastLinq.Skip(this.stringList, 30),
                10);
        }

        [Benchmark]
        public void FastLinq_Paginate_ToList()
        {
            List<string> _ = FastLinq.ToList(
                FastLinq.Take(
                    FastLinq.Skip(this.stringList, 30),
                    10));
        }

        [Benchmark]
        public void FastLinq_Paginate_AndEnumerate()
        {
            var _ = FastLinq.Take(
                FastLinq.Skip(this.stringList, 30),
                10);

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }

        [Benchmark]
        public void Enumerable_SelectAField_Lazy()
        {
            var _ = Enumerable.Select(this.stringList, str => str.Length);
        }

        [Benchmark]
        public void Enumerable_SelectAField_ToList()
        {
            List<int> _ = Enumerable.ToList(
                Enumerable.Select(this.stringList, str => str.Length));
        }

        [Benchmark]
        public void Enumerable_SelectAField_AndEnumerate()
        {
            var _ = Enumerable.Select(this.stringList, str => str.Length);

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }

        [Benchmark]
        public void Enumerable_LastTen_Lazy()
        {
            var _ = Enumerable.Reverse(
                Enumerable.Take(
                    Enumerable.Reverse(this.intArray),
                    10));
        }

        [Benchmark]
        public void Enumerable_LastTen_ToList()
        {
            IReadOnlyList<int> _ = Enumerable.ToList(
                Enumerable.Reverse(
                    Enumerable.Take(
                        Enumerable.Reverse(this.intArray),
                        10)));
        }

        [Benchmark]
        public void Enumerable_LastTen_AndEnumerate()
        {
            var _ = Enumerable.Reverse(
                Enumerable.Take(
                    Enumerable.Reverse(this.intArray),
                    10));

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }

        [Benchmark]
        public void Enumerable_SecondToLastItemCollection()
        {
            char _ = Enumerable.FirstOrDefault(
                Enumerable.Skip(
                    Enumerable.Reverse(this.allLetters),
                    1));
        }

        [Benchmark]
        public void Enumerable_SecondToLastItemArray()
        {
            int _ = Enumerable.FirstOrDefault(
                Enumerable.Skip(
                    Enumerable.Reverse(this.intArray),
                    1));
        }

        [Benchmark]
        public void Enumerable_Paginate_Lazy()
        {
            var _ = Enumerable.Take(
                Enumerable.Skip(this.stringList, 30),
                10);
        }

        [Benchmark]
        public void Enumerable_Paginate_ToList()
        {
            List<string> _ = Enumerable.ToList(
                Enumerable.Take(
                    Enumerable.Skip(this.stringList, 30),
                    10));
        }

        [Benchmark]
        public void Enumerable_Paginate_AndEnumerate()
        {
            var _ = Enumerable.Take(
                Enumerable.Skip(this.stringList, 30),
                10);

            int i = 0;
            foreach (var item in _)
            {
                i++;
            }
        }


        // TODO: ArrayPool utility that can do Where w/o allocations
    }
}