``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10.0.17134
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.3101.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|              Method | EnumerateAfterwards |       Mean |      Error |     StdDev |  Gen 0 | Allocated |
|-------------------- |-------------------- |-----------:|-----------:|-----------:|-------:|----------:|
|      **Array_FastLinq** |               **False** |  **48.455 ns** |  **56.519 ns** |  **3.1934 ns** | **0.0457** |     **192 B** |
|       Array_Optimal |               False |   6.667 ns |   4.642 ns |  0.2623 ns |      - |       0 B |
|        Array_System |               False |  28.673 ns |   7.082 ns |  0.4002 ns | 0.0381 |     160 B |
| Collection_FastLinq |               False |  49.847 ns |  17.141 ns |  0.9685 ns | 0.0457 |     192 B |
|  Collection_Optimal |               False | 107.606 ns | 122.297 ns |  6.9100 ns |      - |       0 B |
|   Collection_System |               False |  27.293 ns |   8.098 ns |  0.4575 ns | 0.0381 |     160 B |
|  Enumerable_Optimal |               False | 193.002 ns | 110.792 ns |  6.2599 ns | 0.0226 |      96 B |
|   Enumerable_System |               False |  26.992 ns |  23.033 ns |  1.3014 ns | 0.0381 |     160 B |
|       List_FastLinq |               False |  42.184 ns |   8.016 ns |  0.4529 ns | 0.0457 |     192 B |
|        List_Optimal |               False |  23.287 ns |   4.436 ns |  0.2506 ns |      - |       0 B |
|         List_System |               False |  27.323 ns |   8.900 ns |  0.5029 ns | 0.0381 |     160 B |
|      **Array_FastLinq** |                **True** | **344.202 ns** | **223.769 ns** | **12.6434 ns** | **0.0606** |     **256 B** |
|       Array_Optimal |                True |   6.544 ns |   3.436 ns |  0.1941 ns |      - |       0 B |
|        Array_System |                True | 330.602 ns | 187.118 ns | 10.5725 ns | 0.0529 |     224 B |
| Collection_FastLinq |                True | 439.463 ns |  52.993 ns |  2.9942 ns | 0.0644 |     272 B |
|  Collection_Optimal |                True |  94.496 ns |  13.320 ns |  0.7526 ns |      - |       0 B |
|   Collection_System |                True | 455.892 ns | 501.172 ns | 28.3172 ns | 0.0567 |     240 B |
|  Enumerable_Optimal |                True | 202.422 ns | 172.803 ns |  9.7637 ns | 0.0226 |      96 B |
|   Enumerable_System |                True | 372.010 ns | 505.457 ns | 28.5592 ns | 0.0606 |     256 B |
|       List_FastLinq |                True | 406.709 ns |  74.256 ns |  4.1956 ns | 0.0644 |     272 B |
|        List_Optimal |                True |  25.073 ns |  14.648 ns |  0.8277 ns |      - |       0 B |
|         List_System |                True | 376.699 ns | 155.722 ns |  8.7986 ns | 0.0567 |     240 B |
