``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|   Method | EnumerateAfterwards | SizeOfRepeat |        Mean |         Error |     StdDev |  Gen 0 | Allocated |
|--------- |-------------------- |------------- |------------:|--------------:|-----------:|-------:|----------:|
| **FastLinq** |               **False** |            **0** |   **4.9399 ns** |     **0.4117 ns** |  **0.0233 ns** | **0.0057** |      **24 B** |
|  Optimal |               False |            0 |   0.3984 ns |     0.2735 ns |  0.0155 ns |      - |       0 B |
|   System |               False |            0 |   9.8652 ns |     0.5205 ns |  0.0294 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |            **1** |   **5.4434 ns** |     **1.0939 ns** |  **0.0618 ns** | **0.0057** |      **24 B** |
|  Optimal |               False |            1 |   0.3963 ns |     0.6453 ns |  0.0365 ns |      - |       0 B |
|   System |               False |            1 |   9.9575 ns |     5.5806 ns |  0.3153 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |           **10** |   **4.9187 ns** |     **0.5736 ns** |  **0.0324 ns** | **0.0057** |      **24 B** |
|  Optimal |               False |           10 |   0.4036 ns |     0.1474 ns |  0.0083 ns |      - |       0 B |
|   System |               False |           10 |   9.8289 ns |     0.9978 ns |  0.0564 ns | 0.0114 |      48 B |
| **FastLinq** |               **False** |          **100** |   **5.3902 ns** |     **2.9336 ns** |  **0.1658 ns** | **0.0057** |      **24 B** |
|  Optimal |               False |          100 |   0.4058 ns |     0.8873 ns |  0.0501 ns |      - |       0 B |
|   System |               False |          100 |   9.6339 ns |     2.0878 ns |  0.1180 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |            **0** |  **20.9146 ns** |     **1.8814 ns** |  **0.1063 ns** | **0.0133** |      **56 B** |
|  Optimal |                True |            0 |   0.4184 ns |     0.1901 ns |  0.0107 ns |      - |       0 B |
|   System |                True |            0 |  20.9068 ns |     1.6315 ns |  0.0922 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |            **1** |  **29.1549 ns** |     **5.8850 ns** |  **0.3325 ns** | **0.0133** |      **56 B** |
|  Optimal |                True |            1 |   0.0489 ns |     0.0984 ns |  0.0056 ns |      - |       0 B |
|   System |                True |            1 |  25.9667 ns |     2.7525 ns |  0.1555 ns | 0.0114 |      48 B |
| **FastLinq** |                **True** |           **10** | **104.1817 ns** |    **31.9122 ns** |  **1.8031 ns** | **0.0132** |      **56 B** |
|  Optimal |                True |           10 |   4.4120 ns |     1.3177 ns |  0.0745 ns |      - |       0 B |
|   System |                True |           10 |  87.7355 ns |     9.3050 ns |  0.5257 ns | 0.0113 |      48 B |
| **FastLinq** |                **True** |          **100** | **806.0823 ns** |   **718.8742 ns** | **40.6177 ns** | **0.0124** |      **56 B** |
|  Optimal |                True |          100 |  48.0004 ns |    34.2899 ns |  1.9374 ns |      - |       0 B |
|   System |                True |          100 | 702.2498 ns | 1,139.7796 ns | 64.3997 ns | 0.0105 |      48 B |
