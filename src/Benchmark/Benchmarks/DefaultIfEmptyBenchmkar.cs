using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Collection
{
    /*
     * 
         Method | InputLength |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
--------------- |------------ |-----------:|----------:|----------:|-------:|----------:|
   System_Array |           0 | 11.0464 ns | 1.1780 ns | 0.0666 ns | 0.0152 |      64 B |
 FastLinq_Array |           0 |  7.1747 ns | 0.3224 ns | 0.0182 ns | 0.0076 |      32 B | < we could avoid allocation, but that could be dangerous
  Optimal_Array |           0 |  0.2406 ns | 0.4754 ns | 0.0269 ns |      - |       0 B |
   System_Array |          10 | 11.0866 ns | 0.6644 ns | 0.0375 ns | 0.0152 |      64 B |
 FastLinq_Array |          10 |  4.1937 ns | 1.8625 ns | 0.1052 ns |      - |       0 B |
  Optimal_Array |          10 |  0.0998 ns | 0.2597 ns | 0.0147 ns |      - |       0 B |
     */

    /// <summary>
    /// Enumerable.DefaultIfEmpty gets an enumerator.
    /// So Test Array, List, ICollection and IEnumerable
    /// .
    /// FastLinq behaves differently if there are no items
    /// </summary>
    public class DefaultIfEmptyBenchmkark
    {
        [Params(0, 10)] public int InputLength;

        private int[] array;
        private List<int> list;
        private ReadOnlyCollection<int> collection;
        private IEnumerable<int> enumerable;

        [GlobalSetup]
        public void Setup()
        {
            this.enumerable = Enumerable.Range(0, this.InputLength);
            this.array = enumerable.ToArray();
            this.list = enumerable.ToList();
            this.collection = new ReadOnlyCollection<int>(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Enumerable")]
        public void System_Enumerable()
        {
            var _ = Enumerable.DefaultIfEmpty(this.enumerable);
        }

        [Benchmark]
        [BenchmarkCategory("System", "List")]
        public void System_List()
        {
            var _ = Enumerable.DefaultIfEmpty(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Array")]
        public void System_Array()
        {
            var _ = Enumerable.DefaultIfEmpty(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Collection")]
        public void System_Collection()
        {
            var _ = Enumerable.DefaultIfEmpty(this.collection);
        }

        // Not implemented by FastLinq for Enumerable
        //[Benchmark]
        //[BenchmarkCategory("FastLinq", "Enumerable")]
        //public void FastLinq_Enumerable()
        //{
        //    var _ = FastLinq.DefaultIfEmpty(this.enumerable);
        //}

        [Benchmark]
        [BenchmarkCategory("FastLinq", "List")]
        public void FastLinq_List()
        {
            var _ = FastLinq.DefaultIfEmpty(this.list);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Array")]
        public void FastLinq_Array()
        {
            var _ = FastLinq.DefaultIfEmpty(this.array);
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Collection")]
        public void FastLinq_Collection()
        {
            var _ = FastLinq.DefaultIfEmpty(this.collection);
        }

        // TODO: Optimal perhaps could be faster by being lazy
        [Benchmark]
        [BenchmarkCategory("Optimal", "Enumerable")]
        public void Optimal_Enumerable()
        {
            // System is pretty close to optimal for IEnumerable, good enough for now
            System_Enumerable();
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "List")]
        public void Optimal_List()
        {
            List<int> _;
            if (this.list.Count > 0)
            {
                _ = this.list;
            }
            else
            {
                // TODO: With a singleton copy-on-write list here, could optimize further
                _ = new List<int>(1) { default(int) };
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "IList")]
        public void Optimal_IList()
        {
            IList<int> _;
            if (this.list.Count > 0)
            {
                _ = this.list;
            }
            else
            {
                _ = DefaultArray;
            }
        }

        private static readonly int[] DefaultArray = new int[1] { default(int) };

        [Benchmark]
        [BenchmarkCategory("Optimal", "Array")]
        public void Optimal_Array()
        {
            int[] _;
            if (this.array.Length > 0)
            {
                _ = this.array;
            }
            else
            {
                _ = DefaultArray;
            }
        }

        [Benchmark]
        [BenchmarkCategory("Optimal", "Collection")]
        public void Optimal_Collection()
        {
            ICollection<int> _;
            if (this.collection.Count > 0)
            {
                _ = this.collection;
            }
            else
            {
                _ = DefaultArray;
            }
        }
    }
}
