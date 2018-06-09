``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput | SkipCount |     Mean |     Error |    StdDev | Allocated |
|--------------- |--------- |------------ |---------- |---------:|----------:|----------:|----------:|
|          **Count** |    **Array** |         **100** |         **1** | **1.556 ns** | **5.1096 ns** | **0.2887 ns** |       **0 B** |
| FastLinq_Count |    Array |         100 |         1 | 4.028 ns | 1.8162 ns | 0.1026 ns |       0 B |
| FastLinq_Index |    Array |         100 |         1 | 4.166 ns | 0.1564 ns | 0.0088 ns |       0 B |
|          Index |    Array |         100 |         1 | 2.373 ns | 3.3910 ns | 0.1916 ns |       0 B |
|          **Count** |     **List** |         **100** |         **1** | **1.470 ns** | **1.6440 ns** | **0.0929 ns** |       **0 B** |
| FastLinq_Count |     List |         100 |         1 | 4.130 ns | 4.7524 ns | 0.2685 ns |       0 B |
| FastLinq_Index |     List |         100 |         1 | 3.826 ns | 0.7911 ns | 0.0447 ns |       0 B |
|          Index |     List |         100 |         1 | 2.013 ns | 0.5917 ns | 0.0334 ns |       0 B |
