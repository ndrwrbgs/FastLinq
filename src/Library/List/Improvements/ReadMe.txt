These are needed because, even though we don't implement "terminal" LINQ methods specifically for IList
the BCL does use "is IList" to optimize some of those. By maintaining that information we permit it to
optimize.

(Also, the only reason we don't implement them here is because the BCL already has handled the relevant 
IList optimization cases)


TODO: List the BCL methods that optimize on IList, and benchmark with the results of these methods