``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|                  Method | EnumerateAfterwards |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
|------------------------ |-------------------- |------------:|------------:|-----------:|-------:|----------:|
|          **Array_FastLinq** |               **False** |   **9.0097 ns** |   **0.4225 ns** |  **0.0239 ns** | **0.0076** |      **32 B** |
|           Array_Optimal |               False |   0.3161 ns |   0.2970 ns |  0.0168 ns |      - |       0 B |
|            Array_System |               False |  13.8056 ns |   0.8078 ns |  0.0456 ns | 0.0171 |      72 B |
| CollectionList_FastLinq |               False |  26.5966 ns |   2.2925 ns |  0.1295 ns | 0.0248 |     104 B |
|  CollectionList_Optimal |               False |  10.6773 ns |   0.4656 ns |  0.0263 ns |      - |       0 B |
|   CollectionList_System |               False |  13.7426 ns |   2.3796 ns |  0.1345 ns | 0.0171 |      72 B |
|     Collection_FastLinq |               False |  26.3380 ns |   6.9955 ns |  0.3953 ns | 0.0248 |     104 B |
|      Collection_Optimal |               False |  10.8544 ns |   7.6750 ns |  0.4337 ns |      - |       0 B |
|       Collection_System |               False |  13.6078 ns |   1.1034 ns |  0.0623 ns | 0.0171 |      72 B |
|      Enumerable_Optimal |               False |   0.7671 ns |   0.3099 ns |  0.0175 ns |      - |       0 B |
|       Enumerable_System |               False |  14.4249 ns |   3.9196 ns |  0.2215 ns | 0.0171 |      72 B |
|          IList_FastLinq |               False |   9.5638 ns |  10.0032 ns |  0.5652 ns | 0.0076 |      32 B |
|           IList_Optimal |               False |   0.3674 ns |   0.4736 ns |  0.0268 ns |      - |       0 B |
|            IList_System |               False |  16.3893 ns |   1.8888 ns |  0.1067 ns | 0.0171 |      72 B |
| ListCollection_FastLinq |               False |  31.5118 ns |   2.1735 ns |  0.1228 ns | 0.0247 |     104 B |
|  ListCollection_Optimal |               False |  11.9570 ns |   4.2895 ns |  0.2424 ns |      - |       0 B |
|   ListCollection_System |               False |  16.5342 ns |  13.7222 ns |  0.7753 ns | 0.0171 |      72 B |
|           List_FastLinq |               False |  10.4097 ns |   3.0402 ns |  0.1718 ns | 0.0076 |      32 B |
|            List_Optimal |               False |   0.7407 ns |   0.6018 ns |  0.0340 ns |      - |       0 B |
|             List_System |               False |  15.9653 ns |   1.5028 ns |  0.0849 ns | 0.0171 |      72 B |
|          **Array_FastLinq** |                **True** | **234.9637 ns** |  **19.9318 ns** |  **1.1262 ns** | **0.0074** |      **32 B** |
|           Array_Optimal |                True |  12.5194 ns |   1.3623 ns |  0.0770 ns |      - |       0 B |
|            Array_System |                True | 433.0768 ns | 103.6992 ns |  5.8592 ns | 0.0319 |     136 B |
| CollectionList_FastLinq |                True | 505.5612 ns | 249.2993 ns | 14.0859 ns | 0.0429 |     184 B |
|  CollectionList_Optimal |                True |  64.0808 ns |  23.6552 ns |  1.3366 ns |      - |       0 B |
|   CollectionList_System |                True | 501.3554 ns | 358.9207 ns | 20.2797 ns | 0.0362 |     152 B |
|     Collection_FastLinq |                True | 525.8066 ns | 251.3329 ns | 14.2008 ns | 0.0429 |     184 B |
|      Collection_Optimal |                True |  97.8563 ns |  31.1457 ns |  1.7598 ns |      - |       0 B |
|       Collection_System |                True | 533.7319 ns | 217.5933 ns | 12.2944 ns | 0.0362 |     152 B |
|      Enumerable_Optimal |                True | 196.6140 ns |  35.2918 ns |  1.9941 ns | 0.0226 |      96 B |
|       Enumerable_System |                True | 444.3199 ns |  25.3100 ns |  1.4301 ns | 0.0401 |     168 B |
|          IList_FastLinq |                True | 341.6455 ns |  98.4666 ns |  5.5635 ns | 0.0072 |      32 B |
|           IList_Optimal |                True |  79.2192 ns |  25.7070 ns |  1.4525 ns |      - |       0 B |
|            IList_System |                True | 476.3469 ns |  31.7653 ns |  1.7948 ns | 0.0362 |     152 B |
| ListCollection_FastLinq |                True | 517.3352 ns |  37.9170 ns |  2.1424 ns | 0.0429 |     184 B |
|  ListCollection_Optimal |                True |  62.3297 ns |  12.1485 ns |  0.6864 ns |      - |       0 B |
|   ListCollection_System |                True | 506.2845 ns | 222.2517 ns | 12.5576 ns | 0.0362 |     152 B |
|           List_FastLinq |                True | 228.0778 ns |  29.4609 ns |  1.6646 ns | 0.0074 |      32 B |
|            List_Optimal |                True |  21.3469 ns |   4.8889 ns |  0.2762 ns |      - |       0 B |
|             List_System |                True | 478.3123 ns | 337.9079 ns | 19.0924 ns | 0.0362 |     152 B |
