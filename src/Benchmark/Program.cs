namespace Benchmark
{
    using System.Linq;

    using Benchmark.Benchmarks;
    using Benchmark.Collection;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Filters;
    using BenchmarkDotNet.Jobs;
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

            
            BenchmarkRunner.Run<ToDictionaryBenchmark>(
                DefaultConfig.Instance
                    .With(MemoryDiagnoser.Default)
                    .With(
                        Job.ShortRun
                            .With(CsProjClassicNetToolchain.Net46))
                    //.With(new CategoryFilter("Array"))
                    );
            //BenchmarkRunner.Run<SkipTakeListBenchmark>(
            //    DefaultConfig.Instance
            //        .With(MemoryDiagnoser.Default)
            //        .With(
            //            Job.ShortRun
            //                .With(CsProjClassicNetToolchain.Net47)));
            //BenchmarkRunner.Run<SkipTakeListBenchmark>(
            //    DefaultConfig.Instance
            //        .With(MemoryDiagnoser.Default)
            //        .With(
            //            Job.ShortRun
            //                .With(CsProjCoreToolchain.NetCoreApp11)));
            //BenchmarkRunner.Run<SkipTakeListBenchmark>(
            //    DefaultConfig.Instance
            //        .With(MemoryDiagnoser.Default)
            //        .With(
            //            Job.ShortRun
            //                .With(CsProjCoreToolchain.NetCoreApp12)));
        }
    }
}
