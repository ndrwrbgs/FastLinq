``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput |     Mean |      Error |    StdDev |
|--------------- |--------- |------------ |---------:|-----------:|----------:|
|          **Count** |    **Array** |         **100** | **1.485 ns** |  **1.4620 ns** | **0.0826 ns** |
| FastLinq_Count |    Array |         100 | 3.769 ns |  4.8384 ns | 0.2734 ns |
| FastLinq_Index |    Array |         100 | 5.657 ns |  2.9515 ns | 0.1668 ns |
|          Index |    Array |         100 | 2.976 ns |  1.7518 ns | 0.0990 ns |
|          **Count** |     **List** |         **100** | **2.494 ns** |  **2.3219 ns** | **0.1312 ns** |
| FastLinq_Count |     List |         100 | 5.797 ns |  0.8336 ns | 0.0471 ns |
| FastLinq_Index |     List |         100 | 6.025 ns | 11.6135 ns | 0.6562 ns |
|          Index |     List |         100 | 3.281 ns |  6.0883 ns | 0.3440 ns |
