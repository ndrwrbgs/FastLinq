``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards | SizeOfInput | TakeCount |          Mean |         Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------ |---------- |--------------:|--------------:|-----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |           **0** |         **0** |     **9.8916 ns** |     **6.5777 ns** |  **0.3716 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |         0 |     0.5112 ns |     1.3424 ns |  0.0758 ns |      - |       0 B |
|        Array_System |               False |           0 |         0 |    13.2992 ns |     7.6060 ns |  0.4298 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |         0 |    26.2490 ns |    25.2692 ns |  1.4278 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |         0 |    13.7901 ns |    14.7820 ns |  0.8352 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |         0 |    13.1289 ns |     3.0961 ns |  0.1749 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |         0 |    10.4328 ns |     5.4490 ns |  0.3079 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |         0 |     0.3181 ns |     1.0668 ns |  0.0603 ns |      - |       0 B |
|        IList_System |               False |           0 |         0 |    13.3661 ns |     2.9410 ns |  0.1662 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |         0 |     9.8585 ns |     2.1475 ns |  0.1213 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |         0 |     0.4555 ns |     2.2762 ns |  0.1286 ns |      - |       0 B |
|         List_System |               False |           0 |         0 |    13.4188 ns |     3.7593 ns |  0.2124 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |        **10** |    **14.1712 ns** |    **11.2492 ns** |  **0.6356 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |        10 |     0.3868 ns |     0.2836 ns |  0.0160 ns |      - |       0 B |
|        Array_System |               False |           0 |        10 |    14.3928 ns |     3.3945 ns |  0.1918 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |        10 |    26.9163 ns |     5.5666 ns |  0.3145 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |        10 |    14.4397 ns |     7.3339 ns |  0.4144 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |        10 |    14.6901 ns |     6.0177 ns |  0.3400 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |        10 |    16.8150 ns |     5.3223 ns |  0.3007 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |        10 |     0.4015 ns |     0.1555 ns |  0.0088 ns |      - |       0 B |
|        IList_System |               False |           0 |        10 |    13.4914 ns |     7.3789 ns |  0.4169 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |        10 |    14.2838 ns |     8.4533 ns |  0.4776 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |        10 |     0.4545 ns |     0.6074 ns |  0.0343 ns |      - |       0 B |
|         List_System |               False |           0 |        10 |    14.2144 ns |    14.0566 ns |  0.7942 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |       **100** |    **14.6032 ns** |     **8.0077 ns** |  **0.4524 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |       100 |     0.4965 ns |     1.9297 ns |  0.1090 ns |      - |       0 B |
|        Array_System |               False |           0 |       100 |    14.5672 ns |     6.5490 ns |  0.3700 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |       100 |    24.7196 ns |     6.6111 ns |  0.3735 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |       100 |    13.8514 ns |     9.4795 ns |  0.5356 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |       100 |    14.2091 ns |     9.1664 ns |  0.5179 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |       100 |    16.1726 ns |     4.3142 ns |  0.2438 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |       100 |     0.3324 ns |     0.1479 ns |  0.0084 ns |      - |       0 B |
|        IList_System |               False |           0 |       100 |    15.3401 ns |    19.4435 ns |  1.0986 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |       100 |    14.2808 ns |     7.7514 ns |  0.4380 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |       100 |     0.5870 ns |     1.7093 ns |  0.0966 ns |      - |       0 B |
|         List_System |               False |           0 |       100 |    14.0205 ns |    13.9811 ns |  0.7900 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |         **0** |    **10.0279 ns** |     **2.4855 ns** |  **0.1404 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |         0 |     0.5021 ns |     1.8250 ns |  0.1031 ns |      - |       0 B |
|        Array_System |               False |          10 |         0 |    13.6534 ns |     2.8734 ns |  0.1624 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |         0 |    27.2345 ns |     6.4042 ns |  0.3618 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |         0 |    13.4446 ns |     6.8970 ns |  0.3897 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |         0 |    14.6561 ns |     8.2400 ns |  0.4656 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |         0 |     9.9897 ns |     2.2377 ns |  0.1264 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |         0 |     0.4030 ns |     0.9217 ns |  0.0521 ns |      - |       0 B |
|        IList_System |               False |          10 |         0 |    13.6462 ns |    10.0181 ns |  0.5660 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |         0 |    10.8316 ns |     1.6349 ns |  0.0924 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |         0 |     0.4591 ns |     0.2620 ns |  0.0148 ns |      - |       0 B |
|         List_System |               False |          10 |         0 |    13.4969 ns |     4.0581 ns |  0.2293 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |        **10** |    **13.4683 ns** |     **1.6802 ns** |  **0.0949 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |        10 |     0.4349 ns |     0.4915 ns |  0.0278 ns |      - |       0 B |
|        Array_System |               False |          10 |        10 |    13.6852 ns |     1.7959 ns |  0.1015 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |        10 |    24.5318 ns |     4.4677 ns |  0.2524 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |        10 |    13.7240 ns |     5.0655 ns |  0.2862 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |        10 |    14.0226 ns |     6.2209 ns |  0.3515 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |        10 |    15.1206 ns |     3.1775 ns |  0.1795 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |        10 |     0.3383 ns |     1.0720 ns |  0.0606 ns |      - |       0 B |
|        IList_System |               False |          10 |        10 |    13.7847 ns |     2.9693 ns |  0.1678 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |        10 |    13.8356 ns |     6.4320 ns |  0.3634 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |        10 |     0.4149 ns |     0.1831 ns |  0.0103 ns |      - |       0 B |
|         List_System |               False |          10 |        10 |    13.6669 ns |     6.9138 ns |  0.3906 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |       **100** |    **13.1368 ns** |     **1.9610 ns** |  **0.1108 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |       100 |     0.4170 ns |     0.8391 ns |  0.0474 ns |      - |       0 B |
|        Array_System |               False |          10 |       100 |    13.5054 ns |     1.9309 ns |  0.1091 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |       100 |    24.1864 ns |     5.5518 ns |  0.3137 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |       100 |    13.4867 ns |     8.7877 ns |  0.4965 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |       100 |    13.4166 ns |     8.5415 ns |  0.4826 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |       100 |    15.2315 ns |     3.8812 ns |  0.2193 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |       100 |     0.3972 ns |     1.4739 ns |  0.0833 ns |      - |       0 B |
|        IList_System |               False |          10 |       100 |    13.7314 ns |     6.7495 ns |  0.3814 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |       100 |    13.5053 ns |     4.3494 ns |  0.2457 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |       100 |     0.4138 ns |     0.4058 ns |  0.0229 ns |      - |       0 B |
|         List_System |               False |          10 |       100 |    13.7358 ns |     6.1422 ns |  0.3470 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |         **0** |     **9.8072 ns** |     **1.7484 ns** |  **0.0988 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |         0 |     0.4128 ns |     0.6337 ns |  0.0358 ns |      - |       0 B |
|        Array_System |               False |         100 |         0 |    13.4488 ns |     1.7963 ns |  0.1015 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |         0 |    24.7788 ns |     1.0359 ns |  0.0585 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |         0 |    13.5940 ns |     6.0205 ns |  0.3402 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |         0 |    13.3653 ns |     1.0853 ns |  0.0613 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |         0 |     9.8057 ns |     3.0063 ns |  0.1699 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |         0 |     0.3370 ns |     0.8654 ns |  0.0489 ns |      - |       0 B |
|        IList_System |               False |         100 |         0 |    13.3845 ns |     1.0008 ns |  0.0565 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |         0 |     9.6398 ns |     2.0578 ns |  0.1163 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |         0 |     0.4426 ns |     0.4562 ns |  0.0258 ns |      - |       0 B |
|         List_System |               False |         100 |         0 |    13.4924 ns |     1.1419 ns |  0.0645 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |        **10** |    **13.8584 ns** |     **8.4556 ns** |  **0.4778 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |        10 |     0.4620 ns |     0.5603 ns |  0.0317 ns |      - |       0 B |
|        Array_System |               False |         100 |        10 |    13.8294 ns |     5.8104 ns |  0.3283 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |        10 |    24.7460 ns |     9.4979 ns |  0.5366 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |        10 |    13.4520 ns |     5.7024 ns |  0.3222 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |        10 |    13.7792 ns |     2.5254 ns |  0.1427 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |        10 |    15.1482 ns |     2.5363 ns |  0.1433 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |        10 |     0.3762 ns |     0.6258 ns |  0.0354 ns |      - |       0 B |
|        IList_System |               False |         100 |        10 |    13.3475 ns |     1.6863 ns |  0.0953 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |        10 |    13.1192 ns |     1.0036 ns |  0.0567 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |        10 |     0.4186 ns |     0.6195 ns |  0.0350 ns |      - |       0 B |
|         List_System |               False |         100 |        10 |    12.9570 ns |     7.8159 ns |  0.4416 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |       **100** |    **13.0988 ns** |     **4.6732 ns** |  **0.2640 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |       100 |     0.4452 ns |     0.3246 ns |  0.0183 ns |      - |       0 B |
|        Array_System |               False |         100 |       100 |    13.3071 ns |     4.5831 ns |  0.2590 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |       100 |    23.8195 ns |     7.3048 ns |  0.4127 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |       100 |    13.1664 ns |     0.4296 ns |  0.0243 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |       100 |    12.9931 ns |     1.2614 ns |  0.0713 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |       100 |    14.9781 ns |     2.5525 ns |  0.1442 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |       100 |     0.3565 ns |     0.6954 ns |  0.0393 ns |      - |       0 B |
|        IList_System |               False |         100 |       100 |    12.9414 ns |     4.1589 ns |  0.2350 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |       100 |    12.9026 ns |     0.7110 ns |  0.0402 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |       100 |     0.4149 ns |     0.3495 ns |  0.0197 ns |      - |       0 B |
|         List_System |               False |         100 |       100 |    13.0922 ns |     3.7529 ns |  0.2120 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |         **0** |    **32.8504 ns** |     **6.6999 ns** |  **0.3786 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |         0 |     0.4220 ns |     0.3154 ns |  0.0178 ns |      - |       0 B |
|        Array_System |                True |           0 |         0 |    27.9124 ns |    12.1581 ns |  0.6870 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |         0 |    41.7776 ns |    12.0644 ns |  0.6817 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |         0 |    27.6681 ns |     1.4179 ns |  0.0801 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |         0 |    27.9360 ns |     5.5857 ns |  0.3156 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |           0 |         0 |    31.8919 ns |     2.3237 ns |  0.1313 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |         0 |     0.3835 ns |     0.4197 ns |  0.0237 ns |      - |       0 B |
|        IList_System |                True |           0 |         0 |    30.0778 ns |     9.1550 ns |  0.5173 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |           0 |         0 |    32.4524 ns |     2.3733 ns |  0.1341 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |         0 |     0.4292 ns |     0.5116 ns |  0.0289 ns |      - |       0 B |
|         List_System |                True |           0 |         0 |    27.8838 ns |     2.8357 ns |  0.1602 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |        **10** |    **37.0433 ns** |    **29.1958 ns** |  **1.6496 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |           0 |        10 |    44.4552 ns |     9.0806 ns |  0.5131 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |        10 |    62.4584 ns |    10.2504 ns |  0.5792 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |        10 |    48.9557 ns |    20.4886 ns |  1.1576 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |        10 |    50.0306 ns |    11.4593 ns |  0.6475 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |        10 |    37.0276 ns |     4.7152 ns |  0.2664 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |           0 |        10 |    50.7647 ns |     8.9966 ns |  0.5083 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |        10 |    36.4345 ns |    10.8065 ns |  0.6106 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |           0 |        10 |    47.9220 ns |     3.8121 ns |  0.2154 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |       **100** |    **35.2625 ns** |     **6.0008 ns** |  **0.3391 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |           0 |       100 |    43.7409 ns |     6.5476 ns |  0.3700 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |       100 |    63.0828 ns |     3.3929 ns |  0.1917 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |       100 |    48.3030 ns |     8.3069 ns |  0.4694 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |       100 |    48.7927 ns |    17.7583 ns |  1.0034 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |       100 |    37.4792 ns |     2.7761 ns |  0.1569 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |           0 |       100 |    49.2675 ns |     5.0982 ns |  0.2881 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |       100 |    36.1021 ns |     1.5508 ns |  0.0876 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |           0 |       100 |    48.0431 ns |     5.4034 ns |  0.3053 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |         **0** |    **31.5207 ns** |    **16.7017 ns** |  **0.9437 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |          10 |         0 |     0.3606 ns |     0.2463 ns |  0.0139 ns |      - |       0 B |
|        Array_System |                True |          10 |         0 |    28.5019 ns |    11.5734 ns |  0.6539 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |          10 |         0 |    41.9013 ns |     8.3688 ns |  0.4729 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |         0 |    27.9210 ns |     1.3694 ns |  0.0774 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |         0 |    28.2178 ns |     1.1470 ns |  0.0648 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |          10 |         0 |    30.8848 ns |     3.7979 ns |  0.2146 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |          10 |         0 |     0.3555 ns |     0.3788 ns |  0.0214 ns |      - |       0 B |
|        IList_System |                True |          10 |         0 |    28.4019 ns |     2.9345 ns |  0.1658 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |          10 |         0 |    32.1284 ns |    11.7948 ns |  0.6664 ns | 0.0171 |      72 B |
|        List_Optimal |                True |          10 |         0 |     0.4366 ns |     0.7275 ns |  0.0411 ns |      - |       0 B |
|         List_System |                True |          10 |         0 |    28.0135 ns |     0.9372 ns |  0.0530 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |          **10** |        **10** |   **144.4731 ns** |    **27.2988 ns** |  **1.5424 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |          10 |        10 |     7.3354 ns |     0.5172 ns |  0.0292 ns |      - |       0 B |
|        Array_System |                True |          10 |        10 |   204.3709 ns |    31.9487 ns |  1.8052 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |        10 |   244.1554 ns |    38.1544 ns |  2.1558 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |        10 |   232.1275 ns |    46.4376 ns |  2.6238 ns | 0.0246 |     104 B |
|  Enumerable_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |        10 |   194.5238 ns |    35.3573 ns |  1.9978 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |        10 |   163.0859 ns |    22.1564 ns |  1.2519 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |          10 |        10 |    33.2557 ns |     2.6828 ns |  0.1516 ns |      - |       0 B |
|        IList_System |                True |          10 |        10 |   218.6949 ns |    32.7836 ns |  1.8523 ns | 0.0246 |     104 B |
|       List_FastLinq |                True |          10 |        10 |   144.4946 ns |    78.2304 ns |  4.4202 ns | 0.0169 |      72 B |
|        List_Optimal |                True |          10 |        10 |    13.3396 ns |     4.4995 ns |  0.2542 ns |      - |       0 B |
|         List_System |                True |          10 |        10 |   209.7003 ns |    32.8935 ns |  1.8585 ns | 0.0246 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |       **100** |   **145.6627 ns** |    **12.5754 ns** |  **0.7105 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |          10 |       100 |   200.8346 ns |    43.8365 ns |  2.4768 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |       100 |   254.2575 ns |    58.1719 ns |  3.2868 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |       100 |   252.5958 ns |   281.4972 ns | 15.9051 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |       100 |   219.1229 ns |   155.6445 ns |  8.7942 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |       100 |   188.5328 ns |   202.1874 ns | 11.4240 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |          10 |       100 |   228.7534 ns |   102.7382 ns |  5.8049 ns | 0.0243 |     104 B |
|       List_FastLinq |                True |          10 |       100 |   145.3267 ns |    33.3217 ns |  1.8827 ns | 0.0169 |      72 B |
|        List_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |          10 |       100 |   224.0385 ns |   110.9646 ns |  6.2697 ns | 0.0246 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |         **0** |    **32.8593 ns** |     **8.8650 ns** |  **0.5009 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |         100 |         0 |     0.4400 ns |     0.3928 ns |  0.0222 ns |      - |       0 B |
|        Array_System |                True |         100 |         0 |    29.6145 ns |     9.1587 ns |  0.5175 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |         100 |         0 |    43.8209 ns |     3.5417 ns |  0.2001 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |         0 |    29.7710 ns |    23.5082 ns |  1.3283 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |         0 |    30.6331 ns |    31.3319 ns |  1.7703 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |         100 |         0 |    32.6889 ns |    10.0062 ns |  0.5654 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |         100 |         0 |     0.3715 ns |     0.2716 ns |  0.0153 ns |      - |       0 B |
|        IList_System |                True |         100 |         0 |    29.2590 ns |     9.7342 ns |  0.5500 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |         100 |         0 |    32.8646 ns |     4.5742 ns |  0.2584 ns | 0.0171 |      72 B |
|        List_Optimal |                True |         100 |         0 |     0.4301 ns |     0.6106 ns |  0.0345 ns |      - |       0 B |
|         List_System |                True |         100 |         0 |    29.9817 ns |     9.0990 ns |  0.5141 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |         **100** |        **10** |   **151.3346 ns** |     **9.6208 ns** |  **0.5436 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |         100 |        10 |     7.5512 ns |     3.0089 ns |  0.1700 ns |      - |       0 B |
|        Array_System |                True |         100 |        10 |   201.4963 ns |    22.3258 ns |  1.2614 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |         100 |        10 |   252.7608 ns |    67.7768 ns |  3.8295 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |        10 |   237.1170 ns |    57.5080 ns |  3.2493 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |        10 |   200.2678 ns |    22.2948 ns |  1.2597 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |         100 |        10 |   166.9592 ns |    72.1833 ns |  4.0785 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |         100 |        10 |    34.1276 ns |     7.4770 ns |  0.4225 ns |      - |       0 B |
|        IList_System |                True |         100 |        10 |   225.8587 ns |    45.5573 ns |  2.5741 ns | 0.0246 |     104 B |
|       List_FastLinq |                True |         100 |        10 |   146.7703 ns |    12.5348 ns |  0.7082 ns | 0.0169 |      72 B |
|        List_Optimal |                True |         100 |        10 |    13.3990 ns |     4.5267 ns |  0.2558 ns |      - |       0 B |
|         List_System |                True |         100 |        10 |   217.6368 ns |    74.9876 ns |  4.2369 ns | 0.0246 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |       **100** | **1,061.9088 ns** |   **403.6822 ns** | **22.8088 ns** | **0.0153** |      **72 B** |
|       Array_Optimal |                True |         100 |       100 |    79.4864 ns |    22.4139 ns |  1.2664 ns |      - |       0 B |
|        Array_System |                True |         100 |       100 | 1,550.1095 ns | 1,410.4950 ns | 79.6956 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |       100 | 1,800.8659 ns |   312.1008 ns | 17.6343 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |       100 | 1,800.9695 ns |   337.3296 ns | 19.0597 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |       100 | 1,429.6209 ns |   305.2913 ns | 17.2495 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |       100 | 1,222.9272 ns |   350.6640 ns | 19.8132 ns | 0.0153 |      72 B |
|       IList_Optimal |                True |         100 |       100 |   338.2424 ns |   150.5685 ns |  8.5074 ns |      - |       0 B |
|        IList_System |                True |         100 |       100 | 1,582.6080 ns |   586.8873 ns | 33.1602 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |       100 | 1,010.9264 ns |   334.9343 ns | 18.9244 ns | 0.0153 |      72 B |
|        List_Optimal |                True |         100 |       100 |   121.0496 ns |    11.6333 ns |  0.6573 ns |      - |       0 B |
|         List_System |                True |         100 |       100 | 1,572.4937 ns |   603.1247 ns | 34.0777 ns | 0.0229 |     104 B |

Benchmarks with issues:
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=0]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=0]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=10]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=0]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=10]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, SizeOfInput=100, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=0]
  TakeBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=10]
  TakeBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=0, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=0]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=10]
  TakeBenchmark.Array_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.IList_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.List_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=10, TakeCount=100]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=0]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=0]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=10]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=10]
  TakeBenchmark.Collection_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=100]
  TakeBenchmark.Enumerable_Optimal: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, SizeOfInput=100, TakeCount=100]
