``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
| Method |   ItemType | SizeOfInput |     Mean |     Error |    StdDev | Allocated |
|------- |----------- |------------ |---------:|----------:|----------:|----------:|
|  **Count** | **Collection** |           **0** | **3.503 ns** | **1.9773 ns** | **0.1117 ns** |       **0 B** |
|  **Count** | **Collection** |           **1** | **3.522 ns** | **0.5653 ns** | **0.0319 ns** |       **0 B** |
|  **Count** | **Collection** |         **100** | **3.498 ns** | **0.5581 ns** | **0.0315 ns** |       **0 B** |
|  **Count** | **Enumerable** |           **0** | **3.500 ns** | **0.9057 ns** | **0.0512 ns** |       **0 B** |
|  **Count** | **Enumerable** |           **1** | **3.459 ns** | **1.1193 ns** | **0.0632 ns** |       **0 B** |
|  **Count** | **Enumerable** |         **100** | **3.555 ns** | **1.0392 ns** | **0.0587 ns** |       **0 B** |
|  **Count** |       **List** |           **0** | **3.436 ns** | **1.2366 ns** | **0.0699 ns** |       **0 B** |
|  **Count** |       **List** |           **1** | **3.405 ns** | **0.9953 ns** | **0.0562 ns** |       **0 B** |
|  **Count** |       **List** |         **100** | **3.358 ns** | **0.3812 ns** | **0.0215 ns** |       **0 B** |
