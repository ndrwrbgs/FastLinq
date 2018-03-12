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
|      **Array_FastLinq** |               **False** |           **0** |         **0** |    **11.0991 ns** |     **0.9858 ns** |  **0.0557 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |         0 |     0.5129 ns |     0.3829 ns |  0.0216 ns |      - |       0 B |
|        Array_System |               False |           0 |         0 |    15.1468 ns |     4.5806 ns |  0.2588 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |         0 |    28.9544 ns |    10.4461 ns |  0.5902 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |         0 |    15.0615 ns |     3.3389 ns |  0.1887 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |         0 |    15.6107 ns |     6.6620 ns |  0.3764 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |         0 |    11.3623 ns |     3.7446 ns |  0.2116 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |         0 |     0.4269 ns |     0.4800 ns |  0.0271 ns |      - |       0 B |
|        IList_System |               False |           0 |         0 |    15.3719 ns |     2.7107 ns |  0.1532 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |         0 |    11.3647 ns |     1.5711 ns |  0.0888 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |         0 |     0.6392 ns |     0.6116 ns |  0.0346 ns |      - |       0 B |
|         List_System |               False |           0 |         0 |    15.3753 ns |     0.8386 ns |  0.0474 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |        **10** |    **16.1309 ns** |     **5.4559 ns** |  **0.3083 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |        10 |     0.5169 ns |     0.6091 ns |  0.0344 ns |      - |       0 B |
|        Array_System |               False |           0 |        10 |    15.6649 ns |     1.8417 ns |  0.1041 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |        10 |    29.2962 ns |     4.5800 ns |  0.2588 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |        10 |    15.3699 ns |     0.5489 ns |  0.0310 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |        10 |    15.1883 ns |     9.4202 ns |  0.5323 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |        10 |    17.2979 ns |     3.0474 ns |  0.1722 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |        10 |     0.3562 ns |     0.1985 ns |  0.0112 ns |      - |       0 B |
|        IList_System |               False |           0 |        10 |    15.2742 ns |     1.6908 ns |  0.0955 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |        10 |    16.2406 ns |     2.8412 ns |  0.1605 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |        10 |     0.6849 ns |     0.4989 ns |  0.0282 ns |      - |       0 B |
|         List_System |               False |           0 |        10 |    15.5245 ns |     2.8609 ns |  0.1616 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |       **100** |    **15.6889 ns** |     **7.6282 ns** |  **0.4310 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |       100 |     0.5315 ns |     0.2446 ns |  0.0138 ns |      - |       0 B |
|        Array_System |               False |           0 |       100 |    15.3540 ns |     3.2863 ns |  0.1857 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |       100 |    29.1233 ns |     1.9721 ns |  0.1114 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |       100 |    15.1954 ns |     0.7227 ns |  0.0408 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |       100 |    15.0280 ns |     1.8971 ns |  0.1072 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |       100 |    18.0059 ns |     6.1171 ns |  0.3456 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |       100 |     0.3285 ns |     0.8622 ns |  0.0487 ns |      - |       0 B |
|        IList_System |               False |           0 |       100 |    14.8900 ns |    17.2550 ns |  0.9749 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |       100 |    15.9969 ns |     4.4122 ns |  0.2493 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |       100 |     0.7091 ns |     1.2444 ns |  0.0703 ns |      - |       0 B |
|         List_System |               False |           0 |       100 |    15.7023 ns |     5.0515 ns |  0.2854 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |         **0** |    **11.5880 ns** |     **2.0458 ns** |  **0.1156 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |         0 |     0.5268 ns |     0.2023 ns |  0.0114 ns |      - |       0 B |
|        Array_System |               False |          10 |         0 |    15.1019 ns |     3.8075 ns |  0.2151 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |         0 |    28.4291 ns |    11.1293 ns |  0.6288 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |         0 |    15.5828 ns |     0.8779 ns |  0.0496 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |         0 |    15.2880 ns |     4.4797 ns |  0.2531 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |         0 |    11.1540 ns |     6.4510 ns |  0.3645 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |         0 |     0.3833 ns |     0.5377 ns |  0.0304 ns |      - |       0 B |
|        IList_System |               False |          10 |         0 |    14.8811 ns |     7.4003 ns |  0.4181 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |         0 |    10.6448 ns |     2.6312 ns |  0.1487 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |         0 |     0.6198 ns |     1.0675 ns |  0.0603 ns |      - |       0 B |
|         List_System |               False |          10 |         0 |    14.2058 ns |     4.4340 ns |  0.2505 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |        **10** |    **14.8979 ns** |     **8.5800 ns** |  **0.4848 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |        10 |     0.4930 ns |     0.7185 ns |  0.0406 ns |      - |       0 B |
|        Array_System |               False |          10 |        10 |    14.7558 ns |     3.4367 ns |  0.1942 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |        10 |    27.2632 ns |    10.3806 ns |  0.5865 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |        10 |    14.4497 ns |     5.4998 ns |  0.3108 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |        10 |    14.8347 ns |     5.2892 ns |  0.2989 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |        10 |    16.5146 ns |     4.2558 ns |  0.2405 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |        10 |     0.3988 ns |     0.2803 ns |  0.0158 ns |      - |       0 B |
|        IList_System |               False |          10 |        10 |    12.6471 ns |     3.6822 ns |  0.2080 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |        10 |    15.5277 ns |     5.3768 ns |  0.3038 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |        10 |     0.6167 ns |     1.0435 ns |  0.0590 ns |      - |       0 B |
|         List_System |               False |          10 |        10 |    14.4725 ns |     4.5895 ns |  0.2593 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |       **100** |    **15.1755 ns** |    **11.7213 ns** |  **0.6623 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |       100 |     0.5043 ns |     0.6887 ns |  0.0389 ns |      - |       0 B |
|        Array_System |               False |          10 |       100 |    15.0634 ns |     6.1764 ns |  0.3490 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |       100 |    28.7283 ns |     7.4411 ns |  0.4204 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |       100 |    15.3295 ns |     6.5556 ns |  0.3704 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |       100 |    14.8892 ns |     4.3753 ns |  0.2472 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |       100 |    17.8732 ns |     3.0661 ns |  0.1732 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |       100 |     0.2893 ns |     0.2021 ns |  0.0114 ns |      - |       0 B |
|        IList_System |               False |          10 |       100 |    14.6572 ns |     4.1598 ns |  0.2350 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |       100 |    14.7638 ns |     2.9980 ns |  0.1694 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |       100 |     0.6355 ns |     1.5028 ns |  0.0849 ns |      - |       0 B |
|         List_System |               False |          10 |       100 |    14.9147 ns |     7.5134 ns |  0.4245 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |         **0** |    **10.7024 ns** |     **2.2168 ns** |  **0.1253 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |         0 |     0.5845 ns |     0.3757 ns |  0.0212 ns |      - |       0 B |
|        Array_System |               False |         100 |         0 |    15.1683 ns |     2.7961 ns |  0.1580 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |         0 |    28.7338 ns |    11.9742 ns |  0.6766 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |         0 |    15.1134 ns |     7.1849 ns |  0.4060 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |         0 |    14.7038 ns |     3.7045 ns |  0.2093 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |         0 |    10.4055 ns |     2.0428 ns |  0.1154 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |         0 |     0.4212 ns |     0.6557 ns |  0.0370 ns |      - |       0 B |
|        IList_System |               False |         100 |         0 |    15.2715 ns |     2.1041 ns |  0.1189 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |         0 |    11.0420 ns |     3.9463 ns |  0.2230 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |         0 |     0.5985 ns |     3.3675 ns |  0.1903 ns |      - |       0 B |
|         List_System |               False |         100 |         0 |    15.2588 ns |     5.1695 ns |  0.2921 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |        **10** |    **15.3349 ns** |     **3.4329 ns** |  **0.1940 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |        10 |     0.4962 ns |     3.9323 ns |  0.2222 ns |      - |       0 B |
|        Array_System |               False |         100 |        10 |    15.3019 ns |     4.6393 ns |  0.2621 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |        10 |    29.1501 ns |     2.2401 ns |  0.1266 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |        10 |    15.0245 ns |     1.9783 ns |  0.1118 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |        10 |    14.7427 ns |     1.7295 ns |  0.0977 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |        10 |    17.3150 ns |     6.7308 ns |  0.3803 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |        10 |     0.3830 ns |     0.5081 ns |  0.0287 ns |      - |       0 B |
|        IList_System |               False |         100 |        10 |    14.4553 ns |     2.6721 ns |  0.1510 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |        10 |    14.5047 ns |     6.8303 ns |  0.3859 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |        10 |     0.6009 ns |     0.5007 ns |  0.0283 ns |      - |       0 B |
|         List_System |               False |         100 |        10 |    14.8798 ns |    10.3611 ns |  0.5854 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |       **100** |    **14.6779 ns** |     **3.6236 ns** |  **0.2047 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |       100 |     0.4936 ns |     0.2036 ns |  0.0115 ns |      - |       0 B |
|        Array_System |               False |         100 |       100 |    14.9871 ns |     5.9225 ns |  0.3346 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |       100 |    28.0475 ns |     4.0316 ns |  0.2278 ns | 0.0229 |      96 B |
|  Collection_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |       100 |    14.8354 ns |     4.9160 ns |  0.2778 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |       100 |    16.0206 ns |     1.0529 ns |  0.0595 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |       100 |    17.4137 ns |     8.1691 ns |  0.4616 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |       100 |     0.3416 ns |     0.4230 ns |  0.0239 ns |      - |       0 B |
|        IList_System |               False |         100 |       100 |    15.2085 ns |     2.8906 ns |  0.1633 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |       100 |    15.2336 ns |     5.4168 ns |  0.3061 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |       100 |     0.6683 ns |     0.6277 ns |  0.0355 ns |      - |       0 B |
|         List_System |               False |         100 |       100 |    15.4445 ns |     6.2800 ns |  0.3548 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |         **0** |    **38.2732 ns** |    **20.0872 ns** |  **1.1350 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |         0 |     0.5686 ns |     0.8441 ns |  0.0477 ns |      - |       0 B |
|        Array_System |                True |           0 |         0 |    31.1467 ns |     7.7314 ns |  0.4368 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |         0 |    53.1378 ns |    16.4572 ns |  0.9299 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |         0 |    33.2129 ns |     6.7264 ns |  0.3801 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |         0 |    31.2944 ns |    15.7120 ns |  0.8878 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |           0 |         0 |    38.0618 ns |    15.5404 ns |  0.8781 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |         0 |     0.4830 ns |     0.8902 ns |  0.0503 ns |      - |       0 B |
|        IList_System |                True |           0 |         0 |    32.5930 ns |     8.8364 ns |  0.4993 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |           0 |         0 |    37.6082 ns |     3.4310 ns |  0.1939 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |         0 |     0.7396 ns |     1.1001 ns |  0.0622 ns |      - |       0 B |
|         List_System |                True |           0 |         0 |    32.3149 ns |     5.7521 ns |  0.3250 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |        **10** |    **42.3627 ns** |    **17.8426 ns** |  **1.0081 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |           0 |        10 |    52.9605 ns |     8.2205 ns |  0.4645 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |        10 |    78.6475 ns |    30.5281 ns |  1.7249 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |        10 |    57.7949 ns |    18.6452 ns |  1.0535 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |        10 |    59.4359 ns |    11.5784 ns |  0.6542 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |        10 |    44.2301 ns |     8.0624 ns |  0.4555 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |           0 |        10 |    62.2279 ns |    30.9479 ns |  1.7486 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |        10 |    42.3203 ns |     6.8539 ns |  0.3873 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |           0 |        10 |    58.4511 ns |    12.3632 ns |  0.6985 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |       **100** |    **41.4990 ns** |    **20.0542 ns** |  **1.1331 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |           0 |       100 |    51.9680 ns |    18.7605 ns |  1.0600 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |       100 |    77.9157 ns |    22.9889 ns |  1.2989 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |       100 |    57.6249 ns |     9.6768 ns |  0.5468 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |       100 |    56.0696 ns |    17.9942 ns |  1.0167 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |       100 |    44.2887 ns |     2.8840 ns |  0.1630 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |           0 |       100 |    58.7838 ns |    28.2823 ns |  1.5980 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |       100 |    41.9497 ns |    20.5324 ns |  1.1601 ns | 0.0171 |      72 B |
|        List_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |           0 |       100 |    59.0668 ns |    20.1437 ns |  1.1382 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |         **0** |    **36.5326 ns** |     **3.3530 ns** |  **0.1895 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |          10 |         0 |     0.5853 ns |     0.4166 ns |  0.0235 ns |      - |       0 B |
|        Array_System |                True |          10 |         0 |    32.8041 ns |     5.8716 ns |  0.3318 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |          10 |         0 |    49.3153 ns |     6.6883 ns |  0.3779 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |         0 |    34.1494 ns |     7.2317 ns |  0.4086 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |         0 |    33.6748 ns |     1.8498 ns |  0.1045 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |          10 |         0 |    37.1618 ns |     4.3764 ns |  0.2473 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |          10 |         0 |     0.4688 ns |     1.2011 ns |  0.0679 ns |      - |       0 B |
|        IList_System |                True |          10 |         0 |    33.5487 ns |     7.7181 ns |  0.4361 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |          10 |         0 |    36.9782 ns |     6.2209 ns |  0.3515 ns | 0.0171 |      72 B |
|        List_Optimal |                True |          10 |         0 |     0.6435 ns |     0.9606 ns |  0.0543 ns |      - |       0 B |
|         List_System |                True |          10 |         0 |    32.6784 ns |     9.5112 ns |  0.5374 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |          **10** |        **10** |   **173.1797 ns** |    **57.7741 ns** |  **3.2643 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |          10 |        10 |     8.9508 ns |     4.0994 ns |  0.2316 ns |      - |       0 B |
|        Array_System |                True |          10 |        10 |   238.1180 ns |    79.9488 ns |  4.5173 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |        10 |   286.0232 ns |    70.7776 ns |  3.9991 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |        10 |   265.8068 ns |   113.5974 ns |  6.4185 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |        10 |   222.6644 ns |    30.5796 ns |  1.7278 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |        10 |   195.9581 ns |    56.6303 ns |  3.1997 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |          10 |        10 |    44.7479 ns |    14.1001 ns |  0.7967 ns |      - |       0 B |
|        IList_System |                True |          10 |        10 |   246.8604 ns |    20.3610 ns |  1.1504 ns | 0.0243 |     104 B |
|       List_FastLinq |                True |          10 |        10 |   165.2481 ns |   128.9220 ns |  7.2843 ns | 0.0169 |      72 B |
|        List_Optimal |                True |          10 |        10 |    14.4871 ns |     6.5526 ns |  0.3702 ns |      - |       0 B |
|         List_System |                True |          10 |        10 |   238.3086 ns |   109.5635 ns |  6.1905 ns | 0.0243 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |       **100** |   **163.9826 ns** |    **56.7130 ns** |  **3.2044 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        Array_System |                True |          10 |       100 |   227.9232 ns |    88.7987 ns |  5.0173 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |       100 |   299.0570 ns |    19.5563 ns |  1.1050 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |       100 |   278.3631 ns |    74.2897 ns |  4.1975 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |       100 |   237.1254 ns |   132.5108 ns |  7.4871 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |       100 |   190.1738 ns |    83.2117 ns |  4.7016 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|        IList_System |                True |          10 |       100 |   251.5121 ns |    50.4025 ns |  2.8478 ns | 0.0243 |     104 B |
|       List_FastLinq |                True |          10 |       100 |   165.6154 ns |    99.2726 ns |  5.6091 ns | 0.0169 |      72 B |
|        List_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|         List_System |                True |          10 |       100 |   253.4127 ns |   113.7106 ns |  6.4249 ns | 0.0243 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |         **0** |    **35.8212 ns** |     **4.7388 ns** |  **0.2678 ns** | **0.0171** |      **72 B** |
|       Array_Optimal |                True |         100 |         0 |     0.5746 ns |     0.1409 ns |  0.0080 ns |      - |       0 B |
|        Array_System |                True |         100 |         0 |    32.5182 ns |     4.8721 ns |  0.2753 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |         100 |         0 |    47.5726 ns |    97.3197 ns |  5.4987 ns | 0.0228 |      96 B |
|  Collection_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |         0 |    32.6934 ns |    11.1964 ns |  0.6326 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |         0 |    32.3684 ns |    13.3349 ns |  0.7534 ns | 0.0152 |      64 B |
|      IList_FastLinq |                True |         100 |         0 |    35.3033 ns |     6.6661 ns |  0.3766 ns | 0.0171 |      72 B |
|       IList_Optimal |                True |         100 |         0 |     0.4791 ns |     0.3151 ns |  0.0178 ns |      - |       0 B |
|        IList_System |                True |         100 |         0 |    32.2917 ns |     6.8166 ns |  0.3851 ns | 0.0152 |      64 B |
|       List_FastLinq |                True |         100 |         0 |    35.2371 ns |     1.8730 ns |  0.1058 ns | 0.0171 |      72 B |
|        List_Optimal |                True |         100 |         0 |     0.8314 ns |     1.0346 ns |  0.0585 ns |      - |       0 B |
|         List_System |                True |         100 |         0 |    33.2811 ns |     4.2081 ns |  0.2378 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |         **100** |        **10** |   **169.0064 ns** |    **24.7009 ns** |  **1.3956 ns** | **0.0169** |      **72 B** |
|       Array_Optimal |                True |         100 |        10 |     8.5593 ns |     5.3820 ns |  0.3041 ns |      - |       0 B |
|        Array_System |                True |         100 |        10 |   235.9060 ns |    56.5018 ns |  3.1925 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |         100 |        10 |   299.3674 ns |   150.9473 ns |  8.5288 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |        10 |   273.0283 ns |    45.3367 ns |  2.5616 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |        10 |   222.4643 ns |    14.5308 ns |  0.8210 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |         100 |        10 |   187.5194 ns |    43.4228 ns |  2.4535 ns | 0.0169 |      72 B |
|       IList_Optimal |                True |         100 |        10 |    39.6062 ns |    13.7703 ns |  0.7780 ns |      - |       0 B |
|        IList_System |                True |         100 |        10 |   255.7175 ns |    39.7401 ns |  2.2454 ns | 0.0243 |     104 B |
|       List_FastLinq |                True |         100 |        10 |   169.0662 ns |    68.0795 ns |  3.8466 ns | 0.0169 |      72 B |
|        List_Optimal |                True |         100 |        10 |    14.4130 ns |     5.7717 ns |  0.3261 ns |      - |       0 B |
|         List_System |                True |         100 |        10 |   241.9512 ns |    48.2938 ns |  2.7287 ns | 0.0246 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |       **100** | **1,186.4317 ns** |   **156.2966 ns** |  **8.8310 ns** | **0.0153** |      **72 B** |
|       Array_Optimal |                True |         100 |       100 |    90.1439 ns |    17.4004 ns |  0.9832 ns |      - |       0 B |
|        Array_System |                True |         100 |       100 | 1,699.9423 ns |   345.5155 ns | 19.5223 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |       100 | 2,053.8110 ns |   509.5539 ns | 28.7907 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |       100 | 2,046.0332 ns | 1,124.9696 ns | 63.5629 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |       100 | 1,598.7651 ns |   291.5882 ns | 16.4753 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |       100 | 1,379.6805 ns |   335.2558 ns | 18.9426 ns | 0.0153 |      72 B |
|       IList_Optimal |                True |         100 |       100 |   380.6038 ns |   142.9716 ns |  8.0782 ns |      - |       0 B |
|        IList_System |                True |         100 |       100 | 1,748.9825 ns |   462.5164 ns | 26.1330 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |       100 | 1,166.1165 ns |   226.2416 ns | 12.7831 ns | 0.0153 |      72 B |
|        List_Optimal |                True |         100 |       100 |   137.3009 ns |    59.6205 ns |  3.3687 ns |      - |       0 B |
|         List_System |                True |         100 |       100 | 1,772.0044 ns |   839.8315 ns | 47.4520 ns | 0.0229 |     104 B |

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
