# FastLinq

This library optimizes on top of LINQ by avoiding loss of information. Many of LINQ's methods can be better implemented against ICollection or IList, and indeed in many cases LINQ itself does these optimizations. Unfortunately, it typically only does them when the original input was ICollection/IList and that information is lost as soon as you call a LINQ method and get back IEnumerable -- making method chaining sub-optimal.

This library achieves better performance by staying within the ICollection/IList types where possible.

Later goals for it will include optimizing memory allocations to avoid them where not absolutely necessary and optimizations for List/Array. Potential late-stage work will include information-GAIN opportunities (where the result of a LINQ method on IEnumerable is known to have more characteristics than just IEnumerable \[max/min length\]) and a try-it-out library that can be dropped in place to measure the impact that will be achieved by using this library.

# Improved methods

These methods can be improved from having Collection/List information
* All
* Any
* Count
* DefaultIfEmpty
* ElementAt
* ElementAtOrDefault
* Skip
* Take
* ToArray
* ToDictionary
* ToList

Other methods are implemented also to preserve information lost today (e.g. Take(ICollection, int) -> the exact count can be known). By preserving these methods, the above improved methods can apply more broadly (e.g. if we did not add information-preservation methods, then ElementAt could only optmize if it's immediate predecessor were an IList, however if Skip maintains IList information, then ElementAt can be optimized in more scenarios).

&#42; Most of these 'information preservation' methods have a small overhead. Though the overhead pays for itself when you use any method in the list above.

# Sample Performance gains

RealWorldBenchmark.cs has some LINQ usage scenarios scraped from an existing code base.

Scenario | BCL&nbsp;ns | FastLinq&nbsp;ns | Δ&nbsp;ns | %Δ&nbsp;ns | BCL&nbsp;B | FastLinq&nbsp;B | Δ&nbsp;B | %Δ&nbsp;B |
---------|-------:|------------:|-----:|------:|------:|-----------:|---:|-----:|
Get the 2nd to last item from collection|153|205|+52*|+34%*|208|272|+64|+31%†|
Get the 2nd to last item from array|201|67|-134|-67%|552|56|-496|-90%|
Lazy select a field in existing list|40|9|-31|-78%|80|32|-48|-60%|
"" and enumerate the result|315|367|+52*|+17%*|80|80|0|0%|
"" and materialize a list|688|489|-199|-29%|456|248|-208|-46%|
Lazy get last 10 items from existing list|38|26|-12|-32%|192|80|-112|-58%|
"" and enumerate the result|628|315|-313|-50%|800|120|-680|-85%|
"" and materialize a list|764|401|-363|-48%|1024|224|-800|-78%|
Lazy simple pagination|28|32|-363|-48%|128|64|-64|-50%|
"" and enumerate the result|298|61|-237|-80%|168|112|-56|-33%|
"" and materialize a list|339|108|-231|-68%|208|152|-56|-27%|

&#42; Note that this case is not one that can be optimizes, and shows overhead

† though the amount of memory overhead is being investigated
