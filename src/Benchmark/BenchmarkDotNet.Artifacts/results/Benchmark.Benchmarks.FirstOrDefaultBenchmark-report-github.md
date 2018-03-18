``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|            Method | HasAny |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
|------------------ |------- |-----------:|-----------:|----------:|-------:|----------:|
|    **Array_FastLinq** |  **False** |  **3.7506 ns** |  **1.7448 ns** | **0.0986 ns** |      **-** |       **0 B** |
|     Array_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|      Array_System |  False | 28.6670 ns |  2.9491 ns | 0.1666 ns |      - |       0 B |
| Collection_System |  False | 28.1842 ns | 11.1193 ns | 0.6283 ns | 0.0095 |      40 B |
| Enumerable_System |  False | 28.4303 ns | 24.6394 ns | 1.3922 ns | 0.0114 |      48 B |
|    IList_FastLinq |  False |  5.9616 ns | 11.1510 ns | 0.6301 ns |      - |       0 B |
|     IList_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|      IList_System |  False |  7.8960 ns |  1.3654 ns | 0.0771 ns |      - |       0 B |
|     List_FastLinq |  False |  3.5190 ns |  1.3889 ns | 0.0785 ns |      - |       0 B |
|      List_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|       List_System |  False |  6.3368 ns |  1.7689 ns | 0.0999 ns |      - |       0 B |
|    **Array_FastLinq** |   **True** |  **6.1318 ns** |  **2.3143 ns** | **0.1308 ns** |      **-** |       **0 B** |
|     Array_Optimal |   True |  0.0248 ns |  0.1570 ns | 0.0089 ns |      - |       0 B |
|      Array_System |   True | 36.5153 ns | 99.1339 ns | 5.6012 ns |      - |       0 B |
| Collection_System |   True | 40.1723 ns | 73.8663 ns | 4.1736 ns | 0.0095 |      40 B |
| Enumerable_System |   True | 30.8741 ns | 16.9167 ns | 0.9558 ns | 0.0114 |      48 B |
|    IList_FastLinq |   True |  9.8742 ns | 13.7507 ns | 0.7769 ns |      - |       0 B |
|     IList_Optimal |   True |  2.8608 ns |  0.7335 ns | 0.0414 ns |      - |       0 B |
|      IList_System |   True | 12.4725 ns |  4.6488 ns | 0.2627 ns |      - |       0 B |
|     List_FastLinq |   True |  6.1468 ns |  1.9280 ns | 0.1089 ns |      - |       0 B |
|      List_Optimal |   True |  0.7859 ns |  0.4348 ns | 0.0246 ns |      - |       0 B |
|       List_System |   True |  8.7282 ns |  2.2273 ns | 0.1258 ns |      - |       0 B |

Benchmarks with issues:
  FirstOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
  FirstOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
  FirstOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
