``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|          Method | EnumerateAfterwards | SizeOfInput |      Mean |      Error |    StdDev |  Gen 0 | Allocated |
|---------------- |-------------------- |------------ |----------:|-----------:|----------:|-------:|----------:|
| Array_FastLinq1 |                True |         100 | 10.094 us | 25.5718 us | 1.4449 us | 0.5798 |   2.41 KB |
| IList_FastLinq1 |                True |         100 |  2.973 us |  6.6744 us | 0.3771 us | 0.5875 |   2.41 KB |
|  List_FastLinq1 |                True |         100 |  2.269 us |  0.4180 us | 0.0236 us | 0.5875 |   2.41 KB |
