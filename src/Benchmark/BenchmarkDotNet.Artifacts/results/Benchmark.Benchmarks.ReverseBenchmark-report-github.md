``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards |        Mean |      Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------:|-----------:|----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |   **8.0114 ns** |  **2.1127 ns** | **0.1194 ns** | **0.0057** |      **24 B** |
|       Array_Optimal |               False |   0.5293 ns |  0.0828 ns | 0.0047 ns |      - |       0 B |
|        Array_System |               False |  13.5870 ns |  6.1365 ns | 0.3467 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |  24.6204 ns |  4.3334 ns | 0.2448 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          NA |         NA |        NA |    N/A |       N/A |
|   Collection_System |               False |  13.3149 ns |  4.7825 ns | 0.2702 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          NA |         NA |        NA |    N/A |       N/A |
|   Enumerable_System |               False |  13.4019 ns |  6.8572 ns | 0.3874 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |   8.1743 ns |  3.0403 ns | 0.1718 ns | 0.0057 |      24 B |
|       IList_Optimal |               False |   0.5813 ns |  0.4943 ns | 0.0279 ns |      - |       0 B |
|        IList_System |               False |  13.0546 ns |  5.0325 ns | 0.2843 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |   8.0956 ns |  3.4619 ns | 0.1956 ns | 0.0057 |      24 B |
|        List_Optimal |               False |   0.5255 ns |  0.7509 ns | 0.0424 ns |      - |       0 B |
|         List_System |               False |  13.1851 ns |  2.1992 ns | 0.1243 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** | **105.5477 ns** |  **4.4901 ns** | **0.2537 ns** | **0.0056** |      **24 B** |
|       Array_Optimal |                True |   8.4670 ns |  0.9808 ns | 0.0554 ns |      - |       0 B |
|        Array_System |                True | 201.0022 ns | 27.8874 ns | 1.5757 ns | 0.0303 |     128 B |
| Collection_FastLinq |                True | 185.0265 ns | 72.8083 ns | 4.1138 ns | 0.0379 |     160 B |
|  Collection_Optimal |                True |          NA |         NA |        NA |    N/A |       N/A |
|   Collection_System |                True | 159.5309 ns | 57.7379 ns | 3.2623 ns | 0.0303 |     128 B |
|  Enumerable_Optimal |                True |          NA |         NA |        NA |    N/A |       N/A |
|   Enumerable_System |                True | 302.6076 ns | 50.5376 ns | 2.8555 ns | 0.0701 |     296 B |
|      IList_FastLinq |                True | 154.5498 ns | 41.2891 ns | 2.3329 ns | 0.0055 |      24 B |
|       IList_Optimal |                True |  38.5731 ns |  7.0462 ns | 0.3981 ns |      - |       0 B |
|        IList_System |                True | 170.7278 ns |  1.9816 ns | 0.1120 ns | 0.0303 |     128 B |
|       List_FastLinq |                True | 101.7380 ns | 13.7987 ns | 0.7797 ns | 0.0056 |      24 B |
|        List_Optimal |                True |  13.7614 ns |  3.9420 ns | 0.2227 ns |      - |       0 B |
|         List_System |                True | 172.2000 ns | 48.6646 ns | 2.7496 ns | 0.0303 |     128 B |

Benchmarks with issues:
  ReverseBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False]
  ReverseBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False]
  ReverseBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True]
  ReverseBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True]
