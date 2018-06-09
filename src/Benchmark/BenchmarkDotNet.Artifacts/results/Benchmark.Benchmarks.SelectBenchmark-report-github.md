``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|             Method | EnumerateAfterwards | InputSize |       Mean |       Error |     StdDev |  Gen 0 | Allocated |
|------------------- |-------------------- |---------- |-----------:|------------:|-----------:|-------:|----------:|
|     **Array_FastLinq** |               **False** |         **0** |  **18.537 ns** |  **17.5674 ns** |  **0.9926 ns** | **0.0229** |      **96 B** |
|      Array_Optimal |               False |         0 |   5.756 ns |   3.4786 ns |  0.1965 ns | 0.0057 |      24 B |
|       Array_System |               False |         0 |  34.131 ns |  16.2450 ns |  0.9179 ns | 0.0305 |     128 B |
| Enumerable_Optimal |               False |         0 |   5.570 ns |   1.7475 ns |  0.0987 ns | 0.0057 |      24 B |
|  Enumerable_System |               False |         0 |  33.495 ns |   8.4836 ns |  0.4793 ns | 0.0305 |     128 B |
|     IList_FastLinq |               False |         0 |  16.451 ns |   7.2760 ns |  0.4111 ns | 0.0229 |      96 B |
|      IList_Optimal |               False |         0 |   5.709 ns |   1.6923 ns |  0.0956 ns | 0.0057 |      24 B |
|       IList_System |               False |         0 |  34.274 ns |  10.4486 ns |  0.5904 ns | 0.0305 |     128 B |
|      List_FastLinq |               False |         0 |  16.719 ns |   4.9075 ns |  0.2773 ns | 0.0229 |      96 B |
|       List_Optimal |               False |         0 |   5.782 ns |   2.8551 ns |  0.1613 ns | 0.0057 |      24 B |
|        List_System |               False |         0 |  33.987 ns |  25.8868 ns |  1.4627 ns | 0.0343 |     144 B |
|     **Array_FastLinq** |               **False** |        **10** |  **16.466 ns** |   **3.7930 ns** |  **0.2143 ns** | **0.0229** |      **96 B** |
|      Array_Optimal |               False |        10 |   5.680 ns |   2.9527 ns |  0.1668 ns | 0.0057 |      24 B |
|       Array_System |               False |        10 |  34.138 ns |   6.7535 ns |  0.3816 ns | 0.0305 |     128 B |
| Enumerable_Optimal |               False |        10 |   6.189 ns |  10.1557 ns |  0.5738 ns | 0.0057 |      24 B |
|  Enumerable_System |               False |        10 |  33.121 ns |   3.3609 ns |  0.1899 ns | 0.0305 |     128 B |
|     IList_FastLinq |               False |        10 |  16.967 ns |  15.6526 ns |  0.8844 ns | 0.0229 |      96 B |
|      IList_Optimal |               False |        10 |   5.582 ns |   0.4757 ns |  0.0269 ns | 0.0057 |      24 B |
|       IList_System |               False |        10 |  35.417 ns |  18.0744 ns |  1.0212 ns | 0.0305 |     128 B |
|      List_FastLinq |               False |        10 |  16.220 ns |   4.1110 ns |  0.2323 ns | 0.0229 |      96 B |
|       List_Optimal |               False |        10 |   5.807 ns |   1.5880 ns |  0.0897 ns | 0.0057 |      24 B |
|        List_System |               False |        10 |  34.244 ns |  13.1696 ns |  0.7441 ns | 0.0343 |     144 B |
|     **Array_FastLinq** |               **False** |       **100** |  **16.643 ns** |  **10.4091 ns** |  **0.5881 ns** | **0.0229** |      **96 B** |
|      Array_Optimal |               False |       100 |   5.656 ns |   1.0984 ns |  0.0621 ns | 0.0057 |      24 B |
|       Array_System |               False |       100 |  33.984 ns |   2.5232 ns |  0.1426 ns | 0.0305 |     128 B |
| Enumerable_Optimal |               False |       100 |   6.079 ns |   0.2652 ns |  0.0150 ns | 0.0057 |      24 B |
|  Enumerable_System |               False |       100 |  35.235 ns |  28.2649 ns |  1.5970 ns | 0.0305 |     128 B |
|     IList_FastLinq |               False |       100 |  16.619 ns |   9.3542 ns |  0.5285 ns | 0.0229 |      96 B |
|      IList_Optimal |               False |       100 |   5.578 ns |   0.4777 ns |  0.0270 ns | 0.0057 |      24 B |
|       IList_System |               False |       100 |  33.860 ns |  10.0233 ns |  0.5663 ns | 0.0305 |     128 B |
|      List_FastLinq |               False |       100 |  16.661 ns |   1.2854 ns |  0.0726 ns | 0.0229 |      96 B |
|       List_Optimal |               False |       100 |   5.604 ns |   2.2858 ns |  0.1292 ns | 0.0057 |      24 B |
|        List_System |               False |       100 |  33.554 ns |  11.7738 ns |  0.6652 ns | 0.0343 |     144 B |
|     **Array_FastLinq** |                **True** |         **0** | **204.693 ns** |  **50.4256 ns** |  **2.8491 ns** | **0.0341** |     **144 B** |
|      Array_Optimal |                True |         0 |  12.095 ns |   8.4115 ns |  0.4753 ns | 0.0057 |      24 B |
|       Array_System |                True |         0 | 160.542 ns |  45.6113 ns |  2.5771 ns | 0.0303 |     128 B |
| Enumerable_Optimal |                True |         0 |  88.633 ns |  25.0778 ns |  1.4169 ns | 0.0172 |      72 B |
|  Enumerable_System |                True |         0 | 241.089 ns |  79.0670 ns |  4.4674 ns | 0.0417 |     176 B |
|     IList_FastLinq |                True |         0 | 219.743 ns |   7.8810 ns |  0.4453 ns | 0.0341 |     144 B |
|      IList_Optimal |                True |         0 |  41.721 ns |  20.1775 ns |  1.1401 ns | 0.0057 |      24 B |
|       IList_System |                True |         0 | 288.716 ns | 105.7968 ns |  5.9777 ns | 0.0401 |     168 B |
|      List_FastLinq |                True |         0 | 215.369 ns |  46.1350 ns |  2.6067 ns | 0.0341 |     144 B |
|       List_Optimal |                True |         0 |  16.775 ns |  12.0238 ns |  0.6794 ns | 0.0057 |      24 B |
|        List_System |                True |         0 | 204.333 ns | 125.8392 ns |  7.1101 ns | 0.0341 |     144 B |
|     **Array_FastLinq** |                **True** |        **10** | **203.293 ns** |  **71.0479 ns** |  **4.0143 ns** | **0.0341** |     **144 B** |
|      Array_Optimal |                True |        10 |  12.161 ns |   2.5222 ns |  0.1425 ns | 0.0057 |      24 B |
|       Array_System |                True |        10 | 162.384 ns | 143.6199 ns |  8.1148 ns | 0.0303 |     128 B |
| Enumerable_Optimal |                True |        10 |  89.339 ns |  28.2267 ns |  1.5949 ns | 0.0172 |      72 B |
|  Enumerable_System |                True |        10 | 241.815 ns | 122.5888 ns |  6.9265 ns | 0.0415 |     176 B |
|     IList_FastLinq |                True |        10 | 221.632 ns |  36.8691 ns |  2.0832 ns | 0.0341 |     144 B |
|      IList_Optimal |                True |        10 |  42.497 ns |  50.6201 ns |  2.8601 ns | 0.0057 |      24 B |
|       IList_System |                True |        10 | 276.828 ns |  69.3556 ns |  3.9187 ns | 0.0401 |     168 B |
|      List_FastLinq |                True |        10 | 204.970 ns | 163.5360 ns |  9.2401 ns | 0.0341 |     144 B |
|       List_Optimal |                True |        10 |  17.626 ns |  31.9410 ns |  1.8047 ns | 0.0057 |      24 B |
|        List_System |                True |        10 | 205.962 ns | 127.3214 ns |  7.1939 ns | 0.0341 |     144 B |
|     **Array_FastLinq** |                **True** |       **100** | **199.482 ns** |  **54.3752 ns** |  **3.0723 ns** | **0.0341** |     **144 B** |
|      Array_Optimal |                True |       100 |  11.542 ns |   1.1766 ns |  0.0665 ns | 0.0057 |      24 B |
|       Array_System |                True |       100 | 160.652 ns |  42.5465 ns |  2.4040 ns | 0.0303 |     128 B |
| Enumerable_Optimal |                True |       100 |  88.184 ns |   6.3226 ns |  0.3572 ns | 0.0172 |      72 B |
|  Enumerable_System |                True |       100 | 242.325 ns |  98.3076 ns |  5.5546 ns | 0.0415 |     176 B |
|     IList_FastLinq |                True |       100 | 223.471 ns |  53.2781 ns |  3.0103 ns | 0.0341 |     144 B |
|      IList_Optimal |                True |       100 |  41.014 ns |  10.1424 ns |  0.5731 ns | 0.0057 |      24 B |
|       IList_System |                True |       100 | 308.947 ns | 307.8415 ns | 17.3936 ns | 0.0401 |     168 B |
|      List_FastLinq |                True |       100 | 198.450 ns |  92.1605 ns |  5.2072 ns | 0.0341 |     144 B |
|       List_Optimal |                True |       100 |  17.183 ns |   8.6289 ns |  0.4875 ns | 0.0057 |      24 B |
|        List_System |                True |       100 | 204.254 ns | 131.1615 ns |  7.4109 ns | 0.0341 |     144 B |
