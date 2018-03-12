``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|   Method |   ItemType | SizeOfInput |         Mean |         Error |     StdDev |  Gen 0 | Allocated |
|--------- |----------- |------------ |-------------:|--------------:|-----------:|-------:|----------:|
| **Contains** | **Collection** |           **0** |    **14.936 ns** |     **6.9816 ns** |  **0.3945 ns** |      **-** |       **0 B** |
|   CopyTo | Collection |           0 |     3.522 ns |     0.9467 ns |  0.0535 ns |      - |       0 B |
|    Count | Collection |           0 |     2.800 ns |     1.3422 ns |  0.0758 ns |      - |       0 B |
| **Contains** | **Collection** |           **1** |    **13.829 ns** |     **2.8783 ns** |  **0.1626 ns** |      **-** |       **0 B** |
|   CopyTo | Collection |           1 |    35.416 ns |     2.3200 ns |  0.1311 ns | 0.0095 |      40 B |
|    Count | Collection |           1 |     2.710 ns |     0.7957 ns |  0.0450 ns |      - |       0 B |
| **Contains** | **Collection** |         **100** |    **17.977 ns** |    **19.2991 ns** |  **1.0904 ns** |      **-** |       **0 B** |
|   CopyTo | Collection |         100 | 1,077.422 ns |   408.2513 ns | 23.0670 ns | 0.0076 |      40 B |
|    Count | Collection |         100 |     2.711 ns |     0.9453 ns |  0.0534 ns |      - |       0 B |
| **Contains** | **Enumerable** |           **0** |    **41.339 ns** |    **12.6237 ns** |  **0.7133 ns** | **0.0114** |      **48 B** |
|   CopyTo | Enumerable |           0 |     3.545 ns |     1.2468 ns |  0.0704 ns |      - |       0 B |
|    Count | Enumerable |           0 |     2.705 ns |     0.3024 ns |  0.0171 ns |      - |       0 B |
| **Contains** | **Enumerable** |           **1** |    **51.932 ns** |     **3.1259 ns** |  **0.1766 ns** | **0.0114** |      **48 B** |
|   CopyTo | Enumerable |           1 |    33.369 ns |    11.3061 ns |  0.6388 ns | 0.0114 |      48 B |
|    Count | Enumerable |           1 |     2.687 ns |     0.4268 ns |  0.0241 ns |      - |       0 B |
| **Contains** | **Enumerable** |         **100** |    **93.216 ns** |    **20.8231 ns** |  **1.1765 ns** | **0.0113** |      **48 B** |
|   CopyTo | Enumerable |         100 |   684.580 ns | 1,141.5724 ns | 64.5010 ns | 0.0105 |      48 B |
|    Count | Enumerable |         100 |     2.696 ns |     2.8874 ns |  0.1631 ns |      - |       0 B |
| **Contains** |       **List** |           **0** |    **17.012 ns** |     **5.5688 ns** |  **0.3146 ns** |      **-** |       **0 B** |
|   CopyTo |       List |           0 |     3.415 ns |     0.9911 ns |  0.0560 ns |      - |       0 B |
|    Count |       List |           0 |     2.901 ns |     1.6743 ns |  0.0946 ns |      - |       0 B |
| **Contains** |       **List** |           **1** |    **18.771 ns** |     **6.9316 ns** |  **0.3916 ns** |      **-** |       **0 B** |
|   CopyTo |       List |           1 |    33.894 ns |     8.7565 ns |  0.4948 ns | 0.0095 |      40 B |
|    Count |       List |           1 |     2.975 ns |     3.1238 ns |  0.1765 ns |      - |       0 B |
| **Contains** |       **List** |         **100** |    **29.432 ns** |     **9.9107 ns** |  **0.5600 ns** |      **-** |       **0 B** |
|   CopyTo |       List |         100 |   838.962 ns |   222.5926 ns | 12.5769 ns | 0.0086 |      40 B |
|    Count |       List |         100 |     2.726 ns |     1.3383 ns |  0.0756 ns |      - |       0 B |
