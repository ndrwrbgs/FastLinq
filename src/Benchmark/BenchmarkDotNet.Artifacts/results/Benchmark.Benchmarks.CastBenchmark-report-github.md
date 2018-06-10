``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|                   Method | EnumerateAfterwards | SizeOfInput |        Mean |        Error |      StdDev |  Gen 0 | Allocated |
|------------------------- |-------------------- |------------ |------------:|-------------:|------------:|-------:|----------:|
|      **Array_FastLinqEager** |                **True** |           **0** |    **12.14 ns** |     **9.026 ns** |   **0.5100 ns** | **0.0057** |      **24 B** |
| Collection_FastLinqEager |                True |           0 |    31.72 ns |    12.750 ns |   0.7204 ns | 0.0152 |      64 B |
|      IList_FastLinqEager |                True |           0 |    14.56 ns |     2.967 ns |   0.1676 ns | 0.0057 |      24 B |
|       List_FastLinqEager |                True |           0 |    11.70 ns |     5.502 ns |   0.3109 ns | 0.0057 |      24 B |
|      **Array_FastLinqEager** |                **True** |          **10** |   **259.51 ns** |    **41.530 ns** |   **2.3465 ns** | **0.0815** |     **344 B** |
| Collection_FastLinqEager |                True |          10 |   316.78 ns |   509.499 ns |  28.7876 ns | 0.0911 |     384 B |
|      IList_FastLinqEager |                True |          10 |   298.12 ns |    63.288 ns |   3.5759 ns | 0.0815 |     344 B |
|       List_FastLinqEager |                True |          10 |   255.45 ns |    95.489 ns |   5.3953 ns | 0.0815 |     344 B |
|      **Array_FastLinqEager** |                **True** |         **100** | **2,618.63 ns** | **3,572.471 ns** | **201.8513 ns** | **0.7668** |    **3224 B** |
| Collection_FastLinqEager |                True |         100 | 2,617.80 ns |   506.436 ns |  28.6146 ns | 0.7744 |    3264 B |
|      IList_FastLinqEager |                True |         100 | 2,794.63 ns | 1,670.182 ns |  94.3684 ns | 0.7668 |    3224 B |
|       List_FastLinqEager |                True |         100 | 2,342.21 ns |   524.011 ns |  29.6076 ns | 0.7668 |    3224 B |
