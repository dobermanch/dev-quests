# [90. Subsets II](https://leetcode.com/problems/subsets-ii/)

**Difficulty:** `Medium`  
**Topics:** `Array` `Backtracking` `Bit Manipulation`  
**Solutions:** [`Python`](../../src/python/challenges/problems/subsets_ii_test.py) [`C#`](../../src/csharp/challenges/Problems/SubsetsIi.cs) [`Go`](../../src/go/challenges/problems/subsets_ii_test.go)  

---

Given an integer array `nums` that may contain duplicates, return *all possible* *subsets* *(the power set)*.

The solution set **must not** contain duplicate subsets. Return the solution in **any order**.

**Example 1:**

```
Input: nums = [1,2,2]
Output: [[],[1],[1,2],[1,2,2],[2],[2,2]]
```

**Example 2:**

```
Input: nums = [0]
Output: [[],[0]]
```

**Constraints:**

* `1 <= nums.length <= 10`
* `-10 <= nums[i] <= 10`