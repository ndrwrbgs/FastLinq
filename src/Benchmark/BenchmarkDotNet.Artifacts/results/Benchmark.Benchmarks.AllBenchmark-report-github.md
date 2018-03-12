``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|                 Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
|----------------------- |-----------:|-----------:|----------:|-------:|----------:|
|     Array_FastLinq_All |  70.722 ns | 16.6872 ns | 0.9429 ns |      - |       0 B |
|    Array_FastLinq_None |   9.029 ns |  0.5541 ns | 0.0313 ns |      - |       0 B |
|    Array_FastLinq_Some |  20.332 ns |  0.8438 ns | 0.0477 ns |      - |       0 B |
|       Array_System_All |  92.742 ns |  9.5105 ns | 0.5374 ns | 0.0075 |      32 B |
|      Array_System_None |  22.665 ns | 16.7330 ns | 0.9454 ns | 0.0076 |      32 B |
|      Array_System_Some |  37.653 ns |  2.5049 ns | 0.1415 ns | 0.0076 |      32 B |
|  Enumerable_System_All |  99.831 ns | 10.4670 ns | 0.5914 ns | 0.0113 |      48 B |
| Enumerable_System_None |  26.742 ns |  1.1738 ns | 0.0663 ns | 0.0114 |      48 B |
| Enumerable_System_Some |  43.110 ns |  3.9894 ns | 0.2254 ns | 0.0114 |      48 B |
|     IList_FastLinq_All |  78.283 ns | 11.1986 ns | 0.6327 ns |      - |       0 B |
|    IList_FastLinq_None |  12.508 ns |  0.5545 ns | 0.0313 ns |      - |       0 B |
|    IList_FastLinq_Some |  27.892 ns |  4.4287 ns | 0.2502 ns |      - |       0 B |
|       IList_System_All | 135.350 ns |  8.2937 ns | 0.4686 ns | 0.0093 |      40 B |
|      IList_System_None |  28.933 ns |  1.4390 ns | 0.0813 ns | 0.0095 |      40 B |
|      IList_System_Some |  48.642 ns |  5.4406 ns | 0.3074 ns | 0.0095 |      40 B |
|      List_FastLinq_All |  66.713 ns | 15.0200 ns | 0.8487 ns |      - |       0 B |
|     List_FastLinq_None |   9.397 ns |  1.3492 ns | 0.0762 ns |      - |       0 B |
|     List_FastLinq_Some |  20.290 ns |  4.2073 ns | 0.2377 ns |      - |       0 B |
|        List_System_All | 136.594 ns |  4.1525 ns | 0.2346 ns | 0.0093 |      40 B |
|       List_System_None |  26.745 ns |  5.8852 ns | 0.3325 ns | 0.0095 |      40 B |
|       List_System_Some |  45.512 ns |  2.9786 ns | 0.1683 ns | 0.0095 |      40 B |
