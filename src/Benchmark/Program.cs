namespace Benchmark
{
    using System;
    using System.Linq;

    using Benchmark.Benchmarks;
    using Benchmark.Collection;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Filters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Order;
    using BenchmarkDotNet.Running;
    using BenchmarkDotNet.Toolchains.CsProj;

    internal static class Program
    {
        private static void Main()
        {
            //var test = new SkipTakeListBenchmark();
            //test.realType = "list";
            //test.skip = 10;
            //test.take = 50;
            //test.collectionSize = 100;
            //test.EnumerateAfterwards = false;
            //test.Setup();

            //test.FastLinq();
            //return;
            
            IConfig config = DefaultConfig.Instance
                    .With(MemoryDiagnoser.Default)
                    .With(
                        Job.ShortRun
                            .With(CsProjClassicNetToolchain.Net46))
                    .With(
                        new DefaultOrderProvider(
                            SummaryOrderPolicy.Default,
                            MethodOrderPolicy.Alphabetical))
                .With(
                    new DisjunctionFilter(
                        new CategoryFilter("FastLinq_Eager")))
                ;

            //BenchmarkRunner.Run<AllBenchmark>(config);
            //BenchmarkRunner.Run<AnyBenchmark>(config);
            //BenchmarkRunner.Run<ConcatBenchmark>(config);
            //BenchmarkRunner.Run<CountBenchmark>(config);
            //BenchmarkRunner.Run<DefaultIfEmptyBenchmark>(config);
            //BenchmarkRunner.Run<EnumerableWithCountBenchmark>(config);
            //BenchmarkRunner.Run<HashSetBenchmark>(config);
            //BenchmarkRunner.Run<ReverseBenchmark>(config);
            //BenchmarkRunner.Run<ToArrayBenchmark>(config);
            //BenchmarkRunner.Run<ToDictionaryBenchmark>(config);


            BenchmarkRunner.Run<CastBenchmark>(config);
            //BenchmarkRunner.Run<TakeBenchmark>(config);
        }
    }
}
