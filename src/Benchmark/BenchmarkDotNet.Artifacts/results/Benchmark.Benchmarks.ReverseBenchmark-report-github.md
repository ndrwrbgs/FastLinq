``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards |        Mean |       Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------:|------------:|----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |   **9.8161 ns** |   **2.9665 ns** | **0.1676 ns** | **0.0057** |      **24 B** |
|       Array_Optimal |               False |   0.3111 ns |   0.1624 ns | 0.0092 ns |      - |       0 B |
|        Array_System |               False |  14.1074 ns |   0.5684 ns | 0.0321 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |  23.7612 ns |   8.1960 ns | 0.4631 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
|   Collection_System |               False |  14.3760 ns |   5.0603 ns | 0.2859 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          NA |          NA |        NA |    N/A |       N/A |
|   Enumerable_System |               False |  14.1952 ns |   8.9952 ns | 0.5082 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |   9.2317 ns |   6.6637 ns | 0.3765 ns | 0.0057 |      24 B |
|       IList_Optimal |               False |   0.7194 ns |   1.1814 ns | 0.0668 ns |      - |       0 B |
|        IList_System |               False |  14.2978 ns |   8.8880 ns | 0.5022 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |   8.7528 ns |   1.1154 ns | 0.0630 ns | 0.0057 |      24 B |
|        List_Optimal |               False |   0.6375 ns |   0.6379 ns | 0.0360 ns |      - |       0 B |
|         List_System |               False |  14.0248 ns |   2.6882 ns | 0.1519 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** | **147.4212 ns** |  **25.4948 ns** | **1.4405 ns** | **0.0150** |      **64 B** |
|       Array_Optimal |                True |   5.5987 ns |   1.1732 ns | 0.0663 ns |      - |       0 B |
|        Array_System |                True | 181.0404 ns |  46.1988 ns | 2.6103 ns | 0.0303 |     128 B |
| Collection_FastLinq |                True | 161.7787 ns |  96.2341 ns | 5.4374 ns | 0.0379 |     160 B |
|  Collection_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |
|   Collection_System |                True | 140.4907 ns |  38.2562 ns | 2.1615 ns | 0.0303 |     128 B |
|  Enumerable_Optimal |                True |          NA |          NA |        NA |    N/A |       N/A |
|   Enumerable_System |                True | 277.3531 ns | 102.9282 ns | 5.8156 ns | 0.0701 |     296 B |
|      IList_FastLinq |                True | 167.5476 ns |  28.6078 ns | 1.6164 ns | 0.0150 |      64 B |
|       IList_Optimal |                True |  45.9394 ns |  76.7305 ns | 4.3354 ns |      - |       0 B |
|        IList_System |                True | 150.1909 ns |  39.5882 ns | 2.2368 ns | 0.0303 |     128 B |
|       List_FastLinq |                True | 150.2385 ns |  91.8654 ns | 5.1906 ns | 0.0150 |      64 B |
|        List_Optimal |                True |  13.5159 ns |   3.1870 ns | 0.1801 ns |      - |       0 B |
|         List_System |                True | 140.7028 ns |  32.6095 ns | 1.8425 ns | 0.0303 |     128 B |

Benchmarks with issues:
  ReverseBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False]
  ReverseBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False]
  ReverseBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True]
  ReverseBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True]
