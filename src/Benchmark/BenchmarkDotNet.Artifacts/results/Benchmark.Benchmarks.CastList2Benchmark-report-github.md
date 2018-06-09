``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput |      Mean |      Error |    StdDev | Allocated |
|--------------- |--------- |------------ |----------:|-----------:|----------:|----------:|
|          **Count** |    **Array** |         **100** |  **2.377 ns** |  **0.2055 ns** | **0.0116 ns** |       **0 B** |
| FastLinq_Count |    Array |         100 |  4.359 ns |  5.8721 ns | 0.3318 ns |       0 B |
| FastLinq_Index |    Array |         100 | 29.962 ns |  4.6489 ns | 0.2627 ns |       0 B |
|          Index |    Array |         100 | 16.476 ns |  3.4417 ns | 0.1945 ns |       0 B |
|          **Count** |     **List** |         **100** |  **1.328 ns** |  **0.0236 ns** | **0.0013 ns** |       **0 B** |
| FastLinq_Count |     List |         100 |  4.507 ns |  8.6761 ns | 0.4902 ns |       0 B |
| FastLinq_Index |     List |         100 | 15.312 ns | 16.5262 ns | 0.9338 ns |       0 B |
|          Index |     List |         100 |  2.400 ns |  1.4062 ns | 0.0795 ns |       0 B |
