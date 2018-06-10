``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards |        Mean |       Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |------------:|------------:|-----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |  **21.8587 ns** |  **14.6251 ns** |  **0.8263 ns** | **0.0248** |     **104 B** |
|       Array_Optimal |               False |   0.4149 ns |   0.1862 ns |  0.0105 ns |      - |       0 B |
|        Array_System |               False |  25.5308 ns |   5.2119 ns |  0.2945 ns | 0.0381 |     160 B |
| Collection_FastLinq |               False |  39.2455 ns |   8.6869 ns |  0.4908 ns | 0.0457 |     192 B |
|  Collection_Optimal |               False |   9.2727 ns |   2.8936 ns |  0.1635 ns |      - |       0 B |
|   Collection_System |               False |  26.5947 ns |  14.9681 ns |  0.8457 ns | 0.0381 |     160 B |
|  Enumerable_Optimal |               False |   0.7430 ns |   0.6223 ns |  0.0352 ns |      - |       0 B |
|   Enumerable_System |               False |  25.9749 ns |  18.3976 ns |  1.0395 ns | 0.0381 |     160 B |
|       List_FastLinq |               False |  19.3810 ns |   6.4793 ns |  0.3661 ns | 0.0248 |     104 B |
|        List_Optimal |               False |   0.7201 ns |   0.3284 ns |  0.0186 ns |      - |       0 B |
|         List_System |               False |  25.7567 ns |   5.3586 ns |  0.3028 ns | 0.0381 |     160 B |
|      **Array_FastLinq** |                **True** | **242.6555 ns** |  **96.8320 ns** |  **5.4712 ns** | **0.0358** |     **152 B** |
|       Array_Optimal |                True |   5.1286 ns |   1.6221 ns |  0.0917 ns |      - |       0 B |
|        Array_System |                True | 298.7849 ns |   9.8949 ns |  0.5591 ns | 0.0529 |     224 B |
| Collection_FastLinq |                True | 425.1573 ns | 494.8287 ns | 27.9587 ns | 0.0644 |     272 B |
|  Collection_Optimal |                True |  94.6849 ns |  10.0629 ns |  0.5686 ns |      - |       0 B |
|   Collection_System |                True | 414.1860 ns |  57.8575 ns |  3.2691 ns | 0.0567 |     240 B |
|  Enumerable_Optimal |                True | 181.1744 ns |  30.3436 ns |  1.7145 ns | 0.0226 |      96 B |
|   Enumerable_System |                True | 320.2579 ns | 100.9610 ns |  5.7045 ns | 0.0606 |     256 B |
|       List_FastLinq |                True | 242.7638 ns |  96.0144 ns |  5.4250 ns | 0.0358 |     152 B |
|        List_Optimal |                True |  24.1503 ns |   8.6846 ns |  0.4907 ns |      - |       0 B |
|         List_System |                True | 385.3970 ns | 150.7987 ns |  8.5204 ns | 0.0567 |     240 B |
