``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | ItemType | SizeOfInput |     Mean |     Error |    StdDev | Allocated |
|--------------- |--------- |------------ |---------:|----------:|----------:|----------:|
|          **Count** |    **Array** |         **100** | **7.444 ns** | **6.9677 ns** | **0.3937 ns** |       **0 B** |
| FastLinq_Count |    Array |         100 | 9.983 ns | 0.8014 ns | 0.0453 ns |       0 B |
| FastLinq_Index |    Array |         100 | 9.700 ns | 3.0202 ns | 0.1706 ns |       0 B |
|          Index |    Array |         100 | 3.169 ns | 1.1070 ns | 0.0625 ns |       0 B |
|          **Count** |     **List** |         **100** | **4.063 ns** | **0.8860 ns** | **0.0501 ns** |       **0 B** |
| FastLinq_Count |     List |         100 | 7.133 ns | 2.6915 ns | 0.1521 ns |       0 B |
| FastLinq_Index |     List |         100 | 7.189 ns | 3.5523 ns | 0.2007 ns |       0 B |
|          Index |     List |         100 | 2.340 ns | 2.7474 ns | 0.1552 ns |       0 B |
