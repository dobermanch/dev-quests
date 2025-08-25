# [23. Merge k Sorted Lists](https://leetcode.com/problems/merge-k-sorted-lists/)

**Difficulty:** `Hard`

**Topics:** `Linked List` `Divide and Conquer` `Heap (Priority Queue)` `Merge Sort`

**Solutions:** [`Python`](../../src/python/challenges/problems/merge_k_sorted_lists_test.py) [`C#`](../../src/csharp/challenges/Problems/MergeKSortedLists.cs) [`Go`](../../src/go/challenges/problems/merge_k_sorted_lists_test.go)

---

You are given an array of `k` linked-lists `lists`, each linked-list is sorted in ascending order.

*Merge all the linked-lists into one sorted linked-list and return it.*

**Example 1:**

```
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted linked list:
1->1->2->3->4->4->5->6
```

**Example 2:**

```
Input: lists = []
Output: []
```

**Example 3:**

```
Input: lists = [[]]
Output: []
```

**Constraints:**

* `k == lists.length`
* `0 <= k <= 104`
* `0 <= lists[i].length <= 500`
* `-104 <= lists[i][j] <= 104`
* `lists[i]` is sorted in **ascending order**.
* The sum of `lists[i].length` will not exceed `104`.