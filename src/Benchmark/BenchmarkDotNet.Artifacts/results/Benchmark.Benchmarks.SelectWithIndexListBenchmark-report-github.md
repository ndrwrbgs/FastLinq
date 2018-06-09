``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput |      Mean |     Error |    StdDev |
|--------------- |--------- |------------ |----------:|----------:|----------:|
|          **Count** |    **Array** |         **100** |  **1.815 ns** | **6.0516 ns** | **0.3419 ns** |
| FastLinq_Count |    Array |         100 |  3.426 ns | 1.1384 ns | 0.0643 ns |
| FastLinq_Index |    Array |         100 | 10.018 ns | 4.6981 ns | 0.2654 ns |
|          Index |    Array |         100 |  2.629 ns | 1.3226 ns | 0.0747 ns |
|          **Count** |     **List** |         **100** |  **1.489 ns** | **1.7677 ns** | **0.0999 ns** |
| FastLinq_Count |     List |         100 |  3.267 ns | 1.0700 ns | 0.0605 ns |
| FastLinq_Index |     List |         100 |  5.489 ns | 1.5323 ns | 0.0866 ns |
|          Index |     List |         100 |  2.262 ns | 0.0479 ns | 0.0027 ns |
