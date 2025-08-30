// https://leetcode.com/problems/find-k-pairs-with-smallest-sums

package problems

import (
	"container/heap"
	"testing"

	"github.com/dobermanch/leetcode/core"
)

type FindKPairsWithSmallestSums struct{}

func TestFindKPairsWithSmallestSums(t *testing.T) {
	gen := core.TestSuite[FindKPairsWithSmallestSums]{}
	gen.Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 7, 11}).Param([]int{2, 4, 6}).Param(3).Result([][]int{{1, 2}, {1, 4}, {1, 6}})
	}).Add(func(tc *core.TestCase) {
		tc.Param([]int{1, 1, 2}).Param([]int{1, 2, 3}).Param(2).Result([][]int{{1, 1}, {1, 1}})
	}).Run(t)
}

type pair struct {
	sum int
	i   int
	j   int
}

type minHeap []pair

func (h minHeap) Len() int            { return len(h) }
func (h minHeap) Less(i, j int) bool  { return h[i].sum < h[j].sum }
func (h minHeap) Swap(i, j int)       { h[i], h[j] = h[j], h[i] }
func (h *minHeap) Push(x interface{}) { *h = append(*h, x.(pair)) }
func (h *minHeap) Pop() interface{} {
	old := *h
	n := len(old)
	x := old[n-1]
	*h = old[:n-1]
	return x
}

func (FindKPairsWithSmallestSums) Solution(nums1 []int, nums2 []int, k int) [][]int {
	m, n := len(nums1), len(nums2)
	result := [][]int{}
	visited := make(map[[2]int]bool)
	h := &minHeap{}

	heap.Push(h, pair{nums1[0] + nums2[0], 0, 0})
	visited[[2]int{0, 0}] = true

	for k > 0 && h.Len() > 0 {
		p := heap.Pop(h).(pair)
		i, j := p.i, p.j
		result = append(result, []int{nums1[i], nums2[j]})

		if i+1 < m && !visited[[2]int{i + 1, j}] {
			heap.Push(h, pair{nums1[i+1] + nums2[j], i + 1, j})
			visited[[2]int{i + 1, j}] = true
		}
		if j+1 < n && !visited[[2]int{i, j + 1}] {
			heap.Push(h, pair{nums1[i] + nums2[j+1], i, j + 1})
			visited[[2]int{i, j + 1}] = true
		}
		k--
	}

	return result
}
