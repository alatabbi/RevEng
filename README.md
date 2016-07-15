# RevEng
An algorithm that constructs a lexicographically least string corresponding to a given feasible array.

Citation: 

Ali Alatabbi, M. Sohel Rahman, W.F. Smyth, Inferring an indeterminate string from a prefix graph, Journal of Discrete Algorithms, Volume 32, May 2015, Pages 6-13, ISSN 1570-8667, http://dx.doi.org/10.1016/j.jda.2014.12.006.
(http://www.sciencedirect.com/science/article/pii/S1570866714000999)

Abstract: 

An indeterminate string (or, more simply, just a string) x = x [ 1 . . n ] on an alphabet Σ is a sequence of nonempty subsets of Σ. We say that x [ i 1 ] and x [ i 2 ] match (written x [ i 1 ] ≈ x [ i 2 ] ) if and only if x [ i 1 ] ∩ x [ i 2 ] ≠ ∅ . A feasible array is an array y = y [ 1 . . n ] of integers such that y [ 1 ] = n and for every i ∈ 2 . . n , y [ i ] ∈ 0 . . n − i + 1 . A prefix table of a string x is an array π = π [ 1 . . n ] of integers such that, for every i ∈ 1 . . n , π [ i ] = j if and only if x [ i . . i + j − 1 ] is the longest substring at position i of x that matches a prefix of x. It is known from [6] that every feasible array is a prefix table of some indeterminate string. A prefix graph P = P y is a labelled simple graph whose structure is determined by a feasible array y. In this paper we show, given a feasible array y, how to use P y to construct a lexicographically least indeterminate string on a minimum alphabet whose prefix table π = y.
