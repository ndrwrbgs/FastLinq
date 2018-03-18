``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|   Method | EnumerateAfterwards |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|--------- |-------------------- |----------:|----------:|----------:|-------:|----------:|
| **FastLinq** |               **False** |  **4.444 ns** | **0.6401 ns** | **0.0362 ns** | **0.0057** |      **24 B** |
|   System |               False |  3.882 ns | 0.6009 ns | 0.0340 ns |      - |       0 B |
| **FastLinq** |                **True** | **20.972 ns** | **5.3893 ns** | **0.3045 ns** | **0.0057** |      **24 B** |
|   System |                True | 19.837 ns | 3.4047 ns | 0.1924 ns |      - |       0 B |
