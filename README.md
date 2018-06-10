# FastLinq

This library optimizes on top of LINQ by avoiding loss of information. Many of LINQ's methods can be better implemented against ICollection or IList, and indeed in many cases LINQ itself does these optimizations. Unfortunately, it typically only does them when the original input was ICollection/IList and that information is lost as soon as you call a LINQ method and get back IEnumerable -- making method chaining sub-optimal.

This library achieves better performance by staying within the ICollection/IList types where possible.

Later goals for it will include optimizing memory allocations to avoid them where not absolutely necessary and optimizations for List/Array. Potential late-stage work will include information-GAIN opportunities (where the result of a LINQ method on IEnumerable is known to have more characteristics than just IEnumerable \[max/min length\]) and a try-it-out library that can be dropped in place to measure the impact that will be achieved by using this library.

# Performance gains

RealWorldBenchmark.cs has some LINQ usage scenarios scraped from an existing code base.

Scenario | BCL&nbsp;ns | FastLinq&nbsp;ns | Δ&nbsp;ns | %Δ&nbsp;ns | BCL&nbsp;B | FastLinq&nbsp;B | Δ&nbsp;B | %Δ&nbsp;B |
---------|-------:|------------:|-----:|------:|------:|-----------:|---:|-----:|
Get the 2nd to last item from collection (investigating)|149|179|+30|+20%|208|272|+64|+31%|
Get the 2nd to last item from array|195|36|-159|-82%|552|56|-496|-90%|
Make new list based on field in existing list|682|475|-207|-30%|456|248|-208|-46%|
"" and enumerate the result|750|563|-187|-25%|456|248|-208|-46%|
Get last 10 items from existing list|37|28|-9|-24%|192|80|-112|-58%|
"" and enumerate the result|661|284|-377|-57%|800|120|-680|-85%|
Simple pagination|318|130|-188|-59%|208|152|-56|-27%|
"" and enumerate the result|331|122|-209|-63%|208|152|-56|-27%|
