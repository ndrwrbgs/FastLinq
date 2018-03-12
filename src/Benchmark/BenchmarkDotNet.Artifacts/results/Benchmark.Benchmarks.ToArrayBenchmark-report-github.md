``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | InputSize |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------------- |---------- |-----------:|----------:|----------:|-------:|----------:|
|      **Array_FastLinq** |         **0** |  **23.164 ns** |  **9.649 ns** | **0.5452 ns** | **0.0057** |      **24 B** |
|       Array_Optimal |         0 |  13.639 ns |  3.571 ns | 0.2018 ns | 0.0057 |      24 B |
|        Array_System |         0 |  58.982 ns | 15.152 ns | 0.8561 ns | 0.0056 |      24 B |
| Collection_FastLinq |         0 |  13.465 ns |  4.530 ns | 0.2559 ns | 0.0057 |      24 B |
|  Collection_Optimal |         0 |   8.267 ns |  1.683 ns | 0.0951 ns | 0.0057 |      24 B |
|   Collection_System |         0 |  29.696 ns |  8.625 ns | 0.4873 ns | 0.0057 |      24 B |
|  Enumerable_Optimal |         0 |  54.923 ns | 12.064 ns | 0.6816 ns | 0.0172 |      72 B |
|   Enumerable_System |         0 |  54.556 ns | 15.145 ns | 0.8557 ns | 0.0172 |      72 B |
|      IList_FastLinq |         0 |  24.142 ns |  7.482 ns | 0.4228 ns | 0.0057 |      24 B |
|       IList_Optimal |         0 |  19.411 ns |  4.316 ns | 0.2439 ns | 0.0057 |      24 B |
|        IList_System |         0 |  33.578 ns |  7.601 ns | 0.4295 ns | 0.0057 |      24 B |
|       List_FastLinq |         0 |  19.371 ns |  7.207 ns | 0.4072 ns | 0.0057 |      24 B |
|        List_Optimal |         0 |  13.555 ns |  5.660 ns | 0.3198 ns | 0.0057 |      24 B |
|         List_System |         0 |  30.286 ns |  1.872 ns | 0.1058 ns | 0.0057 |      24 B |
|      **Array_FastLinq** |         **2** |  **27.037 ns** |  **8.037 ns** | **0.4541 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |         2 |  18.473 ns |  2.793 ns | 0.1578 ns | 0.0076 |      32 B |
|        Array_System |         2 |  84.209 ns | 23.582 ns | 1.3324 ns | 0.0075 |      32 B |
| Collection_FastLinq |         2 |  17.718 ns |  6.863 ns | 0.3877 ns | 0.0076 |      32 B |
|  Collection_Optimal |         2 |  12.849 ns |  3.548 ns | 0.2005 ns | 0.0076 |      32 B |
|   Collection_System |         2 |  40.446 ns |  7.281 ns | 0.4114 ns | 0.0076 |      32 B |
|  Enumerable_Optimal |         2 |  95.208 ns | 39.577 ns | 2.2362 ns | 0.0285 |     120 B |
|   Enumerable_System |         2 |  93.883 ns | 20.106 ns | 1.1360 ns | 0.0285 |     120 B |
|      IList_FastLinq |         2 |  28.157 ns | 13.715 ns | 0.7749 ns | 0.0076 |      32 B |
|       IList_Optimal |         2 |  23.013 ns |  6.501 ns | 0.3673 ns | 0.0076 |      32 B |
|        IList_System |         2 |  54.092 ns | 15.627 ns | 0.8830 ns | 0.0076 |      32 B |
|       List_FastLinq |         2 |  24.149 ns |  6.878 ns | 0.3886 ns | 0.0076 |      32 B |
|        List_Optimal |         2 |  19.282 ns |  7.231 ns | 0.4086 ns | 0.0076 |      32 B |
|         List_System |         2 |  50.199 ns | 17.075 ns | 0.9648 ns | 0.0076 |      32 B |
|      **Array_FastLinq** |        **10** |  **42.565 ns** | **14.508 ns** | **0.8197 ns** | **0.0152** |      **64 B** |
|       Array_Optimal |        10 |  34.458 ns | 22.629 ns | 1.2786 ns | 0.0152 |      64 B |
|        Array_System |        10 |  97.607 ns | 32.729 ns | 1.8492 ns | 0.0151 |      64 B |
| Collection_FastLinq |        10 |  36.812 ns | 18.297 ns | 1.0338 ns | 0.0152 |      64 B |
|  Collection_Optimal |        10 |  31.736 ns | 11.149 ns | 0.6299 ns | 0.0152 |      64 B |
|   Collection_System |        10 |  61.427 ns | 22.327 ns | 1.2615 ns | 0.0151 |      64 B |
|  Enumerable_Optimal |        10 | 231.619 ns | 44.283 ns | 2.5021 ns | 0.0703 |     296 B |
|   Enumerable_System |        10 | 235.569 ns | 14.243 ns | 0.8047 ns | 0.0703 |     296 B |
|      IList_FastLinq |        10 |  43.863 ns | 13.094 ns | 0.7398 ns | 0.0152 |      64 B |
|       IList_Optimal |        10 |  38.117 ns | 11.588 ns | 0.6547 ns | 0.0152 |      64 B |
|        IList_System |        10 |  66.676 ns |  6.174 ns | 0.3489 ns | 0.0151 |      64 B |
|       List_FastLinq |        10 |  39.139 ns | 13.034 ns | 0.7365 ns | 0.0152 |      64 B |
|        List_Optimal |        10 |  33.464 ns |  9.008 ns | 0.5090 ns | 0.0152 |      64 B |
|         List_System |        10 |  63.273 ns | 20.994 ns | 1.1862 ns | 0.0151 |      64 B |
