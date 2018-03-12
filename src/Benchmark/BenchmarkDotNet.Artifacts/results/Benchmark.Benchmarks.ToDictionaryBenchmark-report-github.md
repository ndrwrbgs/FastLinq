``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | SizeOfInput |         Mean |         Error |      StdDev |   Gen 0 | Allocated |
|-------------------- |------------ |-------------:|--------------:|------------:|--------:|----------:|
| **Collection_FastLinq** |           **0** |     **47.25 ns** |      **5.208 ns** |   **0.2943 ns** |  **0.0286** |     **120 B** |
|   Collection_System |           0 |     54.48 ns |      7.510 ns |   0.4243 ns |  0.0286 |     120 B |
|   Enumerable_System |           0 |     55.55 ns |      5.734 ns |   0.3240 ns |  0.0305 |     128 B |
| **Collection_FastLinq** |           **1** |    **110.24 ns** |     **48.401 ns** |   **2.7347 ns** |  **0.0552** |     **232 B** |
|   Collection_System |           1 |    122.11 ns |     21.042 ns |   1.1889 ns |  0.0551 |     232 B |
|   Enumerable_System |           1 |    115.21 ns |     72.615 ns |   4.1029 ns |  0.0570 |     240 B |
| **Collection_FastLinq** |          **10** |    **402.42 ns** |    **219.953 ns** |  **12.4277 ns** |  **0.0930** |     **392 B** |
|   Collection_System |          10 |    606.22 ns |     19.579 ns |   1.1062 ns |  0.1936 |     816 B |
|   Enumerable_System |          10 |    552.13 ns |    207.003 ns |  11.6960 ns |  0.1955 |     824 B |
| **Collection_FastLinq** |        **1000** | **30,584.83 ns** |  **8,729.738 ns** | **493.2464 ns** |  **5.2490** |   **22247 B** |
|   Collection_System |        1000 | 43,196.54 ns |  9,599.573 ns | 542.3937 ns | 17.3340 |   73264 B |
|   Enumerable_System |        1000 | 38,854.24 ns | 10,584.991 ns | 598.0716 ns | 17.3340 |   73264 B |
