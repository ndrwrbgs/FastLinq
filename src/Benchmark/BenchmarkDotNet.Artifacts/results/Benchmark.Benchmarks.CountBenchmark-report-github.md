``` ini

BenchmarkDotNet=v0.10.12, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.248)
Intel Core i7-6820HQ CPU 2.70GHz (Skylake), 1 CPU, 8 logical cores and 4 physical cores
Frequency=2648436 Hz, Resolution=377.5813 ns, Timer=TSC
  [Host]     : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0
  Job-YODCMV : .NET Framework 4.7 (CLR 4.0.30319.42000), 64bit RyuJIT-v4.7.2633.0

Toolchain=CsProjnet46  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|                 Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------------- |----------:|----------:|----------:|-------:|----------:|
|     Array_FastLinq_All |  68.92 ns | 29.624 ns | 1.6738 ns |      - |       0 B |
|    Array_FastLinq_None |  81.54 ns | 13.812 ns | 0.7804 ns |      - |       0 B |
|    Array_FastLinq_Some |  71.56 ns |  9.818 ns | 0.5548 ns |      - |       0 B |
|       Array_System_All | 110.95 ns | 26.011 ns | 1.4697 ns | 0.0075 |      32 B |
|      Array_System_None | 119.32 ns | 57.766 ns | 3.2639 ns | 0.0074 |      32 B |
|      Array_System_Some | 115.09 ns | 37.764 ns | 2.1337 ns | 0.0075 |      32 B |
|  Enumerable_System_All | 110.15 ns | 12.967 ns | 0.7326 ns | 0.0113 |      48 B |
| Enumerable_System_None | 122.26 ns | 20.942 ns | 1.1833 ns | 0.0112 |      48 B |
| Enumerable_System_Some | 111.31 ns |  5.758 ns | 0.3254 ns | 0.0113 |      48 B |
|     IList_FastLinq_All |  81.63 ns | 16.218 ns | 0.9163 ns |      - |       0 B |
|    IList_FastLinq_None |  92.05 ns |  4.363 ns | 0.2465 ns |      - |       0 B |
|    IList_FastLinq_Some |  88.53 ns | 15.768 ns | 0.8909 ns |      - |       0 B |
|       IList_System_All | 153.89 ns | 57.197 ns | 3.2317 ns | 0.0093 |      40 B |
|      IList_System_None | 148.22 ns | 39.259 ns | 2.2182 ns | 0.0093 |      40 B |
|      IList_System_Some | 156.60 ns | 30.411 ns | 1.7183 ns | 0.0093 |      40 B |
|      List_FastLinq_All |  65.60 ns | 24.175 ns | 1.3659 ns |      - |       0 B |
|     List_FastLinq_None |  78.48 ns | 18.215 ns | 1.0292 ns |      - |       0 B |
|     List_FastLinq_Some |  70.04 ns | 11.840 ns | 0.6690 ns |      - |       0 B |
|        List_System_All | 150.49 ns | 21.596 ns | 1.2202 ns | 0.0093 |      40 B |
|       List_System_None | 147.57 ns | 22.993 ns | 1.2992 ns | 0.0093 |      40 B |
|       List_System_Some | 149.78 ns | 34.336 ns | 1.9400 ns | 0.0093 |      40 B |
