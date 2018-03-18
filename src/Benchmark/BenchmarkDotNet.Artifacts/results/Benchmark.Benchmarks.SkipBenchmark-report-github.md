``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards | SizeOfInput | SkipCount |          Mean |       Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------ |---------- |--------------:|------------:|-----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |           **0** |         **0** |    **10.8951 ns** |   **2.9836 ns** |  **0.1686 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |         0 |     0.4007 ns |   0.1024 ns |  0.0058 ns |      - |       0 B |
|        Array_System |               False |           0 |         0 |    12.1597 ns |   4.8548 ns |  0.2743 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |         0 |    21.7366 ns |   2.0622 ns |  0.1165 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |           0 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |         0 |    12.4125 ns |   7.6303 ns |  0.4311 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |         0 |    12.2223 ns |   0.7933 ns |  0.0448 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |         0 |    12.4601 ns |   1.9669 ns |  0.1111 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |         0 |     0.3302 ns |   0.0415 ns |  0.0023 ns |      - |       0 B |
|        IList_System |               False |           0 |         0 |    12.0903 ns |   3.2195 ns |  0.1819 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |         0 |    11.0983 ns |   6.3574 ns |  0.3592 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |         0 |     0.4339 ns |   0.4955 ns |  0.0280 ns |      - |       0 B |
|         List_System |               False |           0 |         0 |    12.9319 ns |   3.1036 ns |  0.1754 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |        **10** |    **11.1886 ns** |   **1.4344 ns** |  **0.0810 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |        10 |     0.3855 ns |   0.4541 ns |  0.0257 ns |      - |       0 B |
|        Array_System |               False |           0 |        10 |    11.9453 ns |   0.4018 ns |  0.0227 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |        10 |    22.0419 ns |   2.0920 ns |  0.1182 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |           0 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |        10 |    11.9480 ns |   1.7990 ns |  0.1016 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |        10 |    12.1776 ns |   3.1916 ns |  0.1803 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |        10 |    13.0427 ns |   6.6620 ns |  0.3764 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |        10 |     0.3415 ns |   0.6631 ns |  0.0375 ns |      - |       0 B |
|        IList_System |               False |           0 |        10 |    12.1688 ns |   1.2558 ns |  0.0710 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |        10 |    10.8432 ns |   1.0537 ns |  0.0595 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |        10 |     0.4141 ns |   0.4347 ns |  0.0246 ns |      - |       0 B |
|         List_System |               False |           0 |        10 |    12.4253 ns |   6.3358 ns |  0.3580 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |       **100** |    **10.6659 ns** |   **1.3396 ns** |  **0.0757 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |       100 |     0.4020 ns |   0.6090 ns |  0.0344 ns |      - |       0 B |
|        Array_System |               False |           0 |       100 |    12.0255 ns |   1.9080 ns |  0.1078 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |       100 |    21.9630 ns |   2.0514 ns |  0.1159 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |           0 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |       100 |    12.1627 ns |   4.1521 ns |  0.2346 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |       100 |    12.3375 ns |   3.6414 ns |  0.2057 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |       100 |    12.4546 ns |   4.3409 ns |  0.2453 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |       100 |     0.3586 ns |   0.7006 ns |  0.0396 ns |      - |       0 B |
|        IList_System |               False |           0 |       100 |    12.0184 ns |   1.5508 ns |  0.0876 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |       100 |    10.6570 ns |   0.8473 ns |  0.0479 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |       100 |     0.3661 ns |   0.2626 ns |  0.0148 ns |      - |       0 B |
|         List_System |               False |           0 |       100 |    11.9329 ns |   1.4385 ns |  0.0813 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |         **0** |    **12.1246 ns** |   **3.1156 ns** |  **0.1760 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |         0 |     0.4352 ns |   0.8401 ns |  0.0475 ns |      - |       0 B |
|        Array_System |               False |          10 |         0 |    11.9984 ns |   0.3134 ns |  0.0177 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |         0 |    21.6895 ns |   5.5084 ns |  0.3112 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |         0 |    12.0233 ns |   0.3470 ns |  0.0196 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |         0 |    12.2269 ns |   2.7765 ns |  0.1569 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |         0 |    13.8490 ns |   4.3245 ns |  0.2443 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |         0 |     0.3018 ns |   0.0608 ns |  0.0034 ns |      - |       0 B |
|        IList_System |               False |          10 |         0 |    11.9461 ns |   4.5920 ns |  0.2595 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |         0 |    12.4363 ns |   2.4914 ns |  0.1408 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |         0 |     0.3705 ns |   0.1313 ns |  0.0074 ns |      - |       0 B |
|         List_System |               False |          10 |         0 |    12.1511 ns |   5.9913 ns |  0.3385 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |        **10** |    **10.7193 ns** |   **3.9630 ns** |  **0.2239 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |        10 |     0.4000 ns |   0.2022 ns |  0.0114 ns |      - |       0 B |
|        Array_System |               False |          10 |        10 |    12.0599 ns |   3.8444 ns |  0.2172 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |        10 |    21.3974 ns |   5.1679 ns |  0.2920 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |        10 |    11.9493 ns |   7.7546 ns |  0.4382 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |        10 |    11.9996 ns |   2.5169 ns |  0.1422 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |        10 |    13.5144 ns |   4.7153 ns |  0.2664 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |        10 |     0.3265 ns |   0.2100 ns |  0.0119 ns |      - |       0 B |
|        IList_System |               False |          10 |        10 |    12.1044 ns |   1.0234 ns |  0.0578 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |        10 |    10.6185 ns |   1.0314 ns |  0.0583 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |        10 |     0.3746 ns |   0.1230 ns |  0.0070 ns |      - |       0 B |
|         List_System |               False |          10 |        10 |    11.9397 ns |   0.7844 ns |  0.0443 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |       **100** |    **10.5600 ns** |   **0.8650 ns** |  **0.0489 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |       100 |     0.4127 ns |   0.1400 ns |  0.0079 ns |      - |       0 B |
|        Array_System |               False |          10 |       100 |    12.0779 ns |   2.2777 ns |  0.1287 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |       100 |    21.6505 ns |   4.8628 ns |  0.2748 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |       100 |    12.0648 ns |   1.8283 ns |  0.1033 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |       100 |    11.8711 ns |   2.9384 ns |  0.1660 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |       100 |    12.1541 ns |   4.0967 ns |  0.2315 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |       100 |     0.3253 ns |   0.2672 ns |  0.0151 ns |      - |       0 B |
|        IList_System |               False |          10 |       100 |    11.9779 ns |   2.8463 ns |  0.1608 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |       100 |    10.7006 ns |   3.1661 ns |  0.1789 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |       100 |     0.3639 ns |   0.1777 ns |  0.0100 ns |      - |       0 B |
|         List_System |               False |          10 |       100 |    12.1886 ns |   1.7106 ns |  0.0967 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |         **0** |    **12.2702 ns** |   **3.9201 ns** |  **0.2215 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |         0 |     0.3961 ns |   0.0978 ns |  0.0055 ns |      - |       0 B |
|        Array_System |               False |         100 |         0 |    11.8517 ns |   0.2682 ns |  0.0152 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |         0 |    21.4100 ns |   4.3037 ns |  0.2432 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |         0 |    11.8500 ns |   0.9741 ns |  0.0550 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |         0 |    12.0279 ns |   2.2045 ns |  0.1246 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |         0 |    13.9503 ns |   0.9555 ns |  0.0540 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |         0 |     0.3469 ns |   0.5861 ns |  0.0331 ns |      - |       0 B |
|        IList_System |               False |         100 |         0 |    11.9297 ns |   1.9066 ns |  0.1077 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |         0 |    12.3443 ns |   0.3701 ns |  0.0209 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |         0 |     0.3764 ns |   0.0799 ns |  0.0045 ns |      - |       0 B |
|         List_System |               False |         100 |         0 |    11.8833 ns |   0.6268 ns |  0.0354 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |        **10** |    **12.2189 ns** |   **0.6216 ns** |  **0.0351 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |        10 |     0.4601 ns |   1.1479 ns |  0.0649 ns |      - |       0 B |
|        Array_System |               False |         100 |        10 |    11.9075 ns |   2.0620 ns |  0.1165 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |        10 |    21.7202 ns |   6.8780 ns |  0.3886 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |        10 |    11.8768 ns |   2.8588 ns |  0.1615 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |        10 |    12.2745 ns |   3.5526 ns |  0.2007 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |        10 |    13.8540 ns |   2.4003 ns |  0.1356 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |        10 |     0.2914 ns |   0.8920 ns |  0.0504 ns |      - |       0 B |
|        IList_System |               False |         100 |        10 |    12.0324 ns |   4.2255 ns |  0.2388 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |        10 |    12.5026 ns |   4.4084 ns |  0.2491 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |        10 |     0.3536 ns |   0.0930 ns |  0.0053 ns |      - |       0 B |
|         List_System |               False |         100 |        10 |    11.9561 ns |   4.5866 ns |  0.2592 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |       **100** |    **10.6036 ns** |   **3.4223 ns** |  **0.1934 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |       100 |     0.4037 ns |   0.4004 ns |  0.0226 ns |      - |       0 B |
|        Array_System |               False |         100 |       100 |    12.0384 ns |   2.7046 ns |  0.1528 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |       100 |    21.6308 ns |   1.4362 ns |  0.0811 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |       100 |    12.2021 ns |   3.4306 ns |  0.1938 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |       100 |    11.9731 ns |   2.4718 ns |  0.1397 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |       100 |    12.2610 ns |   3.7866 ns |  0.2139 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |       100 |     0.3355 ns |   0.5521 ns |  0.0312 ns |      - |       0 B |
|        IList_System |               False |         100 |       100 |    11.9265 ns |   3.4638 ns |  0.1957 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |       100 |    10.9887 ns |   7.2654 ns |  0.4105 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |       100 |     0.3986 ns |   0.6577 ns |  0.0372 ns |      - |       0 B |
|         List_System |               False |         100 |       100 |    12.1707 ns |   2.0442 ns |  0.1155 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |         **0** |    **34.0527 ns** |   **7.6245 ns** |  **0.4308 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |         0 |     0.4249 ns |   1.0107 ns |  0.0571 ns |      - |       0 B |
|        Array_System |                True |           0 |         0 |    43.4210 ns |   8.5982 ns |  0.4858 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |         0 |    59.6890 ns |   8.7343 ns |  0.4935 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |         0 |    46.2597 ns |  11.8233 ns |  0.6680 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |         0 |    47.5119 ns |  26.1203 ns |  1.4758 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |         0 |    36.7246 ns |   9.7385 ns |  0.5502 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |         0 |     0.3331 ns |   0.1010 ns |  0.0057 ns |      - |       0 B |
|        IList_System |                True |           0 |         0 |    48.6942 ns |  19.6728 ns |  1.1116 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |         0 |    35.0035 ns |  21.2758 ns |  1.2021 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |         0 |     0.4418 ns |   1.0024 ns |  0.0566 ns |      - |       0 B |
|         List_System |                True |           0 |         0 |    45.7764 ns |   7.9939 ns |  0.4517 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |        **10** |    **33.9765 ns** |   **8.8293 ns** |  **0.4989 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |        10 |     0.4315 ns |   0.4677 ns |  0.0264 ns |      - |       0 B |
|        Array_System |                True |           0 |        10 |    44.0040 ns |  25.2752 ns |  1.4281 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |        10 |    59.4030 ns |  16.6700 ns |  0.9419 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |        10 |    45.2402 ns |  21.3022 ns |  1.2036 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |        10 |    46.1227 ns |   6.6159 ns |  0.3738 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |        10 |    35.9573 ns |  11.1566 ns |  0.6304 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |        10 |     0.3308 ns |   0.1209 ns |  0.0068 ns |      - |       0 B |
|        IList_System |                True |           0 |        10 |    47.7320 ns |  24.6259 ns |  1.3914 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |        10 |    33.7683 ns |   2.6609 ns |  0.1503 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |        10 |     0.3610 ns |   0.5052 ns |  0.0285 ns |      - |       0 B |
|         List_System |                True |           0 |        10 |    44.7382 ns |   2.0199 ns |  0.1141 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |       **100** |    **33.5416 ns** |   **6.1775 ns** |  **0.3490 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |       100 |     0.4194 ns |   0.9478 ns |  0.0536 ns |      - |       0 B |
|        Array_System |                True |           0 |       100 |    42.8730 ns |   0.4252 ns |  0.0240 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |       100 |    58.1656 ns |   2.0519 ns |  0.1159 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |       100 |    45.2192 ns |  17.0632 ns |  0.9641 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |       100 |    46.6565 ns |  25.7794 ns |  1.4566 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |       100 |    35.8445 ns |   8.3932 ns |  0.4742 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |       100 |     0.5294 ns |   0.7502 ns |  0.0424 ns |      - |       0 B |
|        IList_System |                True |           0 |       100 |    47.4017 ns |   8.9931 ns |  0.5081 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |       100 |    34.7523 ns |  11.8601 ns |  0.6701 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |       100 |     0.4075 ns |   0.2554 ns |  0.0144 ns |      - |       0 B |
|         List_System |                True |           0 |       100 |    45.0458 ns |  14.8291 ns |  0.8379 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |         **0** |   **146.3548 ns** |  **11.2388 ns** |  **0.6350 ns** | **0.0188** |      **80 B** |
|       Array_Optimal |                True |          10 |         0 |     6.9106 ns |   1.0678 ns |  0.0603 ns |      - |       0 B |
|        Array_System |                True |          10 |         0 |   190.4431 ns |   2.2641 ns |  0.1279 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |         0 |   241.9507 ns |  12.9904 ns |  0.7340 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |         0 |   233.6894 ns |  75.9582 ns |  4.2918 ns | 0.0246 |     104 B |
|  Enumerable_Optimal |                True |          10 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |         0 |   189.6907 ns |  12.6695 ns |  0.7158 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |         0 |   161.7834 ns |  32.4093 ns |  1.8312 ns | 0.0188 |      80 B |
|       IList_Optimal |                True |          10 |         0 |    35.2066 ns |   3.1157 ns |  0.1760 ns |      - |       0 B |
|        IList_System |                True |          10 |         0 |   210.5669 ns |  63.3299 ns |  3.5783 ns | 0.0246 |     104 B |
|       List_FastLinq |                True |          10 |         0 |   141.4199 ns |   4.4552 ns |  0.2517 ns | 0.0188 |      80 B |
|        List_Optimal |                True |          10 |         0 |    12.4624 ns |   1.0316 ns |  0.0583 ns |      - |       0 B |
|         List_System |                True |          10 |         0 |   203.0955 ns |  39.6815 ns |  2.2421 ns | 0.0246 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |        **10** |    **34.1579 ns** |  **13.8205 ns** |  **0.7809 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |          10 |        10 |     0.4119 ns |   0.4633 ns |  0.0262 ns |      - |       0 B |
|        Array_System |                True |          10 |        10 |    73.0497 ns |  13.7234 ns |  0.7754 ns | 0.0228 |      96 B |
| Collection_FastLinq |                True |          10 |        10 |   118.3672 ns |  10.7970 ns |  0.6101 ns | 0.0322 |     136 B |
|  Collection_Optimal |                True |          10 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |        10 |   105.4369 ns |   8.0915 ns |  0.4572 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |          10 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |        10 |    81.9473 ns |  12.4150 ns |  0.7015 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |          10 |        10 |    35.0621 ns |   1.7272 ns |  0.0976 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |          10 |        10 |     0.3530 ns |   0.1470 ns |  0.0083 ns |      - |       0 B |
|        IList_System |                True |          10 |        10 |    89.5708 ns |   4.0424 ns |  0.2284 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |          10 |        10 |    33.3005 ns |  10.5738 ns |  0.5974 ns | 0.0190 |      80 B |
|        List_Optimal |                True |          10 |        10 |     0.3987 ns |   0.0990 ns |  0.0056 ns |      - |       0 B |
|         List_System |                True |          10 |        10 |    90.9162 ns |  35.2997 ns |  1.9945 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |       **100** |    **34.0699 ns** |   **0.8471 ns** |  **0.0479 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |          10 |       100 |     0.4009 ns |   0.1307 ns |  0.0074 ns |      - |       0 B |
|        Array_System |                True |          10 |       100 |    72.6871 ns |  24.1526 ns |  1.3647 ns | 0.0228 |      96 B |
| Collection_FastLinq |                True |          10 |       100 |   119.0818 ns |  49.6870 ns |  2.8074 ns | 0.0322 |     136 B |
|  Collection_Optimal |                True |          10 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |       100 |   105.5252 ns |  10.8025 ns |  0.6104 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |          10 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |       100 |    84.2856 ns |  39.3614 ns |  2.2240 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |          10 |       100 |    35.2386 ns |   6.0149 ns |  0.3399 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |          10 |       100 |     0.3573 ns |   0.4781 ns |  0.0270 ns |      - |       0 B |
|        IList_System |                True |          10 |       100 |    90.5387 ns |   4.9901 ns |  0.2820 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |          10 |       100 |    33.8399 ns |   8.8891 ns |  0.5022 ns | 0.0190 |      80 B |
|        List_Optimal |                True |          10 |       100 |     0.4002 ns |   0.7183 ns |  0.0406 ns |      - |       0 B |
|         List_System |                True |          10 |       100 |    88.8119 ns |   8.6411 ns |  0.4882 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |         **0** | **1,093.5746 ns** | **280.6198 ns** | **15.8555 ns** | **0.0172** |      **80 B** |
|       Array_Optimal |                True |         100 |         0 |    74.0278 ns |   9.7946 ns |  0.5534 ns |      - |       0 B |
|        Array_System |                True |         100 |         0 | 1,343.7749 ns | 162.5183 ns |  9.1826 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |         0 | 1,697.3462 ns | 399.7057 ns | 22.5841 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |         0 | 1,712.9397 ns | 716.6353 ns | 40.4912 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |         0 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |         0 | 1,310.5537 ns | 154.2609 ns |  8.7160 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |         0 | 1,184.1238 ns | 274.6249 ns | 15.5168 ns | 0.0172 |      80 B |
|       IList_Optimal |                True |         100 |         0 |   308.3320 ns |  72.4690 ns |  4.0946 ns |      - |       0 B |
|        IList_System |                True |         100 |         0 | 1,470.8454 ns | 179.6246 ns | 10.1491 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |         0 | 1,026.6404 ns | 229.5952 ns | 12.9726 ns | 0.0172 |      80 B |
|        List_Optimal |                True |         100 |         0 |   111.1286 ns |  24.7328 ns |  1.3974 ns |      - |       0 B |
|         List_System |                True |         100 |         0 | 1,458.5106 ns | 114.4305 ns |  6.4655 ns | 0.0229 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |        **10** |   **941.9786 ns** | **104.5057 ns** |  **5.9048 ns** | **0.0181** |      **80 B** |
|       Array_Optimal |                True |         100 |        10 |    59.8482 ns |  14.8518 ns |  0.8392 ns |      - |       0 B |
|        Array_System |                True |         100 |        10 | 1,262.0298 ns |  63.8962 ns |  3.6103 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |        10 | 1,591.5707 ns |  42.5813 ns |  2.4059 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |        10 | 1,567.3756 ns | 227.0771 ns | 12.8303 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |        10 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |        10 | 1,202.7061 ns | 188.1532 ns | 10.6310 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |        10 | 1,061.7410 ns |  89.7153 ns |  5.0691 ns | 0.0172 |      80 B |
|       IList_Optimal |                True |         100 |        10 |   279.0981 ns |  92.9451 ns |  5.2516 ns |      - |       0 B |
|        IList_System |                True |         100 |        10 | 1,377.8533 ns | 215.9451 ns | 12.2013 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |        10 |   927.4824 ns | 192.1440 ns | 10.8565 ns | 0.0181 |      80 B |
|        List_Optimal |                True |         100 |        10 |   100.2869 ns |   8.6446 ns |  0.4884 ns |      - |       0 B |
|         List_System |                True |         100 |        10 | 1,354.1850 ns | 344.6162 ns | 19.4715 ns | 0.0229 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |       **100** |    **33.9834 ns** |   **1.5689 ns** |  **0.0886 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |         100 |       100 |     0.3950 ns |   0.0667 ns |  0.0038 ns |      - |       0 B |
|        Array_System |                True |         100 |       100 |   385.1331 ns |  43.0056 ns |  2.4299 ns | 0.0224 |      96 B |
| Collection_FastLinq |                True |         100 |       100 |   674.6596 ns | 124.1485 ns |  7.0146 ns | 0.0315 |     136 B |
|  Collection_Optimal |                True |         100 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |       100 |   714.8733 ns | 143.5305 ns |  8.1097 ns | 0.0238 |     104 B |
|  Enumerable_Optimal |                True |         100 |       100 |            NA |          NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |       100 |   432.6802 ns |  18.1535 ns |  1.0257 ns | 0.0262 |     112 B |
|      IList_FastLinq |                True |         100 |       100 |    35.3020 ns |  11.3108 ns |  0.6391 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |         100 |       100 |     0.3500 ns |   0.0349 ns |  0.0020 ns |      - |       0 B |
|        IList_System |                True |         100 |       100 |   504.4363 ns | 246.9151 ns | 13.9512 ns | 0.0238 |     104 B |
|       List_FastLinq |                True |         100 |       100 |    33.5096 ns |   8.1796 ns |  0.4622 ns | 0.0190 |      80 B |
|        List_Optimal |                True |         100 |       100 |     0.3943 ns |   0.3929 ns |  0.0222 ns |      - |       0 B |
|         List_System |                True |         100 |       100 |   494.1940 ns |  24.6272 ns |  1.3915 ns | 0.0238 |     104 B |

Benchmarks with issues:
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, SkipCount=100]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, SkipCount=100]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, SkipCount=100]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, SkipCount=100]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, SkipCount=100]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=0]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=0]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=10]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=10]
  SkipBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=100]
  SkipBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, SkipCount=100]
