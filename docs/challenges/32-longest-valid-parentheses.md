# [32. Longest Valid Parentheses](https://leetcode.com/problems/longest-valid-parentheses/)

**Difficulty:** `Hard`

**Topics:** `String` `Dynamic Programming` `Stack`

**Solutions:** [`Python`](../../src/python/challenges/problems/longest_valid_parentheses_test.py) [`C#`](../../src/csharp/challenges/Problems/LongestValidParentheses.cs) [`Go`](../../src/go/challenges/problems/longest_valid_parentheses_test.go)

---

Given a string containing just the characters `'('` and `')'`, return *the length of the longest valid (well-formed) parentheses* *substring*.

**Example 1:**

```
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".
```

**Example 2:**

```
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".
```

**Example 3:**

```
Input: s = ""
Output: 0
```

**Constraints:**

* `0 <= s.length <= 3 * 104`
* `s[i]` is `'('`, or `')'`.