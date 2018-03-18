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
|    **Array_FastLinq** |  **False** |  **3.5967 ns** |  **0.3359 ns** | **0.0190 ns** |      **-** |       **0 B** |
|     Array_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|      Array_System |  False | 27.6127 ns |  1.5557 ns | 0.0879 ns |      - |       0 B |
| Collection_System |  False | 29.4083 ns |  5.7786 ns | 0.3265 ns | 0.0095 |      40 B |
| Enumerable_System |  False | 26.1367 ns | 10.1251 ns | 0.5721 ns | 0.0114 |      48 B |
|    IList_FastLinq |  False |  5.3702 ns |  0.8012 ns | 0.0453 ns |      - |       0 B |
|     IList_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|      IList_System |  False |  8.0901 ns |  3.8251 ns | 0.2161 ns |      - |       0 B |
|     List_FastLinq |  False |  3.5794 ns |  1.8754 ns | 0.1060 ns |      - |       0 B |
|      List_Optimal |  False |         NA |         NA |        NA |    N/A |       N/A |
|       List_System |  False |  6.3053 ns |  0.9930 ns | 0.0561 ns |      - |       0 B |
|    **Array_FastLinq** |   **True** |  **6.1103 ns** |  **2.1494 ns** | **0.1214 ns** |      **-** |       **0 B** |
|     Array_Optimal |   True |  0.1357 ns |  0.6642 ns | 0.0375 ns |      - |       0 B |
|      Array_System |   True | 30.0653 ns |  7.5179 ns | 0.4248 ns |      - |       0 B |
| Collection_System |   True | 38.0938 ns |  0.8362 ns | 0.0472 ns | 0.0095 |      40 B |
| Enumerable_System |   True | 34.0055 ns | 23.5945 ns | 1.3331 ns | 0.0114 |      48 B |
|    IList_FastLinq |   True |  9.2071 ns |  1.2783 ns | 0.0722 ns |      - |       0 B |
|     IList_Optimal |   True |  2.8094 ns |  3.3399 ns | 0.1887 ns |      - |       0 B |
|      IList_System |   True | 13.6689 ns | 12.8757 ns | 0.7275 ns |      - |       0 B |
|     List_FastLinq |   True |  5.6761 ns |  3.0811 ns | 0.1741 ns |      - |       0 B |
|      List_Optimal |   True |  0.7386 ns |  0.8877 ns | 0.0502 ns |      - |       0 B |
|       List_System |   True |  8.9761 ns |  2.4567 ns | 0.1388 ns |      - |       0 B |

Benchmarks with issues:
  SingleOrDefaultBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
  SingleOrDefaultBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
  SingleOrDefaultBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [HasAny=False]
