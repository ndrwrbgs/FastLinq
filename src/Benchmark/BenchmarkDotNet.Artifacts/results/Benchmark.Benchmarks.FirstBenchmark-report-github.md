``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|            Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
|------------------ |-----------:|-----------:|----------:|-------:|----------:|
|    Array_FastLinq |  5.9220 ns |  0.3545 ns | 0.0200 ns |      - |       0 B |
|     Array_Optimal |  0.0000 ns |  0.0000 ns | 0.0000 ns |      - |       0 B |
|      Array_System | 30.8196 ns |  7.9123 ns | 0.4471 ns |      - |       0 B |
| Collection_System | 32.6562 ns | 19.9903 ns | 1.1295 ns | 0.0095 |      40 B |
| Enumerable_System | 29.0500 ns |  9.0051 ns | 0.5088 ns | 0.0114 |      48 B |
|    IList_FastLinq |  9.2755 ns |  4.0314 ns | 0.2278 ns |      - |       0 B |
|     IList_Optimal |  2.4384 ns |  0.0902 ns | 0.0051 ns |      - |       0 B |
|      IList_System | 11.5500 ns |  4.3098 ns | 0.2435 ns |      - |       0 B |
|     List_FastLinq |  5.6014 ns |  0.9020 ns | 0.0510 ns |      - |       0 B |
|      List_Optimal |  0.6222 ns |  0.6949 ns | 0.0393 ns |      - |       0 B |
|       List_System |  8.1241 ns |  2.1128 ns | 0.1194 ns |      - |       0 B |
