``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|         Method | Start | SizeOfInput |     Mean |     Error |    StdDev |
|--------------- |------ |------------ |---------:|----------:|----------:|
| FastLinq_Count |    50 |         100 | 1.709 ns | 1.7539 ns | 0.0991 ns |
| FastLinq_Index |    50 |         100 | 1.802 ns | 0.8561 ns | 0.0484 ns |
