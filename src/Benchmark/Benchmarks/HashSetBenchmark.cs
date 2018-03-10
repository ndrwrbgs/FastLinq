using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using BenchmarkDotNet.Attributes;

    /*
     *
               Method | SizeOfInput |        Mean |      Error |    StdDev | Allocated |
--------------------- |------------ |------------:|-----------:|----------:|----------:|
       ContainsDirect |           0 |   8.0891 ns |  3.0855 ns | 0.1743 ns |       0 B |
 ContainsViaInterface |           0 |   8.6354 ns |  2.8752 ns | 0.1625 ns |       0 B |
         CopyToDirect |           0 |   3.6926 ns |  3.1324 ns | 0.1770 ns |       0 B |
   CopyToViaInterface |           0 |   4.7780 ns |  2.8098 ns | 0.1588 ns |       0 B |
          CountDirect |           0 |   0.0000 ns |  0.0000 ns | 0.0000 ns |       0 B |
    CountViaInterface |           0 |   1.6710 ns |  1.1001 ns | 0.0622 ns |       0 B |
       ContainsDirect |           1 |   8.0362 ns |  6.9193 ns | 0.3910 ns |       0 B |
 ContainsViaInterface |           1 |   8.9115 ns |  0.8119 ns | 0.0459 ns |       0 B |
         CopyToDirect |           1 |   5.7880 ns |  2.9302 ns | 0.1656 ns |       0 B |
   CopyToViaInterface |           1 |   6.8646 ns |  2.5265 ns | 0.1427 ns |       0 B |
          CountDirect |           1 |   0.0000 ns |  0.0000 ns | 0.0000 ns |       0 B |
    CountViaInterface |           1 |   1.6377 ns |  1.9788 ns | 0.1118 ns |       0 B |
       ContainsDirect |         100 |  11.2285 ns |  2.7729 ns | 0.1567 ns |       0 B |
 ContainsViaInterface |         100 |  11.9377 ns |  7.1724 ns | 0.4053 ns |       0 B |
         CopyToDirect |         100 | 213.8980 ns | 34.1613 ns | 1.9302 ns |       0 B |
   CopyToViaInterface |         100 | 215.3195 ns | 70.9116 ns | 4.0066 ns |       0 B |
          CountDirect |         100 |   0.0253 ns |  0.3934 ns | 0.0222 ns |       0 B |
    CountViaInterface |         100 |   1.7035 ns |  0.7346 ns | 0.0415 ns |       0 B | 
     */
    public class HashSetBenchmark
    {
        [Params(0, 1, 100)] public int SizeOfInput;

        // HashSet is ICollection, not IList, and has a struct enumerator
        private HashSet<int> directCollection;

        private ICollection<int> collectionViaInterface;

        private int[] destination;
        [GlobalSetup]
        public void Setup()
        {
            this.collectionViaInterface = new HashSet<int>(Enumerable.Range(0, this.SizeOfInput));
            this.directCollection = new HashSet<int>(Enumerable.Range(0, this.SizeOfInput));
            this.destination = new int[this.SizeOfInput];
        }

        [Benchmark]
        public bool ContainsDirect()
        {
            return this.directCollection.Contains(5);
        }

        [Benchmark]
        public void CopyToDirect()
        {
            this.directCollection.CopyTo(this.destination, 0);
        }

        [Benchmark]
        public int CountDirect()
        {
            return this.directCollection.Count;
        }

        [Benchmark]
        public bool ContainsViaInterface()
        {
            return this.collectionViaInterface.Contains(5);
        }

        [Benchmark]
        public void CopyToViaInterface()
        {
            this.collectionViaInterface.CopyTo(this.destination, 0);
        }

        [Benchmark]
        public int CountViaInterface()
        {
            return this.collectionViaInterface.Count;
        }
    }
}
