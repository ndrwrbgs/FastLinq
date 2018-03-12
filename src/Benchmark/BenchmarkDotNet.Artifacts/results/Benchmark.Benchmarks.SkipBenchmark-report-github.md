``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards | SizeOfInput | SkipCount |          Mean |         Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------ |---------- |--------------:|--------------:|-----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |           **0** |         **0** |    **13.8509 ns** |     **4.2191 ns** |  **0.2384 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |         0 |     0.4988 ns |     0.7599 ns |  0.0429 ns |      - |       0 B |
|        Array_System |               False |           0 |         0 |    15.7195 ns |     3.1361 ns |  0.1772 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |         0 |    29.4265 ns |     4.8189 ns |  0.2723 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |         0 |    15.1022 ns |     1.4210 ns |  0.0803 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |         0 |    15.0059 ns |     1.8381 ns |  0.1039 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |         0 |    15.5467 ns |     5.5839 ns |  0.3155 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |         0 |     0.4472 ns |     0.4701 ns |  0.0266 ns |      - |       0 B |
|        IList_System |               False |           0 |         0 |    15.3833 ns |     1.9808 ns |  0.1119 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |         0 |    13.7926 ns |     4.4707 ns |  0.2526 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |         0 |     0.6241 ns |     0.7957 ns |  0.0450 ns |      - |       0 B |
|         List_System |               False |           0 |         0 |    15.1676 ns |     2.8367 ns |  0.1603 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |        **10** |    **13.5743 ns** |     **1.3324 ns** |  **0.0753 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |        10 |     0.5725 ns |     0.0866 ns |  0.0049 ns |      - |       0 B |
|        Array_System |               False |           0 |        10 |    15.4166 ns |     0.5127 ns |  0.0290 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |        10 |    29.3354 ns |     4.8315 ns |  0.2730 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |        10 |    15.2949 ns |     1.0583 ns |  0.0598 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |        10 |    15.2676 ns |     1.0833 ns |  0.0612 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |        10 |    15.7304 ns |     2.9373 ns |  0.1660 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |        10 |     0.4587 ns |     0.3565 ns |  0.0201 ns |      - |       0 B |
|        IList_System |               False |           0 |        10 |    15.2983 ns |     4.5967 ns |  0.2597 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |        10 |    13.3150 ns |     3.5127 ns |  0.1985 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |        10 |     0.6551 ns |     0.3635 ns |  0.0205 ns |      - |       0 B |
|         List_System |               False |           0 |        10 |    14.7215 ns |     3.2572 ns |  0.1840 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |           **0** |       **100** |    **13.2762 ns** |     **1.4155 ns** |  **0.0800 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |           0 |       100 |     0.5290 ns |     0.2899 ns |  0.0164 ns |      - |       0 B |
|        Array_System |               False |           0 |       100 |    14.7966 ns |     5.5723 ns |  0.3148 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |           0 |       100 |    28.8510 ns |     2.3188 ns |  0.1310 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |           0 |       100 |    15.1570 ns |     3.6974 ns |  0.2089 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |           0 |       100 |    15.2824 ns |     2.0426 ns |  0.1154 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |           0 |       100 |    15.8460 ns |     6.3681 ns |  0.3598 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |           0 |       100 |     0.3112 ns |     0.2426 ns |  0.0137 ns |      - |       0 B |
|        IList_System |               False |           0 |       100 |    15.8203 ns |     1.3748 ns |  0.0777 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |           0 |       100 |    12.6023 ns |    27.9470 ns |  1.5791 ns | 0.0076 |      32 B |
|        List_Optimal |               False |           0 |       100 |     0.6435 ns |     1.1607 ns |  0.0656 ns |      - |       0 B |
|         List_System |               False |           0 |       100 |    15.6630 ns |     3.0714 ns |  0.1735 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |         **0** |    **15.0556 ns** |     **1.0403 ns** |  **0.0588 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |         0 |     0.5381 ns |     0.6206 ns |  0.0351 ns |      - |       0 B |
|        Array_System |               False |          10 |         0 |    15.5383 ns |     0.7288 ns |  0.0412 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |         0 |    28.5609 ns |     6.7572 ns |  0.3818 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |         0 |    15.3240 ns |     7.4936 ns |  0.4234 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |         0 |    14.8534 ns |     2.1759 ns |  0.1229 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |         0 |    17.1741 ns |     8.3828 ns |  0.4736 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |         0 |     0.3742 ns |     1.5096 ns |  0.0853 ns |      - |       0 B |
|        IList_System |               False |          10 |         0 |    15.4278 ns |     5.9886 ns |  0.3384 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |         0 |    14.7691 ns |     0.1770 ns |  0.0100 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |         0 |     0.7066 ns |     0.8158 ns |  0.0461 ns |      - |       0 B |
|         List_System |               False |          10 |         0 |    15.4479 ns |     3.1332 ns |  0.1770 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |        **10** |    **13.7139 ns** |     **2.3290 ns** |  **0.1316 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |        10 |     0.5466 ns |     0.2033 ns |  0.0115 ns |      - |       0 B |
|        Array_System |               False |          10 |        10 |    14.9648 ns |     1.5312 ns |  0.0865 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |        10 |    27.8213 ns |     7.3409 ns |  0.4148 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |        10 |    15.3521 ns |     7.1702 ns |  0.4051 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |        10 |    15.1776 ns |     0.5075 ns |  0.0287 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |        10 |    15.6917 ns |     4.9016 ns |  0.2769 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |        10 |     0.4225 ns |     0.9902 ns |  0.0559 ns |      - |       0 B |
|        IList_System |               False |          10 |        10 |    15.7275 ns |     5.5155 ns |  0.3116 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |        10 |    13.9308 ns |     1.1238 ns |  0.0635 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |        10 |     0.6979 ns |     0.9885 ns |  0.0559 ns |      - |       0 B |
|         List_System |               False |          10 |        10 |    14.9867 ns |     0.4827 ns |  0.0273 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |          **10** |       **100** |    **13.5653 ns** |     **8.7915 ns** |  **0.4967 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |          10 |       100 |     0.5026 ns |     1.1671 ns |  0.0659 ns |      - |       0 B |
|        Array_System |               False |          10 |       100 |    15.7274 ns |     2.2599 ns |  0.1277 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |          10 |       100 |    28.8933 ns |     9.1873 ns |  0.5191 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |          10 |       100 |    15.1520 ns |     4.8206 ns |  0.2724 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |          10 |       100 |    14.1464 ns |    31.9502 ns |  1.8052 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |          10 |       100 |    15.2488 ns |     1.7072 ns |  0.0965 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |          10 |       100 |     0.4052 ns |     0.4262 ns |  0.0241 ns |      - |       0 B |
|        IList_System |               False |          10 |       100 |    15.3652 ns |     1.8458 ns |  0.1043 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |          10 |       100 |    13.8994 ns |     2.2116 ns |  0.1250 ns | 0.0076 |      32 B |
|        List_Optimal |               False |          10 |       100 |     0.8177 ns |     0.7840 ns |  0.0443 ns |      - |       0 B |
|         List_System |               False |          10 |       100 |    15.3605 ns |     4.2848 ns |  0.2421 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |         **0** |    **14.6634 ns** |     **2.9112 ns** |  **0.1645 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |         0 |     0.5207 ns |     1.3982 ns |  0.0790 ns |      - |       0 B |
|        Array_System |               False |         100 |         0 |    15.3319 ns |     0.5427 ns |  0.0307 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |         0 |    29.6528 ns |     6.9495 ns |  0.3927 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |         0 |    15.4931 ns |     7.7887 ns |  0.4401 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |         0 |    15.7110 ns |     6.8976 ns |  0.3897 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |         0 |    16.7302 ns |     6.4906 ns |  0.3667 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |         0 |     0.4170 ns |     0.4270 ns |  0.0241 ns |      - |       0 B |
|        IList_System |               False |         100 |         0 |    15.2509 ns |     5.8744 ns |  0.3319 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |         0 |    14.7785 ns |     4.6341 ns |  0.2618 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |         0 |     0.6450 ns |     0.9103 ns |  0.0514 ns |      - |       0 B |
|         List_System |               False |         100 |         0 |    15.3708 ns |     5.1530 ns |  0.2912 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |        **10** |    **14.3989 ns** |     **2.6634 ns** |  **0.1505 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |        10 |     0.5191 ns |     0.5807 ns |  0.0328 ns |      - |       0 B |
|        Array_System |               False |         100 |        10 |    15.3070 ns |     0.1864 ns |  0.0105 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |        10 |    29.0643 ns |     9.6131 ns |  0.5432 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |        10 |    15.2937 ns |     4.3251 ns |  0.2444 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |        10 |    15.5888 ns |     1.8994 ns |  0.1073 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |        10 |    16.9897 ns |     1.5740 ns |  0.0889 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |        10 |     0.3818 ns |     0.6011 ns |  0.0340 ns |      - |       0 B |
|        IList_System |               False |         100 |        10 |    15.5922 ns |     0.6671 ns |  0.0377 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |        10 |    14.8028 ns |     8.9975 ns |  0.5084 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |        10 |     0.6019 ns |     3.1682 ns |  0.1790 ns |      - |       0 B |
|         List_System |               False |         100 |        10 |    14.8886 ns |     5.5227 ns |  0.3120 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |               **False** |         **100** |       **100** |    **13.5024 ns** |     **2.4931 ns** |  **0.1409 ns** | **0.0076** |      **32 B** |
|       Array_Optimal |               False |         100 |       100 |     0.6147 ns |     0.3604 ns |  0.0204 ns |      - |       0 B |
|        Array_System |               False |         100 |       100 |    14.7888 ns |     5.0924 ns |  0.2877 ns | 0.0152 |      64 B |
| Collection_FastLinq |               False |         100 |       100 |    28.0030 ns |     6.4230 ns |  0.3629 ns | 0.0228 |      96 B |
|  Collection_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |               False |         100 |       100 |    15.3926 ns |     8.9357 ns |  0.5049 ns | 0.0152 |      64 B |
|  Enumerable_Optimal |               False |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |               False |         100 |       100 |    15.9308 ns |    10.1670 ns |  0.5745 ns | 0.0152 |      64 B |
|      IList_FastLinq |               False |         100 |       100 |    16.2106 ns |     2.2643 ns |  0.1279 ns | 0.0076 |      32 B |
|       IList_Optimal |               False |         100 |       100 |     0.3961 ns |     0.4558 ns |  0.0258 ns |      - |       0 B |
|        IList_System |               False |         100 |       100 |    15.0933 ns |     4.2908 ns |  0.2424 ns | 0.0152 |      64 B |
|       List_FastLinq |               False |         100 |       100 |    13.1785 ns |     0.1633 ns |  0.0092 ns | 0.0076 |      32 B |
|        List_Optimal |               False |         100 |       100 |     0.5487 ns |     1.0922 ns |  0.0617 ns |      - |       0 B |
|         List_System |               False |         100 |       100 |    14.6067 ns |     2.5075 ns |  0.1417 ns | 0.0152 |      64 B |
|      **Array_FastLinq** |                **True** |           **0** |         **0** |    **41.6973 ns** |    **14.4053 ns** |  **0.8139 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |         0 |     0.5731 ns |     0.4130 ns |  0.0233 ns |      - |       0 B |
|        Array_System |                True |           0 |         0 |    53.9097 ns |     6.1986 ns |  0.3502 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |         0 |    76.3486 ns |    23.1076 ns |  1.3056 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |         0 |    58.8652 ns |    11.6083 ns |  0.6559 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |         0 |    59.4646 ns |    39.7138 ns |  2.2439 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |         0 |    45.9060 ns |    24.2350 ns |  1.3693 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |         0 |     0.4514 ns |     0.6062 ns |  0.0342 ns |      - |       0 B |
|        IList_System |                True |           0 |         0 |    61.3883 ns |    21.0792 ns |  1.1910 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |         0 |    44.0344 ns |     5.0066 ns |  0.2829 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |         0 |     0.6668 ns |     0.5350 ns |  0.0302 ns |      - |       0 B |
|         List_System |                True |           0 |         0 |    56.5675 ns |    16.8484 ns |  0.9520 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |        **10** |    **42.8075 ns** |    **11.3136 ns** |  **0.6392 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |        10 |     0.6447 ns |     0.0382 ns |  0.0022 ns |      - |       0 B |
|        Array_System |                True |           0 |        10 |    54.5211 ns |     7.6850 ns |  0.4342 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |        10 |    79.2308 ns |    26.2828 ns |  1.4850 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |        10 |    58.7132 ns |    11.8776 ns |  0.6711 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |        10 |    61.4522 ns |     5.3549 ns |  0.3026 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |        10 |    45.8574 ns |     6.1948 ns |  0.3500 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |        10 |     0.4405 ns |     0.5497 ns |  0.0311 ns |      - |       0 B |
|        IList_System |                True |           0 |        10 |    62.4628 ns |    13.6116 ns |  0.7691 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |        10 |    43.6341 ns |    11.4182 ns |  0.6452 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |        10 |     0.6373 ns |     1.9104 ns |  0.1079 ns |      - |       0 B |
|         List_System |                True |           0 |        10 |    55.6878 ns |    11.5180 ns |  0.6508 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |           **0** |       **100** |    **42.2812 ns** |    **13.3249 ns** |  **0.7529 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |           0 |       100 |     0.5736 ns |     0.5623 ns |  0.0318 ns |      - |       0 B |
|        Array_System |                True |           0 |       100 |    53.6223 ns |    13.2379 ns |  0.7480 ns | 0.0152 |      64 B |
| Collection_FastLinq |                True |           0 |       100 |    77.0204 ns |    39.3267 ns |  2.2220 ns | 0.0323 |     136 B |
|  Collection_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |           0 |       100 |    59.1824 ns |    11.5531 ns |  0.6528 ns | 0.0247 |     104 B |
|  Enumerable_Optimal |                True |           0 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |           0 |       100 |    59.5186 ns |    10.1867 ns |  0.5756 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |           0 |       100 |    46.1490 ns |     4.7250 ns |  0.2670 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |           0 |       100 |     0.3926 ns |     1.9712 ns |  0.1114 ns |      - |       0 B |
|        IList_System |                True |           0 |       100 |    60.4713 ns |    11.8946 ns |  0.6721 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |           0 |       100 |    43.7847 ns |    22.4569 ns |  1.2689 ns | 0.0190 |      80 B |
|        List_Optimal |                True |           0 |       100 |     0.7612 ns |     1.0701 ns |  0.0605 ns |      - |       0 B |
|         List_System |                True |           0 |       100 |    55.3176 ns |    11.8682 ns |  0.6706 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |         **0** |   **177.5968 ns** |    **75.9978 ns** |  **4.2940 ns** | **0.0188** |      **80 B** |
|       Array_Optimal |                True |          10 |         0 |     8.7266 ns |     3.5975 ns |  0.2033 ns |      - |       0 B |
|        Array_System |                True |          10 |         0 |   222.0518 ns |   178.3663 ns | 10.0780 ns | 0.0226 |      96 B |
| Collection_FastLinq |                True |          10 |         0 |   304.0038 ns |    18.8994 ns |  1.0678 ns | 0.0319 |     136 B |
|  Collection_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |         0 |   287.6902 ns |   114.0779 ns |  6.4456 ns | 0.0243 |     104 B |
|  Enumerable_Optimal |                True |          10 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |         0 |   226.0596 ns |    40.7468 ns |  2.3023 ns | 0.0265 |     112 B |
|      IList_FastLinq |                True |          10 |         0 |   195.1958 ns |    51.0127 ns |  2.8823 ns | 0.0188 |      80 B |
|       IList_Optimal |                True |          10 |         0 |    41.7343 ns |    21.7230 ns |  1.2274 ns |      - |       0 B |
|        IList_System |                True |          10 |         0 |   244.7171 ns |    88.3390 ns |  4.9913 ns | 0.0243 |     104 B |
|       List_FastLinq |                True |          10 |         0 |   173.1417 ns |    31.4719 ns |  1.7782 ns | 0.0188 |      80 B |
|        List_Optimal |                True |          10 |         0 |    14.4826 ns |     3.0602 ns |  0.1729 ns |      - |       0 B |
|         List_System |                True |          10 |         0 |   245.3275 ns |   106.7882 ns |  6.0337 ns | 0.0243 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |        **10** |    **43.1868 ns** |     **0.5709 ns** |  **0.0323 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |          10 |        10 |     0.6755 ns |     0.5535 ns |  0.0313 ns |      - |       0 B |
|        Array_System |                True |          10 |        10 |    92.2830 ns |     9.5275 ns |  0.5383 ns | 0.0228 |      96 B |
| Collection_FastLinq |                True |          10 |        10 |   148.7077 ns |    51.2656 ns |  2.8966 ns | 0.0322 |     136 B |
|  Collection_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |        10 |   132.5373 ns |    41.0088 ns |  2.3171 ns | 0.0246 |     104 B |
|  Enumerable_Optimal |                True |          10 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |        10 |   104.5339 ns |    31.4541 ns |  1.7772 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |          10 |        10 |    44.1994 ns |    18.2895 ns |  1.0334 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |          10 |        10 |     0.4332 ns |     0.4050 ns |  0.0229 ns |      - |       0 B |
|        IList_System |                True |          10 |        10 |   119.1747 ns |    56.4233 ns |  3.1880 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |          10 |        10 |    41.5731 ns |    18.5898 ns |  1.0504 ns | 0.0190 |      80 B |
|        List_Optimal |                True |          10 |        10 |     0.5646 ns |     1.4592 ns |  0.0824 ns |      - |       0 B |
|         List_System |                True |          10 |        10 |   105.3538 ns |    21.5873 ns |  1.2197 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |          **10** |       **100** |    **40.6538 ns** |    **14.2539 ns** |  **0.8054 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |          10 |       100 |     0.5268 ns |     0.2649 ns |  0.0150 ns |      - |       0 B |
|        Array_System |                True |          10 |       100 |    88.5944 ns |    16.6839 ns |  0.9427 ns | 0.0228 |      96 B |
| Collection_FastLinq |                True |          10 |       100 |   149.3052 ns |    59.7507 ns |  3.3760 ns | 0.0322 |     136 B |
|  Collection_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |          10 |       100 |   135.8579 ns |    59.5731 ns |  3.3660 ns | 0.0246 |     104 B |
|  Enumerable_Optimal |                True |          10 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |          10 |       100 |   106.5133 ns |    27.7692 ns |  1.5690 ns | 0.0266 |     112 B |
|      IList_FastLinq |                True |          10 |       100 |    43.4603 ns |     5.9680 ns |  0.3372 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |          10 |       100 |     0.5091 ns |     1.2990 ns |  0.0734 ns |      - |       0 B |
|        IList_System |                True |          10 |       100 |   110.4348 ns |    66.8760 ns |  3.7786 ns | 0.0247 |     104 B |
|       List_FastLinq |                True |          10 |       100 |    42.9091 ns |     5.0801 ns |  0.2870 ns | 0.0190 |      80 B |
|        List_Optimal |                True |          10 |       100 |     0.7543 ns |     0.7149 ns |  0.0404 ns |      - |       0 B |
|         List_System |                True |          10 |       100 |   116.6525 ns |    24.9847 ns |  1.4117 ns | 0.0247 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |         **0** | **1,315.8064 ns** |   **426.6440 ns** | **24.1062 ns** | **0.0172** |      **80 B** |
|       Array_Optimal |                True |         100 |         0 |    91.9489 ns |    40.5856 ns |  2.2932 ns |      - |       0 B |
|        Array_System |                True |         100 |         0 | 1,649.6468 ns |   385.1547 ns | 21.7620 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |         0 | 2,125.9272 ns |   472.8124 ns | 26.7148 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |         0 | 2,005.4451 ns |   408.5109 ns | 23.0816 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |         0 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |         0 | 1,598.5288 ns |   980.9232 ns | 55.4240 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |         0 | 1,437.5424 ns |    81.7113 ns |  4.6168 ns | 0.0172 |      80 B |
|       IList_Optimal |                True |         100 |         0 |   374.0251 ns |   151.7512 ns |  8.5742 ns |      - |       0 B |
|        IList_System |                True |         100 |         0 | 1,758.2121 ns | 1,110.6867 ns | 62.7559 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |         0 | 1,252.6412 ns |   240.3461 ns | 13.5800 ns | 0.0172 |      80 B |
|        List_Optimal |                True |         100 |         0 |   134.3088 ns |    47.7020 ns |  2.6953 ns |      - |       0 B |
|         List_System |                True |         100 |         0 | 1,765.6790 ns |   379.6976 ns | 21.4536 ns | 0.0229 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |        **10** | **1,244.7973 ns** |   **194.9093 ns** | **11.0127 ns** | **0.0172** |      **80 B** |
|       Array_Optimal |                True |         100 |        10 |    75.8705 ns |     9.6232 ns |  0.5437 ns |      - |       0 B |
|        Array_System |                True |         100 |        10 | 1,606.8164 ns | 1,101.4396 ns | 62.2334 ns | 0.0210 |      96 B |
| Collection_FastLinq |                True |         100 |        10 | 1,933.5998 ns |   601.6624 ns | 33.9950 ns | 0.0305 |     136 B |
|  Collection_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |        10 | 1,958.1837 ns |   991.9112 ns | 56.0448 ns | 0.0229 |     104 B |
|  Enumerable_Optimal |                True |         100 |        10 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |        10 | 1,517.1255 ns |   612.0171 ns | 34.5801 ns | 0.0248 |     112 B |
|      IList_FastLinq |                True |         100 |        10 | 1,313.1907 ns |   262.1944 ns | 14.8145 ns | 0.0172 |      80 B |
|       IList_Optimal |                True |         100 |        10 |   337.1513 ns |   153.7280 ns |  8.6859 ns |      - |       0 B |
|        IList_System |                True |         100 |        10 | 1,697.0776 ns |   665.1658 ns | 37.5831 ns | 0.0229 |     104 B |
|       List_FastLinq |                True |         100 |        10 | 1,146.2987 ns |   348.9497 ns | 19.7163 ns | 0.0172 |      80 B |
|        List_Optimal |                True |         100 |        10 |   124.8432 ns |    26.3789 ns |  1.4905 ns |      - |       0 B |
|         List_System |                True |         100 |        10 | 1,663.2854 ns |   155.8145 ns |  8.8038 ns | 0.0229 |     104 B |
|      **Array_FastLinq** |                **True** |         **100** |       **100** |    **44.4235 ns** |     **6.9089 ns** |  **0.3904 ns** | **0.0190** |      **80 B** |
|       Array_Optimal |                True |         100 |       100 |     0.5736 ns |     0.7209 ns |  0.0407 ns |      - |       0 B |
|        Array_System |                True |         100 |       100 |   463.2791 ns |   115.6987 ns |  6.5372 ns | 0.0219 |      96 B |
| Collection_FastLinq |                True |         100 |       100 |   824.1791 ns |   159.5740 ns |  9.0162 ns | 0.0315 |     136 B |
|  Collection_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Collection_System |                True |         100 |       100 |   795.0138 ns |   239.9015 ns | 13.5549 ns | 0.0238 |     104 B |
|  Enumerable_Optimal |                True |         100 |       100 |            NA |            NA |         NA |    N/A |       N/A |
|   Enumerable_System |                True |         100 |       100 |   513.2176 ns |   131.2561 ns |  7.4162 ns | 0.0257 |     112 B |
|      IList_FastLinq |                True |         100 |       100 |    44.6533 ns |    27.5202 ns |  1.5549 ns | 0.0190 |      80 B |
|       IList_Optimal |                True |         100 |       100 |     0.4018 ns |     0.8251 ns |  0.0466 ns |      - |       0 B |
|        IList_System |                True |         100 |       100 |   649.7134 ns |   394.5511 ns | 22.2929 ns | 0.0238 |     104 B |
|       List_FastLinq |                True |         100 |       100 |    41.9387 ns |    22.0275 ns |  1.2446 ns | 0.0190 |      80 B |
|        List_Optimal |                True |         100 |       100 |     0.6589 ns |     0.4819 ns |  0.0272 ns |      - |       0 B |
|         List_System |                True |         100 |       100 |   618.4241 ns |   305.8749 ns | 17.2825 ns | 0.0238 |     104 B |

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
