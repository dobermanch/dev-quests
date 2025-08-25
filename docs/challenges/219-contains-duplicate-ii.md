# [219. Contains Duplicate II](https://leetcode.com/problems/contains-duplicate-ii/)

**Difficulty:** `Easy`

**Topics:** `Array` `Hash Table` `Sliding Window`

**Solutions:** [`Python`](../../src/python/challenges/problems/contains_duplicate_ii_test.py) [`C#`](../../src/csharp/challenges/Problems/ContainsDuplicateIi.cs) [`Go`](../../src/go/challenges/problems/contains_duplicate_ii_test.go) [`Rust`](../../src/rust/challenges/src/problems/contains_duplicate_ii_test.rs)

---

Given an integer array `nums` and an integer `k`, return `true` *if there are two **distinct indices*** `i` *and* `j` *in the array such that* `nums[i] == nums[j]` *and* `abs(i - j) <= k`.

**Example 1:**

```
Input: nums = [1,2,3,1], k = 3
Output: true
```

**Example 2:**

```
Input: nums = [1,0,1,1], k = 1
Output: true
```

**Example 3:**

```
Input: nums = [1,2,3,1,2,3], k = 2
Output: false
```

**Constraints:**

* `1 <= nums.length <= 105`
* `-109 <= nums[i] <= 109`
* `0 <= k <= 105`