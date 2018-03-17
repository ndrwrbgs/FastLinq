``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |---------:|----------:|----------:|-------:|----------:|
| Array_FastLinq_Some | 53.55 ns |  4.603 ns | 0.2601 ns |      - |       0 B |
|   Array_System_Some | 81.83 ns | 25.702 ns | 1.4522 ns | 0.0075 |      32 B |
