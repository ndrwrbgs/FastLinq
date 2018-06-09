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
|          **Count** |    **Array** |         **100** |  **3.078 ns** | **0.2947 ns** | **0.0167 ns** |
| FastLinq_Count |    Array |         100 |  5.201 ns | 1.7888 ns | 0.1011 ns |
| FastLinq_Index |    Array |         100 | 18.627 ns | 3.0802 ns | 0.1740 ns |
|          Index |    Array |         100 |  3.180 ns | 1.9171 ns | 0.1083 ns |
|          **Count** |     **List** |         **100** |  **1.363 ns** | **1.2183 ns** | **0.0688 ns** |
| FastLinq_Count |     List |         100 |  3.444 ns | 0.6790 ns | 0.0384 ns |
| FastLinq_Index |     List |         100 | 16.115 ns | 3.3330 ns | 0.1883 ns |
|          Index |     List |         100 |  1.976 ns | 0.3642 ns | 0.0206 ns |
