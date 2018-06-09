``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | SizeOfInput |     Mean |     Error |    StdDev | Allocated |
|--------------- |------------ |---------:|----------:|----------:|----------:|
| FastLinq_Count |         100 | 1.840 ns | 0.5039 ns | 0.0285 ns |       0 B |
| FastLinq_Index |         100 | 2.698 ns | 8.9912 ns | 0.5080 ns |       0 B |
