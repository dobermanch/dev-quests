# [7. Reverse Integer](https://leetcode.com/problems/reverse-integer/)

**Difficulty:** `Medium`  
**Topics:** `Math`  
**Solutions:** [`Python`](../../src/python/challenges/problems/reverse_integer_test.py) [`C#`](../../src/csharp/challenges/Problems/ReverseInteger.cs) [`Go`](../../src/go/challenges/problems/reverse_integer_test.go)  

---

Given a signed 32-bit integer `x`, return `x` *with its digits reversed*. If reversing `x` causes the value to go outside the signed 32-bit integer range `[-231, 231 - 1]`, then return `0`.

**Assume the environment does not allow you to store 64-bit integers (signed or unsigned).**

**Example 1:**

```
Input: x = 123
Output: 321
```

**Example 2:**

```
Input: x = -123
Output: -321
```

**Example 3:**

```
Input: x = 120
Output: 21
```

**Constraints:**

* `-231 <= x <= 231 - 1`