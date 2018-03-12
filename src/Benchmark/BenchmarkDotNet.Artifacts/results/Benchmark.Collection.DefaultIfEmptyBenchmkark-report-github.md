``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | InputLength |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|--------------- |------------ |-----------:|----------:|----------:|-------:|----------:|
|   **Array_System** |           **0** | **11.0464 ns** | **1.1780 ns** | **0.0666 ns** | **0.0152** |      **64 B** |
| Array_FastLinq |           0 |  7.1747 ns | 0.3224 ns | 0.0182 ns | 0.0076 |      32 B |
|  Array_Optimal |           0 |  0.2406 ns | 0.4754 ns | 0.0269 ns |      - |       0 B |
|   **Array_System** |          **10** | **11.0866 ns** | **0.6644 ns** | **0.0375 ns** | **0.0152** |      **64 B** |
| Array_FastLinq |          10 |  4.1937 ns | 1.8625 ns | 0.1052 ns |      - |       0 B |
|  Array_Optimal |          10 |  0.0998 ns | 0.2597 ns | 0.0147 ns |      - |       0 B |
