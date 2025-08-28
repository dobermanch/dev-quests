# [530. Minimum Absolute Difference in BST](https://leetcode.com/problems/minimum-absolute-difference-in-bst/)

**Difficulty:** `Easy`  
**Topics:** `Tree` `Depth-First Search` `Breadth-First Search` `Binary Search Tree` `Binary Tree`  
**Solutions:** [`Python`](../../src/python/challenges/problems/minimum_absolute_difference_in_bst_test.py) [`C#`](../../src/csharp/challenges/Problems/MinimumAbsoluteDifferenceInBst.cs) [`Go`](../../src/go/challenges/problems/minimum_absolute_difference_in_bst_test.go)  

---

Given the `root` of a Binary Search Tree (BST), return *the minimum absolute difference between the values of any two different nodes in the tree*.

**Example 1:**

![](https://assets.leetcode.com/uploads/2021/02/05/bst1.jpg)

```
Input: root = [4,2,6,1,3]
Output: 1
```

**Example 2:**

![](https://assets.leetcode.com/uploads/2021/02/05/bst2.jpg)

```
Input: root = [1,0,48,null,null,12,49]
Output: 1
```

**Constraints:**

* The number of nodes in the tree is in the range `[2, 104]`.
* `0 <= Node.val <= 105`

**Note:** This question is the same as 783: <https://leetcode.com/problems/minimum-distance-between-bst-nodes/>