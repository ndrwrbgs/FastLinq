``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|   Method | EnumerateAfterwards |      Start | Count |       Mean |       Error |     StdDev |  Gen 0 | Allocated |
|--------- |-------------------- |----------- |------ |-----------:|------------:|-----------:|-------:|----------:|
| **FastLinq** |               **False** |       **-100** |     **0** |   **6.199 ns** |   **5.2705 ns** |  **0.2978 ns** | **0.0057** |      **24 B** |
|   System |               False |       -100 |     0 |  12.286 ns |   6.8091 ns |  0.3847 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |       **-100** |     **1** |   **5.920 ns** |   **0.6381 ns** |  **0.0361 ns** | **0.0057** |      **24 B** |
|   System |               False |       -100 |     1 |  11.754 ns |   1.6234 ns |  0.0917 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |       **-100** |    **10** |   **6.332 ns** |   **0.6674 ns** |  **0.0377 ns** | **0.0057** |      **24 B** |
|   System |               False |       -100 |    10 |  11.901 ns |   2.4867 ns |  0.1405 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |       **-100** |   **100** |   **6.315 ns** |   **3.3560 ns** |  **0.1896 ns** | **0.0057** |      **24 B** |
|   System |               False |       -100 |   100 |  11.982 ns |   1.6323 ns |  0.0922 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |          **0** |     **0** |   **5.981 ns** |   **1.4013 ns** |  **0.0792 ns** | **0.0057** |      **24 B** |
|   System |               False |          0 |     0 |  11.818 ns |   2.7209 ns |  0.1537 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |          **0** |     **1** |   **6.063 ns** |   **2.6224 ns** |  **0.1482 ns** | **0.0057** |      **24 B** |
|   System |               False |          0 |     1 |  11.649 ns |   1.4765 ns |  0.0834 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |          **0** |    **10** |   **6.014 ns** |   **0.5967 ns** |  **0.0337 ns** | **0.0057** |      **24 B** |
|   System |               False |          0 |    10 |  11.828 ns |   2.6493 ns |  0.1497 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |          **0** |   **100** |   **6.070 ns** |   **1.2058 ns** |  **0.0681 ns** | **0.0057** |      **24 B** |
|   System |               False |          0 |   100 |  11.923 ns |   1.4723 ns |  0.0832 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** | **2147483647** |     **0** |   **6.060 ns** |   **1.5513 ns** |  **0.0877 ns** | **0.0057** |      **24 B** |
|   System |               False | 2147483647 |     0 |  11.926 ns |   1.9087 ns |  0.1078 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** | **2147483647** |     **1** |   **5.965 ns** |   **2.0131 ns** |  **0.1137 ns** | **0.0057** |      **24 B** |
|   System |               False | 2147483647 |     1 |  11.865 ns |   1.5875 ns |  0.0897 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** | **2147483647** |    **10** |         **NA** |          **NA** |         **NA** |    **N/A** |       **N/A** |
|   System |               False | 2147483647 |    10 |         NA |          NA |         NA |    N/A |       N/A |
| **FastLinq** |               **False** | **2147483647** |   **100** |         **NA** |          **NA** |         **NA** |    **N/A** |       **N/A** |
|   System |               False | 2147483647 |   100 |         NA |          NA |         NA |    N/A |       N/A |
| **FastLinq** |                **True** |       **-100** |     **0** |  **30.321 ns** |  **10.9131 ns** |  **0.6166 ns** | **0.0172** |      **72 B** |
|   System |                True |       -100 |     0 |  24.793 ns |   5.0885 ns |  0.2875 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |       **-100** |     **1** |  **38.634 ns** |  **11.6253 ns** |  **0.6568 ns** | **0.0172** |      **72 B** |
|   System |                True |       -100 |     1 |  33.584 ns |   2.3581 ns |  0.1332 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |       **-100** |    **10** | **111.090 ns** |  **35.7005 ns** |  **2.0171 ns** | **0.0172** |      **72 B** |
|   System |                True |       -100 |    10 | 101.936 ns |   9.9847 ns |  0.5642 ns | 0.0113 |      48 B |
| **FastLinq** |                **True** |       **-100** |   **100** | **822.010 ns** |  **59.5700 ns** |  **3.3658 ns** | **0.0172** |      **72 B** |
|   System |                True |       -100 |   100 | 774.051 ns | 130.1862 ns |  7.3558 ns | 0.0105 |      48 B |
| **FastLinq** |                **True** |          **0** |     **0** |  **31.201 ns** |   **1.7497 ns** |  **0.0989 ns** | **0.0172** |      **72 B** |
|   System |                True |          0 |     0 |  25.660 ns |   3.6424 ns |  0.2058 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |          **0** |     **1** |  **39.645 ns** |  **10.2721 ns** |  **0.5804 ns** | **0.0172** |      **72 B** |
|   System |                True |          0 |     1 |  32.530 ns |   5.8443 ns |  0.3302 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |          **0** |    **10** | **112.312 ns** |  **18.4871 ns** |  **1.0446 ns** | **0.0172** |      **72 B** |
|   System |                True |          0 |    10 | 102.446 ns |  16.1955 ns |  0.9151 ns | 0.0113 |      48 B |
| **FastLinq** |                **True** |          **0** |   **100** | **830.892 ns** | **230.4065 ns** | **13.0184 ns** | **0.0172** |      **72 B** |
|   System |                True |          0 |   100 | 784.656 ns |  42.4629 ns |  2.3992 ns | 0.0105 |      48 B |
| **FastLinq** |                **True** | **2147483647** |     **0** |  **31.200 ns** |   **7.9777 ns** |  **0.4508 ns** | **0.0172** |      **72 B** |
|   System |                True | 2147483647 |     0 |  25.787 ns |   3.4222 ns |  0.1934 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** | **2147483647** |     **1** |  **39.717 ns** |  **12.4445 ns** |  **0.7031 ns** | **0.0172** |      **72 B** |
|   System |                True | 2147483647 |     1 |  33.120 ns |  13.1396 ns |  0.7424 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** | **2147483647** |    **10** |         **NA** |          **NA** |         **NA** |    **N/A** |       **N/A** |
|   System |                True | 2147483647 |    10 |         NA |          NA |         NA |    N/A |       N/A |
| **FastLinq** |                **True** | **2147483647** |   **100** |         **NA** |          **NA** |         **NA** |    **N/A** |       **N/A** |
|   System |                True | 2147483647 |   100 |         NA |          NA |         NA |    N/A |       N/A |

Benchmarks with issues:
  RangeBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, Start=2147483647, Count=10]
  RangeBenchmark.System: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, Start=2147483647, Count=10]
  RangeBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, Start=2147483647, Count=100]
  RangeBenchmark.System: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=False, Start=2147483647, Count=100]
  RangeBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, Start=2147483647, Count=10]
  RangeBenchmark.System: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, Start=2147483647, Count=10]
  RangeBenchmark.FastLinq: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, Start=2147483647, Count=100]
  RangeBenchmark.System: Job-YODCMV(Toolchain=CsProjnet46, LaunchCount=1, TargetCount=3, WarmupCount=3) [EnumerateAfterwards=True, Start=2147483647, Count=100]
