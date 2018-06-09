``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput | TakeCount |     Mean |      Error |    StdDev | Allocated |
|--------------- |--------- |------------ |---------- |---------:|-----------:|----------:|----------:|
|          **Count** |    **Array** |         **100** |         **1** | **1.317 ns** |  **0.3716 ns** | **0.0210 ns** |       **0 B** |
| FastLinq_Count |    Array |         100 |         1 | 4.064 ns |  0.2065 ns | 0.0117 ns |       0 B |
| FastLinq_Index |    Array |         100 |         1 | 6.557 ns |  0.2744 ns | 0.0155 ns |       0 B |
|          Index |    Array |         100 |         1 | 2.098 ns |  0.4099 ns | 0.0232 ns |       0 B |
|          **Count** |     **List** |         **100** |         **1** | **1.294 ns** |  **0.2974 ns** | **0.0168 ns** |       **0 B** |
| FastLinq_Count |     List |         100 |         1 | 4.091 ns |  0.8680 ns | 0.0490 ns |       0 B |
| FastLinq_Index |     List |         100 |         1 | 6.924 ns | 14.7530 ns | 0.8336 ns |       0 B |
|          Index |     List |         100 |         1 | 1.866 ns |  0.3871 ns | 0.0219 ns |       0 B |
