using System.Collections.Generic;
using System.Linq;

namespace Benchmark.Benchmarks
{
    using System;
    using System.Collections.ObjectModel;

    using BenchmarkDotNet.Attributes;

    /*
     * Any results with Collection are invalid - they were often using LIST
     *
     * 
                  Method | EnumerateAfterwards |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
------------------------ |-------------------- |------------:|------------:|-----------:|-------:|----------:|
       System_Enumerable |               False |  14.9889 ns |   6.8148 ns |  0.3850 ns | 0.0171 |      72 B |
             System_List |               False |  12.7545 ns |   2.5871 ns |  0.1462 ns | 0.0171 |      72 B |
            System_Array |               False |  13.9155 ns |   3.1562 ns |  0.1783 ns | 0.0171 |      72 B |
           FastLinq_List |               False |   8.1703 ns |   5.2336 ns |  0.2957 ns | 0.0076 |      32 B |
          FastLinq_Array |               False |   8.9049 ns |   4.1327 ns |  0.2335 ns | 0.0076 |      32 B |
      Optimal_Enumerable |               False |   0.2338 ns |   0.6269 ns |  0.0354 ns |      - |       0 B |
            Optimal_List |               False |   0.3910 ns |   0.7865 ns |  0.0444 ns |      - |       0 B |
           Optimal_Array |               False |   0.3159 ns |   0.7708 ns |  0.0436 ns |      - |       0 B |
       System_Enumerable |                True | 339.9237 ns | 200.4585 ns | 11.3263 ns | 0.0401 |     168 B |
             System_List |                True | 380.0913 ns | 119.3039 ns |  6.7409 ns | 0.0362 |     152 B |
            System_Array |                True | 349.8559 ns | 519.1236 ns | 29.3314 ns | 0.0319 |     136 B |
           FastLinq_List |                True | 201.5675 ns | 122.5967 ns |  6.9269 ns | 0.0074 |      32 B |
          FastLinq_Array |                True | 204.2382 ns | 191.0284 ns | 10.7935 ns | 0.0074 |      32 B |
      Optimal_Enumerable |                True | 138.9611 ns |  18.9528 ns |  1.0709 ns | 0.0226 |      96 B |
            Optimal_List |                True |  18.1582 ns |   1.5240 ns |  0.0861 ns |      - |       0 B |
           Optimal_Array |                True |  11.6440 ns |   4.5830 ns |  0.2589 ns |      - |       0 B |
           
       System_Collection |               False |  13.5308 ns |   9.9896 ns |  0.5644 ns | 0.0171 |      72 B |
   System_CollectionList |               False |  13.4528 ns |  11.1909 ns |  0.6323 ns | 0.0171 |      72 B |
   System_ListCollection |               False |  13.8273 ns |  13.9756 ns |  0.7896 ns | 0.0172 |      72 B |
     FastLinq_Collection |               False |   8.3216 ns |   5.0284 ns |  0.2841 ns | 0.0076 |      32 B |
 FastLinq_CollectionList |               False |   8.1661 ns |   6.8071 ns |  0.3846 ns | 0.0076 |      32 B |
 FastLinq_ListCollection |               False |   9.1397 ns |  19.7583 ns |  1.1164 ns | 0.0076 |      32 B |
      Optimal_Collection |               False |   0.5894 ns |   1.0876 ns |  0.0615 ns |      - |       0 B |
  Optimal_CollectionList |               False |   0.6941 ns |   0.4599 ns |  0.0260 ns |      - |       0 B |
  Optimal_ListCollection |               False |   0.6726 ns |   1.1209 ns |  0.0633 ns |      - |       0 B |
       System_Collection |                True | 391.4323 ns | 185.4428 ns | 10.4779 ns | 0.0362 |     152 B |
   System_CollectionList |                True | 382.3359 ns | 205.4404 ns | 11.6078 ns | 0.0362 |     152 B |
   System_ListCollection |                True | 366.5032 ns |  94.8234 ns |  5.3577 ns | 0.0362 |     152 B |
     FastLinq_Collection |                True | 310.1859 ns |  82.8307 ns |  4.6801 ns | 0.0072 |      32 B |
 FastLinq_CollectionList |                True | 289.9572 ns |  83.7613 ns |  4.7327 ns | 0.0072 |      32 B |
 FastLinq_ListCollection |                True | 253.6210 ns | 167.8290 ns |  9.4826 ns | 0.0074 |      32 B |
      Optimal_Collection |                True | 244.5556 ns | 500.9399 ns | 28.3040 ns | 0.0188 |      80 B |
  Optimal_CollectionList |                True | 123.8851 ns |  78.3213 ns |  4.4253 ns | 0.0094 |      40 B |
  Optimal_ListCollection |                True | 115.9664 ns |  33.3230 ns |  1.8828 ns | 0.0094 |      40 B |
     */

    /// <summary>
    /// Enumerable.Concat just uses IEnumerator, so List, Array, IEnumerable
    /// 
    /// FastLinq optimizes ICollection and IList+IList
    /// </summary>
    public class ConcatBenchmark
    {
        /// <summary>
        /// Probably best to isolate the testing of the enumeration to the underlying class
        /// but since I'm here right now and thinking about the implementation of ICollection+IList,
        /// adding the test here
        /// </summary>
        [Params(true, false)] public bool EnumerateAfterwards;

        private int[] array;
        private List<int> list;
        // TODO: For all tests, ReadOnlyCollection implements IList - did we mean to have an ICollection? -- if so we also probably need a non-list IList (e.g. ReadOnlyCollection)
        // TODO: ReverseBenchmark corrects this mostly
        private ReadOnlyCollection<int> collection;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, 10);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var concat = Enumerable.Concat(this.enumerable, this.enumerable);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var concat = Enumerable.Concat(this.collection, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void System_CollectionList()
        {
            var concat = Enumerable.Concat(this.collection, this.list);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection", "List")]
        public void System_ListCollection()
        {
            var concat = Enumerable.Concat(this.list, this.collection);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var concat = Enumerable.Concat(this.list, this.list);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var concat = Enumerable.Concat(this.array, this.array);

            if (EnumerateAfterwards)
            {
                foreach (var item in concat) ;
            }
        }





        // Not implemented for FastLinq
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var concat = FastLinq.Concat(this.enumerable, this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var concat = FastLinq.Concat(this.collection, this.collection);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void FastLinq_CollectionList()
        {
            var concat = FastLinq.Concat(this.collection, this.list);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection", "List")]
        public void FastLinq_ListCollection()
        {
            var concat = FastLinq.Concat(this.list, this.collection);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var concat = FastLinq.Concat(this.list, this.list);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void FastLinq_Array()
        {
            var concat = FastLinq.Concat(this.array, this.array);

            if (EnumerateAfterwards)
            {
                int concatCount = concat.Count;
                for (int i = 0; i < concatCount; i++)
                {
                    var item = concat[i];
                }
            }
        }



        
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Optimal_Enumerable()
        {
            var first = this.enumerable;
            var second = this.enumerable;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;
                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Optimal_Collection()
        {
            var first = this.collection;
            var second = this.collection;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;
                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection", "List")]
        public void Optimal_CollectionList()
        {
            var first = this.collection;
            var second = this.list;

            if (this.EnumerateAfterwards)
            {
                foreach (var item in first) ;

                var secondCount = second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection", "List")]
        public void Optimal_ListCollection()
        {
            var first = this.list;
            var second = this.collection;

            if (this.EnumerateAfterwards)
            {
                var firstCount = first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                foreach (var item in second) ;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void Optimal_List()
        {
            var first = this.list;
            var second = this.list;

            if (EnumerateAfterwards)
            {
                var firstCount = first.Count;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                var secondCount = second.Count;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Optimal_Array()
        {
            var first = this.array;
            var second = this.array;

            if (EnumerateAfterwards)
            {
                var firstCount = first.Length;
                for (int i = 0; i < firstCount; i++)
                {
                    var item = first[i];
                }

                var secondCount = second.Length;
                for (int i = 0; i < secondCount; i++)
                {
                    var item = second[i];
                }
            }
        }
    }
}
