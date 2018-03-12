``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|               Method | SizeOfInput |        Mean |       Error |    StdDev | Allocated |
|--------------------- |------------ |------------:|------------:|----------:|----------:|
|       **ContainsDirect** |           **0** |   **8.2075 ns** |   **0.8836 ns** | **0.0499 ns** |       **0 B** |
| ContainsViaInterface |           0 |   8.6671 ns |   1.6810 ns | 0.0950 ns |       0 B |
|         CopyToDirect |           0 |   3.8853 ns |   2.3839 ns | 0.1347 ns |       0 B |
|   CopyToViaInterface |           0 |   4.7271 ns |   4.3514 ns | 0.2459 ns |       0 B |
|          CountDirect |           0 |   0.0000 ns |   0.0000 ns | 0.0000 ns |       0 B |
|    CountViaInterface |           0 |   1.6647 ns |   1.4434 ns | 0.0816 ns |       0 B |
|       **ContainsDirect** |           **1** |   **7.8623 ns** |   **1.7508 ns** | **0.0989 ns** |       **0 B** |
| ContainsViaInterface |           1 |   9.1903 ns |   1.7538 ns | 0.0991 ns |       0 B |
|         CopyToDirect |           1 |   5.6922 ns |   1.1632 ns | 0.0657 ns |       0 B |
|   CopyToViaInterface |           1 |   6.9267 ns |   3.4703 ns | 0.1961 ns |       0 B |
|          CountDirect |           1 |   0.0181 ns |   0.5418 ns | 0.0306 ns |       0 B |
|    CountViaInterface |           1 |   1.6841 ns |   0.6953 ns | 0.0393 ns |       0 B |
|       **ContainsDirect** |         **100** |  **11.8118 ns** |   **1.4934 ns** | **0.0844 ns** |       **0 B** |
| ContainsViaInterface |         100 |  12.2557 ns |   1.7549 ns | 0.0992 ns |       0 B |
|         CopyToDirect |         100 | 216.8253 ns | 116.9192 ns | 6.6062 ns |       0 B |
|   CopyToViaInterface |         100 | 218.1284 ns |  14.4730 ns | 0.8177 ns |       0 B |
|          CountDirect |         100 |   0.0050 ns |   0.1530 ns | 0.0086 ns |       0 B |
|    CountViaInterface |         100 |   1.7094 ns |   1.8140 ns | 0.1025 ns |       0 B |
