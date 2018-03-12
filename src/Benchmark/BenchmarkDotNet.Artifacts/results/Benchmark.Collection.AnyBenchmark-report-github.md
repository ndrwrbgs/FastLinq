``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |-----------:|----------:|----------:|-------:|----------:|
|      Array_FastLinq |  3.7524 ns | 0.1898 ns | 0.0107 ns |      - |       0 B |
|       Array_Optimal |  0.0247 ns | 0.2811 ns | 0.0159 ns |      - |       0 B |
|        Array_System | 15.8415 ns | 1.7249 ns | 0.0975 ns | 0.0076 |      32 B |
| Collection_FastLinq |  3.7182 ns | 0.2384 ns | 0.0135 ns |      - |       0 B |
|  Collection_Optimal |  0.0300 ns | 0.9201 ns | 0.0520 ns |      - |       0 B |
|   Collection_System | 20.9815 ns | 6.2517 ns | 0.3532 ns | 0.0095 |      40 B |
|  Enumerable_Optimal | 18.9509 ns | 5.0045 ns | 0.2828 ns | 0.0114 |      48 B |
|   Enumerable_System | 19.3359 ns | 4.3087 ns | 0.2435 ns | 0.0114 |      48 B |
|      IList_FastLinq |  6.1449 ns | 2.4416 ns | 0.1380 ns |      - |       0 B |
|       IList_Optimal |  2.3940 ns | 0.1831 ns | 0.0103 ns |      - |       0 B |
|        IList_System | 21.1968 ns | 8.0429 ns | 0.4544 ns | 0.0095 |      40 B |
|       List_FastLinq |  3.7354 ns | 0.8272 ns | 0.0467 ns |      - |       0 B |
|        List_Optimal |  0.1203 ns | 1.1367 ns | 0.0642 ns |      - |       0 B |
|         List_System | 19.4054 ns | 6.0312 ns | 0.3408 ns | 0.0095 |      40 B |
