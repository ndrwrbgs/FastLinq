``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput |     Mean |     Error |    StdDev |
|--------------- |--------- |------------ |---------:|----------:|----------:|
|          **Count** |    **Array** |         **100** | **1.758 ns** | **0.2569 ns** | **0.0145 ns** |
| FastLinq_Count |    Array |         100 | 3.158 ns | 0.5434 ns | 0.0307 ns |
| FastLinq_Index |    Array |         100 | 6.247 ns | 0.8132 ns | 0.0459 ns |
|          Index |    Array |         100 | 2.207 ns | 2.6130 ns | 0.1476 ns |
|          **Count** |     **List** |         **100** | **1.925 ns** | **0.6515 ns** | **0.0368 ns** |
| FastLinq_Count |     List |         100 | 3.003 ns | 0.5841 ns | 0.0330 ns |
| FastLinq_Index |     List |         100 | 6.063 ns | 3.2890 ns | 0.1858 ns |
|          Index |     List |         100 | 2.111 ns | 2.1939 ns | 0.1240 ns |
