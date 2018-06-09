using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark.Benchmarks
{
    using System.Collections;

    using BenchmarkDotNet.Attributes;

    /*
    Unfair comparison, System is not doing Cast
    
         Method | ItemType | SizeOfInput |      Mean |      Error |    StdDev | Allocated |
--------------- |--------- |------------ |----------:|-----------:|----------:|----------:|
          Count |    Array |         100 |  2.377 ns |  0.2055 ns | 0.0116 ns |       0 B |
 FastLinq_Count |    Array |         100 |  4.359 ns |  5.8721 ns | 0.3318 ns |       0 B |

          Index |    Array |         100 | 16.476 ns |  3.4417 ns | 0.1945 ns |       0 B |
 FastLinq_Index |    Array |         100 | 29.962 ns |  4.6489 ns | 0.2627 ns |       0 B |

          Count |     List |         100 |  1.328 ns |  0.0236 ns | 0.0013 ns |       0 B |
 FastLinq_Count |     List |         100 |  4.507 ns |  8.6761 ns | 0.4902 ns |       0 B |

          Index |     List |         100 |  2.400 ns |  1.4062 ns | 0.0795 ns |       0 B |
 FastLinq_Index |     List |         100 | 15.312 ns | 16.5262 ns | 0.9338 ns |       0 B |
     */

    public class CastList2Benchmark
    {
        [Params(
            UnderlyingItemType.Array,
            UnderlyingItemType.List)]
        public UnderlyingItemType ItemType;

        [Params(100)] public int SizeOfInput;

        private IReadOnlyList<object> CastList;
        private IList underlying;

        [GlobalSetup]
        public void Setup()
        {
            switch (this.ItemType)
            {
                case UnderlyingItemType.Array:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).Select(i => i.ToString()).ToArray();
                    break;
                case UnderlyingItemType.List:
                    this.underlying = Enumerable.Range(0, this.SizeOfInput).Select(i => i.ToString()).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            this.CastList = FastLinq.Cast<object>(
                this.underlying);
        }

        [Benchmark]
        [BenchmarkCategory("System", "Count")]
        public void Count()
        {
            var _ = this.underlying.Count;
        }

        [Benchmark]
        [BenchmarkCategory("System", "Index")]
        public void Index()
        {
            var _ = this.underlying[0];
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Count")]
        public void FastLinq_Count()
        {
            var _ = this.CastList.Count;
        }

        [Benchmark]
        [BenchmarkCategory("FastLinq", "Index")]
        public void FastLinq_Index()
        {
            var _ = this.CastList[0];
        }


        public enum UnderlyingItemType
        {
            List,
            Array
        }
    }
}
