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
|    Array_FastLinq |  6.7915 ns |  7.3322 ns | 0.4143 ns |      - |       0 B |
|     Array_Optimal |  0.0000 ns |  0.0000 ns | 0.0000 ns |      - |       0 B |
|      Array_System | 32.8256 ns | 11.2725 ns | 0.6369 ns |      - |       0 B |
| Collection_System | 42.2858 ns | 16.8478 ns | 0.9519 ns | 0.0095 |      40 B |
| Enumerable_System | 33.6922 ns | 11.4555 ns | 0.6473 ns | 0.0114 |      48 B |
|    IList_FastLinq |  9.9858 ns |  4.9407 ns | 0.2792 ns |      - |       0 B |
|     IList_Optimal |  2.5592 ns |  1.8078 ns | 0.1021 ns |      - |       0 B |
|      IList_System | 11.8506 ns |  5.1590 ns | 0.2915 ns |      - |       0 B |
|     List_FastLinq |  6.0527 ns |  4.7905 ns | 0.2707 ns |      - |       0 B |
|      List_Optimal |  0.7265 ns |  1.4875 ns | 0.0840 ns |      - |       0 B |
|       List_System |  9.0583 ns |  5.4329 ns | 0.3070 ns |      - |       0 B |
