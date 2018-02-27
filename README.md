# FastLinq

_Note: the below is written in present tense but is more accurately future tense, the project is still a WIP. Until you see benchmarks below, be skeptical_

This library optimizes on top of LINQ by avoiding loss of information. Many of LINQ's methods can be better implemented against ICollection or IList, and indeed in many cases LINQ itself does these optimizations. Unfortunately, it typically only does them when the original input was ICollection/IList and that information is lost as soon as you call a LINQ method and get back IEnumerable -- making method chaining sub-optimal.

This library achieves better performance by staying within the ICollection/IList types where possible.

Later goals for it will include optimizing memory allocations to avoid them where not absolutely necessary and optimizations for List/Array. Potential late-stage work will include information-GAIN opportunities (where the result of a LINQ method on IEnumerable is known to have more characteristics than just IEnumerable \[max/min length\]) and a try-it-out library that can be dropped in place to measure the impact that will be achieved by using this library.
