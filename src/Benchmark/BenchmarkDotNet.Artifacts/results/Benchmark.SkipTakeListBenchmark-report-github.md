``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|           Method | EnumerateAfterwards | collectionSize | skip | take |           realType |          Mean |           Error |        StdDev |   Gen 0 | Allocated |
|----------------- |-------------------- |--------------- |----- |----- |------------------- |--------------:|----------------:|--------------:|--------:|----------:|
| **BaseClassLibrary** |               **False** |             **10** |    **5** |    **5** |              **array** |     **362.97 ns** |     **138.2317 ns** |     **7.8104 ns** |  **0.0815** |     **344 B** |
|         FastLinq |               False |             10 |    5 |    5 |              array |      33.59 ns |       2.0293 ns |     0.1147 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** |    **5** |    **5** |               **list** |     **390.51 ns** |     **172.6050 ns** |     **9.7525 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |             10 |    5 |    5 |               list |      30.69 ns |       1.1637 ns |     0.0658 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** |    **5** |    **5** | **readonlycollection** |     **402.23 ns** |     **205.3610 ns** |    **11.6033 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |             10 |    5 |    5 | readonlycollection |      34.45 ns |       2.9412 ns |     0.1662 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** |    **5** | **5000** |              **array** |     **357.25 ns** |      **15.2608 ns** |     **0.8623 ns** |  **0.0815** |     **344 B** |
|         FastLinq |               False |             10 |    5 | 5000 |              array |      33.28 ns |       1.7815 ns |     0.1007 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** |    **5** | **5000** |               **list** |     **399.80 ns** |     **116.3419 ns** |     **6.5735 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |             10 |    5 | 5000 |               list |      30.86 ns |       8.0639 ns |     0.4556 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** |    **5** | **5000** | **readonlycollection** |     **398.47 ns** |      **36.1213 ns** |     **2.0409 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |             10 |    5 | 5000 | readonlycollection |      34.43 ns |       4.4532 ns |     0.2516 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** |    **5** |              **array** |     **151.65 ns** |      **24.0794 ns** |     **1.3605 ns** |  **0.0474** |     **200 B** |
|         FastLinq |               False |             10 | 1000 |    5 |              array |      35.75 ns |       1.2859 ns |     0.0727 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** |    **5** |               **list** |     **207.13 ns** |      **48.9645 ns** |     **2.7666 ns** |  **0.0494** |     **208 B** |
|         FastLinq |               False |             10 | 1000 |    5 |               list |      36.70 ns |       3.7671 ns |     0.2128 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** |    **5** | **readonlycollection** |     **203.06 ns** |       **9.9027 ns** |     **0.5595 ns** |  **0.0494** |     **208 B** |
|         FastLinq |               False |             10 | 1000 |    5 | readonlycollection |      37.08 ns |       3.6646 ns |     0.2071 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** | **5000** |              **array** |     **148.55 ns** |      **37.3929 ns** |     **2.1128 ns** |  **0.0474** |     **200 B** |
|         FastLinq |               False |             10 | 1000 | 5000 |              array |      35.96 ns |      17.8547 ns |     1.0088 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** | **5000** |               **list** |     **200.45 ns** |       **9.6326 ns** |     **0.5443 ns** |  **0.0494** |     **208 B** |
|         FastLinq |               False |             10 | 1000 | 5000 |               list |      35.38 ns |       0.5777 ns |     0.0326 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |             **10** | **1000** | **5000** | **readonlycollection** |     **207.42 ns** |      **22.6237 ns** |     **1.2783 ns** |  **0.0494** |     **208 B** |
|         FastLinq |               False |             10 | 1000 | 5000 | readonlycollection |      37.22 ns |       3.2626 ns |     0.1843 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** |    **5** |              **array** |     **352.06 ns** |      **53.4435 ns** |     **3.0197 ns** |  **0.0815** |     **344 B** |
|         FastLinq |               False |          10000 |    5 |    5 |              array |      33.37 ns |      10.5524 ns |     0.5962 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** |    **5** |               **list** |     **388.80 ns** |      **55.0993 ns** |     **3.1132 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |          10000 |    5 |    5 |               list |      33.54 ns |      14.2778 ns |     0.8067 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** |    **5** | **readonlycollection** |     **391.16 ns** |      **12.7584 ns** |     **0.7209 ns** |  **0.0834** |     **352 B** |
|         FastLinq |               False |          10000 |    5 |    5 | readonlycollection |      35.17 ns |      18.1630 ns |     1.0262 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** | **5000** |              **array** | **146,563.33 ns** |  **38,912.4390 ns** | **2,198.6250 ns** | **31.0059** |  **131564 B** |
|         FastLinq |               False |          10000 |    5 | 5000 |              array |      33.72 ns |       4.5769 ns |     0.2586 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** | **5000** |               **list** | **167,811.33 ns** |  **25,761.5993 ns** | **1,455.5781 ns** | **31.0059** |  **131572 B** |
|         FastLinq |               False |          10000 |    5 | 5000 |               list |      32.42 ns |      40.2447 ns |     2.2739 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** |    **5** | **5000** | **readonlycollection** | **169,200.67 ns** |  **42,413.0713 ns** | **2,396.4172 ns** | **31.0059** |  **131572 B** |
|         FastLinq |               False |          10000 |    5 | 5000 | readonlycollection |      34.66 ns |       4.7513 ns |     0.2685 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** |    **5** |              **array** |   **3,367.87 ns** |   **1,059.4721 ns** |    **59.8621 ns** |  **0.0801** |     **344 B** |
|         FastLinq |               False |          10000 | 1000 |    5 |              array |      33.16 ns |       1.1402 ns |     0.0644 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** |    **5** |               **list** |   **6,460.41 ns** |   **1,617.1880 ns** |    **91.3741 ns** |  **0.0763** |     **352 B** |
|         FastLinq |               False |          10000 | 1000 |    5 |               list |      31.44 ns |       8.1947 ns |     0.4630 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** |    **5** | **readonlycollection** |   **6,777.64 ns** |     **828.4595 ns** |    **46.8095 ns** |  **0.0763** |     **352 B** |
|         FastLinq |               False |          10000 | 1000 |    5 | readonlycollection |      34.06 ns |       1.1993 ns |     0.0678 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** | **5000** |              **array** | **148,940.74 ns** |  **18,565.7796 ns** | **1,049.0010 ns** | **31.0059** |  **131564 B** |
|         FastLinq |               False |          10000 | 1000 | 5000 |              array |      35.29 ns |      21.7927 ns |     1.2313 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** | **5000** |               **list** | **173,624.19 ns** |  **17,455.8090 ns** |   **986.2856 ns** | **31.0059** |  **131572 B** |
|         FastLinq |               False |          10000 | 1000 | 5000 |               list |      33.25 ns |       5.5011 ns |     0.3108 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |               **False** |          **10000** | **1000** | **5000** | **readonlycollection** | **182,922.05 ns** | **110,056.7389 ns** | **6,218.4098 ns** | **31.0059** |  **131572 B** |
|         FastLinq |               False |          10000 | 1000 | 5000 | readonlycollection |      34.65 ns |       1.6704 ns |     0.0944 ns |  0.0305 |     128 B |
| **BaseClassLibrary** |                **True** |             **10** |    **5** |    **5** |              **array** |     **374.67 ns** |      **12.1994 ns** |     **0.6893 ns** |  **0.0815** |     **344 B** |
|         FastLinq |                True |             10 |    5 |    5 |              array |     131.64 ns |      53.7898 ns |     3.0392 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** |    **5** |    **5** |               **list** |     **411.15 ns** |     **153.7165 ns** |     **8.6853 ns** |  **0.0834** |     **352 B** |
|         FastLinq |                True |             10 |    5 |    5 |               list |     121.73 ns |       2.1195 ns |     0.1198 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** |    **5** |    **5** | **readonlycollection** |     **417.27 ns** |     **230.5504 ns** |    **13.0265 ns** |  **0.0830** |     **352 B** |
|         FastLinq |                True |             10 |    5 |    5 | readonlycollection |     148.66 ns |      68.4638 ns |     3.8683 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** |    **5** | **5000** |              **array** |     **399.63 ns** |     **119.9525 ns** |     **6.7775 ns** |  **0.0815** |     **344 B** |
|         FastLinq |                True |             10 |    5 | 5000 |              array |            NA |              NA |            NA |     N/A |       N/A |
| **BaseClassLibrary** |                **True** |             **10** |    **5** | **5000** |               **list** |     **447.63 ns** |     **177.1573 ns** |    **10.0097 ns** |  **0.0834** |     **352 B** |
|         FastLinq |                True |             10 |    5 | 5000 |               list |            NA |              NA |            NA |     N/A |       N/A |
| **BaseClassLibrary** |                **True** |             **10** |    **5** | **5000** | **readonlycollection** |     **494.65 ns** |     **331.1615 ns** |    **18.7112 ns** |  **0.0834** |     **352 B** |
|         FastLinq |                True |             10 |    5 | 5000 | readonlycollection |            NA |              NA |            NA |     N/A |       N/A |
| **BaseClassLibrary** |                **True** |             **10** | **1000** |    **5** |              **array** |     **160.05 ns** |       **9.4489 ns** |     **0.5339 ns** |  **0.0474** |     **200 B** |
|         FastLinq |                True |             10 | 1000 |    5 |              array |      64.77 ns |       0.7826 ns |     0.0442 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** | **1000** |    **5** |               **list** |     **244.70 ns** |      **68.2701 ns** |     **3.8574 ns** |  **0.0494** |     **208 B** |
|         FastLinq |                True |             10 | 1000 |    5 |               list |      69.80 ns |      44.5865 ns |     2.5192 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** | **1000** |    **5** | **readonlycollection** |     **214.18 ns** |     **251.5643 ns** |    **14.2138 ns** |  **0.0491** |     **208 B** |
|         FastLinq |                True |             10 | 1000 |    5 | readonlycollection |      73.11 ns |      34.8710 ns |     1.9703 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** | **1000** | **5000** |              **array** |     **160.91 ns** |     **185.7108 ns** |    **10.4930 ns** |  **0.0474** |     **200 B** |
|         FastLinq |                True |             10 | 1000 | 5000 |              array |      66.78 ns |      44.8357 ns |     2.5333 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** | **1000** | **5000** |               **list** |     **211.53 ns** |     **206.1953 ns** |    **11.6504 ns** |  **0.0494** |     **208 B** |
|         FastLinq |                True |             10 | 1000 | 5000 |               list |      65.62 ns |       7.2683 ns |     0.4107 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |             **10** | **1000** | **5000** | **readonlycollection** |     **222.73 ns** |     **224.1868 ns** |    **12.6670 ns** |  **0.0494** |     **208 B** |
|         FastLinq |                True |             10 | 1000 | 5000 | readonlycollection |      68.89 ns |       1.2534 ns |     0.0708 ns |  0.0418 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** |    **5** |              **array** |     **382.04 ns** |      **88.5741 ns** |     **5.0046 ns** |  **0.0815** |     **344 B** |
|         FastLinq |                True |          10000 |    5 |    5 |              array |     131.90 ns |       4.4635 ns |     0.2522 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** |    **5** |               **list** |     **410.21 ns** |      **56.0318 ns** |     **3.1659 ns** |  **0.0834** |     **352 B** |
|         FastLinq |                True |          10000 |    5 |    5 |               list |     126.50 ns |      13.0251 ns |     0.7359 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** |    **5** | **readonlycollection** |     **412.91 ns** |      **24.8005 ns** |     **1.4013 ns** |  **0.0834** |     **352 B** |
|         FastLinq |                True |          10000 |    5 |    5 | readonlycollection |     143.42 ns |      63.7494 ns |     3.6020 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** | **5000** |              **array** | **161,998.33 ns** |  **13,488.8475 ns** |   **762.1449 ns** | **31.0059** |  **131564 B** |
|         FastLinq |                True |          10000 |    5 | 5000 |              array |  67,041.59 ns |  19,317.5386 ns | 1,091.4768 ns |       - |     177 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** | **5000** |               **list** | **182,555.20 ns** |  **40,721.1069 ns** | **2,300.8181 ns** | **31.0059** |  **131572 B** |
|         FastLinq |                True |          10000 |    5 | 5000 |               list |  62,767.33 ns |   6,337.0994 ns |   358.0579 ns |       - |     177 B |
| **BaseClassLibrary** |                **True** |          **10000** |    **5** | **5000** | **readonlycollection** | **192,485.45 ns** |  **87,988.7691 ns** | **4,971.5286 ns** | **31.0059** |  **131572 B** |
|         FastLinq |                True |          10000 |    5 | 5000 | readonlycollection |  74,931.49 ns |  22,129.7244 ns | 1,250.3705 ns |       - |     177 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** |    **5** |              **array** |   **3,456.30 ns** |   **5,337.2491 ns** |   **301.5645 ns** |  **0.0801** |     **344 B** |
|         FastLinq |                True |          10000 | 1000 |    5 |              array |     129.40 ns |       6.3782 ns |     0.3604 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** |    **5** |               **list** |   **6,314.54 ns** |     **455.0732 ns** |    **25.7125 ns** |  **0.0763** |     **352 B** |
|         FastLinq |                True |          10000 | 1000 |    5 |               list |     123.54 ns |      15.7391 ns |     0.8893 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** |    **5** | **readonlycollection** |   **6,297.95 ns** |     **299.1649 ns** |    **16.9034 ns** |  **0.0763** |     **352 B** |
|         FastLinq |                True |          10000 | 1000 |    5 | readonlycollection |     139.24 ns |      30.7060 ns |     1.7349 ns |  0.0417 |     176 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** | **5000** |              **array** | **172,014.08 ns** | **123,441.2737 ns** | **6,974.6609 ns** | **31.0059** |  **131564 B** |
|         FastLinq |                True |          10000 | 1000 | 5000 |              array |  66,519.84 ns |   6,128.7511 ns |   346.2858 ns |       - |     177 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** | **5000** |               **list** | **189,199.35 ns** |  **81,214.8562 ns** | **4,588.7900 ns** | **31.0059** |  **131572 B** |
|         FastLinq |                True |          10000 | 1000 | 5000 |               list |  61,682.53 ns |   7,081.4860 ns |   400.1171 ns |       - |     177 B |
| **BaseClassLibrary** |                **True** |          **10000** | **1000** | **5000** | **readonlycollection** | **188,212.08 ns** |  **11,502.7083 ns** |   **649.9243 ns** | **31.0059** |  **131572 B** |
|         FastLinq |                True |          10000 | 1000 | 5000 | readonlycollection |  73,940.57 ns |   2,540.1546 ns |   143.5234 ns |       - |     177 B |

Benchmarks with issues:
  SkipTakeListBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, collectionSize=10, skip=5, take=5000, realType=array]
  SkipTakeListBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, collectionSize=10, skip=5, take=5000, realType=list]
  SkipTakeListBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, collectionSize=10, skip=5, take=5000, realType=readonlycollection]
