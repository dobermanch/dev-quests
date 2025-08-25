# [28. Find the Index of the First Occurrence in a String](https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string/)

**Difficulty:** `Easy`

**Topics:** `Two Pointers` `String` `String Matching`

**Solutions:** [`Python`](../../src/python/challenges/problems/find_the_index_of_the_first_occurrence_in_a_string_test.py) [`C#`](../../src/csharp/challenges/Problems/FindTheIndexOfTheFirstOccurrenceInAString.cs) [`Go`](../../src/go/challenges/problems/find_the_index_of_the_first_occurrence_in_a_string_test.go) [`Rust`](../../src/rust/challenges/src/problems/find_the_index_of_the_first_occurrence_in_a_string_test.rs)

---

Given two strings `needle` and `haystack`, return the index of the first occurrence of `needle` in `haystack`, or `-1` if `needle` is not part of `haystack`.

**Example 1:**

```
Input: haystack = "sadbutsad", needle = "sad"
Output: 0
Explanation: "sad" occurs at index 0 and 6.
The first occurrence is at index 0, so we return 0.
```

**Example 2:**

```
Input: haystack = "leetcode", needle = "leeto"
Output: -1
Explanation: "leeto" did not occur in "leetcode", so we return -1.
```

**Constraints:**

* `1 <= haystack.length, needle.length <= 104`
* `haystack` and `needle` consist of only lowercase English characters.