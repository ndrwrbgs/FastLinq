``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|            Method | SizeOfInput |          Mean |       Error |     StdDev |  Gen 0 | Allocated |
|------------------ |------------ |--------------:|------------:|-----------:|-------:|----------:|
|    **Array_FastLinq** |           **1** |     **6.1887 ns** |   **2.3918 ns** |  **0.1351 ns** |      **-** |       **0 B** |
|     Array_Optimal |           1 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
|      Array_System |           1 |    31.7198 ns |  25.4003 ns |  1.4352 ns |      - |       0 B |
| Collection_System |           1 |    39.0971 ns |  14.6710 ns |  0.8289 ns | 0.0095 |      40 B |
| Enumerable_System |           1 |    35.9142 ns |   3.6370 ns |  0.2055 ns | 0.0114 |      48 B |
|    IList_FastLinq |           1 |    10.0588 ns |   6.1762 ns |  0.3490 ns |      - |       0 B |
|     IList_Optimal |           1 |     2.6255 ns |   0.3476 ns |  0.0196 ns |      - |       0 B |
|      IList_System |           1 |    12.6381 ns |   8.4321 ns |  0.4764 ns |      - |       0 B |
|     List_FastLinq |           1 |     6.2121 ns |   3.4564 ns |  0.1953 ns |      - |       0 B |
|      List_Optimal |           1 |     0.6462 ns |   0.8116 ns |  0.0459 ns |      - |       0 B |
|       List_System |           1 |     8.1161 ns |   5.6599 ns |  0.3198 ns |      - |       0 B |
|    **Array_FastLinq** |          **10** |     **6.4521 ns** |   **2.1622 ns** |  **0.1222 ns** |      **-** |       **0 B** |
|     Array_Optimal |          10 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
|      Array_System |          10 |    31.7134 ns |  12.4735 ns |  0.7048 ns |      - |       0 B |
| Collection_System |          10 |   145.6444 ns |  29.5708 ns |  1.6708 ns | 0.0093 |      40 B |
| Enumerable_System |          10 |    89.9560 ns |  78.2585 ns |  4.4218 ns | 0.0113 |      48 B |
|    IList_FastLinq |          10 |    10.3721 ns |   7.7606 ns |  0.4385 ns |      - |       0 B |
|     IList_Optimal |          10 |     2.7249 ns |   1.2406 ns |  0.0701 ns |      - |       0 B |
|      IList_System |          10 |    12.3113 ns |   1.7228 ns |  0.0973 ns |      - |       0 B |
|     List_FastLinq |          10 |     5.8708 ns |   1.5400 ns |  0.0870 ns |      - |       0 B |
|      List_Optimal |          10 |     0.6686 ns |   1.3174 ns |  0.0744 ns |      - |       0 B |
|       List_System |          10 |     8.3254 ns |   3.2903 ns |  0.1859 ns |      - |       0 B |
|    **Array_FastLinq** |         **100** |     **6.6391 ns** |   **1.9385 ns** |  **0.1095 ns** |      **-** |       **0 B** |
|     Array_Optimal |         100 |     0.0000 ns |   0.0000 ns |  0.0000 ns |      - |       0 B |
|      Array_System |         100 |    31.5305 ns |  20.3124 ns |  1.1477 ns |      - |       0 B |
| Collection_System |         100 | 1,073.5330 ns | 229.5793 ns | 12.9717 ns | 0.0076 |      40 B |
| Enumerable_System |         100 |   602.4403 ns |  86.9625 ns |  4.9135 ns | 0.0105 |      48 B |
|    IList_FastLinq |         100 |     9.6009 ns |   2.3517 ns |  0.1329 ns |      - |       0 B |
|     IList_Optimal |         100 |     2.6295 ns |   0.4131 ns |  0.0233 ns |      - |       0 B |
|      IList_System |         100 |    12.3120 ns |   3.0411 ns |  0.1718 ns |      - |       0 B |
|     List_FastLinq |         100 |     6.1794 ns |   5.2296 ns |  0.2955 ns |      - |       0 B |
|      List_Optimal |         100 |     0.5830 ns |   0.3311 ns |  0.0187 ns |      - |       0 B |
|       List_System |         100 |     7.6921 ns |   3.0604 ns |  0.1729 ns |      - |       0 B |
